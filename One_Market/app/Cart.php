<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class Cart extends Model
{
    protected $fillable = ['id', 'p_id' , 'customer_id' , 'quantity' , 'price'];

    protected $hidden = ['remember_token'];
}
