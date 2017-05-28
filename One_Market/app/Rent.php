<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class Rent extends Model
{
    protected $fillable = ['Vendor_Name', 'Shop_Name' , 'Shop_Rent' , 'Paid_Date', 'IsPaid'];

    protected $hidden = ['remember_token'];

    public function shops(){
        return $this->belongsTo('Shop');
    }
}
