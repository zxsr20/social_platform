$(document).ready(function() {
	var masks = []; 
	masks[0] = document.querySelector('.mask1'); 
	masks[1] = document.querySelector('.mask2'); 
	masks[2] = document.querySelector('.mask3'); 
	
	for(var i = 0, l = masks.length; i < l; i++) { 
		if(masks[i]) { 
		masks[i].addEventListener('touchmove', function(e){e.preventDefault();}, false); 
		} 
	}
	
	try { 
		if(window.WeixinJSBridge){
			$("footer").hide();
			}
	}catch(e) { 
	}
   	$(".apply_btn").bind("click",function(){
		$("html").css("overflow","hidden");
		$(".mask1").show();
		});
	$(".share_btn a").bind('click',function(){
		$("html").css("overflow","hidden");
		$(".mask2").show();
		});
	$(".save_btn a").bind('click',function(){
		$("html").css("overflow","hidden");
		$(".mask3").show();
		});			
//Home img	
var t = setInterval("bChange()",5000);
});
//
function bChange(){
$(".banner li").eq(0).appendTo(".banner");
var bImgLen = $(".banner li").length;
for(var i=0; i < bImgLen; i++){
  $(".banner li").eq(i).css({"z-index":i}); 
   }
$(".banner li").eq(bImgLen-1).css({"opacity":"0"}).animate({"opacity":"1.0"},1000);  
}
//关闭报名窗口
function closeWindow(){
	$("html").css("overflow","");
	$(".mask1,.mask2,.mask3").hide();
	}