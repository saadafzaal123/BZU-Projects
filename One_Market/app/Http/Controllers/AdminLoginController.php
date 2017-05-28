<?php
/**
 * Created by PhpStorm.
 * User: Saad Afzaal
 * Date: 8/15/2016
 * Time: 9:25 PM
 */

namespace App\Http\Controllers;

use App\City;
use App\Customer;
use App\Payment;
use App\Rent;
use App\Shop;
use App\User;
use App\Market;
use App\Order;
use Illuminate\Http\Request;
use App\Http\Controllers\Controller;
use Validator;
use Auth;
use Session;
use Crypt;

class AdminLoginController extends Controller
{
    public function doLogin(Request $request)
    {
        $rules = array('email' => 'required|email|max:255' , 'password' => 'required|min:3');

        $validator = Validator::make($request->all() , $rules);

        if ($validator->fails())
        {
            return view('Super_Admin/Admin_Login')->withErrors($validator)->withInput($request->except('password'));
        }
        else
        {
            $admindata = array(
                'email'     => $request->get('email'),
                'password'  => $request->get('password')
            );


            if (Auth::attempt($admindata))
            {
                //$user = Auth::user();
                //Session::put('emails', $user->email);

                return view('Super_Admin/Admin_Welcome');
            }
            else
            {
                $rules = array( 'email' => 'exists:users,email', 'password' => 'exists:users,password');

                $validator = Validator::make($request->all() , $rules);

                if ($validator->fails())
                {
                    return view('Super_Admin/Admin_Login')->withErrors($validator)->withInput($request->except('password'));
                }
            }
        }
    }

    public function adminLogOut(Request $request)
    {
        Auth::logout(); // log the user out of our application
        return redirect()-> route('Admin_Login');
    }

    public function LoginCheck()
    {
        if (Auth::check())
        {
            return view('Super_Admin/Admin_Welcome');
        }
        else
        {
            return view('Super_Admin/Admin_Login');
        }
    }

    public function GetUser()
    {
        if (Auth::check())
        {
            $email = Auth::user()->email;
            $id = Auth::id();

            $pass = Auth::user()->cypher_password;

            $password = Crypt::decrypt($pass);
            $getUser = User::where('id' , $id)->where('email' , $email)->get();

            return view('Super_Admin/Admin_ViewProfile')->with('getUser' , $getUser)->with('password' , $password);
        }
        else
        {
            return view('Super_Admin/Admin_Login');
        }
    }

    public function editProfile($id)
    {
        $admin = User::findOrFail($id);

        return view('Super_Admin/Admin_EditProfile')->with('admin',$admin);
    }

    public function updateProfile(Request $request , $id)
    {
        $rules = array('name' => 'required|max:50' , 'email' => 'required|email|max:255' ,
            'password' => 'required|min:6|confirmed');

        $validator = Validator::make($request->all() , $rules);

        if ($validator->fails())
        {
            return redirect()->route('editProfile' , array('id' => $id))->withErrors($validator)->withInput($request->except('password'));
        }
        else 
        {
            $admin = User::find($id);
            $admin->name = $request->get('name');
            $admin->password = bcrypt($request->get('password'));
            $admin->cypher_password = Crypt::encrypt($request->get('password'));
            $admin->email = $request->get('email');
            $admin->save();
            return redirect()->route('Admin_ViewProfile');
        }
    }

    public function searchAdmin(Request $request)
    {
        $search_type = $request->get('search_type');
        $search = $request->get('search');
        $datetime = $request->get('datetime');

        if($search_type != null )
        {
            if($search_type == "C" && $search != null)
            {
                $city = City::where('id' , $search)->orWhere('name', 'like', '%' . $search . '%')->get();

                return view('Super_Admin/Search_City')->with('city' , $city);
            }

            if($search_type == "M" && $search != null)
            {
                $market = Market::where('id' , $search)->orWhere('name', 'like', '%' . $search . '%')->get();

                $city = City::all();

                return view('Super_Admin/Search_Market')->with('market' , $market)->with('city' , $city);
            }

            if($search_type == "S" && $search != null)
            {
                $shop = Shop::where('id' , $search)->orWhere('username', 'like', '%' . $search . '%')->get();

                $city = City::all();
                $market = Market::all();

                return view('Super_Admin/Search_Shop')->with('shop' , $shop)->with('city' , $city)->with('market' , $market);
            }

            if($search_type == "R" && $search != null)
            {
                $rent = Rent::where('Vendor_Name' , $search)->orWhere('Shop_Name', $search)->get();

                $shop = Shop::all();

                return view('Super_Admin/Search_Rent')->with('rent' , $rent)->with('shop' , $shop);
            }

            if($search_type == "Cu" && $search != null)
            {
                $customer = Customer::where('id' , $search)->orWhere('username', 'like', '%' . $search . '%')->get();

                return view('Super_Admin/Search_Customer')->with('customer' , $customer);
            }

            if($search_type == "O")
            {
                if($datetime != null)
                {
                    $order = Order::where('order_date', 'like', '%' . $datetime . '%')->get();

                    return view('Super_Admin/Search_Order')->with('order', $order);
                }

                if($search != null)
                {
                    $order = Order::where('customer_id', $search)->get();

                    return view('Super_Admin/Search_Order')->with('order', $order);
                }

                else
                {
                    return view('Super_Admin/Admin_Search');
                }
            }

            if($search_type == "P")
            {
                if($datetime != null)
                {
                    $payment = Payment::where('payment_date', 'like', '%' . $datetime . '%')->get();

                    return view('Super_Admin/Search_Payment')->with('payment', $payment);
                }
                if($search != null)
                {
                    $payment = Payment::where('customer_id', $search)->get();

                    return view('Super_Admin/Search_Payment')->with('payment', $payment);
                }

                else
                {
                    return view('Super_Admin/Admin_Search');
                }
            }

            else
            {
                return view('Super_Admin/Admin_Search');
            }
        }
        else
        {
            return view('Super_Admin/Admin_Search');
        }
    }
}