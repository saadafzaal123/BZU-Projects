<?php

namespace App\Http\Controllers;

use App\Customer;
use App\Cart;
use App\Order;
use App\Product;
use App\Payment;
use Illuminate\Http\Request;
use App\Http\Requests;
use Validator;
use Session;
use Crypt;
use DateTime;

class customerController extends Controller
{
    public function newLogin(Request $request)
    {
        $rules = array('username' => 'required|max:50' , 'password' => 'required|min:3|confirmed' ,
            'phone#' => 'required|max:30' , 'address' => 'required|max:255' , 'creditcart#' => 'required|max:255',
            'email' => 'required|email|max:255|unique:customers' , 'customerImage' => 'required');

        $validator = Validator::make($request->all() , $rules);

        if ($validator->fails())
        {
            return redirect()->route('Customer_Login')->withErrors($validator)->withInput($request->except('password'));;
        }
        else
        {
            if ($request->file('customerImage')->isValid())
            {
                $data = new Customer();
                $data->username = $request->get('username');
                $data->password = Crypt::encrypt($request->get('password'));
                $data->email = $request->get('email');
                $data->phoneNo = $request->get('phone#');
                $data->home_address = $request->get('address');
                $data->creditcartNo = $request->get('creditcart#');

                $destinationPath = '/public/customer_images';

                $extension = $request->file('customerImage')->getClientOriginalExtension(); // getting image extension
                $fileName = rand(11111, 99999) . '.' . $extension;
                $request->file('customerImage')->move(base_path() . $destinationPath, $fileName);
                $data->image = $fileName;

                $data->save();

                Session::put('c_email', $request->get('email'));

                return redirect()->route('Customer_MainArea');
            }
        }
    }

    public function showCustomer()
    {
        $email = Session::get('c_email');

        if ($email != null)
        {
            $customer = Customer::where('email' , $email)->first();

            $order = Order::all();

            $product = Product::all();

            return view('Customer/Customer_MainArea')->with('customer' , $customer)->with('order' , $order)->with('product' , $product);
        }
        else
        {
            return redirect()->route('Customer_Login');
        }
        
    }

    public function Customer_Login()
    {
        $email = Session::get('c_email');

        if ($email != null)
        {
            return redirect()->route('Customer_MainArea');
        }
        else
        {
            return view('Customer/Customer_Login');
        }

    }

    public function CustomerLogOut(Request $request)
    {
        Session::forget('c_email');
        return redirect()->route('Customer_Login');
    }


    public function CustomerLogin(Request $request)
    {
        $rules = array('email' => 'required|email|max:255' , 'password' => 'required|min:3');

        $validator = Validator::make($request->all() , $rules);

        if ($validator->fails())
        {
            return redirect()-> route('Customer_Login')->withErrors($validator)->withInput($request->except('password'));
        }
        else
        {
            $email = $request->get('email');
            $pass = $request->get('password');

            $Vendor = Customer::where('email' , $email)->first();

            $password = Crypt::decrypt($Vendor->password);

            if($password != $pass)
            {
                $rules = array( 'email' => 'exists:customers,email', 'password' => 'exists:customers,password');

                $validator = Validator::make($request->all() , $rules);

                if ($validator->fails())
                {
                    return redirect()->route('Customer_Login')->withErrors($validator)->withInput($request->except('password'));
                }
            }
            else
            {
                Session::put('c_email', $email);

                return redirect()->route('Customer_MainArea');
            }
        }
    }

    public function editCProfile($id)
    {
        $email = Session::get('c_email');

        if ($email != null)
        {
            $customer = Customer::findOrFail($id);

            return view('Customer/Customer_EditProfile')->with('customer', $customer);
        }
        else
        {
            return redirect()->route('Customer_Login');
        }
    }

