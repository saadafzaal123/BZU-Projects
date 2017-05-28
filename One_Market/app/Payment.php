<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class Payment extends Model
{
    protected $fillable = ['customer_id' , 'product_id' , 'amount', 'trx_id' , 'currency' , 'payment_date'];

    protected $hidden = ['remember_token'];
}
