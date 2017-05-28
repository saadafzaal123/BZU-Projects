<?php $__env->startSection('title', 'Activity'); ?>

<?php $__env->startSection('heading', 'Manage Your Content'); ?>

<?php $__env->startSection('content'); ?>

    <table width = "800" align = "left" border = "1" bgcolor="black" style = "color:white;">
      
	    <tr>
	        <td colspan = "11" align = "center"><h2>All Shops Owners Here!</h2></td>
	    </tr>
	  
	    <tr align = "center" style = "color:#FFFF00;">
			<th>Vendor_id:</th>
		    <th>Name:</th>
		    <th>Password:</th>
		    <th>Phone#:</th>
	 	    <th>CreditCart#:</th>
		    <th>Email:</th>
		    <th>City:</th>
		    <th>Market:</th>
		    <th>Shop_Name:</th>
	 	    <th>Edit</th>
		    <th>Delete</th>
	    </tr>
	  
	</table>

<?php $__env->stopSection(); ?>

<?php $__env->startSection('navbar'); ?>
	
	<li><a href = "Admin_Search">Search</a></li>
	<li><a href = "Admin_InsertNewCity">Insert New City</a></li>
	<li><a href = "Admin_ViewAllCities">View all Cites</a></li>
	<li><a href = "Admin_InsertNewMarket">Insert New Market</a></li>
	<li><a href = "Admin_ViewAllMarkets">View all Markets</a></li>
	<li><a href = "Admin_ViewAllShops">View all Shops</a></li>
	<li><a href = "Admin_ViewShopOwners" class = "selected">View Shop Owners</a></li>
	<li><a href = "Admin_ViewShopRents">View Shop Rents</a></li>
	<li><a href = "Admin_ViewCustomers">View Customers</a></li>
	<li><a href = "Admin_ViewOrders">View Orders</a></li>
	<li><a href = "Admin_ViewPayments">View Payments</a></li>
	<li><a href = "#">Admin Logout</a></li>

<?php $__env->stopSection(); ?>
<?php echo $__env->make('layouts.masterAdmin', array_except(get_defined_vars(), array('__data', '__path')))->render(); ?>