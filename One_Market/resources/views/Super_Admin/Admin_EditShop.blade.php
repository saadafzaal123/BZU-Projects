@extends('layouts.masterAdmin')

@section('title', 'EditShop')

@section('heading', 'Manage Your Content')

@section('content')

    <div id = "SubmitButton">

	    <form action = "{{route('updateShop' , array('id' => $s->id))}}" method = "POST" enctype = "multipart/form-data">

			<input type = "hidden" name ="_token" value = "{{csrf_token()}}">

            <table width = "800" align = "left" border = "1" bgcolor="white">
      
	            <tr>
	                <td colspan = "2" align = "center"><h2>Edit Shop :</h2></td>
	            </tr>
	  
	            <tr>
	                <th align = "right">Owner Name</th>
	                <td><input type = "text" name = "username" value = "{{$s->username}}" required = "required" size = "50"/></td>
	            </tr>
	  
	            <tr>
	                <th align = "right">Owner Password</th>
	                <td><input type = "text" name = "password" value = "{{Crypt::decrypt($s->password)}}" required = "required" size = "50"/></td>
	            </tr>
	  
	            <tr>
	                <th align = "right">Owner Phone#</th>
	                <td><input type = "text" name = "phone#" value = "{{$s->phoneNo}}" required = "required" size = "50"/></td>
	            </tr>
	  
	            <tr>
	                <th align = "right">Owner CreditCart#</th>
	                <td><input type = "text" name = "creditcart#" value = "{{$s->creditcartNo}}" required = "required" size = "50"/></td>
	            </tr>
	  
	            <tr>
	                <th align = "right">Owner Email</th>
	                <td><input type = "email" name = "email" value = "{{$s->email}}" required = "required" size = "50"/></td>
	            </tr>

				<tr>
					<th align = "right">Owner Home Address</th>
					<td><input type = "text" name = "address" value = "{{$s->address}}" required = "required" size = "50"/></td>
				</tr>
	  
	            <tr>
	                <th align = "right">Shop Name</th>
	                <td><input type = "text" name = "shop_name" value = "{{$s->shop_name}}" required = "required" size = "50"/></td>
	            </tr>
	  
	            <tr>
	                <th align = "right">Shop in Market</th>
	                <td>
		                <select name = "market_id" style = "padding:5px; font-size:15px;">
		                    <option>Select a Market</option>

							@foreach($market as $mk)
							{
								@foreach($city as $c)
								{
									@if($mk->city_id == $c->id)
								       <option value = "{{$mk->id}}" @if($mk->id == $m->id) {{"selected"}} @endif>{{$mk->name." in ".$c->name}}
								       </option>
									@endif
								}
								@endforeach
							}
							@endforeach

						</select>
		            </td>
	            </tr>
	  
	            <tr>
		            <td colspan = "2" align = "center" height = "30"><strong><input type = "submit" name = "update_shop" value = "Update Shop" style = "Color:White; font-size:20px; padding:8px; width:100%"/></strong></td>
	            </tr>
	  
            </table>
   
        </form>
    
	</div>

@endsection

@section('navbar')
	
	<li><a href = "/One_Market/public/Admin_Search">Search</a></li>
	<li><a href = "/One_Market/public/Admin_InsertNewCity">Insert New City</a></li>
	<li><a href = "/One_Market/public/Admin_ViewAllCities">View all Cites</a></li>
	<li><a href = "/One_Market/public/Admin_InsertNewMarket">Insert New Market</a></li>
	<li><a href = "/One_Market/public/Admin_ViewAllMarkets">View all Markets</a></li>
	<li><a href = "/One_Market/public/Admin_ViewAllShops">View all Shops</a></li>
	<li><a href = "/One_Market/public/Admin_ViewShopRents">View Shop Rents</a></li>
	<li><a href = "/One_Market/public/Admin_ViewCustomers">View Customers</a></li>
	<li><a href = "/One_Market/public/Admin_ViewOrders">View Orders</a></li>
	<li><a href = "/One_Market/public/Admin_ViewPayments">View Payments</a></li>
	<li><a href = "/One_Market/public/Admin_ViewProfile">View Profile</a></li>
	<li><a href = "{{ URL::route('adminLogOut')}}">Admin Logout</a></li>

@endsection