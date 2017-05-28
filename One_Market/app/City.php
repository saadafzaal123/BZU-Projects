<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class City extends Model
{
    protected $fillable = ['id', 'name' , 'image1' , 'image2' , 'image3' , 'description'];

    protected $hidden = ['remember_token'];

    public function markets()
    {
        return $this->hasMany('Market');
    }
}
