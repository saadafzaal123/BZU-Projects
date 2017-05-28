<?php
/**
 * Created by PhpStorm.
 * User: Saad Afzaal
 * Date: 8/31/2016
 * Time: 8:14 PM
 */

namespace App\Http\Controllers;

use App\Payment;

class PaymentController extends Controller
{
    public function adminViewPayments()
    {
        $payment = Payment::all();

        return view('Super_Admin/Admin_ViewPayments')->with('payment' , $payment);
    }

    public function adminDeletePayment($id)
    {
        $payment = Payment::find($id);

        $payment->delete();

        return redirect()->route('Admin_ViewPayments');
    }

    public function vendorDeletePayment($id)
    {
        $payment = Payment::find($id);

        $payment->delete();

        return redirect()->route('Vendor_MainArea');
    }
}