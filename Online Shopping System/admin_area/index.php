<?php

include('include/db.php');
include('include/login_file.php');

if(Loggedin())
{
   header('Location:main_page.php');
}

else
{

?>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
<title>Admin Login</title>
<script src = "//tinymce.cachefly.net/4.0/tinymce.min.js"></script>
<script>
  tinymce.init({selector:'textarea'});
</script>
<link rel = "stylesheet" href = "styles/admin_area_style.css"/>
</head>

<body bgcolor="#e3e3e3">

<div id = "container">

<div id = "mian_heading">
<img src = "styles/login_3.jpg" style = "float:left" width = '180' height = '100' />
<img src = "styles/login_1.jpg" style = "float:right" width = '180' height = '100' />
<h1>Admin Login</h1>
</div>

   <div id = "login">
    <form action = "index.php" method = "POST">
    <table width = "400" align = "center" border = "6" height = "250" bgcolor = "#339900">
        <tr>
		    <td colspan = "5" align = "center">
			    <h2>Login</h2>
			</td>
		</tr>
		
		<tr>
		    <th align = "center">User Name:</th>
		    <td align = "center"><input type = "text" name = "admin_name"></td>
		</tr>
		
		<tr>
		    <th align = "center">User Password:</th>
		    <td align = "center"><input type = "password" name = "admin_pass"></td>
		</tr>
		
		<tr>
		    <td colspan = "6" align = "center"><input type = "submit" name = "submit" value = "Login"></td>
		</tr>
    </table>
    </form>
   </div>
      
	  <div class = "footer">
	  
	      <img src = "styles/saad.jpg" style = "float:left" width = '180' height = '100' />
		  <img src = "styles/saad1.png" style = "float:right" width = '180' height = '97' />
		  <h3 style = "color:#FFFFFF; padding-top:20px; text-align:center;">&copy; 2016 - By (www.Saad-Afzaal.com)</h3>
			
	  </div>
	  
</div>
</body>
</html>

<?php

if(isset($_POST['submit']))
{
	$Admin_name = $_SESSION['admin_name'] = $_POST['admin_name'];
	$Admin_pass = md5($_POST['admin_pass']);
	
	$Admin_name = mysqli_real_escape_string($con, $Admin_name);
	$Admin_pass = mysqli_real_escape_string($con, $Admin_pass);
	
	$query = "select * from `admin_login` where `Name` = '$Admin_name' and `Password` = '$Admin_pass'";
	$query_run = $con->query($query);
	
	if(mysqli_num_rows($query_run) == 1)
	{
		echo "<script>window.open('main_page.php?logged=You are Logged in Successfully...!' , '_self')</script>";
	}
	else
	{
		echo '<script>alert("Username or Password is inccorect.")</script>';
	}
}

}
?>




