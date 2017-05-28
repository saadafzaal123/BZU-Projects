<?php $__env->startSection('title', 'Login'); ?>

<?php $__env->startSection('heading', 'Admin Login'); ?>

<?php $__env->startSection('content'); ?>

    <div class="login-page">
        <div class="form">
            <form class="login-form" action = "<?php echo e(route('doLogin')); ?>" method = "POST">

                <input type = "hidden" name ="_token" value = "<?php echo e(csrf_token()); ?>">

                <input type="email" placeholder="email" required = "required" name = "email"/>

                <?php if($errors->has('email')): ?>
                    <span class="help-block" style = "color: red;">
                        <strong><?php echo e($errors->first('email')); ?></strong>
                    </span>

                    <br>
                    <br>
                <?php endif; ?>

                <input type="password" placeholder="password" required = "required" name = "password"/>

                <?php if($errors->has('password')): ?>
                    <span class="help-block" style = "color: red;">
                        <strong><?php echo e($errors->first('password')); ?></strong>
                    </span>

                    <br>
                    <br>
                <?php endif; ?>

                <button>login</button>
                <p class="message">Forget Password? <a href="#">Click Here!</a></p>
            </form>
        </div>	
    </div>

<?php $__env->stopSection(); ?>
<?php echo $__env->make('layouts.masterAdminLogin', array_except(get_defined_vars(), array('__data', '__path')))->render(); ?>