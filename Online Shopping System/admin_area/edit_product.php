<?php

include('include/db.php');
include('include/login_file.php');

if(!Loggedin())
{
   header('Location:index.php');
}

else
{

$edit_product = $_GET['edit_product'];

 $query = "select * from `products` where `product_id` = '$edit_product'";
 
 $query_run = $con->query($query);
 
 while($row = mysqli_fetch_array($query_run))
 {
	$p_title = $row['product_title'];
    $p_price = $row['product_price'];
    $p_description = $row['product_description'];
	$cats_id = $row['cat_id'];
	$brands_id = $row['brand_id'];
	$product_img1 = $row['product_img1'];
	$product_img2 = $row['product_img2'];
	$product_img3 = $row['product_img3'];
	$product_keywords = $row['product_keywords'];
 }

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

<form action = "" method = "POST" enctype = "multipart/form-data">

   <table width = "700" align = "left" border = "1" bgcolor="white">
      
	  <tr>
	    <td colspan = "2" align = "center"><h2>Insert New Product:</h2></td>
	  </tr>
	  
	  <tr>
	    <th align = "right">Product Title</th>
	    <td><input type = "text" name = "product_title" size = "50" value = "<?php echo $p_title; ?>"/></td>
	  </tr>
	  
	  <tr>
	    <th align = "right">Product Category</th>
	    <td>
		   <select name = "product_cat">
		      <option>Select a Category</option>
			     <?php
						   $get_cats =  "select * from categories";
						   $run_cats = $con->query($get_cats);
						   
						   while($row_cats = mysqli_fetch_array($run_cats))
						   {
					          $cat_id = $row_cats['cat_id'];
							  $cat_title = $row_cats['cat_title'];
							  
							  $selected = ($cat_id == $cats_id) ? 'selected' : '';
							  
							  echo "<option value = $cat_id $selected>$cat_title</option>";
						   }
				 ?>
			</select> 
		</td>
	  </tr>
	  
	  <tr>
	    <th align = "right">Product Brand</th>
	    <td>
		   <select name = "product_brand">
		      <option>Select Brand</option>
			     <?php
						   $get_brands =  "select * from brands";
						   $run_brands = $con->query($get_brands);
						   
						   while($row_brands = mysqli_fetch_array($run_brands))
						   {
					          $brand_id = $row_brands['brand_id'];
							  $brand_title = $row_brands['brand_title'];
							  
							  $selected = ($brand_id == $brands_id) ? 'selected' : '';
							  
							  echo "<option value = $brand_id $selected>$brand_title</option>";
						   }
				 ?> 
			  </select>
		</td>
	  </tr>
	  
	  <tr>
	    <th align = "right">Product Price</th>
	    <td><input type = "text" name = "product_price" value = "<?php echo $p_price; ?>"/></td>
	  </tr>
	  
	  <tr>
	    <th align = "right">Product Description</th>
	    <td><textarea name = "product_description" cols = "35" rows = "10"> <?php echo $p_description; ?> </textarea></td>
	  </tr>
	  
	  <tr>
	    <th align = "right">Product Keywords</th>
	    <td><input type = "text" name = "product_keywords" size = "50" value = "<?php echo $product_keywords; ?>"/></td>
	  </tr>
	  
	  <tr>
	    <td colspan = "2" align = "center"><input type = "submit" name = "update_product" value = "Update Product"/></td>
	  </tr>
	  
   </table>
   
</form>

    <div id = "right_content">
	   <h3>Manage Content</h3>
	   
	   <div id = "navbar">
			    
				<ul id = "menu">
				    <li><a href = "searching.php">Searching</a></li>
			    	<li><a href = "insert_product.php" class = "selected">Insert New Product</a></li>
			    	<li><a href = "view_all_products.php">View all Products</a></li>
			    	<li><a href = "insert_new_category.php">Insert New Category</a></li>
			    	<li><a href = "view_all_categories.php">View all Category</a></li>
			    	<li><a href = "insert_new_brand.php">Insert New Brand</a></li>
			    	<li><a href = "view_all_brands.php">View all Brands</a></li>
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

if(isset($_POST['update_product']))
{
   $product_title = $_POST['product_title'];
   $product_cat = $_POST['product_cat'];
   $product_brand = $_POST['product_brand'];
   $product_price = $_POST['product_price'];
   $product_description = $_POST['product_description'];
   $status = 'on';
   $product_keywords = $_POST['product_keywords'];
   
   if(empty($product_title)	|| empty($product_cat) || empty($product_brand) || empty($product_price) || empty( $product_description) || 
      empty($product_keywords))// || empty($product_img1) || empty($product_img2) || empty($product_img3))
   {
      echo "<script>alert('All Fields are Required...')</script>";
	  exit();
   }
   else
   {
	  $product_title = mysqli_real_escape_string($con , $product_title);
	  $product_cat = (int) $product_cat;
	  $product_brand = (int) $product_brand;
	  $product_description = mysqli_real_escape_string($con , $product_description);
	  $product_price = (int) $product_price;
	  $product_keywords = mysqli_real_escape_string($con , $product_keywords);
	  
	  $query = "update products set cat_id = '$product_cat' , brand_id = '$product_brand' , date = NOW() , product_title = '$product_title'               , product_price = '$product_price' , product_description = '$product_description' , product_keywords = '$product_keywords' , status =               '$status' where product_id = '$edit_product'";
			   
	  $run_query = $con->query($query);
	  
	  if($run_query)
	  {
	     echo "<script>window.open('view_all_products.php?updated=A Product has been updated...!' , '_self');
		       alert('Product Update Successfully...')</script>"; 
	  }
   }	
}

}

?>
