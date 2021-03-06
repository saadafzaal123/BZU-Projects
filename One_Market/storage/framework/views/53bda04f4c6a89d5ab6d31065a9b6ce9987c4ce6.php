<?php $__env->startSection('title', 'Vendor Login'); ?>

<?php $__env->startSection('img'); ?>

    <img data-wow-duration="4s" src="img/d_arrow.png" height = "165px" alt="Downward Arrow"/>  
	
<?php $__env->stopSection(); ?>

<?php $__env->startSection('heading'); ?>

<h2 class="wow fadeInUp" data-wow-duration="5s">To Login : Please Scroll Down</h2>  

<?php $__env->stopSection(); ?>

<?php $__env->startSection('navbar'); ?>

    <div class="collapse navbar-collapse">
        <ul class="nav navbar-nav navbar-right"><!--YOUR NAVIGATION ITEMS STRAT BELOW-->
            <li><a href="index"><span class="btnicon icon-user"></span>Home</a></li>
		    <li><a href="#about"><span class="btnicon icon-user"></span>About Vendor Admin</a></li>
		    <li class="active"><a href="#portfolio"><span class="btnicon icon-cloud-download"></span>Vendor Log In</a></li>
        </ul>        
    </div><!--.nav-collapse -->

<?php $__env->stopSection(); ?>


