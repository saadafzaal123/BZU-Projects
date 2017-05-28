<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class Brand extends Model
{
    protected $fillable = ['id', 'name'];

    protected $hidden = ['remember_token'];

    public function products(){
        return $this->hasMany('Product');
    }

    public function shops()
    {
        return $this->belongsTo('Shop');
    }

    
}
