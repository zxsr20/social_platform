<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <title>管理信息系统</title>
    <script src="<%: Url.Content("~/Scripts/jquery.min.js") %>" type="text/javascript"></script>
    <link href="<%: Url.Content("~/Content/default.css") %>" rel="stylesheet" type="text/css" />
    
    <script src="<%: Url.Content("~/Res/easyui/easyloader.js") %>" type="text/javascript"></script>
    <script src="<%: Url.Content("~/Scripts/outlook2.js") %>" type="text/javascript"></script>
    <script type="text/javascript">
              var _menus = { "menus": [
           					 <%= ViewData["Menu"] %>
				]
        };
    
   
    </script>
    <style type="text/css">
      
    </style>
</head>
<body class="easyui-layout" >
    <noscript>
        <div style="position: absolute; z-index: 100000; height: 2046px; top: 0px; left: 0px;
            width: 100%; background: white; text-align: center;">
            <img src="../../images/noscript.gif" alt='抱歉，请开启脚本支持！' />
        </div>
    </noscript>
    <div region="north" split="true" border="false" style="overflow: hidden; height: 76px;
        line-height: 20px; color: #fff; font-family: 微软雅黑,黑体">
        <div class="top">
            <div id="mainctrl">
                <div style="padding-right: 5px; text-align: right; color: Black">
                    <%= ViewData["PersonName"]%>
                    ,欢迎您的光临！ <a href="#" id="loginOut" >安全退出</a></div>
      
            </div>
        </div>
    </div>
    <div region="south" split="true" style="height: 29px;">
         <div style="padding: 0px; margin-left:50%;">
            技术支持 </div>
    </div>
    <div region="west" hide="true" split="true" title="导航菜单" style="width: 180px;" id="west">
        <div id="nav" class="easyui-accordion" fit="true" border="false">
            <!--  导航内容 -->
        </div>
    </div>
    <div id="mainPanle" region="center" style="background: #eee; overflow-y: hidden;">
        <div id="tabs" class="easyui-tabs" fit="true" border="false">
            <div title="我的工作台" style="padding: 20px; overflow: hidden; width: 820px; height: 480px;
                float: left;">
              
            </div>
        </div>
    </div>
     
    <div id="mm" class="easyui-menu" style="width: 150px;">
        <div id="mm-tabupdate">
            刷新</div>
        <div class="menu-sep">
        </div>
        <div id="mm-tabclose">
            关闭</div>
        <div id="mm-tabcloseall">
            全部关闭</div>
        <div id="mm-tabcloseother">
            除此之外全部关闭</div>
        <div class="menu-sep">
        </div>
        <div id="mm-tabcloseright">
            当前页右侧全部关闭</div>
        <div id="mm-tabcloseleft">
            当前页左侧全部关闭</div>
       
    </div>
</body>
</html>
