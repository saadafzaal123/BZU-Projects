<?php $__env->startSection('title', 'EditShop'); ?>

<?php $__env->startSection('heading', 'Manage Your Content'); ?>

<?php $__env->startSection('content'); ?>

    <div id = "SubmitButton">

	    <form action = "<?php echo e(route('updateShop' , array('id' => $s->id))); ?>" method = "POST" enctype = "multipart/form-data">

			<input type = "hidden" name ="_token" value = "<?php echo e(csrf_token()); ?>">

            <table width = "800" align = "left" border = "1" bgcolor="white">
      
	            <tr>
	                <td colspan = "2" align = "center"><h2>Edit Shop :</h2></td>
	            </tr>
	  
	            <tr>
	                <th align = "right">Owner Name</th>
	                <td><input type = "text" name = "username" value = "<?php echo e($s->username); ?>" required = "required" size = "50"/></td>
	            </tr>
	  
	            <tr>
	                <th align = "right">Owner Password</th>
	                <td><input type = "text" name = "password" value = "<?php echo e(Crypt::decrypt($s->password)); ?>" required = "required" size = "50"/></td>
	            </tr>
	  
	            <tr>
	                <th align = "right">Owner Phone#</th>
	                <td><input type = "text" name = "phone#" value = "<?php echo e($s->phoneNo); ?>" required = "required" size = "50"/></td>
	            </tr>
	  
	            <tr>
	                <th align = "right">Owner CreditCart#</th>
	                <td><input type = "text" name = "creditcart#" value = "<?php echo e($s->creditcartNo); ?>" required = "required" size = "50"/></td>
	            </tr>
	  
	            <tr>
	                <th align = "right">Owner Email</th>
	                <td><input type = "email" name = "email" value = "<?php echo e($s->email); ?>" required = "required" size = "50"/></td>
	            </tr>

				<tr>
					<th align = "right">Owner Home Address</th>
					<td><input type = "text" name = "address" value = "<?php echo e($s->address); ?>" required = "required" size = "50"/></td>
				</tr>
	  
	            <tr>
	                <th align = "right">Shop Name</th>
	                <td><input type = "text" name = "shop_name" value = "<?php echo e($s->shop_name); ?>" required = "required" size = "50"/></td>
	            </tr>
	  
	            <tr>
	                <th align = "right">Shop in Market</th>
	                <td>
		                <select name = "market_id" style = "padding:5px; font-size:15px;">
		                    <option>Select a Market</option>

							<?php foreach($market as $mk): ?>
							{
								<?php foreach($city as $c): ?>
								{
									<?php if($mk->city_id == $c->id): ?>
								       <option value = "<?php echo e($mk->id); ?>" <?php if($mk->id == $m->id): ?> <?php echo e("selected"); ?> <?php endif; ?>><?php echo e($mk->name." in ".$c->name); ?>

								       </option>
									<?php endif; ?>
								}
								<?php endforeach; ?>
							}
							<?php endforeach; ?>

						</select>
		            </td>
	            </tr>
	  
	            <tr>
		            <td colspan = "2" align = "center" height = "30"><strong><input type = "submit" name = "update_shop" value = "Update Shop" style = "Color:White; font-size:20px; padding:8px; width:100%"/></strong></td>
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