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
						       <li><a href = "edit_account.php" class = "selected">Edit Account</a></li>
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
					   
					<div style = "width:800px; margin-bottom:28px; margin-top:26px;">
						
					 <div style = "border-radius:30px; width:400px; margin:0px auto; background:green;">
					  <form action = "edit_account.php" method = "POST" enctype = "multipart/form-data">
					   <table width = "400" align = "center" border = "1" height = "350" style = "color:white;">
      
	                    <tr>
	                      <td colspan = "2" align = "center"><h1>Edit Account</h1></td>
	                    </tr>
	  
	                    <tr>
						<th><span style = "margin-left:92px; font-size:20px; clear:both">Image:</span></th>
						<td><span style = "margin-left:-6px;"><input type = "file" name = "img" /></span></td>
						</tr>
						
						<tr>
	                      <!--<th align = "right">Name:</th>-->
	                    <td align = "center" colspan = "2"><input type = "text" name = "name" placeholder = "Name" value = "<?php echo $name; ?>"/>
						</td>
	                    </tr>
	  
	                    <tr>
	                      <!--<th align = "right">Email:</th>-->
						  <td align = "center" colspan = "2"><input type = "text" name = "email" placeholder = "Email" value = "<?php echo $email; ?>"/>                          </td>
	                    </tr>
						
						<tr>
	                     <!-- <th align = "right">Country:</th>-->
						  <td align = "center" colspan = "2"><input type = "text" name = "country" placeholder = "Country" value = "<?php echo $country                          ;?>"/></td>
	                    </tr>
						
						<tr>
	                      <!--<th align = "right">City:</th>-->
						  <td align = "center" colspan = "2"><input type = "text" name = "city" placeholder = "City" value = "<?php echo $city; ?>"/>
						  </td>
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
					      $c_name = $_POST['name'];
						  $c_email = $_POST['email'];
						  $c_country = $_POST['country'];
						  $c_city = $_POST['city'];
						  
						  $c_user_img = $_FILES['img']['name'];
						  $temp_name1 = @$_FILES['img']['tmp_name'];
						  
						  if(!empty($c_name) && !empty($c_email) && !empty($c_country) && !empty($c_city) && !empty($c_user_img))
						  {
                              move_uploaded_file($temp_name1 , "images/$c_user_img");
								
							  $query = "update customers set customer_name = '$c_name' , customer_email = '$c_email' , customer_country = '$c_country',
							            customer_city = '$c_city' , customer_image = '$c_user_img' where customer_email = '$user'";
										
							    $run_query = $con->query($query);
   
                                if($run_query)
                                {
                                   echo "<script>alert('Account Upadted Successfully...');
	                               window.open('my_account.php?updated=Account Updated Successfully...' , '_self')</script>";
                                }
								else
                                {
                                   echo "<script>alert('Email ID is dublicate change it...');
	                               window.open('edit_account.php' , '_self')</script>";
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
