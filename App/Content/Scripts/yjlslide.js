var YJLwidth=718,YJLheight=257,userAgent=navigator.userAgent.toLowerCase(),is_opera=userAgent.indexOf("opera")!=-1&&opera.version(),is_moz=navigator.product=="Gecko"&&userAgent.substr(userAgent.indexOf("firefox")+8,3),is_ie=userAgent.indexOf("msie")!=-1&&!is_opera&&userAgent.substr(userAgent.indexOf("msie")+5,3),Dome={id:function(a,c){var b=typeof a!="string"?a:document.getElementById(a);return c?b.getElementsByTagName(c):b},hasClass:function(a,c){return!a||!c||!a.className?false:RegExp("(?:^|\\s+)"+ c+"(?:\\s+|$)").test(a.className)},addClass:function(a,c){if(!a||!c)return false;if(Dome.hasClass(a,c))return true;a.className=a.className?a.className+" "+c:c;return true},removeClass:function(a,c){if(!Dome.hasClass(a,c))return true;var b=a.className;b==c?a.className="":(b=b.replace(RegExp("(?:^|\\s+)"+c+"(?:\\s+|$)","g"),"").replace(/^\s*/,""),a.className=b)}},vEvent=function(){return{addEvent:function(a,c,b,d){try{a=Dome.id(a),a.addEventListener?c==="mouseenter"?a.addEventListener("mouseover",withoutChildFunction(b), d):c==="mouseleave"?a.addEventListener("mouseout",withoutChildFunction(b),d):a.addEventListener(c,b,d):a.attachEvent&&a.attachEvent("on"+c,b)}catch(k){}},addmousewheel:function(a,c){try{a.addEventListener?a.addEventListener("DOMMouseScroll",c,false):a.attachEvent&&a.attachEvent("onmousewheel",c)}catch(b){}}}}(),withoutChildFunction=function(a){return function(c){for(var b=c.relatedTarget;b!=this&&b;)try{b=b.parentNode}catch(d){break}b!=this&&a(c)}}; function getSon(a){for(var c=[],a=a.childNodes,b=a.length,d=0;d<b;d++)a[d].nodeType==1&&c.push(a[d]);return c} function picShowNew(a,c,b){function d(a){if(!l&&a!=f){l=true;i=a;Dome.removeClass(h[f],"cur");var b=g[f].getElementsByTagName("img")[0].getAttribute("data"),c=g[a].getElementsByTagName("img")[0].getAttribute("data");g[f].getElementsByTagName("img")[0].setAttribute("src",b);g[a].getElementsByTagName("img")[0].setAttribute("src",c);o[0].innerHTML=g[f].innerHTML;o[1].innerHTML=g[a].innerHTML;j.scrollLeft=0;var d=setInterval(function(){j.scrollLeft+=20;if(j.scrollLeft>=YJLwidth-17)j.scrollLeft=YJLwidth, clearInterval(d)},5);Dome.addClass(h[a],"cur");f=i;l=false}}function k(){var a=d,b=i;b+=1;b>m-1&&(b=0);a(b)}var p=Dome.id(a),o=getSon(p),c=Dome.id(c),g=getSon(c),m=g.length,i=0,f=-1,l=false,j=Dome.id(a+"_wrap"),n=null,a=document.createElement("div");a.className="change";for(var c="",e=0;e<m;e++)c+="<i></i>";a.innerHTML=c;var h=getSon(a);p.appendChild(a);(function(a){Dome.addClass(h[a],"cur");f=a})(i);n=setInterval(k,b);for(e=0;e<m;e++)vEvent.addEvent(h[e],"mouseover",new function(){var a=e;return function(){clearInterval(n); d(a)}}),vEvent.addEvent(h[e],"mouseout",new function(){return function(){n=setInterval(k,b)}})} function YSlideInit(a,c){if(c.length<2)return document.getElementById(a).innerHTML="\u5e7b\u706f\u6570\u636e\u52a0\u8f7d\u5931\u8d25",false;var b=".pics_show_wrap{width:"+YJLwidth+"px;height:"+(YJLheight+40)+"px;overflow:hidden;}.pics_show{height:"+(YJLheight+40)+"px;width:9999px;}.pics_show .image{width:"+YJLwidth+"px;float:left;display:block;}.pics_show .image .bg{width:"+YJLwidth+"px;height:37px;background:#000;margin:-37px 0 0 0;filter:alpha(opacity=50); -moz-opacity:0.5; -khtml-opacity:0.5; opacity:0.5;}.pics_show .image img{border:none;display:block;}.pics_show .change{position:absolute;height:20px;clear:both;top:265px;left:110px;z-index:1;}.pics_show .change i{color:#8c8c8c;cursor:pointer;zoom:1;background:url(http://static.xz.veimg.cn/images/flash-img.png) no-repeat;width:40px;height:16px;line-height:16px;display:inline-block;margin-right:2px;}.pics_show .change i.cur{background-position:-40px 0px;color:#9e9e9e;}.pics_show .text{z-index:100;height:37px;position:relative;*position:static;margin:-43px 0 0 0;color:#fff;display:block;text-align:left;font:normal 23px/45px \u5fae\u8f6f\u96c5\u9ed1;background:url(http://static.xz.veimg.cn/images/playlist.gif) no-repeat 10px 10px;padding-left:53px;}.pics_show .text a{color:#fff;}"; if(is_ie){var d=document.createStyleSheet();d.cssText=b}else d=document.createElement("style"),d.type="text/css",d.appendChild(document.createTextNode(b)),document.getElementsByTagName("head")[0].appendChild(d);b='<div id="'+a+'pics_show_wrap" class="pics_show_wrap"><div id="'+a+'pics_show" class="pics_show">';for(d=0;d<2;d++)b=b+'<div class="image"><a title="'+SlideArr[d].Title+'" target="_blank" href="'+SlideArr[d].Link+'"><img height="'+YJLheight+'" width="'+YJLwidth+'" data="'+SlideArr[d].PicUrl+ '" src="'+SlideArr[d].PicUrl+'"></a><div class="bg"></div><h2 class="text"><a target="_blank" href="'+SlideArr[d].Link+'">'+SlideArr[d].Title+"</a></h2>",b+="</div>";b+="</div>";b=b+'<div style="display: none;" id="'+a+'pics_arr">';for(d=0;d<c.length;d++)b=b+'<div class="image" style="display: none;"><a title="'+SlideArr[d].Title+'" target="_blank" href="'+SlideArr[d].Link+'"><img height="'+YJLheight+'" width="'+YJLwidth+'" data="'+SlideArr[d].PicUrl+'" src="'+SlideArr[d].PicUrl+'"></a><div class="bg"></div><h2 class="text"><a target="_blank" href="'+ SlideArr[d].Link+'">'+SlideArr[d].Title+"</a></h2>",b+="</div>";b+="</div>";b+="</div>";document.getElementById(a).innerHTML=b;picShowNew(a+"pics_show",a+"pics_arr",4E3)}YSlideInit("CjSlide",SlideArr);