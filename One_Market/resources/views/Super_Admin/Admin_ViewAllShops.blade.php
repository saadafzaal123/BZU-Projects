@extends('layouts.masterAdmin')

@section('title', 'ViewAllShops')

@section('heading', 'Manage Your Content')

@section('content')

    <table width = "800" align = "left" border = "1" bgcolor="black" style = "color:white; font-size: 16px;">
      
	    <tr>
	        <td colspan = "11" align = "center"><h2>All Shops Here!</h2></td>
	    </tr>
	  
	    <tr align = "center" style = "color:#FFFF00;">
			<th>id:</th>
		    <th>Name:</th>
		    <th>Password:</th>
		    <th>Phone#:</th>
	 	    <th>CreditCart#:</th>
		    <th>Email:</th>
		    <th>Market:</th>
		    <th>Shop_Name:</th>
	 	    <th>Edit</th>
		    <th>Delete</th>
	    </tr>

		@foreach($shop as $s)
			<tr style="text-align: center">

				<td>{{$s->id}}</td>
				<td>{{$s->username}}</td>
				<td>{{Crypt::decrypt($s->password)}}</td>
				<td>{{$s->phoneNo}}</td>
				<td>{{$s->creditcartNo}}</td>
				<td>{{$s->email}}</td>

				<td>
					@foreach($market as $m)
						@if($s->market_id == $m->id)
							@foreach($city as $c)
								@if($m->city_id == $c->id)
									{{$m->name.' in '.$c->name}}
								@endif
							@endforeach
						@endif
					@endforeach
				</td>

				<td>{{$s->shop_name}}</td>
				<td><div id = "edit"><a href = "{{ URL::route('editShop', array('id' => $s->id , 'm_id' => $s->market_id)) }}">Edit</a></div></td>
				<td><div id = "delete"><a href = "{{ URL::route('deleteShop', array('id' => $s->id)) }}">Delete</a></div></td>

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
	<li><a href = "Admin_ViewAllShops" class = "selected">View all Shops</a></li>
	<li><a href = "Admin_ViewShopRents">View Shop Rents</a></li>
	<li><a href = "Admin_ViewCustomers">View Customers</a></li>
	<li><a href = "Admin_ViewOrders">View Orders</a></li>
	<li><a href = "Admin_ViewPayments">View Payments</a></li>
	<li><a href = "Admin_ViewProfile">View Profile</a></li>
	<li><a href = "{{ URL::route('adminLogOut')}}">Admin Logout</a></li>

@endsection