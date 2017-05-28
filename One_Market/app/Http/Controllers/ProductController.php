<?php
/**
 * Created by PhpStorm.
 * User: Saad Afzaal
 * Date: 7/31/2016
 * Time: 7:13 PM
 */

namespace App\Http\Controllers;

use App\Brand;
use App\Category;
use App\Product;
use App\Rent;
use App\Shop;
use App\City;
use App\Customer;
use App\Cart;
use App\Order;
use App\Payment;
use App\Http\Controllers\Controller;
use Illuminate\Http\Request;
use Session;
use Validator;


class ProductController extends Controller
{
    public function showdata()
    {
        $email = Session::get('email');

        if ($email != null)
        {
            $getVendor = Shop::where('email' , $email)->first();

            $product = Product::where('vendor_id' , $getVendor->id)->get();

            $rent = Rent::where('Vendor_Name' , $getVendor->id)->get();

            $brand = Brand::all();
            $data = Category::all();
            $shop = Shop::all();
            $customer = Customer::all();
            $order = Order::all();
            $payment = Payment::all();

            return view('Vendor_Admin/Vendor_MainArea', array('brand' => $brand, 'data' => $data, 'product' => $product,
                'rent' => $rent, 'shop' => $shop , 'getVendor' => $getVendor , 'customer' => $customer ,
                'order' => $order , 'payment' => $payment));
        }
        else
        {
            return redirect()->route('Vendor_Login');
        }
    }

    public function deleteProduct($id)
    {
        $email = Session::get('email');

        if ($email != null)
        {
            $pro = Product::find($id);

            $pro->delete();

            return redirect()->route('Vendor_MainArea');
        }
        else
        {
            return redirect()->route('Vendor_Login');
        }
    }

    public function editProduct($id , $c_id , $b_id)
    {
        $email = Session::get('email');

        if ($email != null)
        {
            $p = Product::findOrFail($id);
            $cat = Category::find($c_id);
            $brand = Brand::find($b_id);

            $c_data = Category::all();
            $b_data = Brand::all();

            return view('Vendor_Admin/Vendor_EditProduct')->with('p', $p)->with('cat', $cat)->with('c_data', $c_data)->with('brand', $brand)->with('b_data', $b_data);
        }
        else
        {
            return redirect()->route('Vendor_Login');
        }
    }

    public function updateProduct(Request $request , $id)
    {
        $email = Session::get('email');

        if ($email != null)
        {
            $rules = array('name' => 'required|max:50' , 'cats_id' => 'required' , 'brands_id' => 'required' ,
                'price' => 'required|integer' , 'keywords' => 'required|max:50');

            $validator = Validator::make($request->all() , $rules);

            if ($validator->fails())
            {
                $c_id = $request->get('cats_id');
                $b_id = $request->get('brands_id');
                $p_id = $id;

                return redirect()->route('editProduct' , array('id' => $p_id , 'c_id' => $c_id , 'b_id' => $b_id))->withErrors($validator)->withInput();
            }
            else
            {
                $p = Product::find($id);
                $p->name = $request->get('name');

                $getVendor = Shop::where('email', $email)->first();

                $p->vendor_id = $getVendor->id;

                $p->cat_id = $request->get('cats_id');
                $p->brand_id = $request->get('brands_id');

                if($request->file('product_img1') != null)
                {
                    if ($request->file('product_img1')->isValid())
                    {

                        $destinationPath = '/public/product_images';

                        $extension = $request->file('product_img1')->getClientOriginalExtension(); // getting image extension
                        $fileName = rand(11111, 99999) . '.' . $extension;
                        $request->file('product_img1')->move(base_path() . $destinationPath, $fileName);
                        $p->image1 = $fileName;
                    }
                }

                if($request->file('product_img2') != null)
                {
                    if ($request->file('product_img2')->isValid())
                    {
                        $destinationPath = '/public/product_images';

                        $extension = $request->file('product_img2')->getClientOriginalExtension(); // getting image extension
                        $fileName = rand(11111, 99999) . '.' . $extension;
                        $request->file('product_img2')->move(base_path() . $destinationPath, $fileName);
                        $p->image2 = $fileName;
                    }
                }

                if($request->file('product_img3') != null)
                {
                    if ($request->file('product_img3')->isValid()) {

                        $destinationPath = '/public/product_images';

                        $extension = $request->file('product_img3')->getClientOriginalExtension(); // getting image extension
                        $fileName = rand(11111, 99999) . '.' . $extension;
                        $request->file('product_img3')->move(base_path() . $destinationPath, $fileName);
                        $p->image3 = $fileName;
                    }
                }

                $p->price = $request->get('price');
                $p->description = $request->get('description');
                $p->keywords = $request->get('keywords');

                $p->save();

                return redirect()->route('Vendor_MainArea');
            }
        }
        else
        {
            return redirect()->route('Vendor_Login');
        }
    }

