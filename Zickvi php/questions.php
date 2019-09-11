<?php
// Ne prosledjujes mi nista, samo pozivas ovaj fajl a ja ti vracam sva pitanja.
// Pitanja su spakovana u matricu, da bi pristupio svakom od pitanja, samo provuces niz kroz foreachloop i odatle pristupas svakom polju pitanja i upisujes ih u svoje varijable.
include("conn.php");

$array = array();

$sql = "SELECT * FROM questions";
$result = $conn->query($sql);
      if($result->num_rows>0){
        while($row = $result->fetch_assoc()){
          $question = array('text' => $row['text'], 'answer' => $row['answer'], 'a1' => $row['a1'], 'a2' => $row['a2'], 'a3' => $row['a3'], 'a4' => $row['a4'],
           'size' => $row['size'], 'timer' => $row['timer']);
           array_push($array, $question);
        }
        echo json_encode($array);
      }else{
        echo 'nema';
      }

 ?>
