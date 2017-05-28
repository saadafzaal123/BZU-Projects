@extends('layouts.Master')

@section('title', 'Customer Payment')

@section('img')

    <img data-wow-duration="4s" src="/One_Market/public/img/d_arrow.png" height = "165px" alt="Downward Arrow"/>
	
@endsection


@section('heading')

<h2 class="wow fadeInUp" data-wow-duration="5s">To Payment : Please Scroll Down</h2>  

@endsection


@section('navbar')

    <div class="collapse navbar-collapse">
        <ul class="nav navbar-nav navbar-right"><!--YOUR NAVIGATION ITEMS STRAT BELOW-->
            <li><a href="/One_Market/public/index"><span class="btnicon icon-user"></span>Home</a></li>
	        <li class="active"><a href="#services"><span class="btnicon icon-user"></span>Customer Payment</a></li>
			<li><a href="/One_Market/public/Customer_MainArea"><span class="btnicon icon-cloud-download"></span>Customer MainArea</a></li>
            <li><a href="{{ URL::route('CustomerLogOut')}}"><span class="btnicon icon-cloud-download"></span>Customer LogOut</a></li>
        </ul>    
    </div><!--.nav-collapse -->

@endsection


@section('content')

    	 <!-- ===========================
    Payment SECTION START
    =========================== -->
    <div id="services" class="container">
       
        <!-- Payment SECTION HEADING START -->
        <div class="sectionhead  row wow fadeInUp">
            <!--<span class="bigicon icon-cup "></span>-->
			<img data-wow-duration="4s" src="/One_Market/public/img/PLogo2.png" height = "90px" alt="Payment Logo"/>
            <h3>Pay now with PayPal</h3>
            <hr class="separetor">						
			
			<form action="{{ route('customerPayment' , array('id' => $customer->id)) }}" method="POST" style = "margin-top:50px;">  <!--https://www.sandbox.paypal.com/cgi-bin/webscr-->

                <input type = "hidden" name ="_token" value = "{{csrf_token()}}">

                <!--Identify your business so that you can collect the payments. -->
                <input type="hidden" name="business" value="herschelgomez@xyzzyu.com">

                <!-- Specify a Buy Now button. -->
                <input type="hidden" name="cmd" value="_xclick">

                <!-- Specify details about the item that buyers will purchase. -->

                <input type="hidden" name="item_name" value = "

                <?php

                    foreach($cart as $c)
                    {
                       foreach ($product as $p)
                       {
                          if ($c->p_id == $p->id)
                          {
                              echo $p->name." , ";
                          }
                       }
                    }

                ?>

                " >


			    <input type="hidden" name="item_number" value = "

			    <?php

                foreach($cart as $c)
                {
                    foreach ($product as $p)
                    {
                        if ($c->p_id == $p->id)
                        {
                            echo $p->id.",";
                        }
                    }
                }

                ?>

			    " >

                <input type="hidden" name="amount" value = "{{$total}}">

                <input type="hidden" name="currency_code" value="USD">
                
                <input type="hidden" name="return" value = "">
			    <input type="hidden" name="cancel_return" value = "">

                <!-- Display the payment button. -->
                <input type="image" name="submit" border="0"
                       src="/One_Market/public/img/paypal_button.png"
					   alt="PayPal - The safer, easier way to pay online">

                       <img alt="" border="0" width="1" height="1" data-wow-duration="4s"
                       src="https://www.paypalobjects.com/en_US/i/scr/pixel.gif" />

            </form>
					 
	        <img data-wow-duration="4s" src = "/One_Market/public/img/paypal.png" width = "200" height = "100" style = "margin-bottom:60px;" />
			
         </div><!--Payment SECTION HEADING END-->
         
        <!-- Payment ITEMS START -->
    </div><!-- Payment SECTION END -->

@endsection


@section('footernavbar')

    <li><a href="index">Home</a></li>

@endsection