    public function insertProduct(Request $request)
    {
        $email = Session::get('email');

        if ($email != null)
        {
            $rules = array('name' => 'required|max:50' , 'cats_id' => 'required' , 'brands_id' => 'required' ,
                'product_img1' => 'required' , 'product_img2' => 'required' , 'product_img3' => 'required' ,
                'price' => 'required|integer' , 'keywords' => 'required|max:50');

            $validator = Validator::make($request->all() , $rules);

            if ($validator->fails())
            {
                return redirect()->route('Vendor_MainArea')->withErrors($validator)->withInput();
            }
            else
            {
                if ($request->file('product_img1')->isValid() && $request->file('product_img2')->isValid() && $request->file('product_img3')->isValid()) {
                    $p = new Product();
                    $p->name = $request->get('name');

                    $getVendor = Shop::where('email', $email)->first();

                    $p->vendor_id = $getVendor->id;

                    $p->cat_id = $request->get('cats_id');
                    $p->brand_id = $request->get('brands_id');

                    $destinationPath = '/public/product_images';

                    $extension = $request->file('product_img1')->getClientOriginalExtension(); // getting image extension
                    $fileName = rand(11111, 99999) . '.' . $extension;
                    $request->file('product_img1')->move(base_path() . $destinationPath, $fileName);
                    $p->image1 = $fileName;

                    $extension = $request->file('product_img2')->getClientOriginalExtension(); // getting image extension
                    $fileName = rand(11111, 99999) . '.' . $extension;
                    $request->file('product_img2')->move(base_path() . $destinationPath, $fileName);
                    $p->image2 = $fileName;

                    $extension = $request->file('product_img3')->getClientOriginalExtension(); // getting image extension
                    $fileName = rand(11111, 99999) . '.' . $extension;
                    $request->file('product_img3')->move(base_path() . $destinationPath, $fileName);
                    $p->image3 = $fileName;

                    $p->price = $request->get('price');
                    $p->description = $request->get('description');
                    $p->keywords = $request->get('keywords');
                    $p->save();
                    return redirect()->route('Vendor_MainArea');
                }
            }
        }
        else
        {
            return redirect()->route('Vendor_Login');
        }
    }

