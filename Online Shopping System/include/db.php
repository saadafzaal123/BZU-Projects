<?php

$host = "localhost"; 
$user = "root";
$pass = ""; 
$db_name = "myshop"; 

$con = new mysqli($host,$user,$pass,$db_name);

if(mysqli_connect_errno())
{
   echo 'The connection was not established: '.mysqli_connect_error();
}

?>