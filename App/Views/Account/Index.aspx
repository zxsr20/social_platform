<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<App.Models.LogOnModel>" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <title>登 录</title>
    <style type="text/css">
        body
        {
            font-family: 微软雅黑, Verdana;
        }
        fieldset
        {
            padding: 9px;
            border: 1px solid #CCC;
            width: 287px;
        }
        
        legend
        {
            font-size: 1.1em;
            font-weight: 600;
            padding: 2px 4px 8px 4px;
        }
        input[type="text"], input[type="password"]
        {
            width: 200px;
            border: 1px solid #CCC;
        }
        .editor-label
        {
            margin: 1em 0 0 0;
        }
        
        .editor-field
        {
            margin: 0.5em 0 0 0;
        }
        
        .field-validation-error
        {
            color: #ff0000;
        }
        .login
        {
            width: 545px;
            margin-top: 90px;
            margin-left: 25%;
        }
        .login .top
        {
            background: url(../images/login_top.gif) left top no-repeat;
            width: 545px;
            height: 86px;
        }
        .login .middle
        {
            background: url(../images/login_midbg.gif) left top repeat-y;
            width: 545px;
        }
        .login .middle .left
        {
            float: left;
            width: 204px !important;
            width: 194px;
            padding-left: 6px !important;
            padding-left: 0px;
            margin-left: 6px;
            overflow: hidden;
        }
        
        .buttonOn
        {
            background: url(../images/buttonOn_login.gif) left top no-repeat;
            height: 21px;
            width: 109px;
            text-align: center;
            border: 0px;
            margin: 9px,150px,0px,222px;
        }
        
        .login .bottom
        {
            background: url(../images/login_bottom.gif) left top no-repeat;
            width: 545px;
            height: 18px;
        }
    </style>
            <script type="text/javascript">
                function RefreshValidateCode(obj) {
                    obj.src = "/Account/ValidateCode/" + Math.floor(Math.random() * 10000);
                }
    </script>
</head>
<body>
    <form id="Form1" runat="server">
    <div class="login">
        <div class="top">
        </div>
        <div class="middle">
            <div class="left">
                <img alt="登录" src="../images/login_pic.gif"></div>
            <div class="right">
                <div class="right2">
                    <fieldset style="border-top: 0px; border-left: #e8e8e8 1px solid; border-right: #e8e8e8 1px solid;
                        border-bottom: #e8e8e8 1px solid;">
                        <div class="editor-label">
                            用户名：
                        </div>
                        <div class="editor-field">
                            <%: Html.TextBoxFor(m => m.PersonName)%>
                        </div>
                        <div class="editor-label">
                            密&nbsp;&nbsp; 码：
                        </div>
                        <div class="editor-field">
                            <%: Html.PasswordFor(m => m.Password) %>
                        </div>
                        <div class="editor-label">
                            验证码：
                          <img alt="点击刷新验证码！" title="点击刷新验证码！" src="/Account/ValidateCode" style="cursor: pointer;"
                    onclick="RefreshValidateCode(this);" />         </div>
                        <div class="editor-field">
                            <%: Html.TextBoxFor(m => m.ValidateCode, new { MaxLength = "4"})%>
                        </div>
                        <p>
                            <input class="buttonOn" type="submit" value="登录系统" />
                        </p>
                        <p>
                            <%: Html.ValidationMessageFor(m => m.PersonName) %><br />
                            <%: Html.ValidationMessageFor(m => m.Password) %>
                        </p>
                    </fieldset>
                </div>
            </div>
        </div>
        <div class="bottom">
        </div>
    </div>
    </form>
</body>
</html>
