window.addEventListener("scroll", function () {
    if (window.scrollY > 250) {
        $('.navbar').fadeOut(500);
    }
    else {
        $('.navbar').fadeIn();
    }
}, false);

//$(window).scroll(function () {
//    if ($(this).scrollTop() > 300) {
//        $('.navbar-fixed-top').addClass('opaque');
//    } else {
//        $('.navbar-fixed-top').removeClass('opaque');
//    }
//});

//<script type="text/javascript">
//    (function($) {
//        $(document).ready(function () {
//            $(window).scroll(function () {
//                if ($(this).scrollTop() > 200) {
//                    $('#menu').fadeIn(500);
//                } else {
//                    $('#menu').fadeOut(500);
//                }
//            });
//        });
//    })(jQuery);
//</script>