<?php $__env->startSection('content'); ?>

    <!-- ===========================
    ABOUT SECTION START
    =========================== -->
     
	 <div id="about" class="container">
        
        <!-- LEFT PART OF THE ABOUT SECTION -->
         <div class="col-md-6">
            <div class="row">
             <h2 class="wow fadeInDown" data-wow-duration="2s">About Vendor Admin</h2>
              <h4 class="wow fadeInDown" data-wow-duration="2s" style = "margin-top:-15px;">(Shop Owner)</h4>
             <h4 class="wow fadeInUp" data-wow-duration="3s">A vendor admin is basically a Shop Owner who deal with Customers! sell products and also Manage his Shop!</h4>
             
             <p class="wow fadeInDown" data-wow-duration="3s" style = "color:gray;">We provide facilities those who interested to take shop on rent in particular markets in particular city. Where you deal with your customers sell products also manage your shop and earn handsome money through online. You can put any product in your shop which you want to sale.</p>
             <p class="wow fadeInDown" data-wow-duration="3s" style = "color:gray;">So we provide platform to take shop on rent on our website in particular markets where you want to open your shop.We charges 500$ monthly to you.You can continue your activity giving require charges monthly.We does not take any commision in your product which you sale.This is very good chance to open your own shop so why you waiting for Create your account take shop on rent and enjoy our services.Thanks!</p>
             
             <a class="dribbble-follow-button wow bounce" href="http://dribbble.com/srizon">Follow</a>
             </div> <!-- ABOUT INFO END -->

         </div><!-- LEFT PART OF THE ABOUT SECTION END -->
        <!--Left part end-->
         
         <!-- RIGHT PART OF THE ABOUT SECTION -->
         <div class="col-md-6 wow fadeInUp myphoto" data-wow-duration="4s">
             <img src="img/user.png" alt="Mamun Srizon">
         </div><!-- RIGHT PART OF THE ABOUT SECTION END -->        
     </div><!-- ABOUT SECTION END -->
        
    <hr><!-- SECTION SEPARETOR LINE -->
	 
	 
	 <!-- ===========================
    LoginForm SECTION START
    =========================== -->	
	
    <div id="portfolio" class="container" style = "width:100%; margin-top:-20px; background:#e3e3e3;">
        <!-- LoginForm SECTION HEADING START -->
        <div class="sectionhead  row wow fadeInUp">
            <span class="bigicon icon-cup "></span>
            <h3>Please Login From Here into your Shop</h3>
			<h3>Not Registered? Click Top Right Corner of Form</h3>
            <hr class="separetor">
         </div><!--LoginForm SECTION HEADING END-->
         
        <!-- Form SECTION START -->
        
		<div class="module form-module" style = "margin-bottom:50px;">
            <div class="toggle"><i class="fa fa-times fa-pencil"></i>
                <div class="tooltip">Click Me</div>
            </div>
      
	        <div class="form">
                <h2>Login to your account</h2>
                <form action = "<?php echo e(route('VendorLogin')); ?>" method = "POST">

                    <input type = "hidden" name ="_token" value = "<?php echo e(csrf_token()); ?>">

                    <input type="email" placeholder="Email" required = "required" name = "email"/>

                    <?php if($errors->has('email')): ?>
                        <span class="help-block" style = "color: red;">
                        <strong><?php echo e($errors->first('email')); ?></strong>
                    </span>

                    <?php endif; ?>

                    <input type="password" placeholder="Password" required = "required" name = "password"/>

                    <?php if($errors->has('password')): ?>
                        <span class="help-block" style = "color: red;">
                        <strong><?php echo e($errors->first('password')); ?></strong>
                    </span>

                    <?php endif; ?>

                    <button style = "padding: 10px 15px; font-size:18px;">Login</button>
                </form>
            </div>
			
            <div class="form">
                <h2>Create an account</h2>
                <form action = "<?php echo e(route('insertShop')); ?>" method = "post" enctype = "multipart/form-data">

                    <input type = "hidden" name ="_token" value = "<?php echo e(csrf_token()); ?>">

                    <input type="text" name = "username" placeholder="Username" required = "required"/>

                    <?php if($errors->has('username')): ?>
                        <span class="help-block" style = "color: red;">
                        <strong><?php echo e($errors->first('username')); ?></strong>
                    </span>

                    <?php endif; ?>

                    <input type="password" name = "password" placeholder="Password" required = "required"/>

                    <?php if($errors->has('password')): ?>
                        <span class="help-block" style = "color: red;">
                        <strong><?php echo e($errors->first('password')); ?></strong>
                    </span>

                    <?php endif; ?>

                    <input type="password" name = "password_confirmation" placeholder="Confirm Password" required = "required"/>

                    <?php if($errors->has('password_confirmation')): ?>
                        <span class="help-block" style = "color: red;">
                        <strong><?php echo e($errors->first('password_confirmation')); ?></strong>
                    </span>

                    <?php endif; ?>

                    <input type="email" name = "email" placeholder="Email Address" required = "required"/>

                    <?php if($errors->has('email')): ?>
                        <span class="help-block" style = "color: red;">
                        <strong><?php echo e($errors->first('email')); ?></strong>
                    </span>

                    <?php endif; ?>

                    <input type="tel" name = "phone#" placeholder="Phone Number" required = "required"/>

                    <?php if($errors->has('phone#')): ?>
                        <span class="help-block" style = "color: red;">
                        <strong><?php echo e($errors->first('phone#')); ?></strong>
                    </span>

                    <?php endif; ?>

                    <input type="text" name = "address" placeholder="Home Address" required = "required"/>


                    <?php if($errors->has('address')): ?>
                        <span class="help-block" style = "color: red;">
                        <strong><?php echo e($errors->first('address')); ?></strong>
                    </span>

                    <?php endif; ?>

                    <input type="text" name = "creditcart#" placeholder="CreditCart Number" required = "required"/>

                    <?php if($errors->has('creditcart#')): ?>
                        <span class="help-block" style = "color: red;">
                        <strong><?php echo e($errors->first('creditcart#')); ?></strong>
                    </span>

                    <?php endif; ?>

                    <input type="text" name = "shop_name" placeholder="Shop Name" required = "required"/>

                    <?php if($errors->has('shop_name')): ?>
                        <span class="help-block" style = "color: red;">
                        <strong><?php echo e($errors->first('shop_name')); ?></strong>
                    </span>

                    <?php endif; ?>

                    <select name = "market_id">

		                 <option>Select a Market</option>

                         <?php foreach($market as $m): ?>
                            {
                                <?php foreach($city as $c): ?>
                                   <?php if($m->city_id == $c->id): ?>
                                    <option value = "<?php echo e($m->id); ?>"><?php echo e($m->name.' in '.$c->name); ?> </option>
                                   <?php endif; ?>
                                <?php endforeach; ?>
                            }
                         <?php endforeach; ?>

                    </select>

                    <?php if($errors->has('market_id')): ?>
                        <span class="help-block" style = "color: red;">
                        <strong><?php echo e($errors->first('confirm_password')); ?></strong>
                    </span>

                    <?php endif; ?>

                    <input id="f02" type="file" name = "shop_img" placeholder="Add Shop Picture" required = "required" />
                    <label for="f02">Add Shop Picture</label>

                    <?php if($errors->has('shop_img')): ?>
                        <span class="help-block" style = "color: red;">
                        <strong><?php echo e($errors->first('shop_img')); ?></strong>
                    </span>

                    <?php endif; ?>

                    <button style = "margin-top:10px;  padding: 10px 15px; font-size:18px;">Register</button>
                </form>
            </div>
			
            <div class="cta"><a href="http://andytran.me">Forgot your password?</a>
			</div>
			
        </div>
		
    </div><!-- Form SECTION END -->

<?php $__env->stopSection(); ?>


<?php $__env->startSection('footernavbar'); ?>

    <li><a href="index">Home</a></li>

<?php $__env->stopSection(); ?>

<?php echo $__env->make('layouts.Master', array_except(get_defined_vars(), array('__data', '__path')))->render(); ?>