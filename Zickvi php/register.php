<?php
// Register pozivas kada igrac unese sve podatke i kilkne Register
// Prvo proveris da li su sva polja ispravno popunjena (da li je email upisan u email formatu) pa onda zoves ovaj php fajl
// Prosledjujes mi Username, Password i Email. Ukoliko Username ili Email vec postoje u bazi, vracam ti false. Ukoliko se igrac uspesno registruje, vracam ti true
include("conn.php");

$username = $_REQUEST['username'];
$email = $_REQUEST['email'];
$password = $_REQUEST['password'];

$sql = "SELECT * FROM users WHERE username = '$username'";

$result = $conn->query($sql);
      if($result->num_rows>0){
        echo "false";
      }else{
        $sql = "SELECT * FROM users WHERE email = '$email'";

        $result = $conn->query($sql);
        if($result->num_rows>0){
          echo "false";
        }else{
          $sql = "INSERT INTO users (username, email, password)
          VALUES ('$username', '$email', '$password');";

          $conn->query($sql);

          echo "0";
        }
      }

 ?>
