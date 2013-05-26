
var ua = navigator.userAgent;

$.each($(".slide_img_list"),
function(e, h) {
	var g = $(h);
	var b = g.attr("id");
	if (!b) {
		return
	}
	if (!window.carousel || ua.indexOf("msie") > -1) {
		return
	}
	var d = g.find(".img_box");
	if (g.length && d.length) {
		d.show()
	}
	var c = new carousel(b, {
		vertical: false,
		horizontal: true,
		pagingDiv: g.next()[0],
		pagingCssName: "img_dot",
		pagingCssNameSelected: "img_dot active",
		pagingFunction: function(i) {
			var j;
			if (this.childrenCount > 1 && this.carouselIndex > 0) {
				var k = g.find(".img_box").eq(this.carouselIndex).find("img");
				if (k.size() > 0) {
					$.each(k,
					function(n, m) {
						var l = $(m);
						var o = l.attr("data-src");
						if (o) {
							l.attr("src", o)
						}
					})
				}
			}
		}
	});
	var f = setInterval(function() {
		autoSlide(c)
	},
	20000)
});
function autoSlide(b) {
	var d = b.carouselIndex;
	var c = d;
	if (b.childrenCount > 1 && d == b.childrenCount - 1) {
		c = 0
	} else {
		c = d + 1
	}
	b.onMoveIndex(c)
}
