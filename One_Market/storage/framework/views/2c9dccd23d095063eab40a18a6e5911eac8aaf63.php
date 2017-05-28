<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">    
          
    <!-- ===========================
    THEME INFO
    =========================== -->
    <meta name="description" content="A free Bootstrap powerd HTML template exclusively crafted for the super lazy designers like me who designed thousand of websites till today but never got a chance to build one himself.">
    <meta name="keywords" content="Free Portfolio Template, Free Template, Free Bootstrap Template, Dribbble Portfolio Template, Free HTML5 Template">
    <meta name="author" content="EvenFly Team">
    
    <!-- DEVEOPER'S NOTE:
    This is a free Bootstrap powered HTML template from EvenFly. Feel free to download, modify and use it for yourself or your clients as long there is no money involved.
    
    Please don't try to sale it from anywhere; because I want it to be free, forever. If you sale it, That's me who deserves the money, not you :)
    -->

    <!-- ===========================
    SITE TITLE
    =========================== -->
    <title>One Market</title><!-- This is what you see on your browser tab-->
    
    <!-- ===========================
    FAVICONS
    =========================== -->
    <link rel="icon" href="/One_Market/public/img/favicon.png">
    <link rel="apple-touch-icon" sizes="144x144" href="img/apple-touch-icon-ipad-retina.png" />
    <link rel="apple-touch-icon" sizes="114x114" href="img/apple-touch-icon-iphone-retina.png" />
    <link rel="apple-touch-icon" sizes="72x72" href="img/apple-touch-icon-ipad.png" />
    <link rel="apple-touch-icon" sizes="57x57" href="img/apple-touch-icon-iphone.png" />
     
    <!-- ===========================
    STYLESHEETS
    =========================== -->

    <link rel="stylesheet" href="/One_Market/public/css/preloader.css">
    <link rel="stylesheet" href="/One_Market/public/css/style.css">
    <link rel="stylesheet" href="/One_Market/public/css/responsive.css">
    <link rel="stylesheet" href="/One_Market/public/css/animate.css">
	<link rel="stylesheet" href="/One_Market/public/css/sidebar.css">
    <link rel="stylesheet" href="/One_Market/public/css/bootstrap.min.css">
    <link rel="stylesheet" href="/One_Market/public/css/bootstrap.css">
    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
        
    <!-- ===========================
    ICONS: 
    =========================== -->
    <link rel="stylesheet" href="/One_Market/public/css/simple-line-icons.css">
    
    <!-- ===========================
    GOOGLE FONTS
    =========================== -->    
    <link rel="stylesheet" href="http://fonts.googleapis.com/css?family=Antic|Raleway:300">

    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
    
  <!-- ===========================
   GOOGLE ANALYTICS (Optional)
   =========================== -->
    
    <!--Replace this line with your analytics code-->
     
    <!-- Analytics end-->
  
   </head>
    <body data-spy="scroll">
        <!-- Preloader -->
        <div id="preloader">           
            <div id="status">
                <div class="loadicon icon-moustache wow tada infinite" data-wow-duration="8s"></div>
            </div>
        </div>
        
       <header>               
        <!-- ===========================
        HERO AREA
        =========================== -->
        <div id="hero">           
            <div class="container herocontent">               
                <h2 class="wow fadeInUp" data-wow-duration="5s">One Market : the Awesome</h2>
                <h4 class="wow fadeInDown" data-wow-duration="3s">Exclusively crafted  for the super lazy designers like me who designed thousand of websites till today but never got a chance to build one himself.</h4>            
			
			<div id = "searching" style = "margin-top:60px; margin-bottom:100px;">
                <div id = "B_Hover">
                    <form action = "<?php echo e(route('searchMarket2')); ?>" method = "POST">

                        <input type = "hidden" name ="_token" value = "<?php echo e(csrf_token()); ?>">

                        <input type = "text" id = "search" name = "market" placeholder = "Search a Market" required = "required"/>

                        <button type="submit" class="btn btn-info">

                            <span class="glyphicon glyphicon-search"></span> Search

                        </button>

                        <!--<button>Search</button>-->
                        <!--<strong><input type = "button" value = "Click to Search"></strong>-->
                    </form>
	 
	            <div id = "table" style = "margin-top:1px;">
	            </div>
				
	        </div>
            </div>
			</div>
        </div><!--HERO AREA END-->        
        
        <!-- ===========================
         NAVBAR START
         =========================== -->
          <nav class="navbar navbar-inverse navbar-fixed-top" role="navigation">
               <div class="container">
                   
                      <div class="navbar-header">
                       <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                           <span class="sr-only">Toggle navigation</span>
                           <span class="icon-bar"></span>
                           <span class="icon-bar"></span>
                           <span class="icon-bar"></span>
                        </button>
                        
                           <a class="navbar-brand" href="#hero">
                            <!-- Replace Drifolio Bootstrap with your Site Name and remove icon-grid to remove the placeholder icon -->
                            <span class="brandicon icon-grid"></span>
                            <span class="brandname">One Market </span>
                        </a>
                    </div>

                <div class="collapse navbar-collapse">
                    <ul class="nav navbar-nav navbar-right"><!--YOUR NAVIGATION ITEMS STRAT BELOW-->
                        <li><a href="/One_Market/public/index"><span class="btnicon icon-user"></span>Home</a></li>
					    <li><a href="#services"><span class="btnicon icon-user"></span>Market Details</a></li>
                        <li><a href="#about"><span class="btnicon icon-user"></span>About</a></li>
                        <li><a href="#server"><span class="btnicon icon-cup"></span>Services</a></li>
                        <li><a href="#portfolio"><span class="btnicon icon-rocket"></span>Shopping Cart</a></li>
                        <li><a href="#testimonials"><span class="btnicon icon-bubble"></span>Admins</a></li>
                        
                        <!--don't forget to replace my email address below with yours-->
                        <li class="active"><a href="/One_Market/public/Customer_Login"><span class="btnicon icon-cloud-download"></span><?php if(Session::get('c_email') != null): ?> <?php echo e($customer->username); ?> <?php else: ?> Customer Log In <?php endif; ?></a></li>
						<li class="active"><a href="/One_Market/public/Vendor_Login"><span class="btnicon icon-cloud-download"></span><?php if(Session::get('email') != null): ?> <?php echo e($vendor->username); ?> <?php else: ?> Vendor Log In <?php endif; ?></a></li>
                    </ul>
                
                </div><!--.nav-collapse -->
            </div>
        </nav><!--navbar end-->        
     </header><!--header end-->     

	 
	  <!-- ==============================
        side bar section start here
        ==========================--->
        <div id="wrapper" style = "background:black;">
        <div id="sidebar-wrapper">
            <ul class="sidebar-nav nav-pills nav-stacked" id="menu">

                <li>
                    <a href="/One_Market/public/index" id="" class="shop"><span class="fa-stack fa-lg pull-left"><i class="fa fa-dashboard fa-stack-1x "></i></span> Major Cities</a>
                    <ul class="nav-pills nav-stacked" style="list-style-type:none;">

                        <li><a href="#"></a></li>

                    </ul>

                </li>

                <?php foreach($market as $m): ?>

                    <?php if($m->id == $market_details->id): ?>

                    <li class = "active">
                        <a href=" <?php echo e(URL::route('getMarketDetails', array('id' => $m->id ))); ?> " class="shop"><span class="fa-stack fa-lg pull-left"><i class="fa fa-flag fa-stack-1x "></i></span> <?php echo e($m->name); ?> </a>
                    </li>

                    <?php elseif($m->id != $market_details->id): ?>

                        <li>
                            <a href="<?php echo e(URL::route('getMarketDetails', array('id' => $m->id ))); ?>" class="shop"><span class="fa-stack fa-lg pull-left"><i class="fa fa-flag fa-stack-1x "></i></span> <?php echo e($m->name); ?> </a>
                        </li>

                    <?php endif; ?>

                <?php endforeach; ?>

                <li>
                    <a href="#about"><span class="fa-stack fa-lg pull-left"><i class="fa fa-youtube-play fa-stack-1x "></i></span>About</a>
                </li>
                <li>
                    <a href="#server"><span class="fa-stack fa-lg pull-left"><i class="fa fa-wrench fa-stack-1x "></i></span>Services</a>
                </li>
                <li>
                    <a href="#portfolio"><span class="fa-stack fa-lg pull-left"><i class="fa fa-server fa-stack-1x "></i></span>Shopping Cart</a>
                </li>
				<li>
                    <a href="#testimonials"><span class="fa-stack fa-lg pull-left"><i class="fa fa-server fa-stack-1x "></i></span>Admins</a>
                </li>
            </ul>
         </div>
        
       
	   <div style = "background:white;">
        
		
		
		<!-- ===========================
    FEATURED CLIENTS SECTION START
    =========================== -->
     <div id="clients">
         <div class="container">
             <div class="col-md-3">
                 <h4>Proudly worked with:</h4>
             </div>
             <div class="col-md-9">
                 <ul><!--CLIENTS LOGO-->
                     <li><img src="/One_Market/public/img/payoneer.png" alt="Payoneer"></li>
                     <li><img src="/One_Market/public/img/amazon.png" alt="Amazon"></li>
                     <li><img src="/One_Market/public/img/elance-odesk.png" alt="Elance-oDesk"></li>
                     <li><img src="/One_Market/public/img/curb.png" alt="Curb Envy"></li>
                 </ul><!--CLIENTS LOGO END-->
             </div>
         </div>
         <hr><!-- SECTION SEPARETOR LINE -->
     </div><!--FEATURED CLIENTS SECTION END-->
		
		
		
    <!-- ===========================
    Cities SECTION START
    =========================== -->
    <div id="services" class="container">
       
        <!-- Cities SECTION HEADING START -->
        <div class="sectionhead  row wow fadeInUp">
            <img data-wow-duration="4s" src="/One_Market/public/img/details.png" height = "70px" alt="Search Logo"/>
            <h3>Market Details Here</h3>
            <hr class="separetor">
         </div><!--Cities SECTION HEADING END-->
         
        <!-- Cities ITEMS START -->
        <div class="row" id = "D_Button">



            <div class="col-md-6 col-lg-12 wow fadeInUp" data-wow-duration="3s">
                <h2 style = "margin-bottom: 20px;"><?php echo e($market_details->name); ?></h2>
                <img src="/One_Market/public/market_images/<?php echo e($market_details->image1); ?>" height = "350" width = "350" alt="<?php echo e($market_details->image1); ?>">
                <img src="/One_Market/public/market_images/<?php echo e($market_details->image2); ?>" height = "350" width = "350" alt="<?php echo e($market_details->image1); ?>">
                <img src="/One_Market/public/market_images/<?php echo e($market_details->image3); ?>" height = "350" width = "350" alt="<?php echo e($market_details->image1); ?>">
                <h3><?php echo e("Area: ".$market_details->area); ?></h3>
                <br>
                <h4><?php echo e($market_details->description); ?></h4>
                <br>
                <a href = "/One_Market/public/index"><button type="button" class="btn btn-primary btn-md" style = "width: auto;">Go Back</button></a>
            </div> <!-- ITEM END -->



        </div><!-- Cities ITEMS END-->
    </div><!-- Cities SECTION END -->


           <hr>

    	<!-- ===========================
    ABOUT SECTION START
    =========================== -->
     
	 <div id="about" class="container" style = "margin-left: 40px;">
        
        <!-- LEFT PART OF THE ABOUT SECTION -->
         <div class="col-md-6">
            <div class="row">
             <h2 class="wow fadeInDown" data-wow-duration="2s">About Us</h2>

             <h4 class="wow fadeInUp" data-wow-duration="3s">A freelance UI/UX wizard as well as a Daydreamer who workes on the Graveyard Shift and sleeps all the day!</h4>
             
             <p class="wow fadeInDown" data-wow-duration="3s">I'm gonna build me an airport, put my name on it. Why, Michael? So you can fly away from your feelings? I don't care if it takes from now till the end of Shrimpfest.</p>
             <p class="wow fadeInDown" data-wow-duration="3s">Bugger bag egg's old boy willy jolly scrote munta skive pillock, bloody shambles nose rag blummin' scrote narky ever so, Lorem ipsum dolor sit amet, consectetur adipisicing elit.</p>
             
             <a class="dribbble-follow-button wow bounce" href="http://dribbble.com/srizon">Follow</a>
             </div> <!-- ABOUT INFO END -->
             
            
            <div class="myapps row">
                <h5>Tools and apps I use everyday:</h5>
                
                <ul><!-- FAVORITE APP ICONS START -->
                    <li><img class="wow animated bounceInUp" data-wow-duration="1s" src="/One_Market/public/img/photoshop.svg" alt="Photoshop"></li>
                    <li><img class="wow bounceInUp" data-wow-duration="2s" src="/One_Market/public/img/illustrator.svg" alt="Illustrator"></li>
                    <li><img class="wow bounceInUp" data-wow-duration="3s" src="/One_Market/public/img/flash.svg" alt="Adobe Flash"></li>
                    <li><img class="wow animated bounceInUp" data-wow-duration="4s" src="/One_Market/public/img/after_effects.svg" alt="After Effects"></li>
                    <li><img class="wow bounceInUp" data-wow-duration="5s" src="/One_Market/public/img/indesign.svg" alt="InDesign"></li>
                </ul><!-- FAVORITE APP ICONS END -->
            </div>
         </div><!-- LEFT PART OF THE ABOUT SECTION END -->
        <!--Left part end-->
         
         <!-- RIGHT PART OF THE ABOUT SECTION -->
         <div class="col-md-6 wow fadeInUp myphoto" data-wow-duration="4s">
             <img src="/One_Market/public/img/user.png" alt="Mamun Srizon">
         </div><!-- RIGHT PART OF THE ABOUT SECTION END -->        
     </div><!-- ABOUT SECTION END -->
        
    <hr><!-- SECTION SEPARETOR LINE -->


	
	 <!-- ===========================
    Cities SECTION START
    =========================== -->
    <div id="server" class="container" style = "text-align:center;">
       
        <!-- Cities SECTION HEADING START -->
        <div class="sectionhead  row wow fadeInUp">
			<span class="bigicon icon-cup "></span>
            <h3>This is what I can do for you</h3>
            <hr class="separetor">
         </div><!--Cities SECTION HEADING END-->
         
        <!-- Cities ITEMS START -->
        <div class="row">				
				<div class="col-md-6 col-lg-6 wow fadeInUp" data-wow-duration="3s">
                   <img src="/One_Market/public/img/s1.png" alt="">
                   <h4>Responsive Web Design</h4>
                   <p>Grinder affogato, dark, sweet carajillo, flavour seasonal aroma single origin cream. Percolator. Eligendi impedit dolores nulla.</p>
                </div> <!-- ITEM END -->

                <div class="col-md-6 col-lg-6 wow fadeInUp" data-wow-duration="3s">
                   <img src="/One_Market/public/img/s2.png" alt="">
                   <h4>Android App Design</h4>
                   <p>Grinder affogato, dark, sweet carajillo, flavour seasonal aroma single origin cream. Percolator. Eligendi impedit dolores nulla.</p>
                </div> <!-- ITEM END -->

				<div class="col-md-6 col-lg-6 wow fadeInUp" data-wow-duration="3s">
                   <img src="/One_Market/public/img/s3.png" alt="">
                   <h4>iOS App Design</h4>
                   <p>Grinder affogato, dark, sweet carajillo, flavour seasonal aroma single origin cream. Percolator. Eligendi impedit dolores nulla.</p>
                </div> <!-- ITEM END -->

               <div class="col-md-6 col-lg-6 wow fadeInUp" data-wow-duration="3s">
                   <img src="/One_Market/public/img/s4.png" alt="">
                   <h4>Windows App Design</h4>
                   <p>Grinder affogato, dark, sweet carajillo, flavour seasonal aroma single origin cream. Percolator. Eligendi impedit dolores nulla.</p>
                </div> <!-- ITEM END -->

                <div class="col-md-6 col-lg-6 wow fadeInUp" data-wow-duration="3s">
                   <img src="/One_Market/public/img/s5.png" alt="">
                   <h4>Brand Identity Design</h4>
                   <p>Grinder affogato, dark, sweet carajillo, flavour seasonal aroma single origin cream. Percolator. Eligendi impedit dolores nulla.</p>
                </div> <!-- ITEM END -->

                <div class="col-md-6 col-lg-6 wow fadeInUp" data-wow-duration="3s">
                   <img src="/One_Market/public/img/s6.png" alt="">
                   <h4>CMYK Print Design</h4>
                   <p>Grinder affogato, dark, sweet carajillo, flavour seasonal aroma single origin cream. Percolator. Eligendi impedit dolores nulla.</p>
                </div> <!-- ITEM END -->
        </div><!-- Cities ITEMS END-->
    </div><!-- Cities SECTION END -->



           <hr>

           <!-- ===========================
   Cities SECTION START
   =========================== -->
           <div id="portfolio" class="container" style = "background: white; margin-bottom: -50px;">

               <!-- Cities SECTION HEADING START -->
               <div class="sectionhead  row wow fadeInUp" style = "margin-top: -40px;">
                   <img data-wow-duration="4s" src="/One_Market/public/img/add.png" height = "120px" alt="Search Logo"/>
                   <h3>Shopping Cart</h3>
                   <hr class="separetor">
               </div><!--Cities SECTION HEADING END-->

               <!-- Cities ITEMS START -->
               <div class="row">

                   <div  class="col-md-6 col-lg-12 wow fadeInUp" data-wow-duration="3s">

                       <div class="container">

                           <table class="table table-condensed" style = "margin-left: 50px;">
                               <thead>
                               <tr>
                                   <th><b>Uptade</b></th>
                                   <th><b>Remove</b></th>
                                   <th><b>Product</b></th>
                                   <th><b>Quantity</b></th>
                                   <th><b>Total Price</b></th>
                               </tr>
                               </thead>
                               <tbody>

                               <?php if(Session::get('c_email') != null): ?>

                                   <?php foreach($cart as $c): ?>

                                       <?php foreach($product as $p): ?>

                                           <?php if($c->p_id == $p->id): ?>

                                               <tr>

                                                   <form action = "<?php echo e(route('updateCart', array('id' => $c->id , 'shop_id' => 0 , 'city_id' => 0 , 'market_id' => 0 , 'city_details_id' => 0 , 'market_details_id' => $market_details->id , 'product_details_id' => 0 , 'shop_details_id' => 0 , 'category_id' => 0 , 'vendor_id' => 0 , 'brand_id' => 0))); ?>" method = "POST">

                                                       <input type = "hidden" name ="_token" value = "<?php echo e(csrf_token()); ?>">

                                                       <td><button style = "width: 40%; margin-left: -100px;" type="submit" class="btn btn-primary btn-md">Uptade</button></td>
                                                       <td><input class="checkbox" type="checkbox" name = "remove" /> </td>
                                                       <td><b style = "margin-left: -170px;"><?php echo e($p->name); ?></b><br> <img src="/One_Market/public/product_images/<?php echo e($p->image1); ?>" width = "60" height = "60" alt="<?php echo e($p->name); ?>" style="text-align: center;  margin-left: -170px;"></td>
                                                       <td><input type="number" max="100" min="0" size="6"  name = "quantity" value = "<?php echo e($c->quantity); ?>" style = "margin-left: -160px;"/> </td>
                                                       <td><p style = "margin-left: -185px; color: black;"><?php echo e('$'.$p->price * $c->quantity); ?></p></td>

                                                   </form>

                                               </tr>

                                           <?php endif; ?>

                                       <?php endforeach; ?>

                                   <?php endforeach; ?>

                               <?php endif; ?>

                               </tbody>
                           </table>

                           <div style = "font-size: 22px;" class="col-md-6 col-lg-9 wow fadeInUp" data-wow-duration="3s">
                               <b style = "float: right; margin-right: -168px;"><?php if(Session::get('c_email') != null): ?> <?php echo e('$'.$total); ?> <?php endif; ?> </b>

                               <b style = "float: right;">Sub total :</b>
                           </div>


                           <div style = "font-size: 22px;" class="col-md-6 col-lg-9 wow fadeInUp" data-wow-duration="3s">
                               <a href = "#services"><button style = "width: 20%;" type="button" class="btn btn-primary btn-md">Continue Shopping</button></a>
                               <button style = "width: 15%; margin-right: -60px; float: right;" type="button" class="btn btn-primary btn-md">Checkout</button>

                           </div>


                       </div>


                   </div> <!-- ITEM END -->

               </div><!-- Cities ITEMS END-->
           </div><!-- Cities SECTION END -->



           <hr>



           <!-- ===========================
           TESTIMONIAL SECTION START
           =========================== -->
    <div id="testimonials" class="container">
        <div class="sectionhead wow bounceInUp" data-wow-duration="2s">
           <span class="bigicon icon-bubbles"></span>
           <h3>We are four admins and designer of this website</h3>
           <h4>Expedita nobis natus doloribus blanditiis quos, atque voluptatem, veritatis soluta eveniet ea!</h4>
           <hr class="separetor">            
        </div><!-- TESTIMONIAL SECTIONHEAD END -->
        
        <!-- TESTIMONIAL ITEMS START -->
        <div class="row" style = "margin-left: 40px;">
            <!-- 1ST TESTIMONIAL ITEM -->
            <div class="col-md-9 wow bounceIn" data-wow-duration="2s">
                <div class="clientsphoto">
                    <img src="/One_Market/public/img/saad.jpg" alt="Dan">
                </div>
                
                <div class="quote">
                    <blockquote>
                       <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Quia et pariatur ipsam tempora officia ea iusto expedita, nulla, hic odit saepe repellat nesciunt dolorum, officiis laborum ad, aliquam. Quos, et.</p>                        
                    </blockquote>
                    <h5>Saad Afzaal</h5>
                    <p>Co-Founder, One Market</p>
                </div>                
            </div><!-- 1ST TESTIMONIAL ITEM END -->
            
            <!-- 2ND TESTIMONIAL ITEM -->
            <div class="col-md-9 wow bounceIn" data-wow-duration="3s">
                <div class="clientsphoto">
                    <img src="/One_Market/public/img/zawar.jpg" alt="Bill">
                </div>
				
				<div class="quote">
                    <blockquote>
                       <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Quia et pariatur ipsam tempora officia ea iusto expedita, nulla, hic odit saepe repellat nesciunt dolorum, officiis laborum ad, aliquam. Quos, et. lorem</p>
                    </blockquote>
                    <h5>Zawar Shahid</h5><p>Art Director at Focus Lab LLC.</p>
                </div>
            </div><!-- 2ND TESTIMONIAL ITEM END -->
            
            <!-- 3RD TESTIMONIAL ITEM -->
            <div class="col-md-9 wow bounceIn" data-wow-duration="3s">
                <div class="clientsphoto">
                    <img src="/One_Market/public/img/halif.jpg" alt="Eric">
                </div>
                
                <div class="quote">
                    <blockquote>
                       <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Quia et pariatur ipsam tempora officia ea iusto expedita, nulla, hic odit saepe repellat nesciunt dolorum, officiis laborum ad, aliquam. Quos, et.</p>                        
                    </blockquote>
                    <h5>Halif Sohail</h5>
                    <p>Principal Designer, JellyJar</p>
                </div>                
            </div><!-- 3RD TESTIMONIAL ITEM END -->
            
            <!-- 4TH TESTIMONIAL ITEM -->
            <div class="col-md-9 wow bounceIn" data-wow-duration="2s">
                <div class="clientsphoto">
                    <img src="/One_Market/public/img/bilal.jpg" alt="Ramil">
                </div>
                
                <div class="quote">
                    <blockquote>
                       <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Quia et pariatur ipsam tempora officia ea iusto expedita, nulla, hic odit saepe repellat nesciunt dolorum, officiis laborum ad, aliquam. Quos, et.</p>                        
                    </blockquote>
                    <h5>Bilal Shah</h5>
                    <p>Visual Designer, Bluroon</p>
                </div>                
            </div><!-- 4TH TESTIMONIAL ITEM END -->
        </div>        
    </div><!-- TESTIMONIAL SECTION END -->
    
	
	</div>
	
	</div>

	 
	 <!-- ===========================
    FOOTER START
    =========================== -->    
    <footer style = "background:;">
        <div class="container">
            <span class="bigicon icon-speedometer "></span>
             
            <div class="footerlinks"><!-- FOOTER LINKS START -->            
                <ul>
                    <li><a href="#hero">Home</a></li>
                    <li><a href="#about">About us</a></li>
                    <li><a href="#server">Services</a></li>
                    <li><a href="#portfolio">Shopping Cart</a></li>
                    <li><a href="#testimonials">Admins</a></li>
                </ul>
            </div><!-- FOOTER LINKS END -->
             
            <div class="copyright"><!-- FOOTER COPYRIGHT START -->
                <p><a href="#">Drifolio</a> stands for Dribbble-Portolio. This is a free HTML template designed and coded by <a href="http://evenfly.com">EvenFly Team</a>. All logo and images in this template used for preview purpose only. You are free to use the template but make sure to use your own images.</p>
            </div><!-- FOOTER COPYRIGHT END -->
             
            <div class="footersocial wow fadeInUp" data-wow-duration="3s"><!-- FOOTER SOCIAL ICONS START -->
                <ul>
                    <li><a href="http://facebook.com/MamunSrizon"><span class="icon-social-facebook"></span></a></li>
                    <li><a href="http://twitter.com/MamunSrizon"><span class="icon-social-twitter"></span></a></li>
                    <li><a href="#"><span class="icon-social-youtube"></span></a></li>
                    <li><a href="http://dribbble.com/srizon"><span class="icon-social-dribbble"></span></a></li>
                    <li><a href="#"><span class="icon-social-tumblr"></span></a></li>
                 </ul>
             </div><!-- FOOTER SOCIAL ICONS END -->
         </div>
     </footer><!-- FOOTER END -->
    <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    <script src="/One_Market/public/js/jquery-latest.min.js"></script>
    
    <!-- Include all compiled plugins (below), or include individual files as needed -->
    <script src="/One_Market/public/js/bootstrap.min.js"></script>
    
    <!--Other necessary scripts-->
    <script src="/One_Market/public/js/jquery.nicescroll.min.js"></script>
    <script src="/One_Market/public/js/jquery.jribbble-1.0.1.ugly.js"></script>
    <script src="/One_Market/public/js/drifolio.js"></script>
    <script src="/One_Market/public/js/wow.min.js"></script>
    <script>new WOW().init();</script>    
  </body>
</html>