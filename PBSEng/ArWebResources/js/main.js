
jQuery(function ($) {
    'use strict',  


	//#main-slider
	$(function(){
		$('#main-slider.carousel').carousel({
			interval: 8000
		});
	});


	// accordian
	$('.accordion-toggle').on('click', function(){
		$(this).closest('.panel-group').children().each(function(){
		$(this).find('>.panel-heading').removeClass('active');
		 });

	 	$(this).closest('.panel-heading').toggleClass('active');
	});

	//Initiat WOW JS
	new WOW().init();

	// portfolio filter
	$(window).on('load', function () {
	    'use strict';
		var $portfolio_selectors = $('.portfolio-filter >li>a');
		var $portfolio = $('.portfolio-items');
		$portfolio.isotope({
			itemSelector : '.portfolio-item',
			layoutMode : 'fitRows'
		});
		
		$portfolio_selectors.on('click', function(){
			$portfolio_selectors.removeClass('active');
			$(this).addClass('active');
			var selector = $(this).attr('data-filter');
			$portfolio.isotope({ filter: selector });
			return false;
		});
	});

	// Contact form
	var form = $('#main-contact-form');
	form.submit(function(event){
		event.preventDefault();
		var form_status = $('<div class="form_status"></div>');
		$.ajax({
			url: $(this).attr('action'),

			beforeSend: function(){
				form.prepend( form_status.html('<p><i class="fa fa-spinner fa-spin"></i> Email is sending...</p>').fadeIn() );
			}
		}).done(function(data){
			form_status.html('<p class="text-success">' + data.message + '</p>').delay(3000).fadeOut();
		});
	});

	
	//goto top
	$('.gototop').click(function(event) {
		event.preventDefault();
		$('html, body').animate({
			scrollTop: $("body").offset().top
		}, 500);
	});	

	//Pretty Photo
	$("a[rel^='prettyPhoto']").prettyPhoto({
		social_tools: false
	});	
});


