<?php

function get_product()
{
    global $con;
	
	if(!isset($_GET['cat']))
	{
	   if(!isset($_GET['brand']))
	   {
	      $query = "select * from products order by rand() Limit 0,6";
	      $run_query = $con->query($query);
						   
	      while($row_products = mysqli_fetch_array($run_query))
	      {
		     $product_id = $row_products['product_id'];
		     $product_title = $row_products['product_title'];
		     $product_cat = $row_products['cat_id'];
		     $product_brand = $row_products['brand_id'];
		     $product_description = $row_products['product_description'];
		     $product_price = $row_products['product_price'];
		     $product_image = $row_products['product_img1'];
							   
		      echo "<div id = 'single_product'>
							  
			        <h3>$product_title</h3>
			        <img src = 'admin_area/product_images/$product_image' width = '200' height = '150'><br>
			        <p><b>Price: $ $product_price</b></p>	
			        <a href = 'details.php?product_id=$product_id' style = 'float:left; color:blue;'>Details</a>
			        <a href = 'index.php?add_cart=$product_id'><button style = 'float:right;'>Add to Cart</button></a>
							        
			        </div>";
		   }
	    }
	 }
}


function get_all_product()
{
    global $con;
	
	$query = "select * from products";
	$run_query = $con->query($query);
						   
	while($row_products = mysqli_fetch_array($run_query))
	{
		$product_id = $row_products['product_id'];
		$product_title = $row_products['product_title'];
		$product_cat = $row_products['cat_id'];
		$product_brand = $row_products['brand_id'];
		$product_description = $row_products['product_description'];
		$product_price = $row_products['product_price'];
		$product_image = $row_products['product_img1'];
							   
		 echo "<div id = 'single_product'>
							  
			   <h3>$product_title</h3>
			   <img src = 'admin_area/product_images/$product_image' width = '200' height = '150'><br>
			   <p><b>Price: $ $product_price</b></p>	
			    <a href = 'details.php?product_id=$product_id' style = 'float:left; color:blue;'>Details</a>
			    <a href = 'index.php?add_cart=$product_id'><button style = 'float:right;'>Add to Cart</button></a>
							        
			    </div>";
	 }
}


function get_category_product()
{
    global $con;
	
	if(isset($_GET['cat']))
	{
	      $cat_id = $_GET['cat'];
		  
	      $query = "select * from products where cat_id = '$cat_id'";
	      $run_query = $con->query($query);
			
		  $count = mysqli_num_rows($run_query);
		  
		  if($count == 0)
		  { 
		     echo '<h2 style = "color:red;">No Products found in this category!</h2>';
		  }
		  			   
	      while($row_products = mysqli_fetch_array($run_query))
	      {
		     $product_id = $row_products['product_id'];
		     $product_title = $row_products['product_title'];
		     $product_cat = $row_products['cat_id'];
		     $product_brand = $row_products['brand_id'];
		     $product_description = $row_products['product_description'];
		     $product_price = $row_products['product_price'];
		     $product_image = $row_products['product_img1'];
							   
		      echo "<div id = 'single_product'>
							  
			        <h3>$product_title</h3>
			        <img src = 'admin_area/product_images/$product_image' width = '200' height = '150'><br>
			        <p><b>Price: $ $product_price</b></p>	
			        <a href = 'details.php?product_id=$product_id' style = 'float:left; color:blue;'>Details</a>
			        <a href = 'index.php?add_cart=$product_id'><button style = 'float:right;'>Add to Cart</button></a>
							        
			        </div>";
		   }
	 }
}


function get_brand_product()
{
    global $con;
	
	if(isset($_GET['brand']))
	{
	      $brand_id = $_GET['brand'];
		  
	      $query = "select * from products where brand_id = '$brand_id'";
	      $run_query = $con->query($query);
				
		  $count = mysqli_num_rows($run_query);
		  
		  if($count == 0)
		  { 
		     echo '<h2 style = "color:red;">No Products found in this brand!</h2>';
		  }
						   
	      while($row_products = mysqli_fetch_array($run_query))
	      {
		     $product_id = $row_products['product_id'];
		     $product_title = $row_products['product_title'];
		     $product_cat = $row_products['cat_id'];
		     $product_brand = $row_products['brand_id'];
		     $product_description = $row_products['product_description'];
		     $product_price = $row_products['product_price'];
		     $product_image = $row_products['product_img1'];
							   
		      echo "<div id = 'single_product'>
							  
			        <h3>$product_title</h3>
			        <img src = 'admin_area/product_images/$product_image' width = '200' height = '150'><br>
			        <p><b>Price: $ $product_price</b></p>	
			        <a href = 'details.php?product_id=$product_id' style = 'float:left; color:blue;'>Details</a>
			        <a href = 'index.php?add_cart=$product_id'><button style = 'float:right;'>Add to Cart</button></a>
							        
			        </div>";
		   }
	 }
}


