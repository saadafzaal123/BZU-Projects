@extends('layouts.masterAdmin')

@section('title', 'ViewPayments')

@section('heading', 'Manage Your Content')

@section('content')

    <table width = "800" align = "left" border = "1" bgcolor="black" style = "color:white;">
      
	    <tr>
	        <td colspan = "10" align = "center"><h2>All Payments Here!</h2></td>
	    </tr>
	  
	    <tr align = "center" style = "color:#FFFF00;">
		    <th>Payment_Id:</th>
		    <th>Customer_Id:</th>
		    <th>Product_Id:</th>
		    <th>Amount:</th>
		    <th>Trx_Id:</th>
		    <th>Currency:</th>
		    <th>Payment_Date:</th>
		    <th>Delete</th>
	    </tr>

		@foreach($payment as $p)
			<tr style="text-align: center">

				<td>{{$p->id}}</td>
				<td>{{$p->customer_id}}</td>
				<td>{{$p->product_id}}</td>
				<td>{{$p->amount}}</td>
				<td>{{$p->trx_id}}</td>
				<td>{{$p->currency}}</td>
				<td>{{$p->payment_date}}</td>
				<td><div id = "delete"><a href = "{{ URL::route('adminDeletePayment', array('id' => $p->id)) }}">Delete</a></div></td>

			</tr>
		@endforeach
	  
	</table>

@endsection

@section('navbar')
	
	<li><a href = "Admin_Search">Search</a></li>
	<li><a href = "Admin_InsertNewCity">Insert New City</a></li>
	<li><a href = "Admin_ViewAllCities">View all Cites</a></li>
	<li><a href = "Admin_InsertNewMarket">Insert New Market</a></li>
	<li><a href = "Admin_ViewAllMarkets">View all Markets</a></li>
	<li><a href = "Admin_ViewAllShops">View all Shops</a></li>
	<li><a href = "Admin_ViewShopRents">View Shop Rents</a></li>
	<li><a href = "Admin_ViewCustomers">View Customers</a></li>
	<li><a href = "Admin_ViewOrders">View Orders</a></li>
	<li><a href = "Admin_ViewPayments" class = "selected">View Payments</a></li>
	<li><a href = "Admin_ViewProfile">View Profile</a></li>
	<li><a href = "{{ URL::route('adminLogOut')}}">Admin Logout</a></li>

@endsection