<?php

session_start();

include('include/db.php');
include('functions/functions.php');

?>

<html>

<head>
<title>Paypal Successful!</title>
</head>

<body>

<?php 
 
 if(isset($_SESSION['customer_email']))
 {
   $user = $_SESSION['customer_email'];						 
   $query = "select * from customers where customer_email = '$user'";							 
   $run_query = $con->query($query);							 
   $get_c = mysqli_fetch_array($run_query); 
   $c_id = $get_c['customer_id'];

  // $amount = @$_GET['amt'];
  // $currency = @$_GET['cc'];
  // $trx_id = @$_GET['tx'];
    
   $trx_id = $Rand = rand(1000000000 , 9999999999);
   $currency = "USD";
	
   $total = 0;
   
   $ip = get_ip();
	  
   $select_pro = "select * from cart where ip_address = '$ip'";
	  
   $run_pro = $con->query($select_pro);
   
   while($p_price = mysqli_fetch_array($run_pro))
   {
      $pro_id = $p_price['p_id'];
	  
	  $pro_price = "SELECT SUM(quantity*price) as price FROM cart where p_id='$pro_id'"; 
	  
	  $run_pro_price = $con->query($pro_price);
	  
	  while($pp_price = mysqli_fetch_array($run_pro_price))
	  {
	     $product_price = array($pp_price['price']);
		 
		 $values = array_sum($product_price);
		 
		 $total+= $values;
	  }
	  
	  $p_info = "select * from products where product_id = '$pro_id'";
	  
	  $run_p_info = $con->query($p_info);
	  
	  $pp_info = mysqli_fetch_array($run_p_info);
	  
	  $product_id = $pp_info['product_id'];
	  
	  
	  $cart_info = "select * from cart where p_id = '$pro_id'";
	  
	  $run_cart_info = $con->query($cart_info);
	  
	  $p_qty = mysqli_fetch_array($run_cart_info);
	  
	  $qty = $p_qty['quantity']; 
	  
	  $insert_orders = "insert into orders values ('' , '$product_id' , '$c_id' , '$qty' , NOW())";

      $run_orders = $con->query($insert_orders);
	  
	  $insert_payments = "insert into payments values ('' , '$values' , '$c_id' , '$product_id' , '$trx_id' , ' $currency' , NOW())";

      $run_payments = $con->query($insert_payments);
   }
   
   $empty_card = "delete from cart";
   $run_cart = $con->query($empty_card);
   
   if($total > 0 /*$amount == $total*/)
   {
?>
 
     <h2>Welcome <?php echo $_SESSION['customer_email']; ?></h2>
     <h3>Your payment was successful, please go to your account</h3>
     <h3><a href = "customer/my_account.php">Go to your Account</a></h3>

<?php
   }
   else
   {
   
   ?>
    
	 <h2>Welcome Guest,</h2>
     <h3>Your payment was not successful, please go back to our shop and try again.</h3>
     <h3><a href = "index.php">Go Back</a></h3>
	
   <?php
   }
 }
?>
	
</body>
</html>