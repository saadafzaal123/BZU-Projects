@extends('layouts.masterAdmin')

@section('title', 'ViewProfile')

@section('heading', 'Manage Your Content')

@section('content')

    <table width = "800" align = "left" border = "1" bgcolor="black" style = "color:white; font-size: 18px;">

        <tr>
            <td colspan = "6" align = "center"><h2>My Profile Here!</h2></td>
        </tr>

        <tr align = "center" style = "color:#FFFF00;">
            <th style = "padding: 15px;">id:</th>
            <th>Name:</th>
            <th>Password:</th>
            <th>Email:</th>
            <th>Edit</th>
        </tr>

        @foreach($getUser as $u)
            <tr style="text-align: center">

                <td>{{$u->id}}</td>
                <td>{{$u->name}}</td>
                <td>{{$password}}</td>
                <td>{{$u->email}}</td>

                <td><div id = "edit"><a href = "{{ URL::route('editProfile', array('id' => $u->id)) }}">Edit</a></div></td>
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
    <li><a href = "Admin_ViewPayments">View Payments</a></li>
    <li><a href = "Admin_ViewProfile" class = "selected">View Profile</a></li>
    <li><a href = "{{ URL::route('adminLogOut')}}">Admin Logout</a></li>

@endsection