<?php $__env->startSection('title', 'Search Customer'); ?>

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
	            <option value = "R">Search a Shop Rents</option>
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

			<table width = "800" align = "left" border = "1" bgcolor="black" style = "color:white;">

				<tr>
					<td colspan = "10" align = "center"><h2>Search Customers Here!</h2></td>
				</tr>

				<tr align = "center" style = "color:#FFFF00;">
					<th>Id:</th>
					<th>Name:</th>
					<th>Password:</th>
					<th>Email:</th>
					<th>CreditCart#:</th>
					<th>Phone#:</th>
					<th>Address:</th>
					<th>Delete</th>
				</tr>

				<?php foreach($customer as $c): ?>
					<tr style="text-align: center">

						<td><?php echo e($c->id); ?></td>
						<td><?php echo e($c->username); ?></td>
						<td><?php echo e(Crypt::decrypt($c->password)); ?></td>
						<td><?php echo e($c->email); ?></td>
						<td><?php echo e($c->creditcartNo); ?></td>
						<td><?php echo e($c->phoneNo); ?></td>
						<td><?php echo e($c->home_address); ?></td>
						<td><div id = "delete"><a href = "<?php echo e(URL::route('adminDeleteCustomer', array('id' => $c->id))); ?>">Delete</a></div></td>

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