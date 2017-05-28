<?php $__env->startSection('title', 'ViewOrders'); ?>

<?php $__env->startSection('heading', 'Manage Your Content'); ?>

<?php $__env->startSection('content'); ?>

    <table width = "800" align = "left" border = "1" bgcolor="black" style = "color:white;">
      
	    <tr>
	        <td colspan = "10" align = "center"><h2>All Orders Here!</h2></td>
	    </tr>
	  
	    <tr align = "center" style = "color:#FFFF00;">
		    <th>Order_Id:</th>
		    <th>Product_Id:</th>
		    <th>Customer_Id:</th>
		    <th>Quantity:</th>
			<th>Amount:</th>
		    <th>Order_Date:</th>
		    <th>Delete</th>
	    </tr>


		<?php foreach($order as $o): ?>
			<tr style="text-align: center">

				<td><?php echo e($o->id); ?></td>
				<td><?php echo e($o->product_id); ?></td>
				<td><?php echo e($o->customer_id); ?></td>
				<td><?php echo e($o->quantity); ?></td>
				<td><?php echo e($o->amount); ?></td>
				<td><?php echo e($o->order_date); ?></td>
				<td><div id = "delete"><a href = "<?php echo e(URL::route('adminDeleteOrder', array('id' => $o->id))); ?>">Delete</a></div></td>

			</tr>
		<?php endforeach; ?>

	</table>

<?php $__env->stopSection(); ?>

<?php $__env->startSection('navbar'); ?>
	
	<li><a href = "Admin_Search">Search</a></li>
	<li><a href = "Admin_InsertNewCity">Insert New City</a></li>
	<li><a href = "Admin_ViewAllCities">View all Cites</a></li>
	<li><a href = "Admin_InsertNewMarket">Insert New Market</a></li>
	<li><a href = "Admin_ViewAllMarkets">View all Markets</a></li>
	<li><a href = "Admin_ViewAllShops">View all Shops</a></li>
	<li><a href = "Admin_ViewShopRents">View Shop Rents</a></li>
	<li><a href = "Admin_ViewCustomers">View Customers</a></li>
	<li><a href = "Admin_ViewOrders" class = "selected">View Orders</a></li>
	<li><a href = "Admin_ViewPayments">View Payments</a></li>
	<li><a href = "Admin_ViewProfile">View Profile</a></li>
	<li><a href = "<?php echo e(URL::route('adminLogOut')); ?>">Admin Logout</a></li>

<?php $__env->stopSection(); ?>
<?php echo $__env->make('layouts.masterAdmin', array_except(get_defined_vars(), array('__data', '__path')))->render(); ?>