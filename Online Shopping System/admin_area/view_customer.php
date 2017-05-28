<?php

include('include/db.php');
include('include/login_file.php');

if(!Loggedin())
{
   header('Location:index.php');
}

else
{

?>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
<title>Admin Area</title>
<script src = "//tinymce.cachefly.net/4.0/tinymce.min.js"></script>
<script>
  tinymce.init({selector:'textarea'});
</script>
<link rel = "stylesheet" href = "styles/admin_area_style.css"/>
</head>

<body bgcolor="#e3e3e3">

<div id = "container">

<div id = "mian_heading">
<img src = "styles/admin.jpg" style = "float:left" width = '180' height = '100' />
<img src = "styles/manage1.jpg" style = "float:right" width = '180' height = '100' />
<h1>Manage Your Content</h1>
</div>

   <table width = "700" align = "left" border = "1" bgcolor="black" style = "color:#FFFFFF;">
      
	  <tr>
	    <td colspan = "7" align = "center"><h2>All Customers Here!</h2></td>
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
	    $query = "select * from `customers`";
        $query_run = $con->query($query);
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
   
    <div id = "right_content">
	   <h3>Manage Content</h3>
	   
	   <div id = "navbar">
			    
				<ul id = "menu">
				     <li><a href = "searching.php">Searching</a></li>
			    	<li><a href = "insert_product.php">Insert New Product</a></li>
			    	<li><a href = "view_all_products.php">View all Products</a></li>
			    	<li><a href = "insert_new_category.php">Insert New Category</a></li>
			    	<li><a href = "view_all_categories.php">View all Category</a></li>
			    	<li><a href = "insert_new_brand.php">Insert New Brand</a></li>
			    	<li><a href = "view_all_brands.php">View all Brands</a></li>
					<li><a href = "view_customer.php" class = "selected">View Customers</a></li>
					<li><a href = "view_order.php">View Orders</a></li>
					<li><a href = "view_payment.php">View Payments</a></li>
					<li><a href = "logout_file.php">Admin Logout</a></li>	
			    </ul>
	   </div>
	   
    </div>
	    
	  <div class = "footer">
	  
	      <img src = "styles/saad.jpg" style = "float:left" width = '180' height = '100' />
		  <img src = "styles/saad1.png" style = "float:right" width = '180' height = '97' />
		  <h3 style = "color:#FFFFFF; padding-top:20px; text-align:center;">&copy; 2016 - By (www.Saad-Afzaal.com)</h3>
			
	  </div>
	  
</div>
</body>
</html>

<?php
}
?>
