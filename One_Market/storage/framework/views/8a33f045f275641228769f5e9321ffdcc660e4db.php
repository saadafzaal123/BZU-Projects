<?php $__env->startSection('title', 'ViewAllMarkets'); ?>

<?php $__env->startSection('heading', 'Manage Your Content'); ?>

<?php $__env->startSection('content'); ?>

    <table width = "800" align = "left" border = "1" bgcolor="black" style = "color:white; font-size: 18px;">
      
	    <tr>
	        <td colspan = "10" align = "center"><h2>All Markets Here!</h2></td>
	    </tr>
	  
	    <tr align = "center" style = "color:#FFFF00;">
		    <th style = "padding: 15px;">Market_id:</th>
		    <th>Market_Name:</th>
		    <th>Market_City:</th>
		    <th>Market_Area:</th>
		    <th>Market_Discription:</th>
		    <th>Edit</th>
		    <th>Delete</th>
	    </tr>

		<?php foreach($market as $m): ?>
			<tr style="text-align: center">

				<td><?php echo e($m->id); ?></td>
				<td><?php echo e($m->name); ?></td>
				<td>
					<?php foreach($city as $c): ?>
						<?php if($m->city_id == $c->id): ?>
							<?php echo e($c->name); ?>

						<?php endif; ?>
                    <?php endforeach; ?>
				</td>

				<td><?php echo e($m->area); ?></td>
				<td><?php echo e($m->description); ?></td>

				<td><div id = "edit"><a href = "<?php echo e(URL::route('editMarket', array('id' => $m->id , 'c_id' => $m->city_id))); ?>">Edit</a></div></td>
				<td><div id = "delete"><a href = "<?php echo e(URL::route('deleteMarket', array('id' => $m->id))); ?>">Delete</a></div></td>

			</tr>
		<?php endforeach; ?>
	  
	</table>

<?php $__env->stopSection(); ?>

<?php $__env->startSection('navbar'); ?>
	
	<li><a href = "Admin_Search">Search</a></li>
	<li><a href = "Admin_InsertNewCity">Insert New City</a></li>
	<li><a href = "Admin_ViewAllCities">View all Cites</a></li>
	<li><a href = "Admin_InsertNewMarket">Insert New Market</a></li>
	<li><a href = "Admin_ViewAllMarkets" class = "selected">View all Markets</a></li>
	<li><a href = "Admin_ViewAllShops">View all Shops</a></li>
	<li><a href = "Admin_ViewShopRents">View Shop Rents</a></li>
	<li><a href = "Admin_ViewCustomers">View Customers</a></li>
	<li><a href = "Admin_ViewOrders">View Orders</a></li>
	<li><a href = "Admin_ViewPayments">View Payments</a></li>
	<li><a href = "Admin_ViewProfile">View Profile</a></li>
	<li><a href = "<?php echo e(URL::route('adminLogOut')); ?>">Admin Logout</a></li>

<?php $__env->stopSection(); ?>
<?php echo $__env->make('layouts.masterAdmin', array_except(get_defined_vars(), array('__data', '__path')))->render(); ?>