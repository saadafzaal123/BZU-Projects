<?php
/**
 * Created by PhpStorm.
 * User: Saad Afzaal
 * Date: 8/25/2016
 * Time: 8:06 PM
 */

namespace App\Http\Controllers;

use App\Cart;
use App\Customer;
use Illuminate\Http\Request;
use App\Http\Requests;
use App\Http\Controllers\Controller;
use Session;

class CartController extends Controller
{
    public function addToCart($p_id , $price , $shop_id , $category_id  , $vendor_id , $brand_id , $product_details_id , $shop_details_id)
    {
        $email = Session::get('c_email');

        if ($email != null)
        {
            $customer = Customer::where('email' , $email)->first();

            $cart = Cart::where('p_id' , $p_id)->where('customer_id' , $customer->id)->first();

            if($cart != null)
            {
                return redirect()->route('getItems' , array('id' => $shop_id));
            }
            else
            {
                $c = new Cart();

                $c->p_id = $p_id;
                $c->customer_id = $customer->id;
                $c->quantity = 1;
                $c->price = $price;

                $c->save();

                if($shop_id != 0)
                {
                    return redirect()->route('getItems', array('id' => $shop_id));
                }

                if($category_id != 0 && $vendor_id != 0)
                {
                    return redirect()->route('getCategory', array('c_id' => $category_id , 'v_id' => $vendor_id));
                }

                if($brand_id != 0 && $vendor_id != 0)
                {
                    return redirect()->route('getBrand', array('b_id' => $brand_id , 'v_id' => $vendor_id));
                }

                if($product_details_id != 0 && $shop_details_id != 0)
                {
                    return redirect()->route('getProductDetails', array('id' => $product_details_id , 'v_id' => $shop_details_id));
                }
            }
        }
        else
        {
            return redirect()->route('Customer_Login');
        }
    }

    public function updateCart(Request $request , $id , $shop_id , $city_id , $market_id , $city_details_id , $market_details_id , $product_details_id , $shop_details_id , $category_id , $vendor_id , $brand_id)
    {
        $email = Session::get('c_email');

        if ($email != null)
        {
            $cart = Cart::find($id);

            $cart->quantity = $request->get('quantity');
            $remove = $request->get('remove');

            if($remove != null)
            {
                $cart->delete();
            }
            else
            {
                $cart->save();
            }

            if($shop_id != 0)
            {
                return redirect()->route('getItems', array('id' => $shop_id));
            }

            if($city_id != 0)
            {
                return redirect()->route('getMarkets', array('id' => $city_id));
            }

            if($market_id != 0)
            {
                return redirect()->route('getShops', array('id' => $market_id));
            }

            if($city_details_id != 0)
            {
                return redirect()->route('getCityDetails', array('id' => $city_details_id));
            }

            if($market_details_id != 0)
            {
                return redirect()->route('getMarketDetails', array('id' => $market_details_id));
            }

            if($product_details_id != 0 && $shop_details_id != 0)
            {
                return redirect()->route('getProductDetails', array('id' => $product_details_id , 'v_id' => $shop_details_id));
            }

            if($category_id != 0 && $vendor_id != 0)
            {
                return redirect()->route('getCategory', array('c_id' => $category_id , 'v_id' => $vendor_id));
            }

            if($brand_id != 0 && $vendor_id != 0)
            {
                return redirect()->route('getBrand', array('b_id' => $brand_id , 'v_id' => $vendor_id));
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
}