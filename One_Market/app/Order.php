<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class Order extends Model
{
    protected $fillable = ['product_id', 'customer_id' , 'quantity', 'order_date'];

    protected $hidden = ['remember_token'];
}