function get_categories()
{
    global $con;
	
    $get_cats =  "select * from categories";
	$run_cats = $con->query($get_cats);
						   
	while($row_cats = mysqli_fetch_array($run_cats))
    {
		$cat_id = $row_cats['cat_id'];
		$cat_title = $row_cats['cat_title'];
							  
		echo "<li><a href = 'index.php?cat=$cat_id'>$cat_title</a></li>";
	}
}


function get_brands()
{
    global $con;
    
    $get_brands =  "select * from brands";
	$run_brands = $con->query($get_brands);
						   
	while($row_brands = mysqli_fetch_array($run_brands))
	{
		$brand_id = $row_brands['brand_id'];
		$brand_title = $row_brands['brand_title'];
							  
	    echo "<li><a href = 'index.php?brand=$brand_id'>$brand_title</a></li>";
	}
}


function search_product($search_words)
{
    global $con;
	
	$query = "select * from products where product_keywords like '%$search_words%'";
	$run_query = $con->query($query);
	
	$count = mysqli_num_rows($run_query);
		  
	if($count == 0)
    { 
	   echo '<h2 style = "color:red;">No Products found in this brand or category!</h2>';
    }
						   
	while($row_products = mysqli_fetch_array($run_query))
	{
		$product_id = $row_products['product_id'];
		$product_title = $row_products['product_title'];
		$product_cat = $row_products['cat_id'];
		$product_brand = $row_products['brand_id'];
		$product_description = $row_products['product_description'];
		$product_price = $row_products['product_price'];
		$product_image = $row_products['product_img1'];
							   
		 echo "<div id = 'single_product'>
							  
			   <h3>$product_title</h3>
			   <img src = 'admin_area/product_images/$product_image' width = '200' height = '150'><br>
			   <p><b>Price: $ $product_price</b></p>	
			    <a href = 'details.php?product_id=$product_id' style = 'float:left; color:blue;'>Details</a>
			    <a href = 'index.php?add_cart=$product_id'><button style = 'float:right;'>Add to Cart</button></a>
							        
			    </div>";
	 }
}


function details_product($product_id)
{
    global $con;
	
	$query = "select * from products where product_id = '$product_id'";
	$run_query = $con->query($query);
						   
	while($row_products = mysqli_fetch_array($run_query))
	{
		$product_id = $row_products['product_id'];
		$product_title = $row_products['product_title'];
		$product_cat = $row_products['cat_id'];
		$product_brand = $row_products['brand_id'];
		$product_description = $row_products['product_description'];
		$product_price = $row_products['product_price'];
		$product_image = $row_products['product_img1'];
		$product_image1 = $row_products['product_img2'];
		$product_image2 = $row_products['product_img3'];
							   
		 echo "<div id = 'single_product'>
							  
			   <h3>$product_title</h3>
			   <img src = 'admin_area/product_images/$product_image' width = '200' height = '150'>
			   <img src = 'admin_area/product_images/$product_image1' width = '230' height = '180'>
			   <img src = 'admin_area/product_images/$product_image2' width = '230' height = '180'>
			   <p><b>Price: $ $product_price</b></p>
			   <p>$product_description</p>	
			    <a href = 'index.php' style = 'float:left; color:blue;'>Go Back</a>
			    <a href = 'index.php?add_cart=$product_id'><button style = 'float:right;'>Add to Cart</button></a>
							        
			    </div>";
	 }
}


function get_ip()
{
   $ip = $_SERVER['REMOTE_ADDR'];
   
   if(!empty($_SERVER['HTTP_CLIENT_IP']))
   {
       $ip = $_SERVER['HTTP_CLIENT_IP'];
   }
   else if(!empty($_SERVER['HTTP_X_FORWARDED_FOR']))
   { 
       $ip = $_SERVER['HTTP_X_FORWARDED_FOR'];
   }
   
   return $ip;
}


function cart()
{
   global $con;
	
   if(isset($_GET['add_cart']))
   {
      $p_id = $_GET['add_cart'];
	  $ip = get_ip();
	  
	  $check_pro = "select * from cart where ip_address = '$ip' AND p_id = '$p_id'";
	  
	  $run_check = $con->query($check_pro);
	  
	  if(mysqli_num_rows($run_check) > 0)
	  {
	      echo "<script>alert('Item you have already selected.')</script>";
	  }
	  else
	  {
	     $get_price = "select * from products where product_id = '$p_id'";
		 
		 $run_price = $con->query($get_price);
		 
		 while($p_price = mysqli_fetch_array($run_price))
		 {
		    $price = $p_price['product_price'];
		 }
		 
	     $insert_pro = "insert into cart values('' , '$p_id' , '$ip' , '1' , '$price')";
		 
		 $run_query = $con->query($insert_pro);
		 
		 echo "<script>window.open('index.php' , '_self')</script>";
	  }
   }
}


