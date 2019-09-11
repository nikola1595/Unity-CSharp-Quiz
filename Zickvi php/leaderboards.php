<?php
// Zoves ovaj fajl kada igrac otvori Leaderboards
// Ne prosledjujes mi nista, ja ti vracam prvih 20
// Lideri su spakovani u matricu, da bi pristupio svakom na listi, samo provuces niz kroz foreachloop i odatle pristupas imenu i skoru svakog od igraca na listi
include("conn.php");

$sql = "SELECT scores.score, users.username FROM scores
INNER JOIN users ON scores.userid = users.id
ORDER BY scores.score desc
LIMIT 20;";
$array = array();

$result = $conn->query($sql);
      if($result->num_rows>0){
        while($row = $result->fetch_assoc()){
          $leader = array('username' => $row['username'], 'score' => $row['score']);
          array_push($array, $leader);
        }
        echo json_encode($array,1);
      }else{
        echo 'nema';
      }


 ?>
