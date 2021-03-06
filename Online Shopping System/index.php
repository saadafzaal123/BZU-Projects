<?php

session_start();

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
			    	<li><a href = "index.php" class = "selected">Home</a></li>
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
						    echo "<b>Welcome:</b>".$_SESSION['customer_email']."<b style = 'color:yellow;'>Your</b>";
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
					   
					   get_product(); 
					   get_category_product();
					   get_brand_product();
					   
					  ?>
				 
				   </div>  
				
			    </div>
			
		    <div class = "footer">
			
			<h2 style = "color:#FFFFFF; padding-top:20px; text-align:center;">&copy; 2016 - By (www.Saad-Afzaal.com)</h2>
			
			</div>
		
        </div>

</body>
</html>
