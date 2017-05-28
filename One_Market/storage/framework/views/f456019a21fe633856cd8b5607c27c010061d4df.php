<?php $__env->startSection('title', 'InsertNewCity'); ?>

<?php $__env->startSection('heading', 'Manage Your Content'); ?>

<?php $__env->startSection('content'); ?>

    <div id = "SubmitButton">
        <form action = "<?php echo e(route('insertCity')); ?>" method = "post" enctype = "multipart/form-data">

			<input type = "hidden" name ="_token" value = "<?php echo e(csrf_token()); ?>">

            <table width = "800" align = "left" border = "1" bgcolor="white">
      
	            <tr>
	                <td colspan = "2" align = "center"><h2>Insert New City:</h2></td>
	            </tr>
	  
	            <tr>
		            <th align = "right">City Name:</th>
		            <td align = "left"><input type = "text" name = "name" required = "required"></td>
	            </tr>

                <tr>
	                <th align = "right">City Image 1</th>
	                <td><input type = "file" name = "city_img1" required = "required"/></td>
	            </tr>
	  
	            <tr>
	                <th align = "right">City Image 2</th>
	                <td><input type = "file" name = "city_img2" required = "required"/></td>
	            </tr>
	  
	            <tr>
	                <th align = "right">City Image 3</th>
	               <td><input type = "file" name = "city_img3" required = "required"/></td>
	            </tr>

                <tr>
	                <th align = "right">City Description</th>
	                <td><textarea name = "description" cols = "35" rows = "10"></textarea></td>
	            </tr>	  
	  
	            <tr>
	                <td colspan = "2" align = "center" height = "30"><strong><input type = "submit" name = "insert_city" value = "Insert City" style = "Color:White; font-size:20px; padding:8px; width:100%"/></strong></td>
	            </tr>
	  
	        </table>
        </form>
  </div>

<?php $__env->stopSection(); ?>

<?php $__env->startSection('navbar'); ?>
	
	<li><a href = "Admin_Search">Search</a></li>
	<li><a href = "Admin_InsertNewCity" class = "selected">Insert New City</a></li>
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