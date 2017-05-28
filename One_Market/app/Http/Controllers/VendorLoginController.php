<?php
/**
 * Created by PhpStorm.
 * User: Saad Afzaal
 * Date: 8/16/2016
 * Time: 11:10 PM
 */

namespace App\Http\Controllers;

use App\Brand;
use App\Category;
use App\Customer;
use App\Order;
use App\User;
use App\Shop;
use App\Market;
use App\City;
use App\Product;
use App\Payment;
use Illuminate\Http\Request;
use App\Http\Controllers\Controller;
use Validator;
use Auth;
use Session;
use Crypt;

class VendorLoginController extends Controller
{
    public function VendorLogin(Request $request)
    {
        $rules = array('email' => 'required|email|max:255' , 'password' => 'required|min:3');

        $validator = Validator::make($request->all() , $rules);

        if ($validator->fails())
        {
            return redirect()-> route('Vendor_Login')->withErrors($validator)->withInput($request->except('password'));
        }
        else
        {
            $email = $request->get('email');
            $pass = $request->get('password');

            $Vendor = Shop::where('email' , $email)->first();

            $password = Crypt::decrypt($Vendor->password);

            if($password != $pass)
            {
                $rules = array( 'email' => 'exists:shops,email', 'password' => 'exists:shops,password');

                $validator = Validator::make($request->all() , $rules);

                if ($validator->fails())
                {
                    return redirect()->route('Vendor_Login')->withErrors($validator)->withInput($request->except('password'));
                }
            }
            else
            {
                Session::put('email', $email);

                return redirect()->route('Vendor_MainArea');
            }
        }
    }

    public function VendorLogOut(Request $request)
    {
        //$request->session()->flush();
        
        Session::forget('email');
        return redirect()->route('Vendor_Login');
    }

    public function VendorPayment()
    {
        $email = Session::get('email');

        if ($email != null)
        {
            return view('Vendor_Admin/Vendor_Payment');
        }
        else
        {
            return redirect()->route('Vendor_Login');
        }
    }

    public function editVProfile($id)
    {
        $email = Session::get('email');

        if ($email != null)
        {
            $vendor = Shop::findOrFail($id);

            $market = Market::all();
            $city = City::all();

            return view('Vendor_Admin/Vendor_EditProfile')->with('vendor', $vendor)->with('market', $market)->with('city', $city);
        }
        else
        {
            return redirect()->route('Vendor_Login');
        }
    }

    public function updateVProfile(Request $request , $id)
    {
        $email = Session::get('email');

        if ($email != null)
        {
            $rules = array('name' => 'required|max:50' , 'password' => 'required|min:3|confirmed' ,
                'phoneNo' => 'required|max:30' , 'address' => 'required|max:255' , 'creditcartNo' => 'required|max:255',
                'shop_name' => 'required|max:255' , 'market_id' => 'required');

            $validator = Validator::make($request->all() , $rules);

            if ($validator->fails())
            {
                return redirect()->route('editVProfile' , array('id' => $id))->withErrors($validator)->withInput();
            }
            else
            {
                $s = Shop::find($id);

                $s->username = $request->get('name');
                $s->password = Crypt::encrypt($request->get('password'));
                $s->phoneNo = $request->get('phoneNo');
                $s->address = $request->get('address');
                $s->creditcartNo = $request->get('creditcartNo');
                $s->shop_name = $request->get('shop_name');
                $s->market_id = $request->get('market_id');

                if($request->file('shop_img') != null)
                {
                    if ($request->file('shop_img')->isValid())
                    {
                        $destinationPath = '/public/shop_images';

                        $extension = $request->file('shop_img')->getClientOriginalExtension(); // getting image extension
                        $fileName = rand(11111, 99999) . '.' . $extension;
                        $request->file('shop_img')->move(base_path() . $destinationPath, $fileName);
                        $s->shop_image = $fileName;
                    }
                }

                $s->save();

                return redirect()->route('Vendor_MainArea');
            }
        }
        else
        {
            return redirect()->route('Vendor_Login');
        }
    }

    public function searchVendor(Request $request)
    {
        $email = Session::get('email');

        if ($email != null)
        {
            $search_type = $request->get('search_type');
            $search = $request->get('search');
            $datetime = $request->get('datetime');

            if($search_type != null )
            {
                if($search_type == "P" && $search != null)
                {
                    $product = Product::where('id' , $search)->orWhere('keywords', 'like', '%' . $search . '%')->get();

                    return view('Vendor_Admin/Search_Product')->with('product' , $product);
                }

                if($search_type == "C" && $search != null)
                {
                    $cat = Category::where('id' , $search)->orWhere('name', 'like', '%' . $search . '%')->get();

                    return view('Vendor_Admin/Search_Category')->with('cat' , $cat);
                }

                if($search_type == "B" && $search != null)
                {
                    $brand = Brand::where('id' , $search)->orWhere('name', 'like', '%' . $search . '%')->get();

                    return view('Vendor_Admin/Search_Brand')->with('brand' , $brand);
                }

                if($search_type == "Cu" && $search != null)
                {
                    $customer = Customer::where('id' , $search)->orWhere('username', 'like', '%' . $search . '%')->get();

                    return view('Vendor_Admin/Search_Customer')->with('customer' , $customer);
                }

                if($search_type == "O")
                {
                    if($datetime != null)
                    {
                        $getVendor = Shop::where('email' , $email)->first();

                        $product = Product::where('vendor_id' , $getVendor->id)->get();

                        $order = Order::where('order_date', 'like', '%' . $datetime . '%')->get();

                        return view('Vendor_Admin/Search_Order')->with('order', $order)->with('product' , $product);
                    }
                    if($search != null)
                    {
                        $getVendor = Shop::where('email' , $email)->first();

                        $product = Product::where('vendor_id' , $getVendor->id)->get();

                        $order = Order::where('customer_id', $search)->get();

                        return view('Vendor_Admin/Search_Order')->with('order', $order)->with('product' , $product);
                    }

                    else
                    {
                        return redirect()->route('Vendor_MainArea');
                    }
                }

                if($search_type == "Pay")
                {
                    if($datetime != null)
                    {
                        $getVendor = Shop::where('email' , $email)->first();

                        $product = Product::where('vendor_id' , $getVendor->id)->get();

                        $payment = Payment::where('payment_date', 'like', '%' . $datetime . '%')->get();

                        return view('Vendor_Admin/Search_Payment')->with('payment', $payment)->with('product' , $product);
                    }
                    if($search != null)
                    {
                        $getVendor = Shop::where('email' , $email)->first();

                        $product = Product::where('vendor_id' , $getVendor->id)->get();

                        $payment = Payment::where('customer_id', $search)->get();

                        return view('Vendor_Admin/Search_Payment')->with('payment', $payment)->with('product' , $product);
                    }

                    else
                    {
                        return redirect()->route('Vendor_MainArea');
                    }
                }

                else
                {
                    return redirect()->route('Vendor_MainArea');
                }
            }
            else
            {
                return redirect()->route('Vendor_MainArea');
            }
        }
        else
        {
            return redirect()->route('Vendor_Login');
        }
    }
}