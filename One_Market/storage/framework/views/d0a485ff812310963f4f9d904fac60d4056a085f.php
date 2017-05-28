<?php $__env->startSection('title', 'Vendor EditProfile'); ?>

<?php $__env->startSection('img'); ?>

	<img data-wow-duration="4s" src="/One_Market/public/img/d_arrow.png" height = "165px" alt="Downward Arrow"/>

<?php $__env->stopSection(); ?>


<?php $__env->startSection('heading'); ?>

	<h2 class="wow fadeInUp" data-wow-duration="5s">To Edit Profile : Please Scroll Down</h2>

<?php $__env->stopSection(); ?>


<?php $__env->startSection('navbar'); ?>

	<div class="collapse navbar-collapse">
		<ul class="nav navbar-nav navbar-right"><!--YOUR NAVIGATION ITEMS STRAT BELOW-->
			<li><a href="#EditP"><span class="btnicon icon-user"></span>Edit Profile</a></li>
			<li class="active"><a href="/One_Market/public/Vendor_MainArea"><span class="btnicon icon-cloud-download"></span>GoBack</a></li>
		</ul>
	</div><!--.nav-collapse -->

	<?php $__env->stopSection(); ?>


	<?php $__env->startSection('content'); ?>

			<!-- ===========================
    EditProduct SECTION START
    =========================== -->
	<div id="EditP" class="container">

		<!-- EditProduct SECTION HEADING START -->
		<div class="sectionhead  row wow fadeInUp">
			<img data-wow-duration="4s" src="/One_Market/public/img/profile.jpg" height = "100px" alt="Profile Logo"/>
			<h3>Edit Profile</h3>
			<hr class="separetor">
		</div>
		<div id = "SubmitButton">

			<form action = "<?php echo e(route('updateVProfile' , array('id' => $vendor->id))); ?>" method = "POST" enctype = "multipart/form-data">

				<input type = "hidden" name ="_token" value = "<?php echo e(csrf_token()); ?>">

				<table width = "1000" align = "center" border = "1" bgcolor = "black" style = "color:white; background:black; font-size:16px; margin-bottom:70px;">

					<tr>
						<td colspan = "2" align = "center"><h2>Edit Profile :</h2></td>
					</tr>

					<tr>
						<th align = "right">Username</th>
						<td><input type = "text" name = "name" size = "90" required = "required" value = "<?php echo e($vendor->username); ?>"/></td>
					</tr>

					<?php if($errors->has('name')): ?>
						<tr>
							<th align = "right" style = "color: red;">Username Error</th>
							<td style = "color: red;"><strong><?php echo e($errors->first('name')); ?></strong></td>
						</tr>
					<?php endif; ?>

					<tr>
						<th align = "right">Passowrd</th>
						<td><input type = "text" name = "password" size = "90" required = "required" value = "<?php echo e(Crypt::decrypt($vendor->password)); ?>"/></td>
					</tr>

					<?php if($errors->has('password')): ?>
						<tr>
							<th align = "right" style = "color: red;">Password Error</th>
							<td style = "color: red;"><strong><?php echo e($errors->first('password')); ?></strong></td>
						</tr>
					<?php endif; ?>

					<tr>
						<th align = "right">Confirm Passowrd</th>
						<td><input type = "text" name = "password_confirmation" size = "90" required = "required" value = "<?php echo e(Crypt::decrypt($vendor->password)); ?>"/></td>
					</tr>

					<?php if($errors->has('password_confirmation')): ?>
						<tr>
							<th align = "right" style = "color: red;">Password Confirmation Error</th>
							<td style = "color: red;"><strong><?php echo e($errors->first('password_confirmation')); ?></strong></td>
						</tr>
					<?php endif; ?>

					<tr>
						<th align = "right">PhoneNo</th>
						<td><input type = "text" name = "phoneNo" size = "90" required = "required" value = "<?php echo e($vendor->phoneNo); ?>"/></td>
					</tr>

					<?php if($errors->has('phoneNo')): ?>
						<tr>
							<th align = "right" style = "color: red;">PhoneNo Error</th>
							<td style = "color: red;"><strong><?php echo e($errors->first('phoneNo')); ?></strong></td>
						</tr>
					<?php endif; ?>

					<tr>
						<th align = "right">Address</th>
						<td><input type = "text" name = "address" size = "90" required = "required" value = "<?php echo e($vendor->address); ?>"/></td>
					</tr>

					<?php if($errors->has('address')): ?>
						<tr>
							<th align = "right" style = "color: red;">Address Error</th>
							<td style = "color: red;"><strong><?php echo e($errors->first('address')); ?></strong></td>
						</tr>
					<?php endif; ?>

					<tr>
						<th align = "right">CreditCartNo</th>
						<td><input type = "text" name = "creditcartNo" size = "90" required = "required" value = "<?php echo e($vendor->creditcartNo); ?>"/></td>
					</tr>

					<?php if($errors->has('creditcartNo')): ?>
						<tr>
							<th align = "right" style = "color: red;">CreditCartNo Error</th>
							<td style = "color: red;"><strong><?php echo e($errors->first('creditcartNo')); ?></strong></td>
						</tr>
					<?php endif; ?>

					<tr>
						<th align = "right">Shop Name</th>
						<td><input type = "text" name = "shop_name" size = "90" required = "required" value = "<?php echo e($vendor->shop_name); ?>"/></td>
					</tr>

					<?php if($errors->has('shop_name')): ?>
						<tr>
							<th align = "right" style = "color: red;">Shop Name Error</th>
							<td style = "color: red;"><strong><?php echo e($errors->first('shop_name')); ?></strong></td>
						</tr>
					<?php endif; ?>

					<tr>
						<th align = "right">Shop in Market</th>
						<td>

							<select name = "market_id" style = "color: black;">
								<option>Select a Market</option>

								<?php foreach($market as $m): ?>
									{
									<?php foreach($city as $c): ?>
										<?php if($m->city_id == $c->id): ?>
											<option value = "<?php echo e($m->id); ?>" <?php if($m->id == $vendor->market_id): ?> <?php echo e("selected"); ?> <?php endif; ?>><?php echo e($m->name.' in '.$c->name); ?> </option>
										<?php endif; ?>
									<?php endforeach; ?>
									}
								<?php endforeach; ?>


							</select>
						</td>
					</tr>

					<?php if($errors->has('market_id')): ?>
						<tr>
							<th align = "right" style = "color: red;">Market Selection Error</th>
							<td style = "color: red;"><strong><?php echo e($errors->first('market_id')); ?></strong></td>
						</tr>
					<?php endif; ?>

					<tr>
						<th align = "right">Shop Image </th>
						<td><input type = "file" name = "shop_img"></td>
					</tr>

					<tr>
						<td colspan = "2" align = "center" height = "30"><strong><input type = "submit" name = "Update_profile" value = "Update Profile" style = "Color:White; font-size:20px; padding:8px; width:100%"/></strong></td>
					</tr>

				</table>

			</form>
		</div>

		<!--EditProduct SECTION HEADING END-->

	</div><!-- EditProduct SECTION END -->

<?php $__env->stopSection(); ?>


<?php $__env->startSection('footernavbar'); ?>

	<li><a href="/One_Market/public/Vendor_MainArea">Go Back</a></li>

<?php $__env->stopSection(); ?>






<?php echo $__env->make('layouts.Master', array_except(get_defined_vars(), array('__data', '__path')))->render(); ?>