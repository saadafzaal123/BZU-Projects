<?php $__env->startSection('title', 'Customer EditProfile'); ?>

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
            <li class="active"><a href="/One_Market/public/Customer_MainArea"><span class="btnicon icon-cloud-download"></span>GoBack</a></li>
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

            <form action = "<?php echo e(route('updateCProfile' , array('id' => $customer->id))); ?>" method = "POST" enctype = "multipart/form-data">

                <input type = "hidden" name ="_token" value = "<?php echo e(csrf_token()); ?>">

                <table width = "1000" align = "center" border = "1" bgcolor = "black" style = "color:white; background:black; font-size:16px; margin-bottom:70px;">

                    <tr>
                        <td colspan = "2" align = "center"><h2>Edit Profile :</h2></td>
                    </tr>

                    <tr>
                        <th align = "right">Username</th>
                        <td><input type = "text" name = "name" size = "90" required = "required" value = "<?php echo e($customer->username); ?>"/></td>
                    </tr>

                    <?php if($errors->has('name')): ?>
                        <tr>
                            <th align = "right" style = "color: red;">Username Error</th>
                            <td style = "color: red;"><strong><?php echo e($errors->first('name')); ?></strong></td>
                        </tr>
                    <?php endif; ?>

                    <tr>
                        <th align = "right">Passowrd</th>
                        <td><input type = "text" name = "password" size = "90" required = "required" value = "<?php echo e(Crypt::decrypt($customer->password)); ?>"/></td>
                    </tr>

                    <?php if($errors->has('password')): ?>
                        <tr>
                            <th align = "right" style = "color: red;">Password Error</th>
                            <td style = "color: red;"><strong><?php echo e($errors->first('password')); ?></strong></td>
                        </tr>
                    <?php endif; ?>

                    <tr>
                        <th align = "right">Confirm Passowrd</th>
                        <td><input type = "text" name = "password_confirmation" size = "90" required = "required" value = "<?php echo e(Crypt::decrypt($customer->password)); ?>"/></td>
                    </tr>

                    <?php if($errors->has('password_confirmation')): ?>
                        <tr>
                            <th align = "right" style = "color: red;">Password Confirmation Error</th>
                            <td style = "color: red;"><strong><?php echo e($errors->first('password_confirmation')); ?></strong></td>
                        </tr>
                    <?php endif; ?>

                    <tr>
                        <th align = "right">PhoneNo</th>
                        <td><input type = "text" name = "phoneNo" size = "90" required = "required" value = "<?php echo e($customer->phoneNo); ?>"/></td>
                    </tr>

                    <?php if($errors->has('phoneNo')): ?>
                        <tr>
                            <th align = "right" style = "color: red;">PhoneNo Error</th>
                            <td style = "color: red;"><strong><?php echo e($errors->first('phoneNo')); ?></strong></td>
                        </tr>
                    <?php endif; ?>

                    <tr>
                        <th align = "right">Address</th>
                        <td><input type = "text" name = "address" size = "90" required = "required" value = "<?php echo e($customer->home_address); ?>"/></td>
                    </tr>

                    <?php if($errors->has('address')): ?>
                        <tr>
                            <th align = "right" style = "color: red;">Address Error</th>
                            <td style = "color: red;"><strong><?php echo e($errors->first('address')); ?></strong></td>
                        </tr>
                    <?php endif; ?>

                    <tr>
                        <th align = "right">CreditCartNo</th>
                        <td><input type = "text" name = "creditcartNo" size = "90" required = "required" value = "<?php echo e($customer->creditcartNo); ?>"/></td>
                    </tr>

                    <?php if($errors->has('creditcartNo')): ?>
                        <tr>
                            <th align = "right" style = "color: red;">CreditCartNo Error</th>
                            <td style = "color: red;"><strong><?php echo e($errors->first('creditcartNo')); ?></strong></td>
                        </tr>
                    <?php endif; ?>


                    <tr>
                        <th align = "right"> Image </th>
                        <td><input type = "file" name = "customer_img"></td>
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