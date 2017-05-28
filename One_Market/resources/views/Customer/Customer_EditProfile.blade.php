@extends('layouts.Master')

@section('title', 'Customer EditProfile')

@section('img')

    <img data-wow-duration="4s" src="/One_Market/public/img/d_arrow.png" height = "165px" alt="Downward Arrow"/>

@endsection


@section('heading')

    <h2 class="wow fadeInUp" data-wow-duration="5s">To Edit Profile : Please Scroll Down</h2>

@endsection


@section('navbar')

    <div class="collapse navbar-collapse">
        <ul class="nav navbar-nav navbar-right"><!--YOUR NAVIGATION ITEMS STRAT BELOW-->
            <li><a href="#EditP"><span class="btnicon icon-user"></span>Edit Profile</a></li>
            <li class="active"><a href="/One_Market/public/Customer_MainArea"><span class="btnicon icon-cloud-download"></span>GoBack</a></li>
        </ul>
    </div><!--.nav-collapse -->

    @endsection


    @section('content')

            <!-- ===========================
    EditProduct SECTION START
    =========================== -->
    <div id="EditP" class="container">

        <!-- EditProduct SECTION HEADING START -->
        <div class="sectionhead  row wow fadeInUp">
            <img data-wow-duration="4s" src="/One_Market/public/img/profile.jpg" height = "100px" alt="Profile Logo"/>
            <h3>Edit Profile</h3>
            <hr class="separetor">
        </div>
        <div id = "SubmitButton">

            <form action = "{{route('updateCProfile' , array('id' => $customer->id))}}" method = "POST" enctype = "multipart/form-data">

                <input type = "hidden" name ="_token" value = "{{csrf_token()}}">

                <table width = "1000" align = "center" border = "1" bgcolor = "black" style = "color:white; background:black; font-size:16px; margin-bottom:70px;">

                    <tr>
                        <td colspan = "2" align = "center"><h2>Edit Profile :</h2></td>
                    </tr>

                    <tr>
                        <th align = "right">Username</th>
                        <td><input type = "text" name = "name" size = "90" required = "required" value = "{{$customer->username}}"/></td>
                    </tr>

                    @if ($errors->has('name'))
                        <tr>
                            <th align = "right" style = "color: red;">Username Error</th>
                            <td style = "color: red;"><strong>{{ $errors->first('name') }}</strong></td>
                        </tr>
                    @endif

                    <tr>
                        <th align = "right">Passowrd</th>
                        <td><input type = "text" name = "password" size = "90" required = "required" value = "{{ Crypt::decrypt($customer->password)}}"/></td>
                    </tr>

                    @if ($errors->has('password'))
                        <tr>
                            <th align = "right" style = "color: red;">Password Error</th>
                            <td style = "color: red;"><strong>{{ $errors->first('password') }}</strong></td>
                        </tr>
                    @endif

                    <tr>
                        <th align = "right">Confirm Passowrd</th>
                        <td><input type = "text" name = "password_confirmation" size = "90" required = "required" value = "{{ Crypt::decrypt($customer->password)}}"/></td>
                    </tr>

                    @if ($errors->has('password_confirmation'))
                        <tr>
                            <th align = "right" style = "color: red;">Password Confirmation Error</th>
                            <td style = "color: red;"><strong>{{ $errors->first('password_confirmation') }}</strong></td>
                        </tr>
                    @endif

                    <tr>
                        <th align = "right">PhoneNo</th>
                        <td><input type = "text" name = "phoneNo" size = "90" required = "required" value = "{{$customer->phoneNo}}"/></td>
                    </tr>

                    @if ($errors->has('phoneNo'))
                        <tr>
                            <th align = "right" style = "color: red;">PhoneNo Error</th>
                            <td style = "color: red;"><strong>{{ $errors->first('phoneNo') }}</strong></td>
                        </tr>
                    @endif

                    <tr>
                        <th align = "right">Address</th>
                        <td><input type = "text" name = "address" size = "90" required = "required" value = "{{$customer->home_address}}"/></td>
                    </tr>

                    @if ($errors->has('address'))
                        <tr>
                            <th align = "right" style = "color: red;">Address Error</th>
                            <td style = "color: red;"><strong>{{ $errors->first('address') }}</strong></td>
                        </tr>
                    @endif

                    <tr>
                        <th align = "right">CreditCartNo</th>
                        <td><input type = "text" name = "creditcartNo" size = "90" required = "required" value = "{{$customer->creditcartNo}}"/></td>
                    </tr>

                    @if ($errors->has('creditcartNo'))
                        <tr>
                            <th align = "right" style = "color: red;">CreditCartNo Error</th>
                            <td style = "color: red;"><strong>{{ $errors->first('creditcartNo') }}</strong></td>
                        </tr>
                    @endif


                    <tr>
                        <th align = "right"> Image </th>
                        <td><input type = "file" name = "customer_img"></td>
                    </tr>

                    <tr>
                        <td colspan = "2" align = "center" height = "30"><strong><input type = "submit" name = "Update_profile" value = "Update Profile" style = "Color:White; font-size:20px; padding:8px; width:100%"/></strong></td>
                    </tr>

                </table>

            </form>
        </div>

        <!--EditProduct SECTION HEADING END-->

    </div><!-- EditProduct SECTION END -->

@endsection


@section('footernavbar')

    <li><a href="/One_Market/public/Vendor_MainArea">Go Back</a></li>

@endsection





