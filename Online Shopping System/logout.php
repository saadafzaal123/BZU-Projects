<?php

session_start();

session_destroy();

header('Location:index.php?LogOut=You are LogOut Successfully!! Come back soon...');

?>