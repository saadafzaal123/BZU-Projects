<?php

/*
|--------------------------------------------------------------------------
| Application Routes
|--------------------------------------------------------------------------
|
| Here is where you can register all of the routes for an application.
| It's a breeze. Simply tell Laravel the URIs it should respond to
| and give it the controller to call when that URI is requested.
|
*/

/*Route::get('/', function () {
    return view('welcome');
});*/

Route::get('welcome', function () {
    return view('welcome');
});

Route::auth();

Route::get('/home', 'HomeController@index');

Route::get('/', function () {
    return view('index');
});


//For admin

Route::group(['middleware' => 'auth'], function () {

    Route::get('Admin_Welcome' , function () {
        return view('Super_Admin/Admin_Welcome');
    });

    Route::get('Admin_InsertNewCity' , function () {
        return view('Super_Admin/Admin_InsertNewCity');
    });

    Route::get('Admin_ViewAllCities' , function () {
        return view('Super_Admin/Admin_ViewAllCities');
    });

    Route::get('Admin_InsertNewMarket' , function () {
        return view('Super_Admin/Admin_InsertNewMarket');
    });

    Route::get('Admin_ViewAllMarkets' , function () {
        return view('Super_Admin/Admin_ViewAllMarkets');
    });

    Route::get('Admin_ViewAllShops' , function () {
        return view('Super_Admin/Admin_ViewAllShops');
    });

    Route::get('Admin_ViewShopOwners' , function () {
        return view('Super_Admin/Admin_ViewShopOwners');
    });

    Route::get('Admin_ViewShopRents' , function () {
        return view('Super_Admin/Admin_ViewShopRents');
    });

    Route::get('Admin_ViewCustomers' , function () {
        return view('Super_Admin/Admin_ViewCustomers');
    });

    Route::get('Admin_ViewOrders' , function () {
        return view('Super_Admin/Admin_ViewOrders');
    });

    Route::get('Admin_ViewPayments' , function () {
        return view('Super_Admin/Admin_ViewPayments');
    });

    Route::get('Admin_EditCity' , function () {
        return view('Super_Admin/Admin_ EditCity');
    });

    Route::get('Admin_EditMarket' , function () {
        return view('Super_Admin/Admin_EditMarket');
    });

    Route::get('Admin_EditShop' , function () {
        return view('Super_Admin/Admin_EditShop');
    });

    Route::get('Admin_EditShop' , function () {
        return view('Super_Admin/Admin_EditShop');
    });

    Route::get('Admin_EditShopOwners' , function () {
        return view('Super_Admin/Admin_EditShopOwners');
    });

    Route::get('Admin_Search' , function () {
        return view('Super_Admin/Admin_Search');
    });

    Route::get('Admin_ViewAllCities', ['as' => 'Admin_ViewAllCities', 'uses' => 'CityController@showCities']);

    Route::get('Admin_ViewAllMarkets', ['as' => 'Admin_ViewAllMarkets', 'uses' => 'MarketController@showMarkets']);

    Route::get('Admin_InsertNewMarket', ['as' => 'Admin_InsertNewMarket', 'uses' => 'MarketController@showCities']);

    Route::get('Admin_ViewAllShops', ['as' => 'Admin_ViewAllShops', 'uses' => 'ShopController@showShops']);

    Route::get('Admin_ViewShopRents', ['as' => 'Admin_ViewShopRents', 'uses' => 'RentController@showRents']);

    Route::get('Admin_ViewProfile', ['as' => 'Admin_ViewProfile', 'uses' => 'AdminLoginController@GetUser']);

    Route::post('insertCity' , ['as' => 'insertCity' , 'uses' => 'CityController@insertCity']);

    Route::get('editCity/{id}', ['as' => 'editCity', 'uses' => 'CityController@editCity']);

    Route::get('deleteCity/{id}', ['as' => 'deleteCity', 'uses' => 'CityController@deleteCity']);

    Route::post('insertMarket' , ['as' => 'insertMarket' , 'uses' => 'MarketController@insertMarket']);

    Route::get('editMarket/{id}/{c_id}', ['as' => 'editMarket', 'uses' => 'MarketController@editMarket']);

    Route::get('deleteMarket/{id}', ['as' => 'deleteMarket', 'uses' => 'MarketController@deleteMarket']);

    Route::post('updateCity/{id}' , ['as' => 'updateCity' , 'uses' => 'CityController@updateCity']);

    Route::post('updateMarket/{id}' , ['as' => 'updateMarket' , 'uses' => 'MarketController@updateMarket']);

    Route::get('deleteShop/{id}', ['as' => 'deleteShop', 'uses' => 'ShopController@deleteShop']);

    Route::get('editShop/{id}/{m_id}', ['as' => 'editShop', 'uses' => 'ShopController@editShop']);

    Route::post('updateShop/{id}' , ['as' => 'updateShop' , 'uses' => 'ShopController@updateShop']);

    Route::get('deleteRent/{id}', ['as' => 'deleteRent', 'uses' => 'RentController@deleteRent']);

    Route::get('editProfile/{id}', ['as' => 'editProfile', 'uses' => 'AdminLoginController@editProfile']);

    Route::post('updateProfile/{id}' , ['as' => 'updateProfile' , 'uses' => 'AdminLoginController@updateProfile']);

    Route::get('Admin_ViewCustomers', ['as' => 'Admin_ViewCustomers', 'uses' => 'CustomerController@adminViewCustomers']);

    Route::get('adminDeleteCustomer/{id}' , ['as' => 'adminDeleteCustomer' , 'uses' => 'CustomerController@adminDeleteCustomer']);

    Route::get('Admin_ViewOrders', ['as' => 'Admin_ViewOrders', 'uses' => 'OrderController@adminViewOrders']);

    Route::get('adminDeleteOrder/{id}' , ['as' => 'adminDeleteOrder' , 'uses' => 'OrderController@adminDeleteOrder']);

    Route::get('Admin_ViewPayments', ['as' => 'Admin_ViewPayments', 'uses' => 'PaymentController@adminViewPayments']);

    Route::get('adminDeletePayment/{id}' , ['as' => 'adminDeletePayment' , 'uses' => 'PaymentController@adminDeletePayment']);

    Route::post('searchAdmin' , ['as' => 'searchAdmin' , 'uses' => 'AdminLoginController@searchAdmin']);

});

