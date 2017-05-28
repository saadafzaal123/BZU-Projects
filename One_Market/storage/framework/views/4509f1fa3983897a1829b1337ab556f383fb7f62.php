<?php $__env->startSection('title', 'Search Market'); ?>

<?php $__env->startSection('heading', 'Manage Your Content'); ?>

<?php $__env->startSection('content'); ?>

    <div id = "searching"> 
	    <form action = "<?php echo e(route('searchAdmin')); ?>" method = "POST">

			<input type = "hidden" name ="_token" value = "<?php echo e(csrf_token()); ?>">

	        <strong><select id = "search_type" name = "search_type">
	            <option value = ""> Select Search Type</option>
	            <option value = "C">Search a City</option>
	            <option value = "M">Search a Market</option>
	            <option value = "S">Search a Shop</option>
	            <option value = "O">Search a Owner</option>
	            <option value = "Cu">Search a Customer</option>
	            <option value = "O">Search a Order</option>
	            <option value = "P">Search a Payment</option>
	        </select></strong>
	 
	        <input type = "text" id = "search" name = "search" placeholder = "Search" />
	 
	        <!--<button>Search</button>-->

			<input type="date"  name = "datetime"/>

	        <strong><input type = "submit" value = "Click to Search"></strong>

	    </form>
	 
	    <div id = "table" style = "margin-top:10px;">

			<table width = "800" align = "left" border = "1" bgcolor="black" style = "color:white; font-size: 18px;">

				<tr>
					<td colspan = "7" align = "center"><h2>Search Markets Here!</h2></td>
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

	    </div>
	
	</div>

<?php $__env->stopSection(); ?>	

<?php $__env->startSection('navbar'); ?>
	
	<li><a href = "Admin_Search" class = "selected">Search</a></li>
	<li><a href = "Admin_InsertNewCity">Insert New City</a></li>
	<li><a href = "Admin_ViewAllCities">View all Cites</a></li>
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