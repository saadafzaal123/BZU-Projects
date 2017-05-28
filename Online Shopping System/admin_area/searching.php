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

<script>
function search_content(the_id , the_file)
{
	if(window.XMLHttpRequest)
	{
		xmlhttp = new XMLHttpRequest();		
	}
	else
	{
		xmlhttp = new ActiveXObject('Microsoft.XMLHTTP');
	}
	
	xmlhttp.onreadystatechange = function()
	{
		if(xmlhttp.readyState == 4 && xmlhttp.status == 200)
		{
			document.getElementById(the_id).innerHTML = xmlhttp.responseText;
		}
	}
	
	parameters = 'search_type=' + document.getElementById('search_type').value + '&search=' + document.getElementById('search').value ;
	
	xmlhttp.open('POST' , the_file , true);
	xmlhttp.setRequestHeader('Content-type' , 'application/x-www-form-urlencoded');
	xmlhttp.send(parameters);
}
</script>

</head>

<body bgcolor="#e3e3e3">

<div id = "container">

<div id = "mian_heading">
<img src = "styles/admin.jpg" style = "float:left" width = '180' height = '100' />
<img src = "styles/manage1.jpg" style = "float:right" width = '180' height = '100' />
<h1>Manage Your Content</h1>
</div>

     <div id = "searching"> 
	 <form action = "" method = "POST">
	 <select id = "search_type">
	 <option> Select Search Type</option>
	 <option value = "P">Search a Product</option>
	 <option value = "C">Search a Category</option>
	 <option value = "B">Search a Brand</option>
	 <option value = "Cu">Search a Customer</option>
	 <option value = "O">Search a Order</option>
	 <option value = "Pay">Search a Payment</option>
	 </select>
	 
	 <input type = "text" id = "search" placeholder = "Search"/>
	 
	<!-- <button onclick = "search_content('table' , 'admin_search.php');">Search</button> -->
	 <input type = "button" value = "Search" onclick = "search_content('table' , 'admin_search.php');">
	 
	 
	 </form>
	 
	 <div id = "table" style = "margin-top:1px;">
	 </div>
	
	 </div>
	 			   
    <div id = "right_content">
	   <h3>Manage Content</h3>
	   
	   <div id = "navbar">
			    
				<ul id = "menu">
				    <li><a href = "searching.php" class = "selected">Searching</a></li>
			    	<li><a href = "insert_product.php">Insert New Product</a></li>
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
}
?>



