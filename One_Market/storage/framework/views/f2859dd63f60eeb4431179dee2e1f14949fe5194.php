<?php $__env->startSection('title', 'Welcome'); ?>

<?php $__env->startSection('heading', 'Manage Your Content'); ?>

<?php $__env->startSection('content'); ?>

    <div id = "img">
        <img src = "styles/wlcm.jpg" width = '800' height = '277' />
	    <img src = "styles/admin_logo.gif" width = '800' height = '276' />
    </div>
	
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
	<li><a href = "Admin_ViewOrders">View Orders</a></li>
	<li><a href = "Admin_ViewPayments">View Payments</a></li>
	<li><a href = "Admin_ViewProfile">View Profile</a></li>
	<li><a href = "<?php echo e(URL::route('adminLogOut')); ?>">Admin Logout</a></li>

<?php $__env->stopSection(); ?>
<?php echo $__env->make('layouts.masterAdmin', array_except(get_defined_vars(), array('__data', '__path')))->render(); ?>