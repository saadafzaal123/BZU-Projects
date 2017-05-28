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

   <table width = "700" align = "left" border = "1" bgcolor="black" style = "color:white;">
      
	  <tr>
	    <td colspan = "6" align = "center"><h2>All Brands Here!</h2></td>
	  </tr>
	  
	  <tr align = "center" style = "color:#FFFF00;">
		<th>Brand_id:</th>
		<th>Brand_title:</th>
		<th>Delete</th>
	  </tr>
	  
	  <?php
	    $query = "select * from `brands`";
        $query_run = $con->query($query);
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
			    	<li><a href = "view_all_brands.php" class = "selected">View all Brands</a></li>
					<li><a href = "view_customer.php">View Customers</a></li>
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
