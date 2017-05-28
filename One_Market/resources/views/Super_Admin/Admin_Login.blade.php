@extends('layouts.masterAdminLogin')

@section('title', 'Login')

@section('heading', 'Admin Login')

@section('content')

    <div class="login-page">
        <div class="form">
            <form class="login-form" action = "{{route('doLogin')}}" method = "POST">

                <input type = "hidden" name ="_token" value = "{{csrf_token()}}">

                <input type="email" placeholder="email" required = "required" name = "email"/>

                @if ($errors->has('email'))
                    <span class="help-block" style = "color: red;">
                        <strong>{{ $errors->first('email') }}</strong>
                    </span>

                    <br>
                    <br>
                @endif

                <input type="password" placeholder="password" required = "required" name = "password"/>

                @if ($errors->has('password'))
                    <span class="help-block" style = "color: red;">
                        <strong>{{ $errors->first('password') }}</strong>
                    </span>

                    <br>
                    <br>
                @endif

                <button>login</button>
                <p class="message">Forget Password? <a href="#">Click Here!</a></p>
            </form>
        </div>	
    </div>

@endsection