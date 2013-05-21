<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Create.Master" Inherits="System.Web.Mvc.ViewPage<DAL.youhui>" %>
<%@ Import Namespace="Common" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CurentPlace" runat="server">
      创建 youhui
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset>
        <legend>
            <input type="submit" value="创建" />
            <input type="button" onclick="BackList('youhui')" value="返回列表" />
        </legend>
        <div class="bigdiv">
                 
            <div class="editor-label">
                <%: Html.LabelFor(model => model.name) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.name) %>
                <%: Html.ValidationMessageFor(model => model.name) %>
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(model => model.decription) %>
            </div>
            <div class="editor-field">
                <%: Html.TextAreaFor(model => model.decription) %>
                <%: Html.ValidationMessageFor(model => model.decription) %>
            </div>     
            <div class="editor-label">
                <%: Html.LabelFor(model => model.net_price) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.net_price) %>
                <%: Html.ValidationMessageFor(model => model.net_price) %>
            </div>     
            <div class="editor-label">
                <%: Html.LabelFor(model => model.save_money) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.save_money) %>
                <%: Html.ValidationMessageFor(model => model.save_money) %>
            </div>     
            <div class="editor-label">
                <%: Html.LabelFor(model => model.telephone) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.telephone) %>
                <%: Html.ValidationMessageFor(model => model.telephone) %>
            </div>     
            <div class="editor-label">
                <%: Html.LabelFor(model => model.mobile) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.mobile) %>
                <%: Html.ValidationMessageFor(model => model.mobile) %>
            </div>     
            <div class="editor-label"  style="display: none">
                <%: Html.LabelFor(model => model.userid) %>
            </div>
            <div class="editor-field"  style="display: none">
                <%: Html.EditorFor(model => model.userid) %>
                <%: Html.ValidationMessageFor(model => model.userid) %>
            </div>     
            <div class="editor-label"  style="display: none">
                <%: Html.LabelFor(model => model.updatetime) %>
            </div>
            <div class="editor-field"  style="display: none">
                <%: Html.TextBox("updatetime", ((Model != null && Model.updatetime != null) ? Model.updatetime.ToString().AsDateTime().ToString("yyyy-MM-dd") : ""), new { onclick = "WdatePicker()", @class="text-box single-line" })%>
                <%: Html.ValidationMessageFor(model => model.updatetime) %>
            </div>     
            <div class="editor-label"  style="display: none">
                <%: Html.LabelFor(model => model.addtime) %>
            </div>
            <div class="editor-field"  style="display: none">
                <%: Html.TextBox("addtime", ((Model != null && Model.addtime != null) ? Model.addtime.ToString().AsDateTime().ToString("yyyy-MM-dd") : ""), new { onclick = "WdatePicker()", @class="text-box single-line" })%>
                <%: Html.ValidationMessageFor(model => model.addtime) %>
            </div>     
            <div class="editor-label"  style="display: none">
                <%: Html.LabelFor(model => model.pic) %>
            </div>
            <div class="editor-field"  style="display: none">
                <%: Html.EditorFor(model => model.pic) %>
                <%: Html.ValidationMessageFor(model => model.pic) %>
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

