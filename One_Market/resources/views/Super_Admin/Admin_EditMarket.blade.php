@extends('layouts.masterAdmin')

@section('title', 'EditMarket')

@section('heading', 'Manage Your Content')

@section('content')

    <div id = "SubmitButton">
        
		<form action = "{{route('updateMarket' , array('id' => $m->id))}}" method = "POST" enctype = "multipart/form-data">

			<input type = "hidden" name ="_token" value = "{{csrf_token()}}">

            <table width = "800" align = "left" border = "1" bgcolor="white">
      
	            <tr>
	                <td colspan = "2" align = "center"><h2>Edit Market:</h2></td>
	            </tr>
	  
	            <tr>
	                <th align = "right">Market Name</th>
	                <td><input type = "text" name = "name" value = "{{$m->name}}" required = "required" size = "50"/></td>
	            </tr>
	  
	            <tr>
	                <th align = "right">Market in City</th>
	                <td>
		                <select name = "city_id" style = "padding:5px; font-size:15px;">
		                    <option>Select a City</option>

							@foreach($city as $ct)
								{
								    <option value = "{{$ct->id}}" @if($ct->id == $c->id) {{"selected"}} @endif>{{$ct->name}}
								    </option>
								}
							@endforeach
			  
			            </select> 
		            </td>
	            </tr>
	  
	            <tr>
	                <th align = "right">Market Area</th>
	                <td><input type = "text" name = "area" value = "{{$m->area}}" required = "required" size = "50"/></td>
	            </tr>
	  
	            <tr>
	                <th align = "right">Market Discription</th>
		            <td><textarea name = "description" cols = "35" rows = "10" required = "required" >{{$m->description}}</textarea></td>
	            </tr>
	  
	            <tr>
		            <td colspan = "2" align = "center" height = "30"><strong><input type = "submit" name = "update_market" value = "Update Market" style = "Color:White; font-size:20px; padding:8px; width:100%"/></strong></td>
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