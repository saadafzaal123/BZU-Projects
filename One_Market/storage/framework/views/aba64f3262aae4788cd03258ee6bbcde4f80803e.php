<?php $__env->startSection('title', 'Vendor EditProduct'); ?>

<?php $__env->startSection('img'); ?>

	<img data-wow-duration="4s" src="/One_Market/public/img/d_arrow.png" height = "165px" alt="Downward Arrow"/>

<?php $__env->stopSection(); ?>


<?php $__env->startSection('heading'); ?>

	<h2 class="wow fadeInUp" data-wow-duration="5s">To Edit Product : Please Scroll Down</h2>

<?php $__env->stopSection(); ?>


<?php $__env->startSection('navbar'); ?>

	<div class="collapse navbar-collapse">
		<ul class="nav navbar-nav navbar-right"><!--YOUR NAVIGATION ITEMS STRAT BELOW-->
			<li><a href="#EditP"><span class="btnicon icon-user"></span>Edit Product</a></li>
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
			<img data-wow-duration="4s" src="/One_Market/public/img/product.png" height = "90px" alt="Product Logo"/>
			<h3>Edit Product</h3>
			<hr class="separetor">
		</div>
		<div id = "SubmitButton">

			<form action = "<?php echo e(route('updateProduct' , array('id' => $p->id))); ?>" method = "POST" enctype = "multipart/form-data">

				<input type = "hidden" name ="_token" value = "<?php echo e(csrf_token()); ?>">

				<table width = "1000" align = "center" border = "1" bgcolor = "black" style = "color:white; background:black; font-size:16px; margin-bottom:70px;">

					<tr>
						<td colspan = "2" align = "center"><h2>Edit Product:</h2></td>
					</tr>

					<tr>
						<th align = "right">Product Title</th>
						<td><input type = "text" name = "name" size = "35" required = "required" value = "<?php echo e($p->name); ?>"/></td>
					</tr>

					<?php if($errors->has('name')): ?>
						<tr>
							<th align = "right" style = "color: red;">Title Error</th>
							<td style = "color: red;"><strong><?php echo e($errors->first('name')); ?></strong></td>
						</tr>
					<?php endif; ?>

					<tr>
						<th align = "right">Product Category</th>
						<td>

							<select name = "cats_id" style = "color: black;">
								<option>Select a Category</option>

								<?php foreach($c_data as $cd): ?>
									{
									<option value = "<?php echo e($cd->id); ?>" <?php if($cd->id == $cat->id): ?> <?php echo e("selected"); ?> <?php endif; ?>><?php echo e($cd->name); ?>

									</option>
									}
								<?php endforeach; ?>

							</select>
						</td>
					</tr>

					<?php if($errors->has('cats_id')): ?>
						<tr>
							<th align = "right" style = "color: red;">Category Error</th>
							<td style = "color: red;"><strong><?php echo e($errors->first('cats_id')); ?></strong></td>
						</tr>
					<?php endif; ?>

					<tr>
						<th align = "right">Product Brand</th>
						<td>
							<select name = "brands_id" style = "color: black;">
								<option>Select Brand</option>

								<?php foreach($b_data as $bd): ?>
									{
									<option value = "<?php echo e($bd->id); ?>" <?php if($bd->id == $brand->id): ?> <?php echo e("selected"); ?> <?php endif; ?>><?php echo e($bd->name); ?>

									</option>
									}
								<?php endforeach; ?>

							</select>
						</td>
					</tr>

					<?php if($errors->has('brands_id')): ?>
						<tr>
							<th align = "right" style = "color: red;">Brand Error</th>
							<td style = "color: red;"><strong><?php echo e($errors->first('brands_id')); ?></strong></td>
						</tr>
					<?php endif; ?>

					<tr>
						<th align = "right">Product Image 1</th>
						<td><input type = "file" name = "product_img1" ></td>
					</tr>

					<?php if($errors->has('product_img1')): ?>
						<tr>
							<th align = "right" style = "color: red;">Image1 Error</th>
							<td style = "color: red;"><strong><?php echo e($errors->first('product_img1')); ?></strong></td>
						</tr>
					<?php endif; ?>

					<tr>
						<th align = "right">Product Image 2</th>
						<td><input type = "file" name = "product_img2" ></td>
					</tr>

					<?php if($errors->has('product_img2')): ?>
						<tr>
							<th align = "right" style = "color: red;">Image2 Error</th>
							<td style = "color: red;"><strong><?php echo e($errors->first('product_img2')); ?></strong></td>
						</tr>
					<?php endif; ?>

					<tr>
						<th align = "right">Product Image 3</th>
						<td><input type = "file" name = "product_img3" ></td>
					</tr>

					<?php if($errors->has('product_img3')): ?>
						<tr>
							<th align = "right" style = "color: red;">Image3 Error</th>
							<td style = "color: red;"><strong><?php echo e($errors->first('product_img3')); ?></strong></td>
						</tr>
					<?php endif; ?>

					<tr>
						<th align = "right">Product Price</th>
						<td><input type = "text" name = "price" required = "required" value ="<?php echo e($p->price); ?>"/></td>
					</tr>

					<?php if($errors->has('price')): ?>
						<tr>
							<th align = "right" style = "color: red;">Price Error</th>
							<td style = "color: red;"><strong><?php echo e($errors->first('price')); ?></strong></td>
						</tr>
					<?php endif; ?>

					<tr>
						<th align = "right">Product Description</th>
						<td><textarea name = "description" cols = "85" rows = "10" ><?php echo e($p->description); ?></textarea></td>
					</tr>

					<tr>
						<th align = "right">Product Keywords</th>
						<td><input type = "text" name = "keywords" size = "30" required = "required" value ="<?php echo e($p->keywords); ?>"/></td>
					</tr>

					<?php if($errors->has('keywords')): ?>
						<tr>
							<th align = "right" style = "color: red;">Keywords Error</th>
							<td style = "color: red;"><strong><?php echo e($errors->first('keywords')); ?></strong></td>
						</tr>
					<?php endif; ?>

					<tr>
						<td colspan = "2" align = "center" height = "35"><strong><input type = "submit" name = "Update_product" value = "Update Product" style = "Color:White; font-size:20px; padding:8px; width:100%"/></strong></td>
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