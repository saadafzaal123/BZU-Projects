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
    <title><?php echo $__env->yieldContent('title'); ?></title><!-- This is what you see on your browser tab-->
    
    <!-- ===========================
    FAVICONS
    =========================== -->
    <link rel="icon" href="/One_Market/public/img/favicon.png">
    <link rel="apple-touch-icon" sizes="144x144" href="/One_Market/public/img/apple-touch-icon-ipad-retina.png" />
    <link rel="apple-touch-icon" sizes="114x114" href="/One_Market/public/img/apple-touch-icon-iphone-retina.png" />
    <link rel="apple-touch-icon" sizes="72x72" href="/One_Market/public/img/apple-touch-icon-ipad.png" />
    <link rel="apple-touch-icon" sizes="57x57" href="/One_Market/public/img/apple-touch-icon-iphone.png" />
     
    <!-- ===========================
    STYLESHEETS
    =========================== -->
    <link rel="stylesheet" href="/One_Market/public/css/bootstrap.min.css">
    <link rel="stylesheet" href="/One_Market/public/css/preloader.css">
    <link rel="stylesheet" href="/One_Market/public/css/style.css">
    <link rel="stylesheet" href="/One_Market/public/css/responsive.css">
    <link rel="stylesheet" href="/One_Market/public/css/animate.css">
    <link rel="stylesheet" href="/One_Market/public/css/bootstrap.css">
    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <link rel="stylesheet" href="/One_Market/public/css/sidebar.css">


	<!-- ===========================
    LoginForm: 
    =========================== -->
	<link rel="stylesheet" href="/One_Market/public/css/reset2.css">
    <link rel='stylesheet prefetch' href='/One_Market/public/css/LoginCss.css'>
    <link rel='stylesheet prefetch' href='/One_Market/public/css/font-awesome.min.css'>
    <link rel="stylesheet" href="/One_Market/public/css/style2.css">
		
    <!-- ===========================
    ICONS: 
    =========================== -->
    <link rel="stylesheet" href="/One_Market/public/css/simple-line-icons.css">
    
    <!-- ===========================
    GOOGLE FONTS
    =========================== -->    
    <link rel="stylesheet" href="/One_Market/public/css/css.css">

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

        <?php echo $__env->yieldContent('space'); ?>

        <div id="hero">
            <div class="container herocontent">               
                <h2 class="wow fadeInUp" data-wow-duration="5s">One Market : the Awesome</h2>
                <h4 class="wow fadeInDown" data-wow-duration="3s">Exclusively crafted  for the super lazy designers like me who designed thousand of websites till today but never got a chance to build one himself.</h4>
                <?php echo $__env->yieldContent('heading'); ?>
			</div>
            
            <!-- Featured image on the Hero area -->

            <div style = "margin-bottom: 50px; margin-top: 30px;">
			      <?php echo $__env->yieldContent('img'); ?>
			</div>

            <!--<img class="heroshot wow bounceInUp" data-wow-duration="4s" src="img/hero-img.png" alt="Featured Work">-->
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
		
                        <a class="navbar-brand" href="index">
                            <!-- Replace Drifolio Bootstrap with your Site Name and remove icon-grid to remove the placeholder icon -->
                            <span class="brandicon icon-grid"></span>
                            <span class="brandname">One Market </span>
                        </a>
                    </div>		   
			        
                   
                      <?php echo $__env->yieldContent('navbar'); ?>
					  
               </div>
        </nav><!--navbar end-->        
     </header><!--header end-->     

     <?php echo $__env->yieldContent('content'); ?>
       
    <!-- ===========================
    FOOTER START
    =========================== -->    
    <footer>
        <div class="container">
            <span class="bigicon icon-speedometer "></span>
             
            <div class="footerlinks"><!-- FOOTER LINKS START -->            
                <ul>

				    <?php echo $__env->yieldContent('footernavbar'); ?>
				
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
	
	<!--LoginForm Scripts-->
	<script src='/One_Market/public/js/LoginJquery.min.js'></script>
    <!--<script src='http://codepen.io/andytran/pen/vLmRVp.js'></script>-->

    <script src="/One_Market/public/js/index.js"></script>

    <script src="/One_Market/public/js/sidebar.js"></script>

    <script src = "//tinymce.cachefly.net/4.0/tinymce.min.js"></script>

    <script>
            tinymce.init({selector:'textarea'});
    </script>

    <!--Other necessary scripts-->
    <script src="/One_Market/public/js/jquery.nicescroll.min.js"></script>
    <script src="/One_Market/public/js/jquery.jribbble-1.0.1.ugly.js"></script>
    <script src="/One_Market/public/js/drifolio.js"></script>
    <script src="/One_Market/public/js/wow.min.js"></script>
    <script>new WOW().init();</script>
  </body>
</html>