<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class Product extends Model
{
    protected $fillable = ['name', 'vendor_id' , 'cat_id', 'brand_id', 'image1', 'image2', 'image3', 'price',
                           'description', 'keywords'];

    protected $hidden = ['remember_token'];

    public function brands()
    {
        return $this->belongsTo('Brand');
    }

    public function categories(){
        return $this->belongsTo('Category');
    }

    public function shops()
    {
        return $this->belongsTo('Shop');
    }
}
