<?php
/**
 * Created by PhpStorm.
 * User: Saad Afzaal
 * Date: 7/31/2016
 * Time: 7:14 PM
 */

namespace App\Http\Controllers;

use App\Brand;
use App\Http\Controllers\Controller;
use Illuminate\Http\Request;
use Session;

class BrandController extends Controller
{
    public function insertBrand(Request $request)
    {
        $email = Session::get('email');

        if ($email != null) 
        {
            $Brand = new Brand();
            $Brand->name = $request->get('name');
            $Brand->save();
            return redirect()->route('Vendor_MainArea');
        }
        else
        {
            return redirect()->route('Vendor_Login');
        }
    }

    public function deleteBrand($id)
    {
        $email = Session::get('email');

        if ($email != null) 
        {
            $brand = Brand::find($id);

            $brand->delete();

            return redirect()->route('Vendor_MainArea');
        }
        else
        {
            return redirect()->route('Vendor_Login');
        }
    }
}