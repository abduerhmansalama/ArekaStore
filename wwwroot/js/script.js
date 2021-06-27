var currentpage = 0;

var form = document.getelementbyid('target');
var pages = form.children[0].children;
var progressbar = document.getelementbyid('progress-bar').children[0];

for(var i = 0; i < pages.length; i++ )
  {
    pages[i].style.display = "none";
  }
pages[currentpage].style.display = "block";
pages[currentpage].classlist.add('active');
document.getelementbyid('next-button').addeventlistener('click', nextpage);
function nextpage() 
{
  progress = ((currentpage + 1) / pages.length) * 100;
  progressbar.style.width = progress + "%"; 
  progressbar.style.backgroundcolor = "#" + progress; + progress
  if(currentpage + 1 < pages.length)
    {
  pages[currentpage].classlist.add('inactive');
  
  settimeout(function()
  {
    document.getelementbyid('next-button').style.display="none";
    pages[currentpage].style.display = "none";
    currentpage++;
    pages[currentpage].style.display = "block";
    pages[currentpage].classlist.add('active');
  }, 500);
  }
  
}

///////////////////////

   // You can also use "$(window).load(function() {"
   $(function () {
    // Slideshow 1
    $("#slider1").responsiveSlides({
       auto: true,
   nav: true,
   speed: 500,
   namespace: "callbacks",
    });
   });

/////////
$(document).ready(function () { $(".megamenu").megamenu(); });

//////// 

$(window).load(function () {
    $("#flexiselDemo1").flexisel({
        visibleItems: 5,
        animationSpeed: 1000,
        autoPlay: true,
        autoPlaySpeed: 3000,
        pauseOnHover: true,
        enableResponsiveBreakpoints: true,
        responsiveBreakpoints: {
            portrait: {
                changePoint: 480,
                visibleItems: 1
            },
            landscape: {
                changePoint: 640,
                visibleItems: 2
            },
            tablet: {
                changePoint: 768,
                visibleItems: 3
            }
        }
    });
});