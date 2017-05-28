<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class Customer extends Model
{
    protected $fillable = ['username', 'password' , 'email','creditCardNo', 'phoneNo', 'home_address', 'image'];

    protected $hidden = ['remember_token'];
}
