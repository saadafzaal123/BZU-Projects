<?php
/**
 * Created by PhpStorm.
 * User: Saad Afzaal
 * Date: 8/1/2016
 * Time: 12:22 AM
 */

namespace App\Http\Controllers;

use App\Market;
use App\City;
use App\Customer;
use App\Cart;
use App\Product;
use App\Shop;
use App\Http\Controllers\Controller;
use Illuminate\Http\Request;
use Session;

class MarketController extends Controller
{
    public function insertMarket(Request $request)
    {
        if ($request->file('market_img1')->isValid() && $request->file('market_img2')->isValid() && $request->file('market_img3')->isValid()) 
        {
            $market = new Market();
            $market->name = $request->get('name');
            $market->city_id = $request->get('city_id');

            $destinationPath = '/public/market_images';

            $extension = $request->file('market_img1')->getClientOriginalExtension(); // getting image extension
            $fileName = rand(11111, 99999) . '.' . $extension;
            $request->file('market_img1')->move( base_path() . $destinationPath, $fileName);
            $market->image1 = $fileName;

            $extension = $request->file('market_img2')->getClientOriginalExtension(); // getting image extension
            $fileName = rand(11111, 99999) . '.' . $extension;
            $request->file('market_img2')->move( base_path() . $destinationPath, $fileName);
            $market->image2 = $fileName;

            $extension = $request->file('market_img3')->getClientOriginalExtension(); // getting image extension
            $fileName = rand(11111, 99999) . '.' . $extension;
            $request->file('market_img3')->move( base_path() . $destinationPath, $fileName);
            $market->image3 = $fileName;
            
            $market->area = $request->get('area');
            $market->description = $request->get('description');
            $market->save();
            return redirect()->route('Admin_ViewAllMarkets');
        }
        else
        {
            return view('Super_Admin/Admin_InsertNewMarket');
        }
    }

    public function showMarkets()
    {
        $market = Market::all();
        $city = City::all();

        return view('Super_Admin/Admin_ViewAllMarkets' , array('market'=>$market , 'city'=>$city));
    }

    public function showCities()
    {
        $city = City::all();

        return view('Super_Admin/Admin_InsertNewMarket' , array('city'=>$city));
    }

    public function deleteMarket($id)
    {

        $market = Market::find($id);

        $market->delete();

        return redirect()-> route('Admin_ViewAllMarkets');
    }

    public function editMarket($id , $c_id)
    {
        $m = Market::findOrFail($id);
        $c = City::findOrFail($c_id);
        $city = City::all();

        return view('Super_Admin/Admin_EditMarket')->with('m' , $m)->with('c' , $c)->with('city' , $city);
    }

    public function updateMarket(Request $request , $id)
    {
        $p = Market::find($id);
        $p->name = $request->get('name');
        $p->city_id = $request->get('city_id');
        $p->area = $request->get('area');
        $p->description = $request->get('description');
        $p->save();
        return redirect()->route('Admin_ViewAllMarkets');
    }

    public function getMarkets($id)
    {
        $market = Market::where('city_id','=',$id)->get();

        $city = City::all();

        $getCity = City::find($id);

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

            return view('markets', array('market' => $market, 'city' => $city, 'getCity' => $getCity , 'city' => $city , 'customer' => $customer , 'vendor' => $vendor ,
                'cart'=>$cart , 'product'=>$product , 'total'=>$total));
        }
        else
        {
            return view('markets', array('market' => $market, 'city' => $city, 'getCity' => $getCity , 'vendor' => $vendor));
        }
    }

    public function getMarketDetails($id)
    {
        $market_details = Market::find($id);

        $city = City::all();

        $market = Market::all();

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

            return view('market_details', array('market_details' => $market_details, 'city' => $city, 'market' => $market , 'customer' => $customer , 'vendor' => $vendor ,
                'cart'=>$cart , 'product'=>$product , 'total'=>$total));
        }
        else
        {
            return view('market_details', array('market_details' => $market_details, 'city' => $city, 'market' => $market , 'vendor' => $vendor));
        }
    }

    public function searchMarket(Request $request , $c_id)
    {
        $words = $request->get('market');

        $search = Market::where('name', 'like', '%' . $words . '%')->where('city_id', $c_id)->get();

        $city = City::all();

        $v_email = Session::get('email');

        $vendor = Shop::where('email' , $v_email)->first();


        $getCity = City::find($c_id);

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

            return view('searchMarket', array('search' => $search, 'city' => $city, 'getCity' => $getCity , 'customer' => $customer , 'vendor' => $vendor ,
                'cart'=>$cart , 'product'=>$product , 'total'=>$total));
        }
        else
        {
            return view('searchMarket', array('search' => $search, 'city' => $city, 'getCity' => $getCity , 'vendor' => $vendor));
        }
    }

    public function searchMarket2(Request $request)
    {
        $words = $request->get('market');

        $search = Market::where('name', 'like', '%' . $words . '%')->get();

        $city = City::all();

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

            return view('searchMarket2', array('search' => $search, 'city' => $city , 'customer' => $customer , 'vendor' => $vendor ,
                'cart'=>$cart , 'product'=>$product , 'total'=>$total));
        }
        else
        {
            return view('searchMarket2', array('search' => $search, 'city' => $city , 'vendor' => $vendor));
        }
    }
}