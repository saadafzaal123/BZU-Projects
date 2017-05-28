@extends('layouts.masterAdmin')

@section('title', 'InsertNewMarket')

@section('heading', 'Manage Your Content')

@section('content')

    <div id = "SubmitButton">
        <form action = "{{route('insertMarket')}}" method = "POST" enctype = "multipart/form-data">

			<input type = "hidden" name ="_token" value = "{{csrf_token()}}">

            <table width = "800" align = "left" border = "1" bgcolor="white">
      
	            <tr>
	                <td colspan = "2" align = "center"><h2>Insert New Market:</h2></td>
	            </tr>
	  
	            <tr>
	                <th align = "right">Market Name</th>
	                <td><input type = "text" name = "name" size = "50" required = "required"/></td>
	            </tr>
	  
	            <tr>
	                <th align = "right">Market in City</th>
	                <td>
		                <select name = "city_id" required = "required" style = "padding:5px; font-size:15px;">
		                    <option>Select a City</option>

							@foreach($city as $c)
								{
								    <option value = "{{$c->id}}">{{$c->name}} </option>
								}
							@endforeach

			            </select> 
		            </td>
	            </tr>
	  
	            <tr>
	                <th align = "right">Market Image 1</th>
	                <td><input type = "file" name = "market_img1" required = "required" /></td>
	            </tr>
	  
	            <tr>
	                <th align = "right">Market Image 2</th>
	                <td><input type = "file" name = "market_img2" required = "required" /></td>
	            </tr>
	  
	            <tr>
	                <th align = "right">Market Image 3</th>
	                <td><input type = "file" name = "market_img3" required = "required" /></td>
	            </tr>
	  
	            <tr>
	                <th align = "right">Market Area</th>
	                <td><input type = "text" name = "area" size = "50" required = "required"/></td>
	            </tr>
	  
	            <tr>
	                <th align = "right">Market Description</th>
	                <td><textarea name = "description" cols = "35" rows = "10" ></textarea></td>
	            </tr>
	  
	            <tr>
	                <td colspan = "2" align = "center" height = "30"><strong><input type = "submit" name = "insert_market" value = "Insert Market" style = "Color:White; font-size:20px; padding:8px; width:100%"/></strong></td>
	            </tr>
	  
            </table>
        </form>
</div>

@endsection

@section('navbar')
	
	<li><a href = "Admin_Search">Search</a></li>
	<li><a href = "Admin_InsertNewCity">Insert New City</a></li>
	<li><a href = "Admin_ViewAllCities">View all Cites</a></li>
	<li><a href = "Admin_InsertNewMarket" class = "selected">Insert New Market</a></li>
	<li><a href = "Admin_ViewAllMarkets">View all Markets</a></li>
	<li><a href = "Admin_ViewAllShops">View all Shops</a></li>
	<li><a href = "Admin_ViewShopRents">View Shop Rents</a></li>
	<li><a href = "Admin_ViewCustomers">View Customers</a></li>
	<li><a href = "Admin_ViewOrders">View Orders</a></li>
	<li><a href = "Admin_ViewPayments">View Payments</a></li>
	<li><a href = "Admin_ViewProfile">View Profile</a></li>
	<li><a href = "{{ URL::route('adminLogOut')}}">Admin Logout</a></li>

@endsection