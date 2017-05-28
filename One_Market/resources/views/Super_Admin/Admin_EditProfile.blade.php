@extends('layouts.masterAdmin')

@section('title', 'EditProfile')

@section('heading', 'Manage Your Content')

@section('content')

    <div id = "SubmitButton">
        
		<form action = "{{route('updateProfile' , array('id' => $admin->id))}}" method = "POST" enctype = "multipart/form-data">

			<input type = "hidden" name ="_token" value = "{{csrf_token()}}">

            <table width = "800" align = "left" border = "1" bgcolor="white">
      
	            <tr>
	                <td colspan = "2" align = "center"><h2>Edit Profile:</h2></td>
	            </tr>
	  
	            <tr>
	                <th align = "right">Name</th>
	                <td><input type = "text" name = "name" value = "{{$admin->name}}" required = "required" size = "50"/></td>
	            </tr>

                @if ($errors->has('name'))
                    <tr>
                        <th align = "right" style = "color: red;">Name Error</th>
                        <td style = "color: red;"><strong>{{ $errors->first('name') }}</strong></td>
                    </tr>
                @endif

                <tr>
                    <th align = "right">Password</th>
                    <td><input type = "text" name = "password" value = "{{Crypt::decrypt($admin->cypher_password)}}" required = "required" size = "50"/></td>
                </tr>

                @if ($errors->has('password'))
                    <tr>
                        <th align = "right" style = "color: red;">Password Error</th>
                        <td style = "color: red;"><strong>{{ $errors->first('password') }}</strong></td>
                    </tr>
                @endif

                <tr>
                    <th align = "right">Confirm Password</th>
                    <td><input type = "text" name = "password_confirmation" value = "{{Crypt::decrypt($admin->cypher_password)}}" required = "required" size = "50"/></td>
                </tr>

                @if ($errors->has('password_confirmation'))
                    <tr>
                        <th align = "right" style = "color: red;">Paasword Confirmation Error</th>
                        <td style = "color: red;"><strong>{{ $errors->first('password_confirmation') }}</strong></td>
                    </tr>
                @endif

                <tr>
                    <th align = "right">Email</th>
                    <td><input type = "text" name = "email" value = "{{$admin->email}}" required = "required" size = "50"/></td>
                </tr>

                @if ($errors->has('email'))
                    <tr>
                        <th align = "right" style = "color: red;">Email Error</th>
                        <td style = "color: red;"><strong>{{ $errors->first('email') }}</strong></td>
                    </tr>
                @endif

	            <tr>
		            <td colspan = "2" align = "center" height = "30"><strong><input type = "submit" name = "update_profile" value = "Update Profile" style = "Color:White; font-size:20px; padding:8px; width:100%"/></strong></td>
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