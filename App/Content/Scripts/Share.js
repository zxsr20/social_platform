
//分享js
function showMyShow() {
    document.writeln("<span class=\"share-shop\"><em>分享到:</em><a class='mdl' href=\"javascript:shareMeadinHome();\" >迈点蓝</a> <a class='xl' href=\"javascript:void((function(s,d,e,r,l,p,t,z,c){x=document;y=window;if(x.selection){Q=x.selection.createRange().text;}else%20if(y.getSelection){Q=y.getSelection();}else%20if(x.getSelection){Q=x.getSelection();};var%20f=\'http://v.t.sina.com.cn/share/share.php?\',u=z||d.location,p=[\'url=\',e(u)+e(\'\n\')+e(Q),\'&amp;title=\',e(t||d.title),\'&amp;source=\',e(r),\'&amp;sourceUrl=\',e(l),\'&amp;content=\',c||\'gb2312\',\'&amp;pic=\',e(p||\'\')].join(\'\');function a(){if(!window.open([f,p].join(\'\'),\'mb\',[\'toolbar=0,status=0,resizable=1,width=440,height=430,left=\',(s.width-440)/2,\',top=\',(s.height-430)/2].join(\'\')))u.href=[f,p].join(\'\');};if(/Firefox/.test(navigator.userAgent))setTimeout(a,0);else a();})(screen,document,encodeURIComponent,\'\',\'\',\'\',\'\',\'\',\'utf-8\'));\" >新浪</a><a class='msn' href=\"javascript:void(0)\" onclick=\"CopyURL();return false;\" >MSN/QQ</a><a class='kx' href=\"javascript:d=document;t=d.selection?(d.selection.type!=\'None\'?d.selection.createRange().text:\'\'):(d.getSelection?d.getSelection():\'\');void(kaixin=window.open(\'http://www.kaixin001.com/~repaste/repaste.php?&amp;rurl=\'+escape(d.location.href)+\'&amp;rtitle=\'+escape(d.title)+\'&amp;rcontent=\'+escape(d.title),\'kaixin\'));kaixin.focus();\" >开心</a><a class='ren' href=\"javascript:void((function(s,d,e){if(/xiaonei\.com/.test(d.location))return;var%20f=\'http://share.xiaonei.com/share/buttonshare.do?link=\',u=d.location,l=d.title,p=[e(u),\'&amp;title=\',e(l)].join(\'\');function a(){if(!window.open([f,p].join(\'\'),\'xnshare\',[\'toolbar=0,status=0,resizable=1,width=626,height=436,left=\',(s.width-626)/2,\',top=\',(s.height-436)/2].join(\'\')))u.href=[f,p].join(\'\');};if(/Firefox/.test(navigator.userAgent))setTimeout(a,0);else a();})(screen,document,encodeURIComponent));\" >人人</a></span>");

}
function shareMeadinHome() {
    var strTitle = document.title;
    var strUrl = window.location.href;
    //alert(escape(strTitle));
    window.open("http://home.meadin.com/share/?uid=&view=me&rtitle=" + escape(strTitle) + "&rurl=" + encodeURIComponent(strUrl));
}
//添加到收藏
function addFavorite() {
    var aUrls = document.URL.split("/");
    var vDomainName = "http://" + aUrls[2] + "/";
    var description = document.title;
    try {//IE 
        window.external.AddFavorite(vDomainName, description);
    } catch (e) {//FF 
        window.sidebar.addPanel(description, vDomainName, "");
    }
}
//复制地址
function CopyURL() {
    var myHerf = top.location.href;
    var title = document.title;
    if (window.clipboardData) {
        var tempCurLink = title + "\n" + myHerf;
        var ok = window.clipboardData.setData("Text", tempCurLink);
        if (ok) alert("帖子标题和链接已复制，您可以转发给QQ/MSN上的好友了。");
    }
    else { alert("您使用的浏览器不支持复制功能，请使用Ctrl+C或鼠标右键在浏览器地址栏复制帖子链接。"); }
}
//站外分享
function outsideShow(s, id) {

    var outside = document.getElementById(id);
    if (s == "show") {
        outside.style.display = "block";
    }
    else {
        setTimeout("document.getElementById('" + id + "').style.display=\"none\";", 3000);
    }
}