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
      	    					
			
			<div style="background:black;">			
				
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
					           <li><a href = "my_order.php">My Orders</a></li>
						       <li><a href = "edit_account.php">Edit Account</a></li>
							   <li><a href = "change_password.php" class = "selected">Change Password</a></li>
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
					   
					<div style = "width:800px; margin-bottom:41px; margin-top:41px;">
						
					 <div style = "border-radius:30px; width:400px; margin:0px auto; background:green;">
					  <form action = "change_password.php" method = "POST" enctype = "multipart/form-data">
					   <table width = "400" align = "center" border = "1" height = "300" style = "color:white;">
      
	                    <tr>
	                      <td colspan = "2" align = "center"><h1>Change Password</h1></td>
	                    </tr>
						
						<tr>
	                      <!--<th align = "right">Password:</th>-->
						  <td align = "center" colspan = "2"><input type = "password" name = "pre_password" placeholder = "Previous Password"/></td>
	                    </tr>
						
						<tr>
	                      <!--<th align = "right">Password:</th>-->
						  <td align = "center" colspan = "2"><input type = "password" name = "password" placeholder = "New Password"/></td>
	                    </tr>
						
						<tr>
	                      <!--<th align = "right">Confirm Password:</th>-->
						  <td align = "center" colspan = "2"><input type = "password" name = "confirm_password" placeholder = "Confirm New Password"/>                          </td>
	                    </tr>
						
						
						
						<tr>
						  <td align = "center" colspan = "2"><input type = "submit" name = "submit" value = "Submit" /></td>
						</tr>
						
					   </table>
					  </form>
					 </div> 
						
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
					 
					   if(isset($_POST['submit']))
					   {
					      $c_pre_pass = $_POST['pre_password'];
						  $c_new_pass = $_POST['password'];
						  $c_confirm_pass = $_POST['confirm_password'];
						  
						  if(!empty($c_pre_pass) && !empty($c_new_pass) && !empty($c_confirm_pass))
						  {
						     $c_pre_pass = md5($c_pre_pass);
							 $c_new_pass = md5($c_new_pass);
							 $c_confirm_pass = md5($c_confirm_pass);
							 
                             if($c_pre_pass == $password)
							 {
							    if($c_new_pass == $c_confirm_pass)
								{
								   $query = "update customers set customer_password = '$c_new_pass' where customer_email = '$user'";
										
							       $run_query = $con->query($query);
   
                                   if($run_query)
                                   {
                                      echo "<script>alert('Password Changed Successfully...');
	                                  window.open('my_account.php?changed=Password Changed Successfully...' , '_self')</script>";
                                   }
								}
								else
								{
								   echo "<script>alert('New Password and Confirm New Password does not match....')</script>";
								}
							 }
							 else
							 {
							    echo "<script>alert('Incorrect Previous Password...')</script>";
							 }
						  }
						  else
						  {
						     echo "<script>alert('All fields should be filled.')</script>";
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
