<?php 

include('include/db.php');

if(isset($_GET['delete_order']))
{
   global $con;
   
   $id = $_GET['delete_order'];
   
   $query = "delete from orders where order_id = '$id'";
   
   $run_query = $con->query($query);
   
   if($run_query)
   {
      echo "<script>alert('Order Deleted Successfully...');
	        window.open('view_order.php?deleted=Order Deleted Successfully...' , '_self')</script>";
   }
}

?>