@extends('layouts.Master')

@section('title', 'Vendor MainArea')

@section('space')

	<div style="margin-top:50px;" xmlns="http://www.w3.org/1999/html"></div>

@endsection

@section('img')

    <img data-wow-duration="4s" src="img/d_arrow.png" height = "165px" alt="Downward Arrow" />
	
@endsection


@section('heading')

<h2 class="wow fadeInUp" data-wow-duration="5s">To Vendor Actitvity : Please Scroll Down</h2>  

@endsection


@section('navbar')

    <div class="collapse navbar-collapse">
        <ul class="nav navbar-nav navbar-right"><!--YOUR NAVIGATION ITEMS STRAT BELOW-->
            <li><a href="index"><span class="btnicon icon-user"></span>Home</a></li>
			<li><a href="#services"><span class="btnicon icon-user"></span>Search</a></li>
			<li><a href="#InsertP"><span class="btnicon icon-user"></span>InsertNewProduct</a></li>
			<li><a href="#ViewAP"><span class="btnicon icon-user"></span>ViewAllProducts</a></li>
			<li><a href="#InsertC"><span class="btnicon icon-user"></span>InsertNewCategory</a></li>
			<li><a href="#ViewAC"><span class="btnicon icon-user"></span>ViewAllCategories</a></li>
			<li><a href="#ViewR"><span class="btnicon icon-user"></span>ViewRents</a></li>
		</ul>
	</div>
				
	<div class="collapse navbar-collapse">
		<ul class="nav navbar-nav navbar-right"><!--YOUR NAVIGATION ITEMS STRAT BELOW-->						
			<li><a href="#InsertB"><span class="btnicon icon-user"></span>Insert New Brand</a></li>
			<li><a href="#ViewAB"><span class="btnicon icon-user"></span>View All Brands</a></li>
			<li><a href="#ViewAO"><span class="btnicon icon-user"></span>View Orders</a></li>
			<li><a href="#ViewACu"><span class="btnicon icon-user"></span>View Customers</a></li>
			<li><a href="#ViewAPa"><span class="btnicon icon-user"></span>View Payments</a></li>
			<li><a href="#ViewPr"><span class="btnicon icon-user"></span>View Profile</a></li>
			<li><a href="Vendor_Payment"><span class="btnicon icon-user"></span>My Payments</a></li>
			<li class="active"><a href="{{ URL::route('VendorLogOut')}}"><span class="btnicon icon-cloud-download"></span>LogOut</a></li>
        </ul>
    </div><!--.nav-collapse -->

@endsection


