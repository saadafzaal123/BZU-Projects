<?php $__env->startSection('title', 'ViewShopRents'); ?>

<?php $__env->startSection('heading', 'Manage Your Content'); ?>

<?php $__env->startSection('content'); ?>

   <table width = "800" align = "left" border = "1" bgcolor="black" style = "color:white; font-size: 18px">
      
	    <tr>
	        <td colspan = "10" align = "center"><h2>All Shops Rents Here!</h2></td>
	    </tr>
	  
	    <tr align = "center" style = "color:#FFFF00;">
		    <th style = "padding: 15px;">Id:</th>
		    <th>Vendor Name:</th>
			<th>Shop Name:</th>
		    <th>Shop_Rent:</th>
		    <th>Paid_Date:</th>
		    <th>IsPaid:</th>
		    <th>Delete</th>
	    </tr>

	   <?php foreach($rent as $r): ?>
		   <tr style="text-align: center">

			   <td><?php echo e($r->id); ?></td>

			   <td>
			       <?php foreach($shop as $s): ?>
				       <?php if($s->id == $r->Vendor_Name): ?>
					       <?php echo e($s->username); ?>

				       <?php endif; ?>
			       <?php endforeach; ?>
               </td>

			   <td>
			       <?php foreach($shop as $s): ?>
				       <?php if($s->id == $r->Shop_Name): ?>
					       <?php echo e($s->shop_name); ?>

				       <?php endif; ?>
			       <?php endforeach; ?>
               </td>

			   <td><?php echo e($r->Shop_Rent); ?></td>
			   <td><?php echo e($r->Paid_Date); ?></td>
			   <td><?php echo e($r->IsPaid); ?></td>

			   <td><div id = "delete"><a href = "<?php echo e(URL::route('deleteRent', array('id' => $r->id))); ?>">Delete</a></div></td>

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
	<li><a href = "Admin_ViewShopRents" class = "selected">View Shop Rents</a></li>
	<li><a href = "Admin_ViewCustomers">View Customers</a></li>
	<li><a href = "Admin_ViewOrders">View Orders</a></li>
	<li><a href = "Admin_ViewPayments">View Payments</a></li>
	<li><a href = "Admin_ViewProfile">View Profile</a></li>
	<li><a href = "<?php echo e(URL::route('adminLogOut')); ?>">Admin Logout</a></li>


<?php $__env->stopSection(); ?>
<?php echo $__env->make('layouts.masterAdmin', array_except(get_defined_vars(), array('__data', '__path')))->render(); ?>