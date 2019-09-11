using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "GameEvents", menuName = "Quiz/new GameEvents")]
public class GameEvents : ScriptableObject
{



    //displaying new question
    public delegate void UpdateQuestionUICallBack(Question question);
    public UpdateQuestionUICallBack UpdateQuestionUI = null;


    //sending answerdata to determine which kind answer we picked
    public delegate void UpdateQuestionAnswerCallBack(AnswerData pickedAnswer);
    public UpdateQuestionAnswerCallBack UpdateQuestionAnswer = null;

    //display resolution screens depending on progress in game
    public delegate void DisplayResolutionScreenCallBack(UIManager.ResolutionScreenType type, int score);
    public DisplayResolutionScreenCallBack DisplayResolutionScreen = null;

    public delegate void ScoreUdpatedCallBack();
    public ScoreUdpatedCallBack ScoreUpdated = null;


    public int level = 1;
    public const int maxLevel = 2;


    [HideInInspector]
    public int CurrentFinalScore = 0;
    [HideInInspector]
    public int StartUpHighScore = 0;
}
