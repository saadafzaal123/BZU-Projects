<?php

use Illuminate\Database\Seeder;

class AdminLoginSeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
        DB::table('admin_login')->insert([
            'username' => 'Saad Afzaal',
            'password' => bcrypt('saad'),
            'email' => 'saad.afzaal777@gmail.com',
        ]);
    }
}
