<?php

include('include/db.php');
include('include/login_file.php');

if(!Loggedin())
{
   header('Location:index.php');
}

else
{

if(isset($_GET['delete_product']))
{
   $delete_product = $_GET['delete_product'];

   $query = "delete from `products` where `product_id` = '$delete_product'";
   $query_run = $con->query($query);

   if($query_run)
   {
	  echo "<script>window.open('view_all_products.php?deleted=A product has been deleted...!' , '_self');
	        alert('A product has been deleted...!')</script>";
   }
}


if(isset($_GET['delete_category']))
{
   $delete_category = $_GET['delete_category'];

   $query = "delete from `categories` where `cat_id` = '$delete_category'";
   $query_run = $con->query($query);

   if($query_run)
   {
	  echo "<script>window.open('view_all_categories.php?deleted=A category has been deleted...!' , '_self');
	        alert('A category has been deleted...!')</script>";
   }
}


if(isset($_GET['delete_brand']))
{
   $delete_brand = $_GET['delete_brand'];

   $query = "delete from `brands` where `brand_id` = '$delete_brand'";
   $query_run = $con->query($query);

   if($query_run)
   {
	  echo "<script>window.open('view_all_brands.php?deleted=A brand has been deleted...!' , '_self');
	        alert('A brand has been deleted...!')</script>";
   }
}

}

?>