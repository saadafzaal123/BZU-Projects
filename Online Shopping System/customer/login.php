<?php

session_start();

include('include/db.php');

?>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
<title>My Shop</title>
<link rel = "stylesheet" href = "style/customer_styles.css"/>
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
			    	<li><a href = "../index.php">Home</a></li>
			    	<li><a href = "../all_products.php">All Products</a></li>
			    	<li><a href = "my_account.php" class = "selected">My Account</a></li>
			    	<li><a href = "../user_register.php">Sign Up</a></li>
			    	<li><a href = "../cart.php">Shopping Cart</a></li>
			    	<li><a href = "../contact.php">Contact US</a></li>
			    </ul>
				
				<div id = "form">
				   <form action = "../results.php" method="get" enctype="multipart/form-data">
				   
				       <input type = "text" name = "user_query" placeholder = "Search a Product"/>
					   <input type = "submit" value = "Search" name = "search"/>
				   
				   </form>
				</div>
				
			</div>
      	    					
				
				<div style="background:#e3e3e3;">			
				
				 <?php
				          if(isset($_SESSION['customer_email']))
						  {
						     $user = $_SESSION['customer_email'];
							 
							 $query = "select * from customers where customer_email = '$user'";
							 
							 $run_query = $con->query($query);
							 
							 $get = mysqli_fetch_array($run_query);
							 $name = $get['customer_name'];
							 $img = $get['customer_image'];
							 $id = $get['customer_id'];
							 $country = $get['customer_country'];
							 $city = $get['customer_city'];
							 $email = $get['customer_email'];
							 $password = $get['customer_password'];
						
						  ?>
						 
						  <div id = "right_sidebar">
				
				            <div id = "sidebar_title">My Account:</div>
					
					          <ul id = "cats">
					
					           <li><img src = "<?php echo 'images/'.$img ?>" alt = "Image" width = "180" height = "200"></li>
					           <li><a href = "my_order.php" class = "selected">My Orders</a></li>
						       <li><a href = "edit_account.php">Edit Account</a></li>
							   <li><a href = "change_password.php">Change Password</a></li>
							   <li><a href = "delete_account.php?id=<?php echo $id; ?>">Delete Account</a></li>
							   <li><a href = "logout.php">LogOut</a></li>
					         
							  </ul>
							 
						  </div>
						  
						  <?php
						  }
						  ?>
				
				
				<?php 
				
				if(isset($_SESSION['customer_email']))
				{
				
				?>
				
				<div id = "right_content"> 
				
				
				   <div id = "headline">
				   
				      <div id = "headline_content">
				  <?php 
				   }
				
				else
				{
				
				?>
				
				<div style = "width:1000px; background:#e3e3e3; float:right; margin-bottom:2px;"> 
				
				   <div style = "background:#000000; color:#FFFFFF; height:30px; width:980px; padding:10px;">
				   
				      <div id = "headline_content">
				
				<?php	
				
				}	 
					 
						 if(isset($_SESSION['customer_email']))
						 {
						    echo "<b>Welcome:</b>".$_SESSION['customer_email'];
						 }
						 else
						 {
						    echo "<b>Welcome Guest:</b>";
						 }
						 
						 if(!isset($_SESSION['customer_email']))
						 {
						    echo "<a href = 'login.php' style = 'color:orange;'>Login</a>";
						 }
						 else
						 {
						    echo "<a href = 'logout.php' style = 'color:orange;'>LogOut</a>";
						 }
						 
				?>
						 
				      </div>
				
				   </div>
				 
				 <?php 
				    
				  if(isset($_SESSION['customer_email']))
				  {
				  
				  ?>  
				   
	              <div id = "products_box">
				 
				    <?php
					
				   }
				   else
				   {
				   
				   ?>
		          	
					<div style = "width:950px; padding:25px; text-align:center; background:#e3e3e3;">
					
					<?php
				   
				   }
					
					if(isset($_SESSION['customer_email']))
					{
					
					?>
					   
					    <div style = "width:800px; height:385px;">
						<h1>Welcome: <?php echo "<span style = 'color:blue;'>".$name."</span>"; ?> </h1>
						<br>
						<h2>You can see your orders progress by clicking <a href = 'my_order.php' style = 'color:green;'>Link</a></h2>
						</div>
						
					<?php
					}
					else
					{
					
					?>
					
					<div style = "margin-top:-25px;">
					 <div id = "checkout_1">
					 <h2>Please Login!</h2>
				     <br />
					 
					 <form action = "login.php" method = "POST">
					 <b>Email:</b>
					 <input type = "text" name = "customer_email" style = "margin-left:25px;"/>
					 <br /><br />
					 <b>Password:</b>
					 <input type = "password" name = "customer_password" />
					 <br /><br />
					 <input type = "submit" name = "login" value = "Login" />
					 </form> 
				     </div>
					 </div>
					 
					 <div id = "checkout_2">
					 <b><a href = "../user_register.php">New? Register Here</a></b>
					 </div>
				        
					<?php
					   
					   if(isset($_POST['login']))
					   {
					      $customer_email = $_POST['customer_email'];
						  $customer_password = md5($_POST['customer_password']);
						  
						  if(!empty($customer_email) && !empty($customer_password))
						  {
						     $customer_email = mysqli_real_escape_string($con , $customer_email);
						     $customer_password = mysqli_real_escape_string($con , $customer_password);
							 
						     $query = "select * from customers where customer_email = '$customer_email' AND customer_password = '$customer_password'";
							 
						     $run_query = $con->query($query);
							 
							 while($row = mysqli_fetch_array($run_query))
							 {
							    $email = $_SESSION['customer_email'] = $row['customer_email'];
							 }
							 
						     if(mysqli_num_rows($run_query) >= 1)
						     {
							     echo "<script>window.open('my_account.php?logged=You are Logged in Successfully...!' , '_self');
								       alert('You are Logged in Successfully...!')</script>";
						     }
						     else
						     {
							     echo "<script>alert('Invalid Email or Password')</script>";
						     }
						  }
						  else
						  {
						     echo "<script>alert('Invalid Email or Password')</script>";
						  }  
					   }
					
	                 }				   
					?>
				 
				   </div>  
				
			    </div> 
				  	
				
			
		    <div class = "footer">
			
			<h2 style = "color:#FFFFFF; padding-top:20px; text-align:center;">&copy; 2016 - By (www.Saad-Afzaal.com)</h2>
			
			</div>
		
        </div>
		
	</div>

</body>
</html>
