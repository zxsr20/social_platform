jQuery.fn.extend({
	highlight: function(search, configs){
		if(typeof(search) == 'undefined') return;
		configs =  jQuery.extend({
			insensitive: 1, //是否匹配大小写  0匹配 1不匹配
			hls_class: 'highlight' // 高亮后的class
		},configs);		
		
		 
		return this.each(function() {
			if(typeof(search) == "string") {
				$(this).highregx(search,configs.insensitive,configs.hls_class);
			} else if (search.constructor === Array ) {
				for(var query in search){ 
					$(this).highregx(search[query],configs.insensitive,configs.hls_class);
				}
			} 
		});				  
	},				
	highregx: function(query,insensitive,hls_class){
		query = this.unicode(query);
		var regex = new RegExp("(<[^>]*>)|("+ query +")", insensitive ? "ig" : "g");		
		this.html(this.html().replace(regex, function(a, b, c){
		    return (a.charAt(0) == "<") ? a : "<font class=\"" + hls_class + "\"  >" + c + "</font>";
		}));
	},
	unicode: function(s){ 
		 var len=s.length; 
		 var rs=""; 
		 s = s.replace(/([-.*+?^${}()|[\]\/\\])/g,"\\$1");
		 for(var i=0;i<len;i++){
			if(s.charCodeAt(i) > 255)
				rs+="\\u"+ s.charCodeAt(i).toString(16);
			else rs +=  s.charAt(i);
		 }   
		 return rs; 
	}  
  });