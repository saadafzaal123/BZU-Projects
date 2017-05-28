<?php $__env->startSection('title', 'ViewAllShops'); ?>

<?php $__env->startSection('heading', 'Manage Your Content'); ?>

<?php $__env->startSection('content'); ?>

    <table width = "800" align = "left" border = "1" bgcolor="black" style = "color:white; font-size: 16px;">
      
	    <tr>
	        <td colspan = "11" align = "center"><h2>All Shops Here!</h2></td>
	    </tr>
	  
	    <tr align = "center" style = "color:#FFFF00;">
			<th>id:</th>
		    <th>Name:</th>
		    <th>Password:</th>
		    <th>Phone#:</th>
	 	    <th>CreditCart#:</th>
		    <th>Email:</th>
		    <th>Market:</th>
		    <th>Shop_Name:</th>
	 	    <th>Edit</th>
		    <th>Delete</th>
	    </tr>

		<?php foreach($shop as $s): ?>
			<tr style="text-align: center">

				<td><?php echo e($s->id); ?></td>
				<td><?php echo e($s->username); ?></td>
				<td><?php echo e(Crypt::decrypt($s->password)); ?></td>
				<td><?php echo e($s->phoneNo); ?></td>
				<td><?php echo e($s->creditcartNo); ?></td>
				<td><?php echo e($s->email); ?></td>

				<td>
					<?php foreach($market as $m): ?>
						<?php if($s->market_id == $m->id): ?>
							<?php foreach($city as $c): ?>
								<?php if($m->city_id == $c->id): ?>
									<?php echo e($m->name.' in '.$c->name); ?>

								<?php endif; ?>
							<?php endforeach; ?>
						<?php endif; ?>
					<?php endforeach; ?>
				</td>

				<td><?php echo e($s->shop_name); ?></td>
				<td><div id = "edit"><a href = "<?php echo e(URL::route('editShop', array('id' => $s->id , 'm_id' => $s->market_id))); ?>">Edit</a></div></td>
				<td><div id = "delete"><a href = "<?php echo e(URL::route('deleteShop', array('id' => $s->id))); ?>">Delete</a></div></td>

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
	<li><a href = "Admin_ViewAllShops" class = "selected">View all Shops</a></li>
	<li><a href = "Admin_ViewShopRents">View Shop Rents</a></li>
	<li><a href = "Admin_ViewCustomers">View Customers</a></li>
	<li><a href = "Admin_ViewOrders">View Orders</a></li>
	<li><a href = "Admin_ViewPayments">View Payments</a></li>
	<li><a href = "Admin_ViewProfile">View Profile</a></li>
	<li><a href = "<?php echo e(URL::route('adminLogOut')); ?>">Admin Logout</a></li>

<?php $__env->stopSection(); ?>
<?php echo $__env->make('layouts.masterAdmin', array_except(get_defined_vars(), array('__data', '__path')))->render(); ?>