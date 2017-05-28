<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class AdminLogin extends Model
{
    protected $fillable = ['id' , 'username', 'password' , 'email'];

    protected $hidden = ['remember_token'];
}
