


 $('.products-1, .products-2, .products-3, .products-4').owlCarousel({
    dots: false,
    loop:true,
    margin:15,
    navText:["<img src='images/next-arrow.svg'>","<img src='images/next-arrow.svg'>"],
    nav:true,
    autoplay:true,
    autoplayTimeout:2000,
    autoplayHoverPause:false,
    responsive:{
        320:{
            items:2
        },
        480:{
            items:2
        },
        600:{
            items:3
        },
        1000:{
            items:5
        }
    }
})
$('.value_slider').owlCarousel({
  arrows: false,
  autoplay: true,
  infinite: true,
  centerMode: true,
  speed: 600,
  slidesToShow:3.5,
  slidesToScroll: 1,
  responsive:{
      0:{
          items:1,
      },
      768:{
          items:2,
      },
      992:{
          items:3,
          margin:20,
      },
      1280:{
        margin:20,
        items:3,
      },
      1600:{
        margin:20,
        items:3.5,
      },
      1700:{
        margin:20,
        items:3.5,
      }
  }
  
})



const footerYear = document.querySelectorAll(".year");
footerYear.forEach(copyright => {
  copyright.innerHTML = new Date().getFullYear();
});

$('.home_slider').slick({
  dots: true,
  arrows: false,
  autoplay: true,
  infinite: true,
  speed: 300,
  slidesToShow:1,
  slidesToScroll: 1
});
$('.rounder_slider').slick({
  dots: false,
  arrows: true,
  autoplay: false,
  infinite: true,
  speed: 600,
  slidesToShow:1,
  slidesToScroll: 1
});
// $('.value_slider').slick({
	
//   arrows: false,
//   autoplay: true,
//   infinite: true,
//   centerMode: true,
//   speed: 600,
//   slidesToShow:3,
//   slidesToScroll: 1,
//   responsive: [
//     {
//       breakpoint: 991,
//       settings: {
//         slidesToShow: 2,
//       }
//     },
//     {
//       breakpoint: 978,
//       settings: {
//         slidesToShow: 2,
//       }
//     },
//     {
//       breakpoint: 768,
//       settings: {
//         slidesToShow: 1,
//       }
//     }
//   ]
// });






$('.testimonial-slider').slick({
  dots: true,
  arrows: false,
  autoplay: false,
  infinite: true,
  speed: 300,
  slidesToShow:2,
  slidesToScroll: 1,
  responsive: [
    
    {
      breakpoint: 992,
      settings: {
        slidesToShow: 2,
      }
    },
    {
      breakpoint: 768,
      settings: {
        slidesToShow: 1,
      }
    }
  ]
});


$('.testimonial-video').slick({
  dots: true,
  arrows: false,
  autoplay: false,
  infinite: true,
  speed: 300,
  slidesToShow:1,
  slidesToScroll: 1,
  responsive: [
    
    {
      breakpoint: 992,
      settings: {
        slidesToShow: 1,
      }
    },
    {
      breakpoint: 768,
      settings: {
        slidesToShow: 1,
      }
    }
  ]
});

$('.filter_slider .slider-box_wrapper').slick({
  dots: false,
  arrows: true,
  autoplay: true,
  infinite: true,
  speed: 900,
  slidesToShow:1,
  slidesToScroll: 1
});



  // jQuery("header nav ul li").hover(function () {
  //   jQuery(this).parent().children("ul").addClass("active").parent().siblings().children("ul").removeClass("active")
  //   //  jQuery(this).toggleClass("active_expend").parent().siblings().children(".expend_menu").removeClass("active_expend");
  // })

  

  $(function() {
    $('.scroll-down').click (function() {
      $('html, body').animate({scrollTop: $('section.filter_slider').offset().top }, 'slow');
      return false;
    });
  });

  jQuery("header nav ul li.drop_down").hover(function () {
    jQuery("header").toggleClass("active");
  })
  // jQuery("header nav ul li.drop_down").hover(function (e) {
  //   jQuery(this).addClass("active").siblings().removeClass("active")
  // })
  jQuery("header .toggle .inner_toggle").click(function (e) {
    jQuery("header .main-menu").toggleClass("active");
    jQuery(this).toggleClass("active");
  })

  // sticky-navbar
$(window).scroll(function () {
  var sticky = $('header'),
    scroll = $(window).scrollTop();

  if (scroll >= 1) sticky.addClass('sticky');
  else sticky.removeClass('sticky');
});


jQuery(window).bind("load", function () {
  if (document.readyState === "complete") {
    setTimeout(function () {
      jQuery(".loading-group").css({ top: "-100%" });
    }, 800);
  }

  AOS.init({
    duration: 1000,
    once: true,
});

});