@section('content')

      <!-- ===========================
    SEARCH SECTION START
    =========================== -->
    <div id="services" class="container">

        <!-- SERVICE SECTION HEADING START -->
        <div class="sectionhead  row wow fadeInUp">
            <img data-wow-duration="4s" src="img/search.jpg" height = "80px" alt="Search Logo"/>   
            <h3>Search AnyThing Related Vendor Work Here!</h3>
            <hr class="separetor">


			<div id = "searching" style = "margin-top:40px;">
	            <form action = "{{route('searchVendor')}}" method = "POST">

					<input type = "hidden" name ="_token" value = "{{csrf_token()}}">

	                <strong>
						<select id = "search_type" name = "search_type">
	                    <option value = ""> Select Search Type</option>
	                    <option value = "P">Search a Product</option>
	                    <option value = "C">Search a Category</option>
	                    <option value = "B">Search a Brand</option>
	                    <option value = "Cu">Search a Customer</option>
	                    <option value = "O">Search a Order</option>
	                    <option value = "Pay">Search a Payment</option>
	                    </select>
					</strong>
	 
	                <input type = "text" id = "search" name = "search" placeholder = "Type Here"/>
	 
	                <!--<button>Search</button>-->

					<button type="submit" class="btn btn-info">
						<span class="glyphicon glyphicon-search"></span> Search
					</button>

					<strong><label>For Order and Payment Select Date</label></strong>

					<input type="date"  name = "datetime"/>

					<!--<input type = "button" class="btn btn-info"  value = "Search" onclick = "search_content('table' , 'Vendor_Search');">-->


	                <!--<strong><input type = "button" value = "Click to Search">
					</strong>-->
	            </form>
	 
	            <div id = "table" style = "margin-top:1px;">
	            </div>

	        </div>
			
        </div><!--SEARCH SECTION HEADING END-->
         
    </div><!-- SEARCH SECTION END -->
   
   <hr style = "margin-top:50px;">
   
   
   <!-- ===========================
    NewProduct SECTION START
    =========================== -->
    <div id="InsertP" class="container">
       
        <!-- NewProduct SECTION HEADING START -->
        <div class="sectionhead  row wow fadeInUp">
           <img data-wow-duration="4s" src="img/product.png" height = "90px" alt="Product Logo"/>   
            <h3>Insert New Product</h3>
            <hr class="separetor">
		</div>	
		<div id = "SubmitButton">
		
			<form action = "{{route('insertProduct')}}" method = "POST" enctype = "multipart/form-data">

				<input type = "hidden" name ="_token" value = "{{csrf_token()}}">

                <table width = "1000" align = "center" border = "1" bgcolor = "black" style = "color:white; background:black; font-size:16px; margin-bottom:70px;">
      
	                <tr>
	                    <td colspan = "2" align = "center"><h2>Insert New Product:</h2></td>
	                </tr>
	  
	                <tr>
	                    <th align = "right">Product Title</th>
	                        <td><input type = "text" name = "name" size = "85" required = "required"></td>
					</tr>

					@if ($errors->has('name'))
						<tr>
							<th align = "right" style = "color: red;">Title Error</th>
							<td style = "color: red;"><strong>{{ $errors->first('name') }}</strong></td>
						</tr>
					@endif
	  
	                <tr>
	                    <th align = "right">Product Category</th>
	                    <td>
		       
			                <select name = "cats_id" style = "color: black;">
		                        <option>Select a Category</option>

								@foreach($data as $d)
									{
									    <option value = "{{$d->id}}">{{$d->name}} </option>
									}
								@endforeach
			     
			                </select>

		                </td>
	                </tr>

					@if ($errors->has('cats_id'))
						<tr>
							<th align = "right" style = "color: red;">Category Error</th>
							<td style = "color: red;"><strong>{{ $errors->first('cats_id') }}</strong></td>
						</tr>
					@endif
	  
	                <tr>
	                    <th align = "right">Product Brand</th>
	                    <td>
		                    <select name = "brands_id" style = "color: black;">
		                        <option>Select Brand</option>

								@foreach($brand as $b)
									{
									    <option value = "{{$b->id}}">{{$b->name}} </option>
									}
								@endforeach
			     
			                </select>
		                </td>
	                </tr>

					@if ($errors->has('brands_id'))
						<tr>
							<th align = "right" style = "color: red;">Brand Error</th>
							<td style = "color: red;"><strong>{{ $errors->first('brands_id') }}</strong></td>
						</tr>
					@endif

	                <tr>
	                    <th align = "right">Product Image 1</th>
	                    <td><input type = "file" name = "product_img1" required = "required" /></td>
	                </tr>

					@if ($errors->has('product_img1'))
						<tr>
							<th align = "right" style = "color: red;">Image1 Error</th>
							<td style = "color: red;"><strong>{{ $errors->first('product_img1') }}</strong></td>
						</tr>
					@endif

	                <tr>
	                    <th align = "right">Product Image 2</th>
	                    <td><input type = "file" name = "product_img2" required = "required" /></td>
	                </tr>

					@if ($errors->has('product_img2'))
						<tr>
							<th align = "right" style = "color: red;">Image2 Error</th>
							<td style = "color: red;"><strong>{{ $errors->first('product_img2') }}</strong></td>
						</tr>
					@endif
	  
	                <tr>
	                    <th align = "right">Product Image 3</th>
	                    <td><input type = "file" name = "product_img3" required = "required" /></td>
	                </tr>

					@if ($errors->has('product_img3'))
						<tr>
							<th align = "right" style = "color: red;">Image3 Error</th>
							<td style = "color: red;"><strong>{{ $errors->first('product_img3') }}</strong></td>
						</tr>
					@endif

	                <tr>
	                    <th align = "right">Product Price</th>
	                    <td><input type = "text" name = "price" required = "required"/></td>
	                </tr>

					@if ($errors->has('price'))
							<tr>
								<th align = "right" style = "color: red;">Price Error</th>
                                      <td style = "color: red;"><strong>{{ $errors->first('price') }}</strong></td>
						    </tr>
					@endif

	                <tr>
	                    <th align = "right">Product Description</th>
	                    <td><textarea name = "description" cols = "85" rows = "10" ></textarea></td>
	                </tr>
	  
	                <tr>
	                    <th align = "right">Product Keywords</th>
	                    <td><input type = "text" name = "keywords" size = "85" required = "required"/></td>
	                </tr>

					@if ($errors->has('keywords'))
						<tr>
							<th align = "right" style = "color: red;">Keywords Error</th>
							<td style = "color: red;"><strong>{{ $errors->first('keywords') }}</strong></td>
						</tr>
					@endif
	  
	                <tr>
						<td colspan = "2" align = "center" height = "30"><strong><input type = "submit" name = "insert_product" value = "Insert Product" style = "Color:White; font-size:20px; padding:8px; width:100%"/></strong></td>
	                </tr>
	  
                </table>
   
             </form>
		</div>	
			
        <!--NewProduct SECTION HEADING END-->	 
        
    </div><!-- NewProduct SECTION END -->
   
   
   <hr style = "margin-top:50px;">
   
   
   <!-- ===========================
    ViewAllProducts SECTION START
    =========================== -->
    <div id="ViewAP" class="container">
       
        <!-- ViewAllProducts SECTION HEADING START -->
        <div class="sectionhead  row wow fadeInUp">
            <img data-wow-duration="4s" src="img/VAP.jpg" height = "120px" alt="Search Logo"/> 
            <h3>View All Products</h3>
            <hr class="separetor">
			
			<div id = "HD"><button class = "displayP">Display</button></div>
        </div><!--ViewAllProducts SECTION HEADING END-->
         

		<div id = "th">
		    <table class = "tableP" width = "1000" align = "center" border = "1" bgcolor="black" style = "color:white; background:black; font-size:16px; margin-bottom:70px;">
      
	            <tr>
	                <td colspan = "6" align = "center"><h2>All Products Here!</h2></td>
	            </tr>
	  
	            <tr align = "center" style = "color:#FFFF00; font-size: 20px;">
		            <th style = "padding: 20px;">Product_id :</th>
		            <th>Product_title :</th>
		            <th>Product_Price :</th>
		            <th>Update</th>
		            <th>Delete</th>
	            </tr>

				@foreach($product as $p)
					<tr style="text-align: center">
						<td>{{$p->id}}</td>
						<td>{{$p->name}}</td>
						<td>{{$p->price}}</td>

						<td>
							<div id = "editPro">
								<a href="{{ URL::route('editProduct', array('id' => $p->id , 'c_id' => $p->cat_id , 'b_id' => $p->brand_id)) }}">
									<button type="submit">
										Update
									</button>
								</a>
							</div>
						</td>

						<td>
							<div id = "deletePro">
								<a href="{{ URL::route('deleteProduct', array('id' => $p->id)) }}">
									<button type="submit">
										Delete
									</button>
								</a>
							</div>
						</td>

					</tr>
				@endforeach
	  
	        </table>
	    </div>
		 
		 
    </div><!-- ViewAllProducts SECTION END -->
   
   <hr style = "margin-top:50px;">
   
      <!-- ===========================
    NewCategory SECTION START
    =========================== -->
    <div id="InsertC" class="container">
       
        <!-- NewCategory SECTION HEADING START -->
        <div class="sectionhead  row wow fadeInUp">
           <img data-wow-duration="4s" src="img/Category.png" height = "90px" alt="Category Logo"/>   
            <h3>Insert New Category</h3>
            <hr class="separetor">
		</div>	
		<div id = "SubmitButton">
		
			<form action = "{{route('insertCategory')}}" method = "POST" enctype = "multipart/form-data">

				<input type = "hidden" name ="_token" value = "{{csrf_token()}}">

                <table width = "1000" align = "center" border = "1" bgcolor = "black" style = "color:white; background:black; font-size:16px; margin-bottom:70px;">
      
	                <tr>
	                    <td colspan = "2" align = "center"><h2>Insert New Category:</h2></td>
	                </tr>
	  
	                <tr>
	                    <th align = "right">Enter Category Name :</th>
	                        <td style = "text-align:left;"><input type = "text" name = "name" size = "50" required = "required"/></td>
	                </tr>
					
	                <tr>
						<td colspan = "2" align = "center" height = "30"><strong><input type = "submit" name = "insert_category" value = "Insert Category" style = "Color:White; font-size:20px; padding:8px; width:100%"/></strong></td>
	                </tr>
	  
                </table>
   
             </form>
		</div>	
			
        <!--NewCategory SECTION HEADING END-->	 
        
    </div><!-- NewCategory SECTION END -->
   
   
   <hr style = "margin-top:50px;">
   
   
    <!-- ===========================
    ViewAllCategory SECTION START
    =========================== -->
    <div id="ViewAC" class="container">
       
        <!-- ViewAllCategory SECTION HEADING START -->
        <div class="sectionhead  row wow fadeInUp">
             <img data-wow-duration="4s" src="img/categories2.jpg" height = "100px" alt="Category Logo"/>   
            <h3>View All Categories</h3>
            <hr class="separetor">

			<div id = "HD"><button class = "displayC">Display</button></div>
			
        </div><!--ViewAllCategory SECTION HEADING END-->
         
		<div id = "th">
		    <table class = "tableC" width = "1000" align = "center" border = "1" bgcolor="black" style = "color:white; background:black; font-size:16px; margin-bottom:70px;">
      
	            <tr>
	                <td colspan = "6" align = "center"><h2>All Categories Here!</h2></td>
	            </tr>
	  
	            <tr align = "center" style = "color:#FFFF00; font-size: 20px;">
		            <th style = "padding:20px;">Category_id :</th>
		            <th>Category_title :</th>
		            <th>Delete</th>
	            </tr>

				@foreach($data as $d)
					<tr style="text-align: center">
						<td>{{$d->id}}</td>
						<td>{{$d->name}}</td>

						<td>
							<div id = "deleteCat">
								<a href="{{ URL::route('deleteCategory', array('id' => $d->id)) }}">
									<button type="submit">
										Delete
									</button>
								</a>
							</div>
						</td>

					</tr>
				@endforeach

	        </table>
	    </div>
		 
    </div><!-- ViewAllCategory SECTION END -->
   
   
   <hr style = "margin-top:50px;">
   
   
    <!-- ===========================
    ViewRents SECTION START
    =========================== -->
    <div id="ViewR" class="container">
       
        <!-- ViewRents SECTION HEADING START -->
        <div class="sectionhead  row wow fadeInUp">
             <img data-wow-duration="4s" src="img/Rents.jpg" height = "100px" alt="Category Logo"/>   
            <h3>View All My Rents</h3>
            <hr class="separetor">

			<div id = "HD"><button class = "displayR">Display</button></div>
			
        </div><!--ViewRents SECTION HEADING END-->
         
		<div id = "th">
		    <table class = "tableR" width = "1000" align = "center" border = "1" bgcolor="black" style = "color:white; background:black; font-size:16px; margin-bottom:70px;">
      
	            <tr>
	                <td colspan = "7" align = "center"><h2>My All Rents Here!</h2></td>
	            </tr>
	  
	            <tr align = "center" style = "color:#FFFF00;">
		           <th style = "padding:20px;">Id :</th>
		           <th>Vendor_Name :</th>
		           <th>Shop Name :</th>
		           <th>Shop Rent :</th>
		           <th>Paid Date :</th>
		           <th>IsPaid :</th>
	            </tr>

				@foreach($rent as $r)
					<tr style="text-align: center">

						<td style = "padding:20px;">{{$r->id}}</td>

						<td>
							@foreach($shop as $s)
								@if($s->id == $r->Vendor_Name)
									{{$s->username}}
								@endif
							@endforeach
						</td>

						<td>
							@foreach($shop as $s)
								@if($s->id == $r->Shop_Name)
									{{$s->shop_name}}
								@endif
							@endforeach
						</td>

						<td>{{$r->Shop_Rent}}</td>
						<td>{{$r->Paid_Date}}</td>
						<td>{{$r->IsPaid}}</td>

					</tr>
				@endforeach
	  
	        </table>
	    </div>
		 
    </div><!-- ViewRents SECTION END -->
   
   <hr style = "margin-top:50px;">
   
     <!-- ===========================
    NewBrand SECTION START
    =========================== -->
    <div id="InsertB" class="container">
       
        <!-- NewBrand SECTION HEADING START -->
        <div class="sectionhead  row wow fadeInUp">
           <img data-wow-duration="4s" src="img/Brand.jpg" height = "100px" alt="Brand Logo"/>   
            <h3>Insert New Brand</h3>
            <hr class="separetor">
		</div>	
		<div id = "SubmitButton">
		
			<form action = "{{route('insertBrand')}}" method = "POST" enctype = "multipart/form-data">

				<input type = "hidden" name ="_token" value = "{{csrf_token()}}">

                <table width = "1000" align = "center" border = "1" bgcolor = "black" style = "color:white; background:black; font-size:16px; margin-bottom:70px;">
      
	                <tr>
	                    <td colspan = "2" align = "center"><h2>Insert New Brand:</h2></td>
	                </tr>
	  
	                <tr>
	                    <th align = "right">Enter Brand Name :</th>
	                        <td style = "text-align:left;"><input type = "text" name = "name" size = "50" required = "required"/></td>
	                </tr>
					
	                <tr>
						<td colspan = "2" align = "center" height = "30"><strong><input type = "submit" name = "insert_brand" value = "Insert Brand" style = "Color:White; font-size:20px; padding:8px; width:100%"/></strong></td>
	                </tr>
	  
                </table>
   
             </form>
		</div>	
			
        <!--NewBrand SECTION HEADING END-->	 
        
    </div><!-- NewBrand SECTION END -->
   
   
   <hr style = "margin-top:50px;">
   
   
   <!-- ===========================
    ViewAllBrands SECTION START
    =========================== -->
    <div id="ViewAB" class="container">
       
        <!-- ViewAllBrands SECTION HEADING START -->
        <div class="sectionhead  row wow fadeInUp">
              <img data-wow-duration="4s" src="img/brand2.jpg" height = "100px" alt="Brand Logo"/>   
            <h3>View All Brands</h3>
            <hr class="separetor">

			<div id = "HD"><button class = "displayB">Display</button></div>
			
        </div><!--ViewAllBrands SECTION HEADING END-->
         
		<div id = "th">
		    <table class = "tableB" width = "1000" align = "center" border = "1" bgcolor="black" style = "color:white; background:black; font-size:16px; margin-bottom:70px;">
      
	            <tr>
	                <td colspan = "6" align = "center"><h2>All Brands Here!</h2></td>
	            </tr>
	  
	            <tr align = "center" style = "color:#FFFF00; font-size: 20px;">
		            <th style = "padding: 20px;">Brand_id :</th>
		            <th>Brand_title :</th>
		            <th>Delete</th>
	            </tr>

				@foreach($brand as $b)
					<tr style="text-align: center">
						<td>{{$b->id}}</td>
						<td>{{$b->name}}</td>

						<td>
							<div id = "deleteBrand">
								<a href="{{ URL::route('deleteBrand', array('id' => $b->id)) }}">
									<button type="submit">
										Delete
									</button>
								</a>
							</div>
						</td>

					</tr>
				@endforeach
	  
	        </table>
	    </div>
		 
    </div><!-- ViewAllBrands SECTION END -->
   
   
   <hr style = "margin-top:50px;">

   
    <!-- ===========================
    ViewAllOrders SECTION START
    =========================== -->
    <div id="ViewAO" class="container">
       
        <!-- ViewAllOrders SECTION HEADING START -->
        <div class="sectionhead  row wow fadeInUp">
             <img data-wow-duration="4s" src="img/order.png" height = "70px" alt="Order Logo"/>   
            <h3>View All Orders</h3>
            <hr class="separetor">

			<div id = "HD"><button class = "displayO">Display</button></div>
			
        </div><!--ViewAllOrders SECTION HEADING END-->
         
		<div id = "th">
		    <table class = "tableO" width = "1000" align = "center" border = "1" bgcolor="black" style = "color:white; background:black; font-size:16px; margin-bottom:70px;">
      
	            <tr>
	                <td colspan = "7" align = "center"><h2>All Orders Here!</h2></td>
	            </tr>
	  
	            <tr align = "center" style = "color:#FFFF00;">
		            <th style = "padding: 20px;">Order_id :</th>
		            <th>Product_id :</th>
		            <th>Customer_id :</th>
		            <th>Quantity :</th>
					<th>Amount :</th>
		            <th>Order_Date :</th>
		            <th>Delete</th>
	            </tr>

				@foreach($order as $o)
					@foreach($product as $p)
						@if($o->product_id == $p->id)

					<tr style="text-align: center">

						<td>{{$o->id}}</td>
						<td>{{$o->product_id}}</td>
						<td>{{$o->customer_id}}</td>
						<td>{{$o->quantity}}</td>
						<td>{{$o->amount}}</td>
						<td>{{$o->order_date}}</td>

						<td>
							<div id = "deleteBrand">
								<a href="{{ URL::route('vendorDeleteOrder', array('id' => $o->id)) }}">
									<button type="submit" style = "width:70px;">
										Delete
									</button>
								</a>
							</div>
						</td>

					</tr>

						@endif
					@endforeach
				@endforeach
	  
	        </table>
	    </div>
		 
    </div><!-- ViewAllOrders SECTION END -->
   
   
    <hr style = "margin-top:50px;">


	<!-- ===========================
   ViewAllCustomers SECTION START
   =========================== -->
	<div id="ViewACu" class="container">

		<!-- ViewAllCustomers SECTION HEADING START -->
		<div class="sectionhead  row wow fadeInUp">
			<img data-wow-duration="4s" src="img/Customer.jpg" height = "100px" alt="Customer Logo"/>
			<h3>View All Customers</h3>
			<hr class="separetor">

			<div id = "HD"><button class = "displayCu">Display</button></div>

		</div><!--ViewAllCustomers SECTION HEADING END-->

		<div id = "th">
			<table class = "tableCu" width = "1000" align = "center" border = "1" bgcolor="black" style = "color:white; background:black; font-size:16px; margin-bottom:70px;">

				<tr>
					<td colspan = "8" align = "center"><h2>All Customers Here!</h2></td>
				</tr>

				<tr align = "center" style = "color:#FFFF00;">
					<th style = "padding: 20px;">id :</th>
					<th>Name :</th>
					<th>Email :</th>
					<th>Address :</th>
					<th>CreditCart# :</th>
					<th>Phone#:</th>
				</tr>

				@foreach($customer as $c)
					<tr style="text-align: center">

						<td style = "padding: 20px;">{{$c->id}}</td>
						<td>{{$c->username}}</td>
						<td>{{$c->email}}</td>
						<td>{{$c->home_address}}</td>
						<td>{{$c->creditcartNo}}</td>
						<td>{{$c->phoneNo}}</td>

					</tr>
				@endforeach

			</table>
		</div>

	</div><!-- ViewAllCustomers SECTION END -->


	<hr style = "margin-top:50px;">
   
   
    <!-- ===========================
    ViewAllPayments SECTION START
    =========================== -->
    <div id="ViewAPa" class="container">
       
        <!-- ViewAllPayments SECTION HEADING START -->
        <div class="sectionhead  row wow fadeInUp">
             <img data-wow-duration="4s" src="img/payments.gif" height = "100px" alt="Order Logo"/>   
            <h3>View All Payments</h3>
            <hr class="separetor">

			<div id = "HD"><button class = "displayPa">Display</button></div>
			
        </div><!--ViewAllPayments SECTION HEADING END-->
         
		<div id = "th">
		    <table class = "tablePa" width = "1000" align = "center" border = "1" bgcolor="black" style = "color:white; background:black; font-size:16px; margin-bottom:70px;">
      
	            <tr>
	                <td colspan = "8" align = "center"><h2>All Payments Here!</h2></td>
	            </tr>
	  
	            <tr align = "center" style = "color:#FFFF00;">
		            <th style = "padding: 20px;">id :</th>
		            <th>Customer_id :</th>
		            <th>Product_id :</th>
		            <th>Amount :</th>
		            <th>Transaction_id :</th>
		            <th>Currency :</th>
		            <th>Payment_Date :</th>
		            <th>Delete</th>
	            </tr>

				@foreach($payment as $pay)
					@foreach($product as $p)
						@if($pay->product_id == $p->id)

							<tr style="text-align: center">

								<td>{{$pay->id}}</td>
								<td>{{$pay->customer_id}}</td>
								<td>{{$pay->product_id}}</td>
								<td>{{$pay->amount}}</td>
								<td>{{$pay->trx_id}}</td>
								<td>{{$pay->currency}}</td>
								<td>{{$pay->payment_date}}</td>

								<td>
									<div id = "deleteBrand">
										<a href="{{ URL::route('vendorDeletePayment', array('id' => $pay->id)) }}">
											<button type="submit" style = "width:70px;">
												Delete
											</button>
										</a>
									</div>
								</td>

							</tr>

						@endif
					@endforeach
				@endforeach
	  
	        </table>
	    </div>
		 
    </div><!-- ViewAllPayments SECTION END -->

	<hr style = "margin-top:50px;">

	<!-- ===========================
    ViewProfile SECTION START
    =========================== -->
	<div id="ViewPr" class="container">

		<!-- ViewProfile SECTION HEADING START -->
		<div class="sectionhead  row wow fadeInUp">
			<img data-wow-duration="4s" src="img/profile.jpg" height = "100px" alt="Profile Logo"/>
			<h3>My Profile</h3>
			<hr class="separetor">

			<div id = "HD"><button class = "displayPr">Display</button></div>

		</div><!--ViewProfile SECTION HEADING END-->

		<div id = "th">
			<table class = "tablePr" width = "1000" align = "center" border = "1" bgcolor="black" style = "color:white; background:black; font-size:16px; margin-bottom:70px;">

				<tr>
					<td colspan = "7" align = "center"><h2>My Profile Here!</h2></td>
				</tr>

				<tr align = "center" style = "color:#FFFF00;">
					<th style = "padding:20px;">Username :</th>
					<th>Password :</th>
					<th>Email :</th>
					<th>Shop Name :</th>
					<th>Update :</th>
				</tr>

					<tr style="text-align: center">
						<td>{{$getVendor->username}}</td>
						<td>{{Crypt::decrypt($getVendor->password)}}</td>
						<td>{{$getVendor->email}}</td>
						<td>{{$getVendor->shop_name}}</td>

						<td>
							<div id = "editPro">
								<a href="{{URL::route('editVProfile', array('id' => $getVendor->id))}}">
									<button type="submit">
										Update
									</button>
								</a>
							</div>
						</td>

					</tr>

			</table>
		</div>

	</div><!-- ViewProfile SECTION END -->

@endsection


@section('footernavbar')

    <li><a href="index">Home</a></li>

@endsection
