<?php 

include('include/db.php');

if(isset($_GET['delete_payment']))
{
   global $con;
   
   $id = $_GET['delete_payment'];
   
   $query = "delete from payments where payment_id = '$id'";
   
   $run_query = $con->query($query);
   
   if($run_query)
   {
      echo "<script>alert('Payment Deleted Successfully...');
	        window.open('view_payment.php?deleted=Payment Deleted Successfully...' , '_self')</script>";
   }
}

?>