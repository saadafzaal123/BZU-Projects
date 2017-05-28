@extends('layouts.masterAdmin')

@section('title', 'ViewShopRents')

@section('heading', 'Manage Your Content')

@section('content')

   <table width = "800" align = "left" border = "1" bgcolor="black" style = "color:white; font-size: 18px">
      
	    <tr>
	        <td colspan = "10" align = "center"><h2>All Shops Rents Here!</h2></td>
	    </tr>
	  
	    <tr align = "center" style = "color:#FFFF00;">
		    <th style = "padding: 15px;">Id:</th>
		    <th>Vendor Name:</th>
			<th>Shop Name:</th>
		    <th>Shop_Rent:</th>
		    <th>Paid_Date:</th>
		    <th>IsPaid:</th>
		    <th>Delete</th>
	    </tr>

	   @foreach($rent as $r)
		   <tr style="text-align: center">

			   <td>{{$r->id}}</td>

			   <td>
			       @foreach($shop as $s)
				       @if($s->id == $r->Vendor_Name)
					       {{$s->username}}
				       @endif
			       @endforeach
               </td>

			   <td>
			       @foreach($shop as $s)
				       @if($s->id == $r->Shop_Name)
					       {{$s->shop_name}}
				       @endif
			       @endforeach
               </td>

			   <td>{{$r->Shop_Rent}}</td>
			   <td>{{$r->Paid_Date}}</td>
			   <td>{{$r->IsPaid}}</td>

			   <td><div id = "delete"><a href = "{{ URL::route('deleteRent', array('id' => $r->id)) }}">Delete</a></div></td>

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
	<li><a href = "Admin_ViewShopRents" class = "selected">View Shop Rents</a></li>
	<li><a href = "Admin_ViewCustomers">View Customers</a></li>
	<li><a href = "Admin_ViewOrders">View Orders</a></li>
	<li><a href = "Admin_ViewPayments">View Payments</a></li>
	<li><a href = "Admin_ViewProfile">View Profile</a></li>
	<li><a href = "{{ URL::route('adminLogOut')}}">Admin Logout</a></li>


@endsection