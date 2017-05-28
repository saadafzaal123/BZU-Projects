<?php
/**
 * Created by PhpStorm.
 * User: Saad Afzaal
 * Date: 8/2/2016
 * Time: 6:00 PM
 */

namespace App\Http\Controllers;

use App\Shop;
use App\Customer;
use App\Cart;
use App\Product;
use App\Http\Controllers\Controller;
use Illuminate\Http\Request;
use App\Market;
use App\City;
use Session;
use Validator;
use Crypt;

class ShopController extends Controller
{
    public function showdata()
    {
        $email = Session::get('email');

        if ($email != null)
        {
            return redirect()->route('Vendor_MainArea');
        }
        else
        {
            $market = Market::all();
            $city = City::all();

            return view('Vendor_Admin/Vendor_Login', array('market' => $market, 'city' => $city));
        }
    }

    public function insertShop(Request $request)
    {
        $rules = array('username' => 'required|max:50' , 'email' => 'required|email|unique:shops|max:255' ,
            'password' => 'required|min:3|confirmed' , 'phone#' => 'required|max:30' , 'address' => 'required|max:255' ,
            'creditcart#' => 'required|max:255' , 'shop_name' => 'required|max:255' , 'market_id' => 'required' ,
            'shop_img' => 'required');

        $validator = Validator::make($request->all() , $rules);

        if ($validator->fails())
        {
            return redirect()->route('Vendor_Login')->withErrors($validator)->withInput($request->except('password'));
        }
        else
        {
            if ($request->file('shop_img')->isValid())
            {
                $s = new Shop();
                $s->username = $request->get('username');
                $s->password = Crypt::encrypt($request->get('password'));
                $s->email = $request->get('email');
                $s->phoneNo = $request->get('phone#');
                $s->address = $request->get('address');
                $s->creditcartNo = $request->get('creditcart#');
                $s->shop_name = $request->get('shop_name');
                $s->market_id = $request->get('market_id');

                $destinationPath = '/public/shop_images';

                $extension = $request->file('shop_img')->getClientOriginalExtension(); // getting image extension
                $fileName = rand(11111, 99999) . '.' . $extension;
                $request->file('shop_img')->move(base_path() . $destinationPath, $fileName);
                $s->shop_image = $fileName;

                $s->save();

                Session::put('email', $request->get('email'));

                return redirect()->route('Vendor_Payment');
            }
        }
    }

    public function showShops()
    {
        $shop = Shop::all();
        $market = Market::all();
        $city = City::all();

        return view('Super_Admin/Admin_ViewAllShops' , array('shop'=>$shop , 'market'=>$market , 'city'=>$city));
    }

    public function deleteShop($id)
    {

        $shop = Shop::find($id);

        $shop->delete();

        return redirect()-> route('Admin_ViewAllShops');
    }

    public function editShop($id , $m_id)
    {
        $s = Shop::findOrFail($id);
        $m = Market::findOrFail($m_id);
        $market = Market::all();
        $city = City::all();

        return view('Super_Admin/Admin_EditShop')->with('s' , $s)->with('m' , $m)->with('market' , $market)->with('city' , $city);
    }

    public function updateShop(Request $request , $id)
    {
        $s = Shop::find($id);
        $s->username = $request->get('username');
        $s->password = Crypt::encrypt($request->get('password'));
        $s->phoneNo = $request->get('phone#');
        $s->creditcartNo = $request->get('creditcart#');
        $s->email = $request->get('email');
        $s->address = $request->get('address');
        $s->shop_name = $request->get('shop_name');
        $s->market_id = $request->get('market_id');
        $s->save();
        return redirect()->route('Admin_ViewAllShops');
    }

    public function getShops($id)
    {
        $shop = Shop::where('market_id','=',$id)->get();

        $market = Market::all();

        $city = City::all();

        $getMarket = Market::find($id);

        $v_email = Session::get('email');

        $vendor = Shop::where('email' , $v_email)->first();

        $email = Session::get('c_email');

        if ($email != null)
        {
            $customer = Customer::where('email' , $email)->first();
            $cart = Cart::where('customer_id' , $customer->id)->get();
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

            return view('shops', array('shop' => $shop, 'market' => $market, 'city' => $city, 'getMarket' => $getMarket , 'customer' => $customer , 'vendor' => $vendor ,
                'cart'=>$cart , 'product'=>$product , 'total'=>$total));
        }
        else
        {
            return view('shops', array('shop' => $shop, 'market' => $market, 'city' => $city, 'getMarket' => $getMarket , 'vendor' => $vendor));
        }
    }

    public function searchShop(Request $request , $m_id)
    {
        $words = $request->get('shop');

        $search = Shop::where('shop_name', 'like', '%' . $words . '%')->where('market_id', $m_id)->get();

        $city = City::all();

        $market = Market::all();

        $getMarket = Market::find($m_id);

        $v_email = Session::get('email');

        $vendor = Shop::where('email' , $v_email)->first();

        $email = Session::get('c_email');

        if ($email != null)
        {
            $customer = Customer::where('email' , $email)->first();
            $cart = Cart::where('customer_id' , $customer->id)->get();
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

            return view('searchShop', array('search' => $search, 'city' => $city, 'market' => $market, 'getMarket' => $getMarket , 'customer' => $customer , 'vendor' => $vendor ,
                'cart'=>$cart , 'product'=>$product , 'total'=>$total));
        }
        else
        {
            return view('searchShop', array('search' => $search, 'city' => $city, 'market' => $market, 'getMarket' => $getMarket , 'vendor' => $vendor));
        }
    }
}