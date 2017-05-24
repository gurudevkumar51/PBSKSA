
//strict mode enabled
    "use strict";
    
    
$(window).load(function(){
    //Filtering with isotope

    var $grid = $('.grid').isotope({
        // options
        itemSelector: '.grid-item',
        layoutMode: 'masonry',
        percentPosition: true
    });

    // filter items on button click
    $('.filter-button-group').on( 'click', 'button', function() {
      var filterValue = $(this).attr('data-filter');
      $grid.isotope({ filter: filterValue });
    });    
});




$(document).ready(function(){


    //Smooth scrolling //Not Required for Portfolio
    //$("nav a").on('click', function(event) {
    //    // Make sure this.hash has a value before overriding default behavior
    //    if (this.hash !== "") {
    //      // Prevent default anchor click behavior
    //      event.preventDefault();

    //      // Store hash
    //      var hash = this.hash;

    //      // Using jQuery's animate() method to add smooth page scroll
    //      // The optional number (800) specifies the number of milliseconds it takes to scroll to the specified area
    //      $('html, body').animate({
    //        scrollTop: $(hash).offset().top
    //      }, 800, function(){
       
    //        // Add hash (#) to URL when done scrolling (default click behavior)
    //        window.location.hash = hash;
    //      });
    //    }  // End if
    //});


    //parallax effect with stellar.js
    //$(window).stellar({
        // Set scrolling to be in either one or both directions
       // horizontalScrolling: false,
       // verticalScrolling: true,

        // Set the global alignment offsets
       // horizontalOffset: 0,
       // verticalOffset: 50,

        // Refreshes parallax content on window load and resize
       // responsive: true,

        // Select which property is used to calculate scroll.
        // Choose 'scroll', 'position', 'margin' or 'transform',
        // or write your own 'scrollProperty' plugin.
       // scrollProperty: 'scroll',

        // Select which property is used to position elements.
        // Choose between 'position' or 'transform',
        // or write your own 'positionProperty' plugin.
       // positionProperty: 'transform',

        // Enable or disable the two types of parallax
       // parallaxBackgrounds: true,
       // parallaxElements: true,

        // Hide parallax elements that move outside the viewport
       // hideDistantElements: true,

        // Customise how elements are shown and hidden
        //hideElement: function($elem) { $elem.hide(); },
        //showElement: function($elem) { $elem.show(); }
        //});



	//animated nav button
	//$(".custom_butt").on('click',function(){
	//	$(this).toggleClass("change");
	//});


    //animation on scroll
    //new WOW().init();


    //fancybox
	$('.fancybox').fancybox();


	//killer carousel
    //$('.kc-wrap').KillerCarousel({
    //    width: 800,
    //    spacing3d: 120, 
    //    spacing2d: 120,
    //    showShadow: true,
    //    showReflection: false,
    //    infiniteLoop: true,
    //    autoScale: 80
    //});


    //owl carousel
    //$("#comment_slider").owlCarousel({
    //    navigation : true,
    //    slideSpeed : 500,
    //    paginationSpeed : 500,
    //    items: 4,
    //    singleItem: true,
    //    autoPlay: true,
    //    autoHeight: false

    //    // itemsDesktop : false,
    //    // itemsDesktopSmall : false,
    //    // itemsTablet: false,
    //    // itemsMobile : false
    //});

    //$(".partner_logos").owlCarousel({
    //	navigation : false,
    //    slideSpeed : 500,
    //    paginationSpeed : 500,
    //    items: 6,
    //    autoPlay: true,
    //    autoHeight: false
    //});


    //tooltip
    //$('[data-toggle="tooltip"]').tooltip()


    
});