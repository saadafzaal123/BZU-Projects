<?php $__env->startSection('title', 'ViewAllCities'); ?>

<?php $__env->startSection('heading', 'Manage Your Content'); ?>

<?php $__env->startSection('content'); ?>

    <table width = "800" align = "left" border = "1" bgcolor="black" style = "color:white; font-size: 18px;">
      
	    <tr>
	        <td colspan = "6" align = "center"><h2>All Cities Here!</h2></td>
	    </tr>
	  
	    <tr align = "center" style = "color:#FFFF00;">
		    <th style = "padding: 15px;">City_id:</th>
	 	    <th>City_Name:</th>
		    <th>City_Discription:</th>
		    <th>Edit</th>
		    <th>Delete</th>
	    </tr>

		<?php foreach($city as $c): ?>
			<tr style="text-align: center">

				<td><?php echo e($c->id); ?></td>
				<td><?php echo e($c->name); ?></td>
				<td><?php echo e($c->description); ?></td>

				<td><div id = "edit"><a href = "<?php echo e(URL::route('editCity', array('id' => $c->id))); ?>">Edit</a></div></td>
				<td><div id = "delete"><a href = "<?php echo e(URL::route('deleteCity', array('id' => $c->id))); ?>">Delete</a></div></td>

			</tr>
		<?php endforeach; ?>
	  
	</table>

<?php $__env->stopSection(); ?>

<?php $__env->startSection('navbar'); ?>
	
	<li><a href = "Admin_Search">Search</a></li>
	<li><a href = "Admin_InsertNewCity">Insert New City</a></li>
	<li><a href = "Admin_ViewAllCities" class = "selected">View all Cites</a></li>
	<li><a href = "Admin_InsertNewMarket">Insert New Market</a></li>
	<li><a href = "Admin_ViewAllMarkets">View all Markets</a></li>
	<li><a href = "Admin_ViewAllShops">View all Shops</a></li>
	<li><a href = "Admin_ViewShopRents">View Shop Rents</a></li>
	<li><a href = "Admin_ViewCustomers">View Customers</a></li>
	<li><a href = "Admin_ViewOrders">View Orders</a></li>
	<li><a href = "Admin_ViewPayments">View Payments</a></li>
	<li><a href = "Admin_ViewProfile">View Profile</a></li>
	<li><a href = "<?php echo e(URL::route('adminLogOut')); ?>">Admin Logout</a></li>

<?php $__env->stopSection(); ?>
<?php echo $__env->make('layouts.masterAdmin', array_except(get_defined_vars(), array('__data', '__path')))->render(); ?>