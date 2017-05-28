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
			    	<li><a href = "my_account.php">My Account</a></li>
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
      	    		<div style="background:black; float:right;">			
				
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
				
				<div id = "left_content"> 
				
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
					 <div style = "width:780px;">
					  
					  <table width = "770" align = "left" border = "1" bgcolor = "black" style="color:white; margin-bottom:15px; margin-left:5px;                       margin-top:5px;" >
      
	                   <tr>
	                    <td colspan = "6" align = "center"><h2 style = "margin-bottom:20px; margin-top:15px;">All Orders Here!</h2></td>
	                   </tr>
	  
	                   <tr align = "center" style = "color:#FFFF00;">
		               <th>Product_Name:</th>
		               <th>Customer_Name:</th>
					   <th>Quantity</th>
		               <th>Order_Date</th>
	                   </tr>
	  
	                   <?php
	                     $query = "select * from `orders`";
                         $query_run = $con->query($query);
                         while($row = mysqli_fetch_array($query_run))
                         {
						     $o_id = $row['order_id'];
		                     $p_id = $row['p_id'];
	                         $c_id = $row['c_id'];
							 $qty = $row['quantity'];
							 $date = $row['order_date'];
							 
							 $query_1 = "select product_title from products where product_id = '$p_id'";
							 $query_run_1 = $con->query($query_1);
							 $p = mysqli_fetch_array($query_run_1);
							 $title = $p['product_title'];
							 
							 $query_2 = "select customer_name from customers where customer_id = '$c_id'";
							 $query_run_2 = $con->query($query_2);
							 $c = mysqli_fetch_array($query_run_2);
							 $name = $c['customer_name']; 
	                   ?>
	
	                     <tr align = "center">
		                 <td><?php echo $title; ?></td>
						 <td><?php echo $name; ?></td>
						 <td><?php echo $qty; ?></td>
		                 <td><?php echo $date; ?></td>
	                     </tr>
	
	                   <?php
	                     }
                       ?>
	  
	                  </table>
					  
					 </div>
						
					<?php
					}
					else
					{
					
					?>
					
				        <div>
						<h2>Please Login Here <a href = 'login.php' style = 'color:green;'>Login</a></h2>
						</div>
					  
					<?php
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