$(".home_banner_slider").owlCarousel({
  loop: true,
  autoplay: false,
  margin: 0,
  nav: true,
  dots: false,
  arrows: true,
  autoplayTimeout: 5500,
  smartSpeed: 2000,
  responsive: {
    0: { items: 1,   nav: false,},
    600: { items: 1 },
    1000: { items: 1 },
  },
});





var counted = 0;
$(window).scroll(function() {

  var oTop = $('#counter').offset().top - window.innerHeight;
  if (counted == 0 && $(window).scrollTop() > oTop) {
    $('.count').each(function() {
      var $this = $(this),
        countTo = $this.attr('data-count');
      $({
        countNum: $this.text()
      }).animate({
          countNum: countTo
        },

        {

          duration: 2000,
          easing: 'swing',
          step: function() {
            $this.text(Math.floor(this.countNum));
          },
          complete: function() {
            $this.text(this.countNum);
            //alert('finished');
          }

        });
    });
    counted = 1;
  }

});









// Mobile Bottom Sticky
$(function(){
  $('section.mobile_bottom_menu li a').click( function() {
    $(this).parent().siblings().children().removeClass('active');
    $(this).addClass('active');
  });
});
$(document).ready(function(){
  $(".quick_links").on("click", function(){
  $(".quicklinks_wrap").toggleClass("show");
  $(".admissions_wrap").removeClass("show1");
  $(".enquiry_wrap").removeClass("show2");
  $(".contact_wrap").removeClass("show3");
  $(".menu_wrap").removeClass("show4");
  });
});
$(document).ready(function(){
  $(".admissions").on("click", function(){
  $(".admissions_wrap").toggleClass("show1");
  $(".quicklinks_wrap").removeClass("show");
  $(".enquiry_wrap").removeClass("show2");
  $(".contact_wrap").removeClass("show3");
  $(".menu_wrap").removeClass("show4");
  });
});
$(document).ready(function(){
  $(".enquiry").on("click", function(){
  $(".enquiry_wrap").toggleClass("show2");
  $(".quicklinks_wrap").removeClass("show");
  $(".admissions_wrap").removeClass("show1");
  $(".contact_wrap").removeClass("show3");
  $(".menu_wrap").removeClass("show4");
  });
});
$(document).ready(function(){
  $(".contact").on("click", function(){
  $(".contact_wrap").toggleClass("show3");
  $(".quicklinks_wrap").removeClass("show");
  $(".admissions_wrap").removeClass("show1");
  $(".enquiry_wrap").removeClass("show2");
  $(".menu_wrap").removeClass("show4");
  });
});
$(document).ready(function(){
  $(".menu").on("click", function(){
  $(".menu_wrap").toggleClass("show4");
  $(".quicklinks_wrap").removeClass("show");
  $(".admissions_wrap").removeClass("show1");
  $(".enquiry_wrap").removeClass("show2");
  $(".contact_wrap").removeClass("show3");
  });
});
//mobile-sticky-end---//

$(document).ready(function() {
  $(".mob_menu a").click(function() {
      var link = $(this);
      var closest_ul = link.closest("ul");
      var parallel_active_links = closest_ul.find(".active")
      var closest_li = link.closest("li");
      var link_status = closest_li.hasClass("active");
      var count = 0;

      closest_ul.find("ul").slideUp(function() {
          if (++count == closest_ul.find("ul").length)
              parallel_active_links.removeClass("active");
      });

      if (!link_status) {
          closest_li.children("ul").slideDown();
          closest_li.addClass("active");
      }
  })
});



// Body toggle-overlay

$(function () {	
$('.inner_toggle').on('click',function () {
      $('body').toggleClass('open-toggle-menu');
  });
});


$(function () {	
  $('header nav ul li.drop_down').mouseover('click',function () {
        $('body').toggleClass('hover-overlay');
    });
    $('header nav ul li.drop_down').mouseout('click',function () {
      $('body').toggleClass('hover-overlay');
  });
});

$('.mobile_bottom_menu ul li a.togglee').click( function(){
  if ( $(this).hasClass('current') ) {
      $(this).removeClass('current');
  } else {
      $('.mobile_bottom_menu ul li a.current').removeClass('current');
      $(this).addClass('current');    
  }
});


// gsap.registerPlugin(ScrollTrigger);  

// gsap.utils.toArray(".image-container").forEach(function(container) {
//     let image = container.querySelector("img");
  
//     let tl = gsap.timeline({
//         scrollTrigger: {
//           trigger: container,
//           scrub: true,
//           pin: false,
//         },
//       }); 
//       tl.from(image, {
//         yPercent: -30,
//         ease: "none",
//       }).to(image, {
//         yPercent: 30,
//         ease: "none",
//       }); 
//   });