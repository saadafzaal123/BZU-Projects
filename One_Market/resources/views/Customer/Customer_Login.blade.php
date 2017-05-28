@extends('layouts.Master')

@section('title', 'Customer Login')

@section('img')

    <img data-wow-duration="4s" src="img/d_arrow.png" height = "165px" alt="Downward Arrow"/>  
	
@endsection

@section('heading')

<h2 class="wow fadeInUp" data-wow-duration="5s">To Login : Please Scroll Down</h2>  

@endsection

@section('navbar')

    <div class="collapse navbar-collapse">
        <ul class="nav navbar-nav navbar-right"><!--YOUR NAVIGATION ITEMS STRAT BELOW-->
            <li><a href="index"><span class="btnicon icon-user"></span>Home</a></li>
		    <li><a href="#about"><span class="btnicon icon-user"></span>About Customer</a></li>
		    <li class="active"><a href="#portfolio"><span class="btnicon icon-cloud-download"></span>Customer Log In</a></li>
        </ul>        
    </div><!--.nav-collapse -->

@endsection


@section('content')

    <!-- ===========================
    ABOUT SECTION START
    =========================== -->
     
	 <div id="about" class="container">
        
        <!-- LEFT PART OF THE ABOUT SECTION -->
         <div class="col-md-6">
            <div class="row">
             <h2 class="wow fadeInDown" data-wow-duration="2s">About Customer</h2>
              <h4 class="wow fadeInDown" data-wow-duration="2s" style = "margin-top:-15px;">(Local User)</h4>
             <h4 class="wow fadeInUp" data-wow-duration="3s">A vendor admin is basically a Shop Owner who deal with Customers! sell products and also Manage his Shop!</h4>
             
             <p class="wow fadeInDown" data-wow-duration="3s" style = "color:gray;">We provide facilities those who interested to take shop on rent in particular markets in particular city. Where you deal with your customers sell products also manage your shop and earn handsome money through online. You can put any product in your shop which you want to sale.</p>
             <p class="wow fadeInDown" data-wow-duration="3s" style = "color:gray;">So we provide platform to take shop on rent on our website in particular markets where you want to open your shop.We charges 500$ monthly to you.You can continue your activity giving require charges monthly.We does not take any commision in your product which you sale.This is very good chance to open your own shop so why you waiting for Create your account take shop on rent and enjoy our services.Thanks!</p>
             
             <a class="dribbble-follow-button wow bounce" href="http://dribbble.com/srizon">Follow</a>
             </div> <!-- ABOUT INFO END -->

         </div><!-- LEFT PART OF THE ABOUT SECTION END -->
        <!--Left part end-->
         
         <!-- RIGHT PART OF THE ABOUT SECTION -->
         <div class="col-md-6 wow fadeInUp myphoto" data-wow-duration="4s">
             <img src="img/user.png" alt="Mamun Srizon">
         </div><!-- RIGHT PART OF THE ABOUT SECTION END -->        
     </div><!-- ABOUT SECTION END -->
        
    <hr><!-- SECTION SEPARETOR LINE -->
	 
	 
	 <!-- ===========================
    LoginForm SECTION START
    =========================== -->	
	
    <div id="portfolio" class="container" style = "width:100%; margin-top:-20px; background:#e3e3e3;">
        <!-- LoginForm SECTION HEADING START -->
        <div class="sectionhead  row wow fadeInUp">
            <span class="bigicon icon-cup "></span>
            <h3>Please Login From Here into your Account</h3>
			<h3>Not Registered? Click Top Right Corner of Form</h3>
            <hr class="separetor">
         </div><!--LoginForm SECTION HEADING END-->
         
        <!-- Form SECTION START -->
        
		<div class="module form-module" style = "margin-bottom:50px;">
            <div class="toggle"><i class="fa fa-times fa-pencil"></i>
                <div class="tooltip">Click Me</div>
            </div>
      
	        <div class="form">
                <h2>Login to your account</h2>
                <form action = "{{route('CustomerLogin')}}" method = "POST">

                    <input type = "hidden" name ="_token" value = "{{csrf_token()}}">

                    <input type="email" placeholder="Email" required = "required" name = "email"/>

                        @if ($errors->has('email'))
                            <span class="help-block" style = "color: red;">
                               <strong>{{ $errors->first('email') }}</strong>
                            </span>
                        @endif

                    <input type="password" placeholder="Password" required = "required" name = "password"/>

                        @if ($errors->has('password'))
                            <span class="help-block" style = "color: red;">
                                <strong>{{ $errors->first('password') }}</strong>
                         </span>
                        @endif

                    <button style = "padding: 10px 15px; font-size:18px;">Login</button>
                </form>
            </div>

			
            <div class="form">
                <h2>Create an account</h2>
                <form action = "{{route('insertCustomer')}}" method = "post" enctype = "multipart/form-data">

                    <input type = "hidden" name ="_token" value = "{{csrf_token()}}">

                    <input type="text" name = "username" placeholder="Username" required = "required"/>

                    @if ($errors->has('username'))
                        <span class="help-block" style = "color: red;">
                        <strong>{{ $errors->first('username') }}</strong>
                    </span>

                    @endif

                    <input type="password" name = "password" placeholder="Password" required = "required"/>

                    @if ($errors->has('password'))
                        <span class="help-block" style = "color: red;">
                        <strong>{{ $errors->first('password') }}</strong>
                    </span>

                    @endif

                    <input type="password" name = "password_confirmation" placeholder="Confirm Password" required = "required"/>

                    @if ($errors->has('password_confirmation'))
                        <span class="help-block" style = "color: red;">
                        <strong>{{ $errors->first('password_confirmation') }}</strong>
                    </span>

                    @endif

                    <input type="email" name = "email" placeholder="Email Address" required = "required"/>

                        @if ($errors->has('email'))
                            <span class="help-block" style = "color: red;">
                        <strong>{{ $errors->first('email') }}</strong>

                        </span>

                        @endif

                    <input type="tel" name = "phone#" placeholder="Phone Number" required = "required"/>

                        @if ($errors->has('phone#'))
                           <span class="help-block" style = "color: red;">
                               <strong>{{ $errors->first('phone#') }}</strong>
                           </span>

                        @endif

                    <input type="text" name = "address" placeholder="Home Address" required = "required"/>

                    @if ($errors->has('address'))
                        <span class="help-block" style = "color: red;">
                        <strong>{{ $errors->first('address') }}</strong>
                    </span>

                    @endif

                    <input type="text" name = "creditcart#" placeholder="Credit Card Number" required = "required"/>

                    @if ($errors->has('creditcart#'))
                        <span class="help-block" style = "color: red;">
                        <strong>{{ $errors->first('creditcart#') }}</strong>
                    </span>

                    @endif

                    <input id="f02" type="file" name = "customerImage" placeholder="Add Picture" required = "required" />
                    <label for="f02">Add Picture</label>

                    @if ($errors->has('customerImage'))
                        <span class="help-block" style = "color: red;">
                        <strong>{{ $errors->first('customerImage') }}</strong>
                    </span>

                    @endif

                    <button style = "margin-top:10px;  padding: 10px 15px; font-size:18px;">Register</button>
                </form>
            </div>
			
            <div class="cta"><a href="#">Forgot your password?</a>
			</div>
			
        </div>
		
    </div><!-- Form SECTION END -->

@endsection


@section('footernavbar')

    <li><a href="index">Home</a></li>

@endsection
