<?php $__env->startSection('title', 'Vendor Search Product'); ?>

<?php $__env->startSection('img'); ?>

    <img data-wow-duration="4s" src="img/d_arrow.png" height = "165px" alt="Downward Arrow"/>  
	
<?php $__env->stopSection(); ?>


<?php $__env->startSection('heading'); ?>

<h2 class="wow fadeInUp" data-wow-duration="5s">To See Search Content : Please Scroll Down</h2>

<?php $__env->stopSection(); ?>


<?php $__env->startSection('navbar'); ?>

    <div class="collapse navbar-collapse">
        <ul class="nav navbar-nav navbar-right"><!--YOUR NAVIGATION ITEMS STRAT BELOW-->
            <li><a href="index"><span class="btnicon icon-user"></span>Home</a></li>
            <li><a href="#ViewAP"><span class="btnicon icon-user"></span>View Search Products</a></li>
            <li><a href="#services"><span class="btnicon icon-user"></span>Search</a></li>
			<li><a href="Vendor_MainArea"><span class="btnicon icon-cloud-download"></span>Go Back</a></li>
        </ul>    
    </div><!--.nav-collapse -->

<?php $__env->stopSection(); ?>


<?php $__env->startSection('content'); ?>


        <!-- ===========================
    ViewAllProducts SECTION START
    =========================== -->
    <div id="ViewAP" class="container">

        <!-- ViewAllProducts SECTION HEADING START -->
        <div class="sectionhead  row wow fadeInUp">
            <img data-wow-duration="4s" src="img/VAP.jpg" height = "120px" alt="Search Logo"/>
            <h3>View Search Products</h3>
            <hr class="separetor">
        </div>

        <div id = "th">
            <table  width = "1000" align = "center" border = "1" bgcolor="black" style = "color:white; background:black; font-size:16px; margin-bottom:70px;">

                <tr>
                    <td colspan = "6" align = "center"><h2>Search Products Here!</h2></td>
                </tr>

                <tr align = "center" style = "color:#FFFF00; font-size: 20px;">
                    <th style = "padding: 20px;">Product_id :</th>
                    <th>Product_title :</th>
                    <th>Product_Price :</th>
                    <th>Update</th>
                    <th>Delete</th>
                </tr>

                <?php foreach($product as $p): ?>
                    <tr style="text-align: center">
                        <td><?php echo e($p->id); ?></td>
                        <td><?php echo e($p->name); ?></td>
                        <td><?php echo e($p->price); ?></td>

                        <td>
                            <div id = "editPro">
                                <a href="<?php echo e(URL::route('editProduct', array('id' => $p->id , 'c_id' => $p->cat_id , 'b_id' => $p->brand_id))); ?>">
                                    <button type="submit">
                                        Update
                                    </button>
                                </a>
                            </div>
                        </td>

                        <td>
                            <div id = "deletePro">
                                <a href="<?php echo e(URL::route('deleteProduct', array('id' => $p->id))); ?>">
                                    <button type="submit">
                                        Delete
                                    </button>
                                </a>
                            </div>
                        </td>

                    </tr>
                <?php endforeach; ?>

            </table>
        </div>

    </div><!-- ViewAllProducts SECTION END -->


    <hr style = "margin-top:50px;">

    <!-- ===========================
    SEARCH SECTION START
    =========================== -->
    <div id="services" class="container">

        <!-- SERVICE SECTION HEADING START -->
        <div class="sectionhead  row wow fadeInUp">
            <img data-wow-duration="4s" src="img/search.jpg" height = "80px" alt="Search Logo"/>
            <h3>Search AnyThing Related Products Here!</h3>
            <hr class="separetor">


            <div id = "searching" style = "margin-top:40px;">
                <form action = "<?php echo e(route('searchVendor')); ?>" method = "POST">

                    <input type = "hidden" name ="_token" value = "<?php echo e(csrf_token()); ?>">

                    <strong>
                        <select id = "search_type" name = "search_type">
                            <option value = ""> Select Search Type</option>
                            <option value = "P">Search a Product</option>
                            <option value = "C">Search a Category</option>
                            <option value = "B">Search a Brand</option>
                            <option value = "Cu">Search a Customer</option>
                            <option value = "O">Search a Order</option>
                            <option value = "Pay">Search a Payment</option>
                        </select>
                    </strong>

                    <input type = "text" id = "search" name = "search" placeholder = "Type Here" />

                    <!--<button>Search</button>-->

                    <button type="submit" class="btn btn-info">
                        <span class="glyphicon glyphicon-search"></span> Search
                    </button>

                    <strong><label>For Order and Payment Select Date</label></strong>

                    <input type="date"  name = "datetime"/>

                    <!--<input type = "button" class="btn btn-info"  value = "Search" onclick = "search_content('table' , 'Vendor_Search');">-->


                    <!--<strong><input type = "button" value = "Click to Search">
                    </strong>-->
                </form>

                <div id = "table" style = "margin-top:1px;">
                </div>

            </div>

        </div><!--SEARCH SECTION HEADING END-->

    </div><!-- SEARCH SECTION END -->

<?php $__env->stopSection(); ?>


<?php $__env->startSection('footernavbar'); ?>

    <li><a href="index">Home</a></li>

<?php $__env->stopSection(); ?>

<?php echo $__env->make('layouts.Master', array_except(get_defined_vars(), array('__data', '__path')))->render(); ?>