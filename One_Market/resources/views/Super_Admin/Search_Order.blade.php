@extends('layouts.masterAdmin')

@section('title', 'Search Order')

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

			<table width = "800" align = "left" border = "1" bgcolor="black" style = "color:white;">

				<tr>
					<td colspan = "10" align = "center"><h2>Search Orders Here!</h2></td>
				</tr>

				<tr align = "center" style = "color:#FFFF00;">
					<th>Order_Id:</th>
					<th>Product_Id:</th>
					<th>Customer_Id:</th>
					<th>Quantity:</th>
					<th>Amount:</th>
					<th>Order_Date:</th>
					<th>Delete</th>
				</tr>


				@foreach($order as $o)
					<tr style="text-align: center">

						<td>{{$o->id}}</td>
						<td>{{$o->product_id}}</td>
						<td>{{$o->customer_id}}</td>
						<td>{{$o->quantity}}</td>
						<td>{{$o->amount}}</td>
						<td>{{$o->order_date}}</td>
						<td><div id = "delete"><a href = "{{ URL::route('adminDeleteOrder', array('id' => $o->id)) }}">Delete</a></div></td>

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
	
