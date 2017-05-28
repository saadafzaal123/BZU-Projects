<?php 

include('include/db.php');

if(isset($_GET['delete_customer']))
{
   global $con;
   
   $id = $_GET['delete_customer'];
   
   $query = "delete from customers where customer_id = '$id'";
   
   $run_query = $con->query($query);
   
   if($run_query)
   {
      echo "<script>alert('Customer Deleted Successfully...');
	        window.open('view_customer.php?deleted=Customer Deleted Successfully...' , '_self')</script>";
   }
}

?>