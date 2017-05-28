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

<form action = "insert_product.php" method = "POST" enctype = "multipart/form-data">

   <table width = "700" align = "left" border = "1" bgcolor="white">
      
	  <tr>
	    <td colspan = "2" align = "center"><h2>Insert New Product:</h2></td>
	  </tr>
	  
	  <tr>
	    <th align = "right">Product Title</th>
	    <td><input type = "text" name = "product_title" size = "50"/></td>
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
							  
							  echo "<option value = $cat_id>$cat_title</option>";
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
							  
							  echo "<option value = $brand_id>$brand_title</option>";
						   }
				 ?> 
			  </select>
		</td>
	  </tr>
	  
	  <tr>
	    <th align = "right">Product Image 1</th>
	    <td><input type = "file" name = "product_img1"/></td>
	  </tr>
	  
	  <tr>
	    <th align = "right">Product Image 2</th>
	    <td><input type = "file" name = "product_img2"/></td>
	  </tr>
	  
	  <tr>
	    <th align = "right">Product Image 3</th>
	    <td><input type = "file" name = "product_img3"/></td>
	  </tr>
	  
	  <tr>
	    <th align = "right">Product Price</th>
	    <td><input type = "text" name = "product_price"/></td>
	  </tr>
	  
	  <tr>
	    <th align = "right">Product Description</th>
	    <td><textarea name = "product_description" cols = "35" rows = "10"></textarea></td>
	  </tr>
	  
	  <tr>
	    <th align = "right">Product Keywords</th>
	    <td><input type = "text" name = "product_keywords" size = "50"/></td>
	  </tr>
	  
	  <tr>
	    <td colspan = "2" align = "center"><input type = "submit" name = "insert_product" value = "Insert Product"/></td>
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

if(isset($_POST['insert_product']))
{
   $product_title = $_POST['product_title'];
   $product_cat = $_POST['product_cat'];
   $product_brand = $_POST['product_brand'];
   $product_price = $_POST['product_price'];
   $product_description = $_POST['product_description'];
   $status = 'on';
   $product_keywords = $_POST['product_keywords'];
   
   $product_img1 = $_FILES['product_img1']['name'];
   $product_img2 = $_FILES['product_img2']['name'];
   $product_img3 = $_FILES['product_img3']['name'];
   
   $temp_name1 = @$_FILES['product_img1']['tmp_name'];
   $temp_name2 = @$_FILES['product_img2']['tmp_name'];
   $temp_name3 = @$_FILES['product_img3']['tmp_name'];
   
   if(empty($product_title)	|| empty($product_cat) || empty($product_brand) || empty($product_price) || empty( $product_description) || 
      empty($product_keywords) || empty($product_img1) || empty($product_img2) || empty($product_img3))
   {
      echo "<script>alert('All Fields are Required...')</script>";
	  exit();
   }
   else
   {
      move_uploaded_file($temp_name1 , "product_images/$product_img1");
	  move_uploaded_file($temp_name2 , "product_images/$product_img2");
	  move_uploaded_file($temp_name3 , "product_images/$product_img3");
	  
	  $product_title = mysqli_real_escape_string($con , $product_title);
	  $product_cat = (int) $product_cat;
	  $product_brand = (int) $product_brand;
	  $product_description = mysqli_real_escape_string($con , $product_description);
	  $product_price = (int) $product_price;
	  $product_keywords = mysqli_real_escape_string($con , $product_keywords);
	  
	  $query = "insert into products values ('' , '$product_cat' , '$product_brand' , NOW() , '$product_title' , '$product_img1' , '$product_img2' , 
	           '$product_img3' , '$product_price' , '$product_description' , '$product_keywords' , '$status')";
			   
	  $run_query = $con->query($query);
	  
	  if($run_query)
	  {
	     echo "<script>alert('Product Insert Successfully...')</script>";
	  }  
   }	
}

}

?>