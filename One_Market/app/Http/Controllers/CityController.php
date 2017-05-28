<?php
/**
 * Created by PhpStorm.
 * User: Saad Afzaal
 * Date: 8/1/2016
 * Time: 12:21 AM
 */

namespace App\Http\Controllers;

use App\City;
use App\Customer;
use App\Cart;
use App\Product;
use App\Shop;
use App\Http\Controllers\Controller;
use Illuminate\Http\Request;
use Session;

class CityController extends Controller
{
    public function insertCity(Request $request)
    {
        if ($request->file('city_img1')->isValid() && $request->file('city_img2')->isValid() && $request->file('city_img3')->isValid())
        {
            $city = new City();
            $city->name = $request->get('name');

            $destinationPath = '/public/city_images';

            $extension = $request->file('city_img1')->getClientOriginalExtension(); // getting image extension
            $fileName = rand(11111, 99999) . '.' . $extension;
            $request->file('city_img1')->move( base_path() . $destinationPath, $fileName);
            $city->image1 = $fileName;

            $extension = $request->file('city_img2')->getClientOriginalExtension(); // getting image extension
            $fileName = rand(11111, 99999) . '.' . $extension;
            $request->file('city_img2')->move( base_path() . $destinationPath, $fileName);
            $city->image2 = $fileName;

            $extension = $request->file('city_img3')->getClientOriginalExtension(); // getting image extension
            $fileName = rand(11111, 99999) . '.' . $extension;
            $request->file('city_img3')->move( base_path() . $destinationPath, $fileName);
            $city->image3 = $fileName;

            $city->description = $request->get('description');
            $city->save();
            return redirect()->route('Admin_ViewAllCities');
        }
        else
        {
            return view('Super_Admin/Admin_InsertNewCity');
        }
    }

    public function showCities()
    {
        $city = City::all();

        return view('Super_Admin/Admin_ViewAllCities' , array('city'=>$city));
    }

    public function deleteCity($id)
    {

        $city = City::find($id);

        $city->delete();

        return redirect()-> route('Admin_ViewAllCities');
    }

    public function editCity($id)
    {
        $p = City::findOrFail($id);

        return view('Super_Admin/Admin_EditCity')->with('p',$p);
    }

    public function updateCity(Request $request , $id)
    {
        $p = City::find($id);
        $p->name = $request->get('name');
        $p->description = $request->get('description');
        $p->save();
        return redirect()->route('Admin_ViewAllCities');
    }

    public function displayCities()
    {
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

            return view('index', array('city' => $city , 'cart'=>$cart , 'product'=>$product , 'total'=>$total , 'customer'=>$customer , 'vendor' => $vendor));
        }
        else
        {
            return view('index', array('city' => $city , 'vendor' => $vendor));
        }
    }

    public function getCityDetails($id)
    {
        $city_details = City::find($id);

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

            return view('city_details', array('city_details' => $city_details, 'city' => $city , 'customer' => $customer , 'vendor' => $vendor ,
                'cart'=>$cart , 'product'=>$product , 'total'=>$total));
        }
        else
        {
            return view('city_details', array('city_details' => $city_details, 'city' => $city , 'vendor' => $vendor));
        }
    }

    public function searchCity(Request $request)
    {
        $words = $request->get('city');

        $search = City::where('name', 'like', '%' . $words . '%')->get();

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

            return view('searchCity', array('search' => $search , 'city' => $city , 'customer' => $customer , 'vendor' => $vendor ,
                'cart'=>$cart , 'product'=>$product , 'total'=>$total));
        }
        else
        {
            return view('searchCity', array('search' => $search, 'city' => $city , 'vendor' => $vendor));
        }
    }
}