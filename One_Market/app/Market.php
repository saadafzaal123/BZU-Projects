<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class Market extends Model
{
    protected $fillable = ['id', 'name' , 'city_id' , 'image1' , 'image2' , 'image3' , 'area' , 'description'];

    protected $hidden = ['remember_token'];

    public function shops(){
        return $this->hasMany('Shop');
    }
    public function cities(){
        return $this->belongsTo('City');
    }
}
