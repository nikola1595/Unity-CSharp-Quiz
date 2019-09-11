<?php
// Login pozivas kada igrac unese sve podatke i kilkne Login
// Prosledjujes mi Username i Password, ja proveravam da li su validni i ukoliko takav igrac postoji, vracam ti njegov userid iz baze. Ukoliko ne postoji, vracam ti false
// Kada dobijes rezultat proveri da li je == false. Ako nije, znaci da ima u sebi userid i taj userid zapisi negde da bi kasnije mogao da upise skor.
include("conn.php");

$username = $_REQUEST['username'];
$password = $_REQUEST['password'];

$sql = "SELECT id FROM users WHERE username = '$username' AND password = '$password'";
$result = $conn->query($sql);
if($result->num_rows>0){
        while($row = $result->fetch_assoc()){
          $return = $row["id"];
        }
      }else{
        $return = '0';
      }

    echo $return;

 ?>
