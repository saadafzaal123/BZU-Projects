<?php
/**
 * Created by PhpStorm.
 * User: Saad Afzaal
 * Date: 8/3/2016
 * Time: 9:19 PM
 */

namespace App\Http\Controllers;

use App\Http\Controllers\Controller;
use Illuminate\Http\Request;
use App\Rent;
use App\Shop;
use DateTime;
use Session;

class RentController extends Controller
{
    public function showRents()
    {
        $rent = Rent::all();
        $shop = Shop::all();

        return view('Super_Admin/Admin_ViewShopRents' , array('rent'=>$rent , 'shop'=>$shop));
    }

    public function deleteRent($id)
    {

        $rent = Rent::find($id);

        $rent->delete();

        return redirect()-> route('Admin_ViewShopRents');
    }

    public function insertRent(Request $request)
    {
        $email = Session::get('email');

        if ($email != null)
        {
            $dt = new DateTime();

            $rent = new Rent();

            $getVendor = Shop::where('email' , $email)->first();

            $rent->Vendor_Name = $getVendor->id;
            $rent->Shop_Name = $getVendor->id;

            $rent->Shop_Rent = 500;
            $rent->Paid_Date = $dt->format('Y-m-d H:i:s');
            $rent->IsPaid = 'Yes';
            $rent->save();
            return redirect()->route('Vendor_MainArea');
        }
        else
        {
            return redirect()->route('Vendor_Login');
        }
    }
}