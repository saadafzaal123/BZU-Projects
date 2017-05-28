<?php
/**
 * Created by PhpStorm.
 * User: Saad Afzaal
 * Date: 8/30/2016
 * Time: 10:23 PM
 */

namespace App\Http\Controllers;

use App\Order;

class OrderController extends Controller
{
    public function adminViewOrders()
    {
        $order = Order::all();

        return view('Super_Admin/Admin_ViewOrders')->with('order' , $order);
    }

    public function adminDeleteOrder($id)
    {
        $order = Order::find($id);

        $order->delete();

        return redirect()->route('Admin_ViewOrders');
    }

    public function vendorDeleteOrder($id)
    {
        $order = Order::find($id);

        $order->delete();

        return redirect()->route('Vendor_MainArea');
    }
}