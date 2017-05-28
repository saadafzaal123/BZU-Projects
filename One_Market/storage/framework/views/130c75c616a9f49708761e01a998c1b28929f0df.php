<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
        <title>Admin <?php echo $__env->yieldContent('title'); ?></title>

		<script src = "//tinymce.cachefly.net/4.0/tinymce.min.js"></script>
        
		<script>
            tinymce.init({selector:'textarea'});
        </script>
        
		<link rel = "stylesheet" href = "/One_Market/public/styles/admin_area_style.css"/>
        <link rel = "stylesheet" href = "/One_Market/public/styles/LoginForm.css"/>
    </head>

    <body bgcolor = "" style = "background-image:url(/One_Market/public/styles/background.jpg);">

        <div id = "container">

            <div id = "mian_heading">
                <img src = "/One_Market/public/styles/login_3.jpg" style = "float:left" width = '180' height = '100' />
                <img src = "/One_Market/public/styles/login_1.jpg" style = "float:right" width = '180' height = '100' />
                <h1><?php echo $__env->yieldContent('heading'); ?></h1>
            </div>
   
            <?php echo $__env->yieldContent('content'); ?>
			
			<div id = "right_content">
	            
				<h3>Manage Content</h3>
	   
	            <div id = "navbar">
			    
				    <ul id = "menu">
					
					<?php echo $__env->yieldContent('navbar'); ?>
				     
			        </ul>
					
	            </div>
	   
            </div>
      
	        <div class = "footer">
	  
	            <img src = "/One_Market/public/styles/saad.jpg" style = "float:left" width = '180' height = '100' />
		        <img src = "/One_Market/public/styles/saad1.png" style = "float:right" width = '180' height = '97' />
		        <h3 style = "color:#FFFFFF; padding-top:20px; text-align:center;">&copy; 2016 - By (www.OneMarket.com)</h3>
			
	        </div>
	  
        </div>
		
</body>
</html>