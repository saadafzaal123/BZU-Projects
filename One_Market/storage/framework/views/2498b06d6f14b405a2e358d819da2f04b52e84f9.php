<?php $__env->startSection('title', 'Customer MainArea'); ?>

<?php $__env->startSection('space'); ?>

	<div style = "margin-top:50px;"></div>

<?php $__env->stopSection(); ?>

<?php $__env->startSection('img'); ?>

    <img data-wow-duration="4s" src="img/d_arrow.png" height = "165px" alt="Downward Arrow" />
	
<?php $__env->stopSection(); ?>


<?php $__env->startSection('heading'); ?>

<h2 class="wow fadeInUp" data-wow-duration="5s">To Customer Actitvity : Please Scroll Down</h2>

<?php $__env->stopSection(); ?>


<?php $__env->startSection('navbar'); ?>

    <div class="collapse navbar-collapse">
        <ul class="nav navbar-nav navbar-right"><!--YOUR NAVIGATION ITEMS STRAT BELOW-->
            <li><a href="index"><span class="btnicon icon-user"></span>Home</a></li>
			<li><a href="#ViewAO"><span class="btnicon icon-user"></span>View Orders</a></li>
			<li><a href="#ViewPr"><span class="btnicon icon-user"></span>View Profile</a></li>
			<li class="active"><a href="<?php echo e(URL::route('CustomerLogOut')); ?>"><span class="btnicon icon-cloud-download"></span>LogOut</a></li>
		</ul>
	</div>

<?php $__env->stopSection(); ?>


<?php $__env->startSection('content'); ?>


		<!-- ===========================
    CustomerImage SECTION START
    =========================== -->
	<div id="services" class="container">

		<!-- CustomerImage SECTION HEADING START -->
		<div class="sectionhead  row wow fadeInUp">
			<img data-wow-duration="4s" src="customer_images/<?php echo e($customer->image); ?>" height = "350" widht = "350" alt="<?php echo e($customer->username); ?>"/>
			<h2><?php echo e($customer->username); ?></h2>
			<hr class="separetor">

		</div><!--CustomerImage SECTION HEADING END-->

	</div><!-- CustomerImage SECTION END -->


	<hr style = "margin-top:50px;">


    <!-- ===========================
    ViewAllOrders SECTION START
    =========================== -->
    <div id="ViewAO" class="container">
       
        <!-- ViewAllOrders SECTION HEADING START -->
        <div class="sectionhead  row wow fadeInUp">
             <img data-wow-duration="4s" src="img/order.png" height = "70px" alt="Order Logo"/>   
            <h3>View All Orders</h3>
            <hr class="separetor">

			<div id = "HD"><button class = "displayO">Display</button></div>
			
        </div><!--ViewAllOrders SECTION HEADING END-->
         
		<div id = "th">
		    <table class = "tableO" width = "1000" align = "center" border = "1" bgcolor="black" style = "color:white; background:black; font-size:16px; margin-bottom:70px;">
      
	            <tr>
	                <td colspan = "7" align = "center"><h2>All Orders Here!</h2></td>
	            </tr>
	  
	            <tr align = "center" style = "color:#FFFF00;">
		            <th style = "padding:20px;">Product_Name :</th>
		            <th>Customer_Name :</th>
		            <th>Quantity :</th>
					<th>Amount :</th>
		            <th>Order_Date :</th>
	            </tr>


				<?php foreach($order as $o): ?>
					<?php foreach($product as $p): ?>
						<?php if($o->customer_id == $customer->id): ?>
							<?php if($o->product_id == $p->id): ?>

							<tr style="text-align: center">

								<td style = "padding:20px;"><?php echo e($p->name); ?></td>
								<td><?php echo e($customer->username); ?></td>
								<td><?php echo e($o->quantity); ?></td>
								<td><?php echo e($o->amount); ?></td>
								<td><?php echo e($o->order_date); ?></td>

							</tr>

							<?php endif; ?>
						<?php endif; ?>
					<?php endforeach; ?>
				<?php endforeach; ?>
	  
	        </table>
	    </div>
		 
    </div><!-- ViewAllOrders SECTION END -->


	<hr style = "margin-top:50px;">

	<!-- ===========================
    ViewProfile SECTION START
    =========================== -->
	<div id="ViewPr" class="container">

		<!-- ViewProfile SECTION HEADING START -->
		<div class="sectionhead  row wow fadeInUp">
			<img data-wow-duration="4s" src="img/profile.jpg" height = "100px" alt="Profile Logo"/>
			<h3>My Profile</h3>
			<hr class="separetor">

			<div id = "HD"><button class = "displayPr">Display</button></div>

		</div><!--ViewProfile SECTION HEADING END-->

		<div id = "th">
			<table class = "tablePr" width = "1000" align = "center" border = "1" bgcolor="black" style = "color:white; background:black; font-size:16px; margin-bottom:70px;">

				<tr>
					<td colspan = "7" align = "center"><h2>My Profile Here!</h2></td>
				</tr>

				<tr align = "center" style = "color:#FFFF00;">
					<th style = "padding:20px;">Username :</th>
					<th>Password :</th>
					<th>Email :</th>
					<th>Update :</th>
					<th>Delete :</th>
				</tr>

					<tr style="text-align: center">
						<td><?php echo e($customer->username); ?></td>
						<td><?php echo e(Crypt::decrypt($customer->password)); ?></td>
						<td><?php echo e($customer->email); ?></td>

						<td>
							<div id = "editPro">
								<a href="<?php echo e(URL::route('editCProfile', array('id' => $customer->id))); ?>">
									<button type="submit">
										Update
									</button>
								</a>
							</div>
						</td>

						<td>
							<div id = "deletePro">
								<a href="<?php echo e(URL::route('deleteCustomer', array('id' => $customer->id))); ?>">
									<button type="submit">
										Delete
									</button>
								</a>
							</div>
						</td>

					</tr>

			</table>
		</div>

	</div><!-- ViewProfile SECTION END -->

<?php $__env->stopSection(); ?>


<?php $__env->startSection('footernavbar'); ?>

    <li><a href="index">Home</a></li>

<?php $__env->stopSection(); ?>

<?php echo $__env->make('layouts.Master', array_except(get_defined_vars(), array('__data', '__path')))->render(); ?>