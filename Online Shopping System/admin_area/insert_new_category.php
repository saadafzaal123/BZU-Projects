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

  <form action = "insert_new_category.php" method = "POST">
   <table width = "700" align = "left" border = "1" bgcolor="white">
      
	  <tr>
	    <td colspan = "2" align = "center"><h2>Insert New Category:</h2></td>
	  </tr>
	  
	  <tr>
		<th align = "right">Enter Category Name:</th>
		<td align = "left"><input type = "text" name = "category"></td>
	  </tr> 
	  
	  <tr>
	    <td colspan = "2" align = "center" height = "30"><input type = "submit" name = "insert_category" value = "Insert Category" style = "margin-top:6px"/></td>
	  </tr>
	  
	  </table>
  </form>
    <div id = "right_content">
	   <h3>Manage Content</h3>
	   
	   <div id = "navbar">
			    
				<ul id = "menu">
				     <li><a href = "searching.php">Searching</a></li>
			    	<li><a href = "insert_product.php">Insert New Product</a></li>
			    	<li><a href = "view_all_products.php">View all Products</a></li>
			    	<li><a href = "insert_new_category.php" class = "selected">Insert New Category</a></li>
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

if(isset($_POST['insert_category']))
{
   $category = $_POST['category'];
   
   if(!empty($category))
   {
      $category = mysqli_real_escape_string($con , $category);
   
      $query = "insert into categories values ('' , '$category')";
			   
	  $run_query = $con->query($query);
	  
	  if($run_query)
	  {
	     echo "<script>alert('Category Insert Successfully...')</script>";
	  }
   }
   else
   {
      echo "<script>alert('Please Insert Category!...')</script>";
   }  
}

}

?>

