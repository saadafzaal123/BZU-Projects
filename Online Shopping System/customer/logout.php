<?php

session_start();

session_destroy();

header('Location:my_account.php?LogOut=You are LogOut Successfully!! Come back soon...');

?>