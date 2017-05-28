<?php

use Illuminate\Database\Schema\Blueprint;
use Illuminate\Database\Migrations\Migration;

class UpdateAdminLogin extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::table('admin_login', function (Blueprint $table) {

            Schema::rename('admin_login' , 'admin_logins');

        });
    }

    /**
     * Reverse the migrations.
     *
     * @return void
     */
    public function down()
    {
        Schema::table('admin_login', function (Blueprint $table) {
            Schema::rename('adminlogins' , 'admin_login');
        });
    }
}
