<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Create.Master" Inherits="System.Web.Mvc.ViewPage<DAL.status>" %>
<%@ Import Namespace="Common" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CurentPlace" runat="server">
      创建 status
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset>
        <legend>
            <input type="submit" value="创建" />
            <input type="button" onclick="BackList('status')" value="返回列表" />
        </legend>
        <div class="bigdiv">
                 
            <div class="editor-label">
                <%: Html.LabelFor(model => model.statusname) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.statusname) %>
                <%: Html.ValidationMessageFor(model => model.statusname) %>
            </div>
        <div class="editor-label">
            <a class="anUnderLine" onclick="showModalOnly('userid','../../SysPerson');">
                <%: Html.LabelFor(model => model.userid) %>
            </a>
        </div>
        <div class="editor-field">
            <div id="checkuserid">            
            </div>
            <%: Html.HiddenFor(model => model.userid)%>
        </div>     
            <div class="editor-label">
                <%: Html.LabelFor(model => model.addtime) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBox("addtime", ((Model != null && Model.addtime != null) ? Model.addtime.ToString().AsDateTime().ToString("yyyy-MM-dd") : ""), new { onclick = "WdatePicker()", @class="text-box single-line" })%>
                <%: Html.ValidationMessageFor(model => model.addtime) %>
            </div>     
            <div class="editor-label">
                <%: Html.LabelFor(model => model.isdel) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.isdel) %>
                <%: Html.ValidationMessageFor(model => model.isdel) %>
            </div>
        </div>
    </fieldset>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
    
                               <script src="<%: Url.Content("~/Res/My97DatePicker/WdatePicker.js") %>" type="text/javascript"></script>
                                 
    <script type="text/javascript">

        $(function () {
            

        });
              

    </script>
</asp:Content>

