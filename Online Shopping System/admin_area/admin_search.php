<?php

include('include/db.php');
include('include/login_file.php');

if(!Loggedin())
{
   header('Location:index.php');
}

else
{

if(isset($_POST['search_type']) && isset($_POST['search']))
{
   $search_type = $_POST['search_type'];
   $search = $_POST['search'];
   
   if(!empty($search_type) && !empty($search))
   {
   
   $search = mysqli_real_escape_string($con , $search);
   
   if($search_type == 'P')
   {
	    $query = "select * from products where product_keywords like '%$search%' OR product_id = '$search' OR product_price = '$search'";
        $query_run = $con->query($query);
		
		if(mysqli_num_rows($query_run) >= 1)
        {
		
		?>
        
		 <table width = "700" align = "left" border = "1" bgcolor="black" style = "color:#FFFFFF;">
      
	   <tr>
	    <td colspan = "6" align = "center"><h2>Search Products Here!</h2></td>
	   </tr>
	  
	   <tr align = "center" style = "color:#FFFF00;">
		<th>Product_id:</th>
		<th>Product_title:</th>
		<th>Product_Price:</th>
		<th>Product_Description:</th>
		<th>Edit</th>
		<th>Delete</th>
	   </tr>		
		
		<?php
        while($row = mysqli_fetch_array($query_run))
        {
		   $p_id = $row['product_id'];
	       $p_title = $row['product_title'];
		   $p_price = $row['product_price'];
		   $p_description = $row['product_description'];
	   ?>
	
	  
		
	    <tr align = "center">
		<td><?php echo $p_id; ?></td>
		<td><?php echo $p_title; ?></td>
		<td><?php echo $p_price; ?></td>
		<td><?php echo $p_description; ?></td>
		<td><div id = "edit"><a href = "edit_product.php?edit_product=<?php echo $p_id; ?>">Edit</a></div></td>
		<td><div id = "delete"><a href = "delete_item.php?delete_product=<?php echo $p_id; ?>">Delete</a></div></td>
	    </tr>
	  
	   <?php
	     }
		 ?>
		 
		 </table>
		 
		 <?php
		 }
		 else
		 {
		     echo '<h3 style = "color:white; margin-top:20px; margin-left:15px;">* Product does not exist.</h3>';
		 }
       ?>
	  
	  
	    
<?php
   }
   
   if($search_type == 'C')
   {
	    $query = "select * from `categories` where `cat_title` like '%$search%' OR cat_id = '$search'";
        $query_run = $con->query($query);
		
		if(mysqli_num_rows($query_run) < 1)
        {
		   echo '<h3 style = "color:white; margin-top:20px; margin-left:15px;">* Category does not exist.</h3>';
        }
        
		else
        {
		?>
		
		<table width = "700" align = "left" border = "1" bgcolor="black" style = "color:#FFFFFF">
      
	    <tr>
	      <td colspan = "6" align = "center"><h2>Search Categories Here!</h2></td>
	    </tr>
	  
	    <tr align = "center" style = "color:#FFFF00;">
		<th>Category_id:</th>
		<th>Category_title:</th>
		<th>Delete</th>
	    </tr>
		
		<?php
        while($row = mysqli_fetch_array($query_run))
        {
		   $cat_id = $row['cat_id'];
	       $cat_title = $row['cat_title'];
	   ?>
		
	    <tr align = "center">
		<td><?php echo $cat_id; ?></td>
		<td><?php echo $cat_title; ?></td>
		<td><div id = "delete"><a href = "delete_item.php?delete_category=<?php echo $cat_id; ?>">Delete</a></div></td>
	    </tr>
		
	
	   <?php
	     }
		 ?>
		 
		 </table>
		 
		 <?php
		 }
     }
   
   if($search_type == 'B')
   {
	    $query = "select * from `brands` where `brand_title` like '%$search%' OR brand_id = '$search'";
        $query_run = $con->query($query);
		
		if(mysqli_num_rows($query_run) < 1)
        {
		   echo '<h3 style = "color:white; margin-top:20px; margin-left:15px;">* Brand does not exist.</h3>';
        }
        
		else
        {
		?>
		 
		  <table width = "700" align = "left" border = "1" bgcolor="black" style = "color:#FFFFFF">
      
	     <tr>
	       <td colspan = "6" align = "center"><h2>Search Brands Here!</h2></td>
	     </tr>
	  
	     <tr align = "center" style = "color:#FFFF00;">
		 <th>Brand_id:</th>
		 <th>Brand_title:</th>
		 <th>Delete</th>
	     </tr>
		 
		<?php
        while($row = mysqli_fetch_array($query_run))
        {
		   $brand_id = $row['brand_id'];
	       $brand_title = $row['brand_title'];
	    ?>
	   
	     <tr align = "center">
		 <td><?php echo $brand_id; ?></td>
		 <td><?php echo $brand_title; ?></td>
		 <td><div id = "delete"><a href = "delete_item.php?delete_brand=<?php echo $brand_id; ?>">Delete</a></div></td>
	     </tr>
	
	   <?php
	     }
		 ?>
		 
		 </table>
		 
		 <?php
		 }
   }
   
   if($search_type == 'Cu')
   {
	    $query = "select * from `customers` where `customer_name` like '%$search%' OR customer_id = '$search'";
        $query_run = $con->query($query);
		
		if(mysqli_num_rows($query_run) < 1)
        {
		   echo '<h3 style = "color:white; margin-top:20px; margin-left:15px;">* Customer does not exist.</h3>';
        }
        
		else
        {
		?>
		
		<table width = "700" align = "left" border = "1" bgcolor="black" style = "color:#FFFFFF">
      
	    <tr>
	      <td colspan = "7" align = "center"><h2>Search Customers Here!</h2></td>
	    </tr>
	  
	    <tr align = "center" style = "color:#FFFF00;">
		<th>C_id:</th>
		<th>C_ip:</th>
		<th>C_Name:</th>
		<th>C_Email:</th>
		<th>C_Country:</th>
		<th>C_City:</th>
		<th>Delete</th>
	    </tr>
		
		<?php
        while($row = mysqli_fetch_array($query_run))
        {
		   $c_id = $row['customer_id'];
	       $ip = $row['customer_ip'];
		   $name = $row['customer_name'];
		   $email = $row['customer_email'];
		   $country = $row['customer_country'];
		   $city = $row['customer_city'];
	   ?>
		
	    <tr align = "center">
		<td><?php echo $c_id; ?></td>
		<td><?php echo $ip; ?></td>
		<td><?php echo $name; ?></td>
		<td><?php echo $email; ?></td>
		<td><?php echo $country; ?></td>
		<td><?php echo $city; ?></td>
		<td><div id = "delete"><a href = "delete_customer.php?delete_customer=<?php echo $c_id; ?>">Delete</a></div></td>
	    </tr>
		
	
	   <?php
	     }
		 ?>
		 
		 </table>
		 
		 <?php
		 }
     }
	 
	 if($search_type == 'O')
     {
	    $query = "select * from `orders` where `order_id` = '$search'";
        $query_run = $con->query($query);
		
		if(mysqli_num_rows($query_run) < 1)
        {
		   echo '<h3 style = "color:white; margin-top:20px; margin-left:15px;">* Order does not exist.</h3>';
        }
        
		else
        {
		?>
		
		<table width = "700" align = "left" border = "1" bgcolor="black" style = "color:#FFFFFF">
      
	    <tr>
	      <td colspan = "6" align = "center"><h2>Search Orders Here!</h2></td>
	    </tr>
	  
	    <tr align = "center" style = "color:#FFFF00;">
		<th>Order_id:</th>
		<th>Product_id:</th>
		<th>Customer_id:</th>
		<th>Quantity:</th>
		<th>Order_Date:</th>
		<th>Delete</th>
	    </tr>
		
		<?php
        while($row = mysqli_fetch_array($query_run))
        {
		    $o_id = $row['order_id'];
	        $p_id = $row['p_id'];
		    $c_id = $row['c_id'];
		    $qty = $row['quantity'];
		    $date = $row['order_date'];
	   ?>
		
	    <tr align = "center">
		<td><?php echo $o_id; ?></td>
		<td><?php echo $p_id; ?></td>
		<td><?php echo $c_id; ?></td>
		<td><?php echo $qty; ?></td>
		<td><?php echo $date; ?></td>
		<td><div id = "delete"><a href = "delete_order.php?delete_order=<?php echo $o_id; ?>">Delete</a></div></td>
	    </tr>
		
	
	   <?php
	     }
		 ?>
		 
		 </table>
		 
		 <?php
		 }
     }
	 
	 if($search_type == 'Pay')
     {
	    $query = "select * from `payments` where `payment_id` = '$search'";
        $query_run = $con->query($query);
		
		if(mysqli_num_rows($query_run) < 1)
        {
		   echo '<h3 style = "color:white; margin-top:20px; margin-left:15px;">* Payment does not exist.</h3>';
        }
        
		else
        {
		?>
		
		<table width = "700" align = "left" border = "1" bgcolor="black" style = "color:#FFFFFF">
      
	    <tr>
	      <td colspan = "8" align = "center"><h2>Search Payments Here!</h2></td>
	    </tr>
	  
	    <tr align = "center" style = "color:#FFFF00;">
		<th>Payment_id:</th>
		<th>Customer_id:</th>
		<th>Product_id:</th>
		<th>Amount:</th>
		<th>Trx_id:</th>
		<th>Currency:</th>
		<th>Payment_Date:</th>
		<th>Delete</th>
	    </tr>
		
		<?php
        while($row = mysqli_fetch_array($query_run))
        {
		   $payment_id = $row['payment_id'];
	       $c_id = $row['customer_id'];
		   $p_id = $row['product_id'];
		   $amount = $row['amount'];
		   $t_id = $row['trx_id'];
		   $currency = $row['currency'];
		   $date = $row['payment_date'];
	   ?>
		
	    <tr align = "center">
		<td><?php echo $payment_id; ?></td>
		<td><?php echo $c_id; ?></td>
		<td><?php echo $p_id; ?></td>
		<td><?php echo $amount; ?></td>
		<td><?php echo $t_id; ?></td>
		<td><?php echo $currency; ?></td>
		<td><?php echo $date; ?></td>
		<td><div id = "delete"><a href = "delete_payment.php?delete_payment=<?php echo $payment_id; ?>">Delete</a></div></td>
	    </tr>
		
	
	   <?php
	     }
		 ?>
		 
		 </table>
		 
		 <?php
		 }
     }  
 }
}

}

?>