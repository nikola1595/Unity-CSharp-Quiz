using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;
using System;

public class GameManager : MonoBehaviour
{

    private GameData data = new GameData();

    //private Question[] _questions = null;
    //public Question[] Questions { get { return _questions; } }


    [SerializeField] GameEvents events = null;

    [SerializeField] Animator timerAnimator = null;

    [SerializeField] TextMeshProUGUI timerText = null;

    [SerializeField] Color TimerHalfWayOutColor = Color.yellow;

    [SerializeField] Color timerAlmostOutColor = Color.red;

    private Color timerDefaultColor = Color.white;

    private List<AnswerData> PickedAnswers = new List<AnswerData>();
    private List<int> FinishedQuestions = new List<int>();

    private int currentQuestion = 0;


    private int timerStateParaHash = 0;

    private IEnumerator IE_WaitTillNextRound = null;
    private IEnumerator IE_StartTimer = null;

    public int counter = 0;
/*
    public void QuizDone()
    {


        while (counter <= 5)
        {
            
            if (counter == 5)
            {
               FinishedQuestions.Count;

            }
            counter++;


        }
        Debug.Log(counter);
    }
    */

    private bool IsFinished
    {
        get
        {
            return (FinishedQuestions.Count <= 10) ? false : true;

        }
    }

    void OnEnable()
    {
        events.UpdateQuestionAnswer += UpdateAnswers;
        
    }

    void OnDisable()
    {
        events.UpdateQuestionAnswer -= UpdateAnswers;
    }


    void Awake()
    {
        events.CurrentFinalScore = 0;
    }

    void Start()
    {
        events.StartUpHighScore = PlayerPrefs.GetInt(GameUtility.SavePrefKey);

        timerDefaultColor = timerText.color;

        LoadData();

        

        timerStateParaHash = Animator.StringToHash("TimerState");


        var seed = UnityEngine.Random.Range(int.MinValue,int.MaxValue);
        UnityEngine.Random.InitState(seed);

         
        DisplayQuestion();
    }


    public void UpdateAnswers(AnswerData newAnswer)
    {
        //if question have single answer
       

        if (data.Questions[currentQuestion].Type == Question.AnswerType.Single)
        {
            foreach (var answer in PickedAnswers)
            {
                if (answer != newAnswer)
                {
                    answer.Reset();
                }
                
            }
            PickedAnswers.Clear();
            PickedAnswers.Add(newAnswer);
        }
        else
        {
            //if question have multiple answers
            //if picked answer exists in list of answers,we are removing the new answer but if it doesn't , we are adding it answer to the pickedAnswers list
            bool alreadyPicked = PickedAnswers.Exists(x => x == newAnswer);
            if(alreadyPicked)
            {
                PickedAnswers.Remove(newAnswer);
            }
            else
            {
                PickedAnswers.Add(newAnswer);
            }
        }

    }



    public void EraseAnswers()
    {
        PickedAnswers = new List<AnswerData>();
    }



    void DisplayQuestion()
    {
        EraseAnswers();
        var question = GetRandomQuestion();

        if(events.UpdateQuestionUI != null)
        {
            events.UpdateQuestionUI(question);
        }
        else
        {
            Debug.LogWarning("Oops! Something went wrong while trying to display new question.Delegate Game events.UpdateQuestionUI is null.The issue occured in GameManager.Display() method"); 
        }
        if(question.UseTimer)
        {
            UpdateTimer(question.UseTimer);
        }
    }


    public void AcceptAnswer()
    {
        UpdateTimer(false);
        bool isCorrect = CheckAnswers();
        FinishedQuestions.Add(currentQuestion);

        
        UpdateScore((isCorrect) ? data.Questions[currentQuestion].AddScore : -data.Questions[currentQuestion].AddScore);


        if (IsFinished)
        {
            events.level++;
            if(events.level > GameEvents.maxLevel)
            {
                events.level = 1;
            }
            SetHighScore();
        }


        var type = (IsFinished) ? UIManager.ResolutionScreenType.Finish : (isCorrect) ? UIManager.ResolutionScreenType.Correct : UIManager.ResolutionScreenType.Incorrect;

        events.DisplayResolutionScreen?.Invoke(type, data.Questions[currentQuestion].AddScore);

        AudioManager.Instance.PlaySound((isCorrect) ? "CorrectSFX" : "IncorrectSFX");
        if (type != UIManager.ResolutionScreenType.Finish)
        {
            

            

            if (IE_WaitTillNextRound != null)
            {
                StopCoroutine(IE_WaitTillNextRound);
            }
            IE_WaitTillNextRound = WaitUntilNextRound();
            StartCoroutine(IE_WaitTillNextRound);

        }





    }