Route::get('Admin_Login', ['as' => 'Admin_Login', 'uses' => 'AdminLoginController@LoginCheck']);

Route::post('doLogin' , ['as' => 'doLogin' , 'uses' => 'AdminLoginController@doLogin']);

Route::get('adminLogOut' , ['as' => 'adminLogOut' , 'uses' => 'AdminLoginController@adminLogOut']);



//For vendor

//Route::group(['middleware' => 'vendor'], function () {

    Route::get('Vendor_MainArea' , function () {
        return view('Vendor_Admin/Vendor_MainArea');
    });

    Route::get('Vendor_Payment' , function () {
        return view('Vendor_Admin/Vendor_Payment');
    });

    Route::get('Vendor_EditProduct' , function () {
        return view('Vendor_Admin/Vendor_EditProduct');
    });

    Route::get('Vendor_MainArea', ['as' => 'Vendor_MainArea', 'uses' => 'ProductController@showData']);

    Route::get('Vendor_Payment', ['as' => 'Vendor_Payment', 'uses' => 'VendorLoginController@VendorPayment']);

    Route::post('insertShop' , ['as' => 'insertShop' , 'uses' => 'ShopController@insertShop']);

    Route::post('insertRent' , ['as' => 'insertRent' , 'uses' => 'RentController@insertRent']);

    Route::post('insertCategory' , ['as' => 'insertCategory' , 'uses' => 'CategoryController@insertCat']);

    Route::post('insertBrand' , ['as' => 'insertBrand' , 'uses' => 'BrandController@insertBrand']);

    Route::get('deleteBrand/{id}', ['as' => 'deleteBrand', 'uses' => 'BrandController@deleteBrand']);

    Route::get('deleteCategory/{id}', ['as' => 'deleteCategory', 'uses' => 'CategoryController@deleteCategory']);

    Route::get('deleteProduct/{id}', ['as' => 'deleteProduct', 'uses' => 'ProductController@deleteProduct']);

    Route::get('editProduct/{id}/{c_id}/{b_id}', ['as' => 'editProduct', 'uses' => 'ProductController@editProduct']);

    Route::post('updateProduct/{id}' , ['as' => 'updateProduct' , 'uses' => 'ProductController@updateProduct']);

    Route::post('insertProduct' , ['as' => 'insertProduct' , 'uses' => 'ProductController@insertProduct']);

    Route::get('editVProfile/{id}' , ['as' => 'editVProfile' , 'uses' => 'VendorLoginController@editVProfile']);

    Route::post('updateVProfile/{id}' , ['as' => 'updateVProfile' , 'uses' => 'VendorLoginController@updateVProfile']);

    Route::get('vendorDeleteOrder/{id}' , ['as' => 'vendorDeleteOrder' , 'uses' => 'OrderController@vendorDeleteOrder']);

    Route::get('vendorDeletePayment/{id}' , ['as' => 'vendorDeletePayment' , 'uses' => 'PaymentController@vendorDeletePayment']);

    Route::post('searchVendor' , ['as' => 'searchVendor' , 'uses' => 'VendorLoginController@searchVendor']);

