<?php

session_start();

if(!isset($_SESSION['customer_email']))
{
    header('Location:checkout.php');
}

else
{

include('include/db.php');
include('functions/functions.php');


?>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
<title>My Shop</title>
<link rel = "stylesheet" href = "styles/index_styles.css"/>
</head>

<body>

<!-- Main Content Starts -->
	    <div class = "main_wrapper">
      	
		  <!-- Header Starts -->
		    <div class = "header_wrapper">
			
		       <a href = "index.php"><img style = "float:left;" src = "images/online-shop-logo.jpg" alt = "logo"/></a>
			   <img style = "float:right;" src = "images/Parade-Banners.jpg" alt = "banner"/>
			   
		    </div>
      	
		  <!-- Navigation Bar Starts -->
		    <div id = "navbar">
			    
				<ul id = "menu">
			    	<li><a href = "index.php">Home</a></li>
			    	<li><a href = "all_products.php">All Products</a></li>
			    	<li><a href = "customer/my_account.php">My Account</a></li>
			    	<li><a href = "user_register.php">Sign Up</a></li>
			    	<li><a href = "cart.php">Shopping Cart</a></li>
			    	<li><a href = "contact.php">Contact US</a></li>
			    </ul>
				
				<div id = "form">
				   <form action = "results.php" method="get" enctype="multipart/form-data">
				   
				       <input type = "text" name = "user_query" placeholder = "Search a Product"/>
					   <input type = "submit" value = "Search" name = "search"/>
				   
				   </form>
				</div>
				
			</div>
      	    
			<div class = "content_wrapper">
			    
				<div id = "left_sidebar"> 
				
				    <div id = "sidebar_title">Categories</div>
					
					<ul id = "cats">
					
					    <?php get_categories(); ?>
						
					</ul>
					
					<div id = "sidebar_title">Brands</div>
					
					<ul id = "cats">
					
					 <?php get_brands(); ?>
					
					</ul>
				
				</div>
				
				<div id = "right_content"> 
				
				<?php cart(); ?>
				
				   <div id = "headline">
				   
				      <div id = "headline_content">
				   
				         <?php
						 
						 if(isset($_SESSION['customer_email']))
						 {
						    echo "<b>Welcome:</b><span style = 'color:gold;'>".$_SESSION['customer_email']."</span><b style = 'color:yellow;'>Your</b>";
						 }
						 else
						 {
						    echo "<b>Welcome Guest:</b>";
						 }
						 
						 ?>
						 
				         <b style = "color:#FFFF00">Shooping Cart:</b>
						 <span>- Total Items: <?php echo "<span style = 'color:#FFFF00'>".total_items()."</span>"; ?> - Total Price: <?php echo "<span                         style = 'color:#FFFF00'>$".total_price()."</span> "; ?><a href =       
						 "cart.php" style = "color:gold">Go to Cart</a></span>
						 
						 <?php
						 
						 if(!isset($_SESSION['customer_email']))
						 {
						    echo "<a href = 'checkout.php' style = 'color:orange;'>Login</a>";
						 }
						 else
						 {
						    echo "<a href = 'logout.php' style = 'color:orange;'>LogOut</a>";
						 }
						 
						 ?>
						 
				      </div>
				
				   </div>
				   
				   
				   <div id = "products_box">
				 
				    <?php 
					   
					    global $con;
   
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
					   }
					?>
				 
				     <div style = "background:white; width:798px; margin-top:-20px; margin-left:-32px;">
					 <h2>Pay now with Paypal:</h2><br />
					 
					 <form action="paypal_success.php" method="post">  <!--https://www.sandbox.paypal.com/cgi-bin/webscr-->

                       <!-- Identify your business so that you can collect the payments. -->
                       <input type="hidden" name="business" value="herschelgomez@xyzzyu.com">

                       <!-- Specify a Buy Now button. -->
                       <input type="hidden" name="cmd" value="_xclick">

                       <!-- Specify details about the item that buyers will purchase. -->
                       <input type="hidden" name="item_name" value="<?php 
					  
					   $i = 0;
					   $select_pro = "select * from cart where ip_address = '$ip'";
	  
                        $run_pro = $con->query($select_pro);
   
                        while($p_price = mysqli_fetch_array($run_pro))
                       {
                         $pro_id = $p_price['p_id'];
						 
						 $p_info = "select * from products where product_id = '$pro_id'";
	  
	                     $run_p_info = $con->query($p_info);
	  
	                     while($pp_info = mysqli_fetch_array($run_p_info))
	                     {
						    $i += 1;
							$product_name = $pp_info['product_title'];
		                    echo $i."-".$product_name;
							echo " ";
						 }
					   }
					   
					   ?>">
					   <input type="hidden" name="item_number" value="<?php 
					   
					   $select_pro = "select * from cart where ip_address = '$ip'";
	  
                       $run_pro = $con->query($select_pro);
                        while($p_price = mysqli_fetch_array($run_pro))
                       {
                         $pro_id = $p_price['p_id'];
						 echo $pro_id;
						 echo ",";
					   }
					   
					   ?>">
                       <input type="hidden" name="amount" value="<?php echo $total; ?>">
                       <input type="hidden" name="currency_code" value="USD">
                
                       <input type="hidden" name="return" value="paypal_success.php">
					   <input type="hidden" name="cancel_return" value="paypal_cancel.php">

                       <!-- Display the payment button. -->
                       <input type="image" name="submit" border="0"
                       src="images/paypal_button.png"
					   alt="PayPal - The safer, easier way to pay online">
                       <img alt="" border="0" width="1" height="1"
                       src="https://www.paypalobjects.com/en_US/i/scr/pixel.gif" >

                     </form>
					 
					 <img src = "images/paypal.png" width = "200" height = "100" style = "margin-bottom:20px;" />
		        	 </div>
				 
				   </div>  
				
			    </div>
			
		    <div class = "footer">
			
			<h2 style = "color:#FFFFFF; padding-top:20px; text-align:center;">&copy; 2016 - By (www.Saad-Afzaal.com)</h2>
			
			</div>
		
        </div>

</body>
</html>

<?php
}
?>