    void UpdateTimer(bool state)
    {
        switch(state)
        {
            case true:
                IE_StartTimer = StartTimer();
                StartCoroutine(IE_StartTimer);

                timerAnimator.SetInteger(timerStateParaHash, 2);
                break;
            case false:
                if(IE_StartTimer != null)
                {
                    StopCoroutine(IE_StartTimer);
                }
                timerAnimator.SetInteger(timerStateParaHash, 1);
                break;
        }

    }


    IEnumerator StartTimer()
    {
        var totalTime = data.Questions[currentQuestion].Timer;
        var timeLeft = totalTime;

        timerText.color = timerDefaultColor;

        while(timeLeft > 0)
        {

            timeLeft--;
            


            if(timeLeft < totalTime /2 && timeLeft > totalTime / 4)
            {

                //if we are half way done with time
                timerText.color = TimerHalfWayOutColor;
            }

            if(timeLeft < totalTime /4)
            {
                AudioManager.Instance.PlaySound("CountdownSFX");
                //if we are almost out of the time
                timerText.color = timerAlmostOutColor;
            }

            timerText.text = timeLeft.ToString();
            yield return new WaitForSeconds(1.0f);
        }
        AcceptAnswer();
    }
    

    IEnumerator WaitUntilNextRound()
    {
        yield return new WaitForSeconds(GameUtility.ResolutionDelayTime);
        DisplayQuestion();
    }


    Question GetRandomQuestion()
    {
        var randomIndex = GetRandomQuestionIndex();
        currentQuestion = randomIndex;

      return data.Questions[currentQuestion];
    }


    int GetRandomQuestionIndex()
    {
        var random = 0;

        if(FinishedQuestions.Count < data.Questions.Length)
        {
            do
            {
                random = UnityEngine.Random.Range(0, data.Questions.Length);

            } while (FinishedQuestions.Contains(random) || random == currentQuestion);

        }
        return random;

   }

    bool CheckAnswers()
    {
        if(!CompareAnswers())
        {
           return false;
        }
       return true;
    }

    bool CompareAnswers()
    {
        if(PickedAnswers.Count > 0)
        {
            List<int> ca = data.Questions[currentQuestion].GetCorrectAnswers();
            List<int> pa = PickedAnswers.Select(x => x.AnswerIndex).ToList();

            var f = ca.Except(pa).ToList();
            var s = pa.Except(ca).ToList();

            //if both list dont contain any elements it will return true
            return !f.Any() && !s.Any();
        }
        return false;
    }

    private void SetHighScore()
    {
        var highscore = PlayerPrefs.GetInt(GameUtility.SavePrefKey);

        if(highscore < events.CurrentFinalScore)
        {
            PlayerPrefs.SetInt(GameUtility.SavePrefKey, events.CurrentFinalScore);
        }
    }

    //function that is called to load data from the xml file
    void LoadData()
    {

        var path = Path.Combine(GameUtility.fileDirectory,GameUtility.FileName+ events.level+ ".xml");
        Debug.Log(path);
        data = GameData.Fetch(path);
  
        
    }

    public void RestartGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

   

    private void UpdateScore(int add)
    {
        events.CurrentFinalScore = events.CurrentFinalScore + add;
        if(events.CurrentFinalScore < 0) { events.CurrentFinalScore = 0; }

        events.ScoreUpdated?.Invoke();


        /*if (events.ScoreUpdated != null)
        {
            events.ScoreUpdated();
        }*/
    }



}


