<?php $__env->startSection('title', 'Vendor Payment'); ?>

<?php $__env->startSection('img'); ?>

    <img data-wow-duration="4s" src="img/d_arrow.png" height = "165px" alt="Downward Arrow"/>  
	
<?php $__env->stopSection(); ?>


<?php $__env->startSection('heading'); ?>

<h2 class="wow fadeInUp" data-wow-duration="5s">To Payment : Please Scroll Down</h2>  

<?php $__env->stopSection(); ?>


<?php $__env->startSection('navbar'); ?>

    <div class="collapse navbar-collapse">
        <ul class="nav navbar-nav navbar-right"><!--YOUR NAVIGATION ITEMS STRAT BELOW-->
            <li><a href="index"><span class="btnicon icon-user"></span>Home</a></li>
	        <li class="active"><a href="#services"><span class="btnicon icon-user"></span>Vender Payment</a></li>
			<li><a href="Vendor_MainArea"><span class="btnicon icon-cloud-download"></span>Vender MainArea</a></li>
            <li><a href="<?php echo e(URL::route('VendorLogOut')); ?>"><span class="btnicon icon-cloud-download"></span>Vender LogOut</a></li>
        </ul>    
    </div><!--.nav-collapse -->

<?php $__env->stopSection(); ?>


<?php $__env->startSection('content'); ?>

    	 <!-- ===========================
    Payment SECTION START
    =========================== -->
    <div id="services" class="container">
       
        <!-- Payment SECTION HEADING START -->
        <div class="sectionhead  row wow fadeInUp">
            <!--<span class="bigicon icon-cup "></span>-->
			<img data-wow-duration="4s" src="img/PLogo2.png" height = "90px" alt="Payment Logo"/>   
            <h3>Pay now with PayPal</h3>
            <hr class="separetor">						
			
			<form action="<?php echo e(route('insertRent')); ?>" method="post" style = "margin-top:50px;">  <!--https://www.sandbox.paypal.com/cgi-bin/webscr-->

                <input type = "hidden" name ="_token" value = "<?php echo e(csrf_token()); ?>">

                <!--Identify your business so that you can collect the payments. -->
                <input type="hidden" name="business" value="herschelgomez@xyzzyu.com">

                <!-- Specify a Buy Now button. -->
                <input type="hidden" name="cmd" value="_xclick">

                <!-- Specify details about the item that buyers will purchase. -->
                <input type="hidden" name="item_name" value = "Rent">
			    <input type="hidden" name="item_number" value = "1">
                <input type="hidden" name="amount" value = "500">
                <input type="hidden" name="currency_code" value="USD">
                
                <input type="hidden" name="return" value = "">
			    <input type="hidden" name="cancel_return" value = "">

                <!-- Display the payment button. -->
                <input type="image" name="submit" border="0"
                       src="img/paypal_button.png"
					   alt="PayPal - The safer, easier way to pay online">

                       <img alt="" border="0" width="1" height="1" data-wow-duration="4s"
                       src="https://www.paypalobjects.com/en_US/i/scr/pixel.gif" />

            </form>
					 
	        <img data-wow-duration="4s" src = "img/paypal.png" width = "200" height = "100" style = "margin-bottom:60px;" />
			
         </div><!--Payment SECTION HEADING END-->
         
        <!-- Payment ITEMS START -->
    </div><!-- Payment SECTION END -->

<?php $__env->stopSection(); ?>


<?php $__env->startSection('footernavbar'); ?>

    <li><a href="index">Home</a></li>

<?php $__env->stopSection(); ?>

<?php echo $__env->make('layouts.Master', array_except(get_defined_vars(), array('__data', '__path')))->render(); ?>