@extends('layouts.masterAdmin')

@section('title', 'Search City')

@section('heading', 'Manage Your Content')

@section('content')

    <div id = "searching"> 
	    <form action = "{{route('searchAdmin')}}" method = "POST">

			<input type = "hidden" name ="_token" value = "{{csrf_token()}}">

	        <strong><select id = "search_type" name = "search_type">
	            <option value = ""> Select Search Type</option>
	            <option value = "C">Search a City</option>
	            <option value = "M">Search a Market</option>
	            <option value = "S">Search a Shop</option>
	            <option value = "R">Search a Shop Rents</option>
	            <option value = "Cu">Search a Customer</option>
	            <option value = "O">Search a Order</option>
	            <option value = "P">Search a Payment</option>
	        </select></strong>
	 
	        <input type = "text" id = "search" name = "search" placeholder = "Search" />
	 
	        <!--<button>Search</button>-->

			<input type="date"  name = "datetime"/>

	        <strong><input type = "submit" value = "Click to Search"></strong>

	    </form>
	 
	    <div id = "table" style = "margin-top:10px;">

			<table width = "800" align = "left" border = "1" bgcolor="black" style = "color:white; font-size: 18px;">

				<tr>
					<td colspan = "6" align = "center"><h2>Search Cities Here!</h2></td>
				</tr>

				<tr align = "center" style = "color:#FFFF00;">
					<th style = "padding: 15px;">City_id:</th>
					<th>City_Name:</th>
					<th>City_Discription:</th>
					<th>Edit</th>
					<th>Delete</th>
				</tr>

				@foreach($city as $c)
					<tr style="text-align: center">

						<td>{{$c->id}}</td>
						<td>{{$c->name}}</td>
						<td>{{$c->description}}</td>

						<td><div id = "edit"><a href = "{{ URL::route('editCity', array('id' => $c->id)) }}">Edit</a></div></td>
						<td><div id = "delete"><a href = "{{ URL::route('deleteCity', array('id' => $c->id)) }}">Delete</a></div></td>

					</tr>
				@endforeach

			</table>

	    </div>
	
	</div>

@endsection	

@section('navbar')
	
	<li><a href = "Admin_Search" class = "selected">Search</a></li>
	<li><a href = "Admin_InsertNewCity">Insert New City</a></li>
	<li><a href = "Admin_ViewAllCities">View all Cites</a></li>
	<li><a href = "Admin_InsertNewMarket">Insert New Market</a></li>
	<li><a href = "Admin_ViewAllMarkets">View all Markets</a></li>
	<li><a href = "Admin_ViewAllShops">View all Shops</a></li>
	<li><a href = "Admin_ViewShopRents">View Shop Rents</a></li>
	<li><a href = "Admin_ViewCustomers">View Customers</a></li>
	<li><a href = "Admin_ViewOrders">View Orders</a></li>
	<li><a href = "Admin_ViewPayments">View Payments</a></li>
	<li><a href = "Admin_ViewProfile">View Profile</a></li>
	<li><a href = "{{ URL::route('adminLogOut')}}">Admin Logout</a></li>

@endsection
	
