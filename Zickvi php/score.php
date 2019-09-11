<?php
// Pozivas ovaj fajl kada igrac zavrsi igru i treba da upise skor u bazu
// Prosledjujes mi userid i skor
include("conn.php");

$userid = $_REQUEST['userid'];
$score = $_REQUEST['score'];

  $sql = "INSERT INTO scores (userid, score)
  VALUES ('$userid', '$score');";

  $conn->query($sql);

 ?>