function total_items()
{
   global $con;
	
   if(isset($_GET['add_cart']))
   {
   	  $ip = get_ip();
	  
	  $get_items = "select * from cart where ip_address = '$ip'";
	  
	  $run_items = $con->query($get_items);
	  
	  $count_items = mysqli_num_rows($run_items);
   }
   else
   {
      $ip = get_ip();
	  
	  $get_items = "select * from cart where ip_address = '$ip'";
	  
	  $run_items = $con->query($get_items);
	  
	  $count_items = mysqli_num_rows($run_items);
   }
   
   return $count_items;
}


function total_price()
{
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
   
   return $total;
}


function cart_display()
{
   global $con;
   
   $total = 0;
   
   $ip = get_ip();
	  
   $select_pro = "select * from cart where ip_address = '$ip'";
	  
   $run_pro = $con->query($select_pro);
   
   while($p_price = mysqli_fetch_array($run_pro))
   {
      $pro_id = $p_price['p_id'];
	  
	  $get_cart = "SELECT SUM(quantity*price) as price FROM cart where p_id='$pro_id'"; 
	  
	  $run_cart = $con->query($get_cart);
	  
	  while($cart_row = mysqli_fetch_array($run_cart))
	  {
	     $prod_price = array($cart_row['price']);
		 
		 $values = array_sum($prod_price);
		 
		 $total+= $values;
	  }
	  
	  $pro_price = "select * from products where product_id = '$pro_id'";
	  
	  $run_pro_price = $con->query($pro_price);
	  
	  while($pp_price = mysqli_fetch_array($run_pro_price))
	  {
	     $product_price = array($pp_price['product_price']);
		 
		 $product_title = $pp_price['product_title'];
		 $product_imgage = $pp_price['product_img1'];
		 $single_price = $pp_price['product_price'];
		 
		 $sqlqtyinfo = $con->query("SELECT * FROM cart WHERE ip_address='$ip' AND p_id='$pro_id'");
         $qty_info=mysqli_fetch_array($sqlqtyinfo);
         $qty_id = $qty_info['quantity'];
		 
		 ?>
		 
		 <tr align = "center">
		 
		<td><input type = "submit" name = "update_cart[<?php echo "$pro_id";?>]" value = "<?php echo $pro_id ?>" style = "width:50px; color:rgba(0, 0,             0, 0);"/></td>
		 
		 <td><input type = "checkbox" name = "remove" value = "<?php echo $pro_id; ?>"/></td>
		 
		 <td><?php echo $product_title; ?> <br />
		 <img src = "admin_area/product_images/<?php echo $product_imgage; ?>" width = "60" height = "60"/>
		 </td>
		 
		 <td><input type = "number" name = "qty[<?php echo "$pro_id";?>]" size = "6" max = "100" min = "0" value = "<?php echo $qty_id; ?>"/></td>
		 
		 <?php
		 
		 if(isset($_POST['update_cart'][$pro_id]))
		 {
		     if(!empty($_POST['remove']))
			 {
			    if($_POST['update_cart'][$pro_id] == $_POST['remove'])
				{
				   $delete_id = $_POST['remove'];
                   $sqlqty = $con->query("DELETE FROM cart WHERE p_id = '$delete_id' AND ip_address = '$ip'");
				   if($sqlqty)
			       {
			          echo "<script>window.open('cart.php','_self')</script>";
			       }
				} 
             }
			 
			 if(isset($_POST['qty'][$pro_id]))
			 {
			    $qty = $_POST['qty'][$pro_id];
                $special_id = $_POST['update_cart'][$pro_id];
			
			    $update_qty = $con->query("UPDATE cart SET quantity='$qty' WHERE p_id='$special_id' AND ip_address='$ip'");
			   
			    if($update_qty)
			    {
			       echo "<script>window.open('cart.php','_self')</script>";
			    }
			 }   
         }
		 		 
		 ?>
		 
		 <td><?php echo "$".$values; ?></td>
		 </tr>
		 
		 <?php  
	  }
   }
   ?>
   
   <tr align = "right">
		 <th colspan = "4">Sub Total:</th>
		 <td><?php echo "$".$total;?></td>
    </tr>
	
   <?php
}


function continue_shopping()
{
   if(isset($_POST['continue']))
   {
       echo "<script>window.open('index.php' , '_self')</script>";
   }
}


function create_account($name , $email , $password , $country , $city , $user_img)
{
   global $con;
   
   $ip = get_ip();
   
   $name = mysqli_real_escape_string($con , $name);
   $email = mysqli_real_escape_string($con , $email);
   $password = mysqli_real_escape_string($con , $password);
   $country = mysqli_real_escape_string($con , $country);
   $city = mysqli_real_escape_string($con , $city);
   
   $query = "insert into customers values('' , '$ip' , '$name' , '$email' , '$password' , '$country' , '$city' , '$user_img')";
   
   $query_run = $con->query($query);
   
   if($query_run)
   {
      echo "<script>alert('Account Created Successfully...');
	        window.open('index.php' , '_self')</script>";
   }
   else
   {
      echo "<script>alert('Email ID is dublicate change it...');
	        window.open('user_register.php' , '_self')</script>";
   }
}

?>

