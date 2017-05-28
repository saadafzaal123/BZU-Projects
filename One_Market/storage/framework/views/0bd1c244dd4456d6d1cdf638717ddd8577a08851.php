<?php $__env->startSection('title', 'EditCity'); ?>

<?php $__env->startSection('heading', 'Manage Your Content'); ?>

<?php $__env->startSection('content'); ?>

    <div id = "SubmitButton">
        
		<form action = "<?php echo e(route('updateCity' , array('id' => $p->id))); ?>" method = "POST" enctype = "multipart/form-data">

			<input type = "hidden" name ="_token" value = "<?php echo e(csrf_token()); ?>">

            <table width = "800" align = "left" border = "1" bgcolor="white">
      
	            <tr>
	                <td colspan = "2" align = "center"><h2>Edit City:</h2></td>
	            </tr>
	  
	            <tr>
	                <th align = "right">City Name</th>
	                <td><input type = "text" name = "name" value = "<?php echo e($p->name); ?>" required = "required" size = "50"/></td>
	            </tr>
	  
	            <tr>
	                <th align = "right">City Discription</th>
		            <td><textarea name = "description" cols = "35" rows = "10" required = "required" ><?php echo e($p->description); ?></textarea></td>
	            </tr>
	  
	            <tr>
		            <td colspan = "2" align = "center" height = "30"><strong><input type = "submit" name = "update_city" value = "Update City" style = "Color:White; font-size:20px; padding:8px; width:100%"/></strong></td>
	            </tr>
	  
            </table>
   
        </form>
		
    </div>

<?php $__env->stopSection(); ?>

<?php $__env->startSection('navbar'); ?>
	
	<li><a href = "/One_Market/public/Admin_Search">Search</a></li>
	<li><a href = "/One_Market/public/Admin_InsertNewCity">Insert New City</a></li>
	<li><a href = "/One_Market/public/Admin_ViewAllCities">View all Cites</a></li>
	<li><a href = "/One_Market/public/Admin_InsertNewMarket">Insert New Market</a></li>
	<li><a href = "/One_Market/public/Admin_ViewAllMarkets">View all Markets</a></li>
	<li><a href = "/One_Market/public/Admin_ViewAllShops">View all Shops</a></li>
	<li><a href = "/One_Market/public/Admin_ViewShopRents">View Shop Rents</a></li>
	<li><a href = "/One_Market/public/Admin_ViewCustomers">View Customers</a></li>
	<li><a href = "/One_Market/public/Admin_ViewOrders">View Orders</a></li>
	<li><a href = "/One_Market/public/Admin_ViewPayments">View Payments</a></li>
	<li><a href = "/One_Market/public/Admin_ViewProfile">View Profile</a></li>
	<li><a href = "<?php echo e(URL::route('adminLogOut')); ?>">Admin Logout</a></li>

<?php $__env->stopSection(); ?>
<?php echo $__env->make('layouts.masterAdmin', array_except(get_defined_vars(), array('__data', '__path')))->render(); ?>