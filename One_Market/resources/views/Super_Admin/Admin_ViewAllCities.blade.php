@extends('layouts.masterAdmin')

@section('title', 'ViewAllCities')

@section('heading', 'Manage Your Content')

@section('content')

    <table width = "800" align = "left" border = "1" bgcolor="black" style = "color:white; font-size: 18px;">
      
	    <tr>
	        <td colspan = "6" align = "center"><h2>All Cities Here!</h2></td>
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

@endsection

@section('navbar')
	
	<li><a href = "Admin_Search">Search</a></li>
	<li><a href = "Admin_InsertNewCity">Insert New City</a></li>
	<li><a href = "Admin_ViewAllCities" class = "selected">View all Cites</a></li>
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