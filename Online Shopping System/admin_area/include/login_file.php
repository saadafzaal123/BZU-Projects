<?php

session_start();

function Loggedin()
{
	if(@$_SESSION['admin_name'])
	{
		return true;
	}
    else
    {
		return false;
    }
}

?>
	