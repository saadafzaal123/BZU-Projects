<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class Shop extends Model
{
    protected $fillable = ['username', 'password' , 'email', 'phoneNo', 'address', 'creditcartNo', 'shop_name',
        'market_id' , 'shop_image'];

    protected $hidden = ['remember_token'];
    public function brands()
    {
        return $this->hasMany('Brand');
    }

    public function products()
    {
        return $this->hasMany('Product');
    }
    
    public function markets(){
        return $this->belongsTo('Market');
    }

    public function categories(){
        return $this->hasMany('Category');
    }

    public function rents()
    {
        return $this->hasOne('Rent');
    }
}
