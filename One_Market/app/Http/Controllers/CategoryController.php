<?php
/**
 * Created by PhpStorm.
 * User: Saad Afzaal
 * Date: 7/31/2016
 * Time: 7:15 PM
 */

namespace App\Http\Controllers;

use App\Category;
use App\Http\Controllers\Controller;
use Illuminate\Http\Request;
use Session;


class CategoryController extends Controller
{
    public function insertCat(Request $request)
    {
        $email = Session::get('email');

        if ($email != null)
        {
            $Cat = new Category();
            $Cat->name = $request->get('name');
            $Cat->save();
            return redirect()->route('Vendor_MainArea');
        }
        else
        {
            return redirect()->route('Vendor_Login');
        }
    }


    public function deleteCategory($id)
    {
        $email = Session::get('email');

        if ($email != null)
        {
            $cat = Category::find($id);

            $cat->delete();

            return redirect()->route('Vendor_MainArea');
        }
        else
        {
            return redirect()->route('Vendor_Login');
        }
    }
}