    public function updateCProfile(Request $request , $id)
    {
        $email = Session::get('c_email');

        if ($email != null)
        {
            $rules = array('name' => 'required|max:50' , 'password' => 'required|min:3|confirmed' ,
                'phoneNo' => 'required|max:30' , 'address' => 'required|max:255' , 'creditcartNo' => 'required|max:255');

            $validator = Validator::make($request->all() , $rules);

            if ($validator->fails())
            {
                return redirect()->route('editCProfile' , array('id' => $id))->withErrors($validator)->withInput();
            }
            else
            {
                $s = Customer::find($id);

                $s->username = $request->get('name');
                $s->password = Crypt::encrypt($request->get('password'));
                $s->phoneNo = $request->get('phoneNo');
                $s->home_address = $request->get('address');
                $s->creditcartNo = $request->get('creditcartNo');

                if($request->file('customer_img') != null)
                {
                    if ($request->file('customer_img')->isValid())
                    {
                        $destinationPath = '/public/customer_images';

                        $extension = $request->file('customer_img')->getClientOriginalExtension(); // getting image extension
                        $fileName = rand(11111, 99999) . '.' . $extension;
                        $request->file('customer_img')->move(base_path() . $destinationPath, $fileName);
                        $s->image = $fileName;
                    }
                }

                $s->save();

                return redirect()->route('Customer_MainArea');
            }
        }
        else
        {
            return redirect()->route('Customer_Login');
        }
    }

    public function deleteCustomer($id)
    {
        $email = Session::get('c_email');

        if ($email != null)
        {
            $customer = Customer::find($id);

            $customer->delete();

            Session::forget('c_email');

            return redirect()->route('Customer_Login');
        }
        else
        {
            return redirect()->route('Customer_Login');
        }
    }

    public function adminViewCustomers()
    {
        $customer = Customer::all();

        return view('Super_Admin/Admin_ViewCustomers')->with('customer' , $customer);
    }

    public function adminDeleteCustomer($id)
    {
        $customer = Customer::find($id);

        $customer->delete();

        return redirect()->route('Admin_ViewCustomers');
    }

    public function customerCheckOut($id)
    {
        $email = Session::get('c_email');

        if ($email != null)
        {
            $cart = Cart::where('customer_id' , $id)->first();

            if($cart != null)
            {
                $customer = Customer::where('email' , $email)->first();
                $cart = Cart::where('customer_id' , $id)->get();
                $product = Product::all();

                $total = 0;

                foreach($cart as $c)
                {
                    foreach ($product as $p)
                    {
                        if ($c->p_id == $p->id)
                        {
                            $total += ($p->price * $c->quantity);
                        }
                    }
                }

                return view('Customer/Customer_Payment' , array('customer' => $customer , 'cart' => $cart ,
                    'product' => $product , 'total' => $total));
            }
            else
            {
                return redirect()->route('index');
            }
        }
        else
        {
            return redirect()->route('Customer_Login');
        }
    }

    public function customerPayment($id)
    {
        $email = Session::get('c_email');

        if ($email != null)
        {
            $dt = new DateTime();

            $cart = Cart::where('customer_id', $id)->get();

            foreach ($cart as $c)
            {
                $order = new Order();
                $order->product_id = $c->p_id;
                $order->customer_id = $c->customer_id;
                $order->quantity = $c->quantity;
                $order->amount = $c->quantity * $c->price;
                $order->order_date = $dt->format('Y-m-d H:i:s');

                $order->save();

                $payment = new Payment();

                $payment->customer_id = $c->customer_id;
                $payment->product_id = $c->p_id;
                $payment->amount = $c->quantity * $c->price;
                $payment->trx_id = rand(1000000000 , 9999999999);
                $payment->currency = "USD";
                $payment->payment_date = $dt->format('Y-m-d H:i:s');

                $payment->save();
            }

            foreach ($cart as $c)
            {
                $c->delete();
            }

            return redirect()->route('Customer_MainArea');
        }
        else
        {
            return redirect()->route('Customer_Login');
        }
    }
}