/* Script on ready
------------------------------------------------------------------------------*/	
$(document).ready(function(){
	
   

	
	
	
	$('.bars').click(function(){
    	$("body").toggleClass("sh");
    });
	
	$('.peoplesay').slick({
        slidesToShow: 1,
        slidesToScroll: 1,
        autoplay: true,
        dots: false,
        arrows: false,
        infinite: true,
        autoplaySpeed: 1500,
        pauseOnDotsHover: false,
        pauseOnHover: false
    });
	
	
	$('.partner-slide').slick({
        slidesToShow: 7,
        slidesToScroll: 1,
        autoplay: true,
        dots: false,
        arrows: true,
        infinite: true,
        autoplaySpeed: 2000,
        pauseOnDotsHover: false,
        pauseOnHover: false,
		responsive: [
		{
		  breakpoint: 1200,
		  settings: {
			slidesToShow: 6,
			slidesToScroll: 1,
			infinite: true,
			dots: false
		  }
		},
		{
		  breakpoint: 1024,
		  settings: {
			slidesToShow: 4,
			slidesToScroll: 1,
			infinite: true,
			dots: false
		  }
		},
		{
		  breakpoint: 768,
		  settings: {
			slidesToShow: 3,
			slidesToScroll: 1
		  }
		},
		{
		  breakpoint: 641,
		  settings: {
			slidesToShow: 2,
			slidesToScroll: 1
		  }
		},
		{
		  breakpoint: 480,
		  settings: {
			slidesToShow: 1,
			slidesToScroll: 1
		  }
		}
	  ]
    });
	
	$('.people-slider-part').slick({
        slidesToShow: 2,
        slidesToScroll: 1,
        autoplay: false,
        dots: true,
        arrows: false,
        infinite: true,
        autoplaySpeed: 2000,
        pauseOnDotsHover: false,
        pauseOnHover: false,
		responsive: [
		
		{
		  breakpoint: 768,
		  settings: {
			slidesToShow: 1,
			slidesToScroll: 1
		  }
		},
		{
		  breakpoint: 480,
		  settings: {
			slidesToShow: 1,
			slidesToScroll: 1
		  }
		}
	  ]
    });
	
	
	
	 $('#carousel').carousel(
		{
			width: 900,
			height: 300,
			itemWidth: 400,
			horizontalRadius: 450,
			verticalRadius: 120,
			resize: false,
			mouseScroll: false,
			mouseDrag: true,
			scaleRatio: 0.4,
			scrollbar: true,
			tooltip: true,
			mouseWheel: true,
			mouseWheelReverse: true
	});
	
	$('.people-work-block .people-work-slider').slick({
        slidesToShow: 1,
        slidesToScroll: 1,
        autoplay: false,
        dots: true,
        arrows: false,
        infinite: true,
        autoplaySpeed: 2500,
        pauseOnDotsHover: false,
        pauseOnHover: false
    });
	
	$('.testimonial-part').slick({
        slidesToShow: 1,
        slidesToScroll: 1,
        autoplay: true,
        dots: true,
        arrows: false,
        infinite: true,
        autoplaySpeed: 2000,
        pauseOnDotsHover: false,
        pauseOnHover: false
    });
	
	$('#recent-works').slick({
        slidesToShow: 4,
        slidesToScroll: 1,
        autoplay: true,
        dots: false,
        arrows: false,
        infinite: true,
        autoplaySpeed: 2000,
        pauseOnDotsHover: false,
        pauseOnHover: false,
		responsive: [
		{
		  breakpoint: 768,
		  settings: {
			slidesToShow: 3,
			slidesToScroll: 1
		  }
		},
		{
		  breakpoint: 640,
		  settings: {
			slidesToShow: 2,
			slidesToScroll: 1
		  }
		},
		{
		  breakpoint: 480,
		  settings: {
			slidesToShow: 1,
			slidesToScroll: 1
		  }
		}
	  ]
    });
	
	$('.happyclients').slick({
        slidesToShow: 5,
        slidesToScroll: 1,
        autoplay: true,
        dots: false,
        arrows: true,
        infinite: true,
        autoplaySpeed: 2000,
        pauseOnDotsHover: false,
        pauseOnHover: false,
		responsive: [
		{
		  breakpoint: 1199,
		  settings: {
			slidesToShow: 4,
			slidesToScroll: 1,
			infinite: true,
			dots: false
		  }
		},
		{
		  breakpoint: 1024,
		  settings: {
			slidesToShow: 3,
			slidesToScroll: 1
		  }
		},
		{
		  breakpoint: 768,
		  settings: {
			slidesToShow: 2,
			slidesToScroll: 1
		  }
		},
		{
		  breakpoint: 480,
		  settings: {
			slidesToShow: 1,
			slidesToScroll: 1
		  }
		}
	  ]
    });
	
	$('.teammembers').slick({
        slidesToShow: 5,
        slidesToScroll: 1,
        autoplay: true,
        dots: false,
        arrows: false,
        infinite: true,
        autoplaySpeed: 2000,
        pauseOnDotsHover: false,
        pauseOnHover: false,
		responsive: [
		{
		  breakpoint: 1024,
		  settings: {
			slidesToShow: 5,
			slidesToScroll: 1
		  }
		},
		{
		  breakpoint: 768,
		  settings: {
			slidesToShow: 4,
			slidesToScroll: 1
		  }
		},
		{
		  breakpoint: 640,
		  settings: {
			slidesToShow: 3,
			slidesToScroll: 1
		  }
		},
		{
		  breakpoint: 480,
		  settings: {
			slidesToShow: 2,
			slidesToScroll: 1
		  }
		}
	  ]
    });
	
	

	
	$(window).scroll(function(){
		if ($(this).scrollTop() > 100) {
			$('.brand').fadeOut(250,function(){
				$('.nav-bar-main').fadeIn(250);
			});
		} else {
			$('.nav-bar-main').fadeOut(250,function(){
				$('.brand').fadeIn(250);
			});
		}
	});
	
	
	
	//----- equal height script ----- //
    function equal_height(className){
        $(className).each(function(){
            var max = 1;
            $(this).find(".equal-height").css("height","auto");
            $(this).find(".equal-height").each(function() {
                var height1 = $(this).outerHeight();
                max = (height1 > max) ? height1 : max;
            });
            $(this).find(".equal-height").css("height",max);
        })
    }

    $(window).on("load resize ready",function(){
        setTimeout(function(){
            equal_height(".blog-part")
        },100)
    });
	
	
	//----- filecv script ----- //
	$('#filecv').change(function(){
  		if($(this).val()){
  		 $('.file_name').html($(this).val());
  		}else{
  		 $('.file_name').html('Upload your CV');
  		}
  	});
	
	
	$("ul#tabs li").click(function(e){
        if (!$(this).hasClass("active")) {
            var tabNum = $(this).index();
            var nthChild = tabNum+1;
            $("ul#tabs li.active").removeClass("active");
            $(this).addClass("active");
            $("ul#tab li.active").removeClass("active");
            $("ul#tab li:nth-child("+nthChild+")").addClass("active");
        }
    });
	
	$('.nav-bar-slide li a').on('click',function(){
		$('html, body').animate({
			scrollTop: $( $.attr(this, 'href') ).offset().top
		}, 500);
		return false;
	});
	$('.nav-bar-main li a').on('click',function(){
		$('html, body').animate({
			scrollTop: $( $.attr(this, 'href') ).offset().top
		}, 500);
		return false;
	});
	$('.responsive-menu ul.tog li a').on('click',function(){
		$('html, body').animate({
			scrollTop: $( $.attr(this, 'href') ).offset().top
		}, 500);
		return false;
	});
	$('.footer-menu li a').on('click',function(){
		$('html, body').animate({
			scrollTop: $( $.attr(this, 'href') ).offset().top
		}, 500);
		return false;
	});
	
	$('#slider-main').owlCarousel({
    loop:true,
    margin:10,
    nav:false,
    items: 1,
   	lazyLoad : false,
 	animateOut: 'fadeOut',
 	animateIn: 'fadeIn',
	autoplay:true,
    responsive:{
    0:{
        items:1
    },
    600:{
        items:1
    },
    1000:{
        items:1
    }
}
});


$('nav ul li a').click(function(e) {
    $('nav ul li a').removeClass('active');
    var $this = $(this);
    if (!$this.hasClass('active')) {
        $this.addClass('active');
    }
    e.preventDefault();
});
	
});	

/* Script on scroll
------------------------------------------------------------------------------*/
$(window).scroll(function() {

			if($(this).scrollTop() != 0) {$('#totop').fadeIn();} else {$('#totop').fadeOut();}
            	});
		    if($(this).scrollTop() != 0) {$('#totop').fadeIn();} else {$('#totop').fadeOut();}
	        $('#totop').click(function() {$('body,html').animate({scrollTop:0},800); 	


       	
});	
$(window).scroll(function() {
			
	 });