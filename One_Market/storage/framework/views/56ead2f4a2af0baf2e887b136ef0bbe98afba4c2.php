<?php $__env->startSection('title', 'Activity'); ?>

<?php $__env->startSection('heading', 'Manage Your Content'); ?>

<?php $__env->startSection('content'); ?>

    <div id = "SubmitButton">

	    <form action = "" method = "POST" enctype = "multipart/form-data">

            <table width = "800" align = "left" border = "1" bgcolor="white">
      
	            <tr>
	                <td colspan = "2" align = "center"><h2>Edit Shop Owner:</h2></td>
	            </tr>
	  
	            <tr>
	                <th align = "right">Owner Name</th>
	                <td><input type = "text" name = "owner_name" value = "" required = "required" size = "50"/></td>
	            </tr>
	  
	            <tr>
	                <th align = "right">Owner Password</th>
	                <td><input type = "text" name = "owner_password" value = "" required = "required" size = "50"/></td>
	            </tr>
	  
	            <tr>
	                <th align = "right">Owner Phone#</th>
	                <td><input type = "text" name = "owner_phone#" value = "" required = "required" size = "50"/></td>
	            </tr>
	  
	            <tr>
	                <th align = "right">Owner CreditCart#</th>
	                <td><input type = "text" name = "owner_creaditcart#" value = "" required = "required" size = "50"/></td>
	            </tr>
	  
	            <tr>
	                <th align = "right">Owner Email</th>
	                <td><input type = "text" name = "owner_Email" value = "" required = "required" size = "50"/></td>
	            </tr>

				<tr>
					<th align = "right">Owner Home Address</th>
					<td><input type = "text" name = "owner_address" value = "" required = "required" size = "50"/></td>
				</tr>
	  
	            <tr>
	                <th align = "right">Shop Name</th>
	                <td><input type = "text" name = "shop_name" value = "" required = "required" size = "50"/></td>
	            </tr>
	  
	            <tr>
	                <th align = "right">Shop in Market</th>
	                <td>
		                <select name = "market" style = "padding:5px; font-size:15px;">
		                    <option>Select a Market</option>
			  
			            </select> 
		            </td>
	            </tr>
	  
	            <tr>
	                <th align = "right">Market in City</th>
	                <td>
		                <select name = "city" style = "padding:5px; font-size:15px;">
		                    <option>Select a City</option>
			  
			            </select> 
		            </td>
	            </tr>
	  
	            <tr>
		            <td colspan = "2" align = "center" height = "30"><strong><input type = "submit" name = "update_shop_owner" value = "Update Shop Owner" style = "Color:White; font-size:20px; padding:8px; width:100%"/></strong></td>
	            </tr>
	  
            </table>
   
        </form>
    
	</div>

<?php $__env->stopSection(); ?>

<?php $__env->startSection('navbar'); ?>
	
	<li><a href = "Admin_Search">Search</a></li>
	<li><a href = "Admin_InsertNewCity">Insert New City</a></li>
	<li><a href = "Admin_ViewAllCities">View all Cites</a></li>
	<li><a href = "Admin_InsertNewMarket">Insert New Market</a></li>
	<li><a href = "Admin_ViewAllMarkets">View all Markets</a></li>
	<li><a href = "Admin_ViewAllShops">View all Shops</a></li>
	<li><a href = "Admin_ViewShopRents">View Shop Rents</a></li>
	<li><a href = "Admin_ViewCustomers">View Customers</a></li>
	<li><a href = "Admin_ViewOrders">View Orders</a></li>
	<li><a href = "Admin_ViewPayments">View Payments</a></li>
	<li><a href = "#">Admin Logout</a></li>

<?php $__env->stopSection(); ?>
<?php echo $__env->make('layouts.masterAdmin', array_except(get_defined_vars(), array('__data', '__path')))->render(); ?>