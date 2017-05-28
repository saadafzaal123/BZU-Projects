@extends('layouts.Master')

@section('title', 'Vendor EditProduct')

@section('img')

	<img data-wow-duration="4s" src="/One_Market/public/img/d_arrow.png" height = "165px" alt="Downward Arrow"/>

@endsection


@section('heading')

	<h2 class="wow fadeInUp" data-wow-duration="5s">To Edit Product : Please Scroll Down</h2>

@endsection


@section('navbar')

	<div class="collapse navbar-collapse">
		<ul class="nav navbar-nav navbar-right"><!--YOUR NAVIGATION ITEMS STRAT BELOW-->
			<li><a href="#EditP"><span class="btnicon icon-user"></span>Edit Product</a></li>
			<li class="active"><a href="/One_Market/public/Vendor_MainArea"><span class="btnicon icon-cloud-download"></span>GoBack</a></li>
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
			<img data-wow-duration="4s" src="/One_Market/public/img/product.png" height = "90px" alt="Product Logo"/>
			<h3>Edit Product</h3>
			<hr class="separetor">
		</div>
		<div id = "SubmitButton">

			<form action = "{{route('updateProduct' , array('id' => $p->id))}}" method = "POST" enctype = "multipart/form-data">

				<input type = "hidden" name ="_token" value = "{{csrf_token()}}">

				<table width = "1000" align = "center" border = "1" bgcolor = "black" style = "color:white; background:black; font-size:16px; margin-bottom:70px;">

					<tr>
						<td colspan = "2" align = "center"><h2>Edit Product:</h2></td>
					</tr>

					<tr>
						<th align = "right">Product Title</th>
						<td><input type = "text" name = "name" size = "35" required = "required" value = "{{$p->name}}"/></td>
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

								@foreach($c_data as $cd)
									{
									<option value = "{{$cd->id}}" @if($cd->id == $cat->id) {{"selected"}} @endif>{{$cd->name}}
									</option>
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

								@foreach($b_data as $bd)
									{
									<option value = "{{$bd->id}}" @if($bd->id == $brand->id) {{"selected"}} @endif>{{$bd->name}}
									</option>
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
						<td><input type = "file" name = "product_img1" ></td>
					</tr>

					@if ($errors->has('product_img1'))
						<tr>
							<th align = "right" style = "color: red;">Image1 Error</th>
							<td style = "color: red;"><strong>{{ $errors->first('product_img1') }}</strong></td>
						</tr>
					@endif

					<tr>
						<th align = "right">Product Image 2</th>
						<td><input type = "file" name = "product_img2" ></td>
					</tr>

					@if ($errors->has('product_img2'))
						<tr>
							<th align = "right" style = "color: red;">Image2 Error</th>
							<td style = "color: red;"><strong>{{ $errors->first('product_img2') }}</strong></td>
						</tr>
					@endif

					<tr>
						<th align = "right">Product Image 3</th>
						<td><input type = "file" name = "product_img3" ></td>
					</tr>

					@if ($errors->has('product_img3'))
						<tr>
							<th align = "right" style = "color: red;">Image3 Error</th>
							<td style = "color: red;"><strong>{{ $errors->first('product_img3') }}</strong></td>
						</tr>
					@endif

					<tr>
						<th align = "right">Product Price</th>
						<td><input type = "text" name = "price" required = "required" value ="{{$p->price}}"/></td>
					</tr>

					@if ($errors->has('price'))
						<tr>
							<th align = "right" style = "color: red;">Price Error</th>
							<td style = "color: red;"><strong>{{ $errors->first('price') }}</strong></td>
						</tr>
					@endif

					<tr>
						<th align = "right">Product Description</th>
						<td><textarea name = "description" cols = "85" rows = "10" >{{$p->description}}</textarea></td>
					</tr>

					<tr>
						<th align = "right">Product Keywords</th>
						<td><input type = "text" name = "keywords" size = "30" required = "required" value ="{{$p->keywords}}"/></td>
					</tr>

					@if ($errors->has('keywords'))
						<tr>
							<th align = "right" style = "color: red;">Keywords Error</th>
							<td style = "color: red;"><strong>{{ $errors->first('keywords') }}</strong></td>
						</tr>
					@endif

					<tr>
						<td colspan = "2" align = "center" height = "35"><strong><input type = "submit" name = "Update_product" value = "Update Product" style = "Color:White; font-size:20px; padding:8px; width:100%"/></strong></td>
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





