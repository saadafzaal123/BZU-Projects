@extends('layouts.masterAdmin')

@section('title', 'ViewAllMarkets')

@section('heading', 'Manage Your Content')

@section('content')

    <table width = "800" align = "left" border = "1" bgcolor="black" style = "color:white; font-size: 18px;">
      
	    <tr>
	        <td colspan = "10" align = "center"><h2>All Markets Here!</h2></td>
	    </tr>
	  
	    <tr align = "center" style = "color:#FFFF00;">
		    <th style = "padding: 15px;">Market_id:</th>
		    <th>Market_Name:</th>
		    <th>Market_City:</th>
		    <th>Market_Area:</th>
		    <th>Market_Discription:</th>
		    <th>Edit</th>
		    <th>Delete</th>
	    </tr>

		@foreach($market as $m)
			<tr style="text-align: center">

				<td>{{$m->id}}</td>
				<td>{{$m->name}}</td>
				<td>
					@foreach($city as $c)
						@if($m->city_id == $c->id)
							{{$c->name}}
						@endif
                    @endforeach
				</td>

				<td>{{$m->area}}</td>
				<td>{{$m->description}}</td>

				<td><div id = "edit"><a href = "{{ URL::route('editMarket', array('id' => $m->id , 'c_id' => $m->city_id)) }}">Edit</a></div></td>
				<td><div id = "delete"><a href = "{{ URL::route('deleteMarket', array('id' => $m->id)) }}">Delete</a></div></td>

			</tr>
		@endforeach
	  
	</table>

@endsection

@section('navbar')
	
	<li><a href = "Admin_Search">Search</a></li>
	<li><a href = "Admin_InsertNewCity">Insert New City</a></li>
	<li><a href = "Admin_ViewAllCities">View all Cites</a></li>
	<li><a href = "Admin_InsertNewMarket">Insert New Market</a></li>
	<li><a href = "Admin_ViewAllMarkets" class = "selected">View all Markets</a></li>
	<li><a href = "Admin_ViewAllShops">View all Shops</a></li>
	<li><a href = "Admin_ViewShopRents">View Shop Rents</a></li>
	<li><a href = "Admin_ViewCustomers">View Customers</a></li>
	<li><a href = "Admin_ViewOrders">View Orders</a></li>
	<li><a href = "Admin_ViewPayments">View Payments</a></li>
	<li><a href = "Admin_ViewProfile">View Profile</a></li>
	<li><a href = "{{ URL::route('adminLogOut')}}">Admin Logout</a></li>

@endsection