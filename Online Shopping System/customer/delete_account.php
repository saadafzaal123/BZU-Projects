<?php 

include('include/db.php');

if(isset($_GET['id']))
{
   global $con;
   
   $id = $_GET['id'];
   
   $query = "delete from customers where customer_id = '$id'";
   
   $run_query = $con->query($query);
   
   if($run_query)
   {
      echo "<script>alert('Account Deleted Successfully...');
	        window.open('my_account.php?deleted=Account Deleted Successfully...' , '_self')</script>";
   }
}

?>