//});

Route::get('Vendor_Login' , function () {
    return view('Vendor_Admin/Vendor_Login');
});

Route::get('Vendor_Login', ['as' => 'Vendor_Login', 'uses' => 'ShopController@showData']);

Route::post('VendorLogin' , ['as' => 'VendorLogin' , 'uses' => 'VendorLoginController@VendorLogin']);

Route::get('VendorLogOut' , ['as' => 'VendorLogOut' , 'uses' => 'VendorLoginController@VendorLogOut']);


//For customers

Route::group(['middleware' => 'customer'], function () {

});


Route::get('Customer_Login', function(){
    return view('Customer/Customer_Login');
});

Route::post('insertCustomer', ['as' => 'insertCustomer', 'uses' => 'CustomerController@newLogin']);

Route::post('CustomerLogin', ['as' => 'CustomerLogin', 'uses' => 'CustomerController@CustomerLogin']);

Route::get('Customer_MainArea', ['as' => 'Customer_MainArea', 'uses' => 'CustomerController@showCustomer']);

Route::get('Customer_Login', ['as' => 'Customer_Login', 'uses' => 'CustomerController@Customer_Login']);

Route::get('CustomerLogOut' , ['as' => 'CustomerLogOut' , 'uses' => 'CustomerController@CustomerLogOut']);

Route::get('editCProfile/{id}' , ['as' => 'editCProfile' , 'uses' => 'CustomerController@editCProfile']);

Route::get('deleteCustomer/{id}' , ['as' => 'deleteCustomer' , 'uses' => 'CustomerController@deleteCustomer']);

Route::post('updateCProfile/{id}' , ['as' => 'updateCProfile' , 'uses' => 'CustomerController@updateCProfile']);

Route::get('customerCheckOut/{id}' , ['as' => 'customerCheckOut' , 'uses' => 'CustomerController@customerCheckOut']);

Route::post('customerPayment/{id}' , ['as' => 'customerPayment' , 'uses' => 'CustomerController@customerPayment']);


Route::get('index' , function () {
    return view('index');
});

Route::get('markets' , function () {
    return view('markets');
});



Route::get('index', ['as' => 'index', 'uses' => 'CityController@displayCities']);

Route::get('/', ['as' => '/', 'uses' => 'CityController@displayCities']);

Route::get('getMarkets/{id}', ['as' => 'getMarkets', 'uses' => 'MarketController@getMarkets']);

Route::get('getShops/{id}', ['as' => 'getShops', 'uses' => 'ShopController@getShops']);

Route::get('getItems/{id}', ['as' => 'getItems', 'uses' => 'ProductController@getItems']);

Route::get('getCityDetails/{id}', ['as' => 'getCityDetails', 'uses' => 'CityController@getCityDetails']);

Route::get('getMarketDetails/{id}', ['as' => 'getMarketDetails', 'uses' => 'MarketController@getMarketDetails']);

Route::get('getProductDetails/{id}/{v_id}', ['as' => 'getProductDetails', 'uses' => 'ProductController@getProductDetails']);

Route::post('searchCity' , ['as' => 'searchCity' , 'uses' => 'CityController@searchCity']);

Route::post('searchMarket/{c_id}' , ['as' => 'searchMarket' , 'uses' => 'MarketController@searchMarket']);

Route::post('searchMarket2' , ['as' => 'searchMarket2' , 'uses' => 'MarketController@searchMarket2']);

Route::post('searchShop/{m_id}' , ['as' => 'searchShop' , 'uses' => 'ShopController@searchShop']);

Route::post('searchProduct/{v_id}' , ['as' => 'searchProduct' , 'uses' => 'ProductController@searchProduct']);

Route::get('getCategory/{c_id}/{v_id}' , ['as' => 'getCategory' , 'uses' => 'ProductController@getCategory']);

Route::get('getBrand/{b_id}/{v_id}' , ['as' => 'getBrand' , 'uses' => 'ProductController@getBrand']);

Route::get('addToCart/{p_id}/{price}/{shop_id}/{category_id}/{vendor_id}/{brand_id}/{product_details_id}/{shop_details_id}' , ['as' => 'addToCart' , 'uses' => 'CartController@addToCart']);

Route::post('updateCart/{id}/{shop_id}/{city_id}/{market_id}/{city_details_id}/{market_details_id}/{product_details_id}/{shop_details_id}/{category_id}/{vendor_id}/{brand_id}' , ['as' => 'updateCart' , 'uses' => 'CartController@updateCart']);