    public function getItems($id)
    {
        $pro = Product::where('vendor_id','=',$id)->get();

        $shop = Shop::find($id);

        $cat = Category::all();

        $brand = Brand::all();

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

            return view('items' , array('pro'=>$pro , 'cat'=>$cat , 'brand'=>$brand , 'shop'=>$shop , 'city'=>$city , 'customer' => $customer , 'vendor' => $vendor ,
                 'cart'=>$cart , 'product'=>$product , 'total'=>$total));
        }
        else
        {
            return view('items', array('pro' => $pro, 'cat' => $cat, 'brand' => $brand, 'shop' => $shop, 'city' => $city , 'vendor' => $vendor));
        }
    }

    public function getProductDetails($id , $v_id)
    {
        $product_details = Product::find($id);

        $shop_details = Shop::find($v_id);

        $cat = Category::all();

        $brand = Brand::all();

        $city = City::all();

        $v_email = Session::get('email');

        $vendor = Shop::where('email' , $v_email)->first();


        $email = Session::get('c_email');

        if ($email != null) {
            $customer = Customer::where('email', $email)->first();
            $cart = Cart::where('customer_id', $customer->id)->get();
            $product = Product::all();

            $total = 0;

            foreach ($cart as $c) {
                foreach ($product as $p) {
                    if ($c->p_id == $p->id) {
                        $total += ($p->price * $c->quantity);
                    }
                }
            }

            return view('product_details', array('product_details' => $product_details, 'shop_details' => $shop_details, 'cat' => $cat, 'brand' => $brand , 'city' => $city , 'customer' => $customer , 'vendor' => $vendor ,
                'cart' => $cart, 'product' => $product, 'total' => $total));
        }
        else
        {
            return view('product_details', array('product_details' => $product_details, 'shop_details' => $shop_details, 'cat' => $cat, 'brand' => $brand , 'city' => $city , 'vendor' => $vendor));
        }
    }

    public function searchProduct(Request $request , $v_id)
    {
        $words = $request->get('product');

        $search = Product::where('keywords', 'like', '%' . $words . '%')->where('vendor_id', $v_id)->get();

        $cat = Category::all();

        $brand = Brand::all();

        $shop = Shop::find($v_id);

        $city = City::all();

        $v_email = Session::get('email');

        $vendor = Shop::where('email' , $v_email)->first();

        $email = Session::get('c_email');

        if ($email != null) {
            $customer = Customer::where('email', $email)->first();
            $cart = Cart::where('customer_id', $customer->id)->get();
            $product = Product::all();

            $total = 0;

            foreach ($cart as $c) {
                foreach ($product as $p) {
                    if ($c->p_id == $p->id) {
                        $total += ($p->price * $c->quantity);
                    }
                }
            }

            return view('searchProduct', array('search' => $search, 'cat' => $cat, 'brand' => $brand, 'shop' => $shop , 'city' => $city , 'customer' => $customer , 'vendor' => $vendor ,
                'cart' => $cart, 'product' => $product, 'total' => $total));
        }
        else
        {
            return view('searchProduct', array('search' => $search, 'cat' => $cat, 'brand' => $brand, 'shop' => $shop , 'city' => $city , 'vendor' => $vendor));
        }
    }

    public function getCategory($c_id , $v_id)
    {
        $category = Product::where('cat_id', $c_id)->where('vendor_id', $v_id)->get();

        $cat = Category::all();

        $brand = Brand::all();

        $shop = Shop::find($v_id);

        $cats = Category::find($c_id);

        $city = City::all();

        $v_email = Session::get('email');

        $vendor = Shop::where('email' , $v_email)->first();

        $email = Session::get('c_email');

        if ($email != null) {
            $customer = Customer::where('email', $email)->first();
            $cart = Cart::where('customer_id', $customer->id)->get();
            $product = Product::all();

            $total = 0;

            foreach ($cart as $c) {
                foreach ($product as $p) {
                    if ($c->p_id == $p->id) {
                        $total += ($p->price * $c->quantity);
                    }
                }
            }

            return view('getCategory', array('category' => $category, 'cat' => $cat, 'brand' => $brand, 'shop' => $shop , 'cats' => $cats , 'city' => $city , 'customer' => $customer , 'vendor' => $vendor ,
                'cart' => $cart, 'product' => $product, 'total' => $total));
        }
        else
        {
            return view('getCategory', array('category' => $category, 'cat' => $cat, 'brand' => $brand, 'shop' => $shop , 'cats' => $cats , 'city' => $city , 'vendor' => $vendor));
        }
    }

    public function getBrand($b_id , $v_id)
    {
        $brands = Product::where('brand_id', $b_id)->where('vendor_id', $v_id)->get();

        $cat = Category::all();

        $brand = Brand::all();

        $shop = Shop::find($v_id);

        $brandss = Brand::find($b_id);

        $city = City::all();

        $v_email = Session::get('email');

        $vendor = Shop::where('email' , $v_email)->first();

        $email = Session::get('c_email');

        if ($email != null) {
            $customer = Customer::where('email', $email)->first();
            $cart = Cart::where('customer_id', $customer->id)->get();
            $product = Product::all();

            $total = 0;

            foreach ($cart as $c) {
                foreach ($product as $p) {
                    if ($c->p_id == $p->id) {
                        $total += ($p->price * $c->quantity);
                    }
                }
            }

            return view('getBrand', array('brands' => $brands, 'cat' => $cat, 'brand' => $brand, 'shop' => $shop , 'brandss' => $brandss , 'city' => $city , 'customer' => $customer , 'vendir' => $vendor ,
                'cart' => $cart, 'product' => $product, 'total' => $total));
        }
        else
        {
            return view('getBrand', array('brands' => $brands, 'cat' => $cat, 'brand' => $brand, 'shop' => $shop , 'brandss' => $brandss , 'city' => $city , 'vendor' => $vendor));
        }
    }
}