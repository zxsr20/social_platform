/*
 *  @author yewang
 *
 *  @data  2013/04/17
 *
 *  @desc  手机端滑动加载js
 *
 */

 (function(w, undefined) {
 	
 	var SLIDE = {
 		init: function() {

 			var o = this.opts(),
 				zs = this;

 			//选中加载第一项tab和内容
 			o.nav.children().eq(0).addClass('current');
 			o.wrap.children().eq(0).addClass('loaded');
 			o.wrap.css('minHeight', $(window).height()-88-o.nav.height()); //设置最小高度

 			var hash = document.location.hash.slice(1);

 			if(hash > 0) {
 				//根据hash值选中tab和内容
 				document.location.hash = '';
 				this.hash(hash);
 			}

 			//驱动touch和click事件
 			this.touchdrive(o);
 			this.clickdrive(o);

 			//绑定设备方向切换定位事件
 			window.addEventListener('orientationchange', function(){zs.onorientationchange(zs)}, false);

 		},

 		hash: function(i) {

 			this.goTo(i);

 		},

 		opts: function() {
 			return {
 				nav: $('#nav'),
				wrap: $('#slideWrap'),
				width: $('#slideWrap').children().eq(0).width(),
				itemTotal: $('#slideWrap').children().length - 1
 			}
 		},

 		onorientationchange: function(zs) {

 			var o = zs.opts(),
 				i = o.nav.find('.current').index(),
 				w;

 			setTimeout(function() {
 				w = o.wrap.children().eq(0).width();
 				o.wrap.css('minHeight', $(window).height()-88-o.nav.height());

 				var ch = o.wrap.children().eq(i).height(),
 					oh = parseInt(o.wrap.css('minHeight'));
 				o.wrap.height((ch > oh) ? ch : oh);
 				o.wrap.css('marginLeft', -(i*w));
 			}, 100);
 		},

 		touchdrive: function(o) {
 			var zs = this,
 				n = o.nav,
 				ua = navigator.userAgent,
 				ip = ua.indexOf(ua.match(/iPhone|iPad|iTouch/)),
 				w = o.wrap;

 			touchEvent();
 			
 			function touchEvent() {

	 			var x = y = endX = endY = 0,
	 				d = null, //滑动方向
					p = 3.5, //角度比例
					len = 20, //滑动距离基准
					moving = false;  //触摸移动中;

				function touchStart(e) {
					
					x = e.touches[0].pageX;
					y = e.touches[0].pageY;

				}

				function touchMove(e) {

					endX = e.touches[0].pageX - x;
					endY = e.touches[0].pageY - y;

					if(moving) {
						e.preventDefault();
					} else {
						d = (Math.abs(endX) > Math.abs(endY)) ? (endX > 0 ? 'right' : 'left') :  (endY > 0 ? 'down' : 'up');

						if('leftright'.indexOf(d) > -1) {
							moving = true;
							e.preventDefault();
						}
						
					}
				}

				function trySwipe() {
					try {
						zs['swipe' + d]();
					} catch (e) {

					}
				}

				function touchEnd(e) {

					moving = false;

					if('leftright'.indexOf(d) === -1)return;

					if(ip > -1) { //苹果系列添加判断 解决反映灵敏问题
						var absX = Math.abs(endX),
							absY = Math.abs(endY);

						if(absX > len && absX/absY > p) {
							trySwipe();
						}
					} else {
						trySwipe();
					}

					d = endX = endY = null;

				}

				document.querySelector("#slideWrap").addEventListener('touchstart', touchStart, false);
				document.querySelector("#slideWrap").addEventListener('touchmove', touchMove, false);
				document.querySelector("#slideWrap").addEventListener('touchend', touchEnd, false);

			}

 		},

 		clickdrive: function(o) {
 			var zs = this,
 				n = o.nav;

 			n.children().on('click', function() {
 				if($(this).hasClass('current'))return;
 				zs.goTo($(this).index());
 			});
 		},

 		goTo: function(i) {
 			var o = this.opts(),
 				n = o.nav,
 				w = o.wrap;

 			n.children().removeClass('current').eq(i).addClass('current');

 			var cur_li = w.children().eq(i);

 			if(!cur_li.hasClass('loaded') && !cur_li.hasClass('loading')) {

 				cur_li.addClass('loading');

 				this.ajax({
	 				url: n.find('.current').attr('rel'),
	 				success: function(d) {
	 					cur_li.html(d).addClass('loaded').removeClass('loading');
	 				}
	 			});
 			}

			function setHeight() {
				if(cur_li.hasClass('loading')) {
					setTimeout(setHeight, 500);
				}
				setTimeout(function() {
					window.scrollTo(0, 1)
				}, 0);
				var ch = cur_li.height(),
 					wh = parseInt(w.css('minHeight'));
 				w.height((ch > wh) ? ch : wh);
			}

 			w.animate({
 				marginLeft: (-(i*o.width) + 'px')
 			}, 300, '', function() {
 				setHeight();	
 			});
 		},

 		getIndex: function() {
 			return this.opts().nav.find('.current').index();
 		},

 		swipeleft: function() {
 			var i = this.getIndex();

 			return (i < this.opts().itemTotal) ? this.goTo(++i) : true;
 		},

 		swiperight: function() {
 			var i = this.getIndex();

 			return (i > 0) ? this.goTo(--i) : true;
 		},

 		ajax: function(opt) {

 			$.ajax({
 				url: opt.url,
 				type: opt.type || "POST",
 				data: opt.data || '',
 				success: function(response) {
 					setTimeout(function() {opt.success(response);}, 200);
 				}

 			});
 		}


 	};

 	$(function() {
 		SLIDE.init();
 	});


 }(window));