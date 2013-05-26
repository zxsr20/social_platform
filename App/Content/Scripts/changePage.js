$(document ).on( "pageinit", function() {

$("#index").bind("swipeleft",function(){	
	$.mobile.changePage(home,{ transition: "slide" },true); 
	$.mobile.pageLoading(true);
});
$("#home").bind("swipeleft",function(){	
	$.mobile.changePage(promotion_index,{ transition: "slide" },true); 
	$.mobile.pageLoading(true);
});
$("#page2").bind("swipeleft",function(){	
	$.mobile.changePage(room_index,{ transition: "slide" },true); 
	$.mobile.pageLoading(true);
});
$("#page2").bind("swiperight",function(){	
	$.mobile.changePage(home,{ transition: "slide", reverse: true },true); 
	$.mobile.pageLoading(true);
});
$("#page4").bind("swiperight",function(){	
	$.mobile.changePage(promotion_index,{ transition: "slide", reverse: true },true); 
	$.mobile.pageLoading(true);
});
$(".enter_btn").bind("click",function(){	
	$.mobile.changePage(home,{ transition: "slide" },true); 
	$.mobile.pageLoading(true);
}); 
});
