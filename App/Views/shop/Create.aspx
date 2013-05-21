<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Create.Master" Inherits="System.Web.Mvc.ViewPage<DAL.shop>" %>
<%@ Import Namespace="Common" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CurentPlace" runat="server">
    <script src="/Res/jquery.uploadify-v2.1.4/swfobject.js" type="text/javascript" ></script>
    <script src="/Res/jquery.uploadify-v2.1.4/jquery.uploadify1.v2.1.4.js" type="text/javascript" ></script>
    <link href="/Res/jquery.uploadify-v2.1.4/uploadify.css" rel="stylesheet" type="text/css" />

    

       
      创建 shop
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">



    <fieldset>
        <legend>
            <input type="submit" value="创建" />
            <input type="button" onclick="BackList('shop')" value="返回列表" />
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
                <%: Html.LabelFor(model => model.description) %>
            </div>
            <div class="editor-field">
                <%: Html.TextAreaFor(model => model.description) %>
                <%: Html.ValidationMessageFor(model => model.description) %>
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(model => model.welcome_pic) %>
            </div>
            <div class="editor-field">

                <p id="fileQueue"></p>
                

                <%: Html.TextAreaFor(model => model.welcome_pic) %>
                <%: Html.ValidationMessageFor(model => model.welcome_pic) %>
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(model => model.home_pic) %>
            </div>
            <div class="editor-field">
                <%: Html.TextAreaFor(model => model.home_pic) %>
                <%: Html.ValidationMessageFor(model => model.home_pic) %>
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
            <div class="editor-label">
                <%: Html.LabelFor(model => model.address) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.address) %>
                <%: Html.ValidationMessageFor(model => model.address) %>
            </div>     
            <div class="editor-label">
                <%: Html.LabelFor(model => model.fax) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.fax) %>
                <%: Html.ValidationMessageFor(model => model.fax) %>
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(model => model.bus_way) %>
            </div>
            <div class="editor-field">
                <%: Html.TextAreaFor(model => model.bus_way) %>
                <%: Html.ValidationMessageFor(model => model.bus_way) %>
            </div>     
            <div class="editor-label">
                <%: Html.LabelFor(model => model.filltime) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBox("filltime", ((Model != null && Model.filltime != null) ? Model.filltime.ToString().AsDateTime().ToString("yyyy-MM-dd") : ""), new { onclick = "WdatePicker()", @class="text-box single-line" })%>
                <%: Html.ValidationMessageFor(model => model.filltime) %>
            </div>     
            <div class="editor-label">
                <%: Html.LabelFor(model => model.shop_type) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.shop_type) %>
                <%: Html.ValidationMessageFor(model => model.shop_type) %>
            </div>     
            <div class="editor-label">
                <%: Html.LabelFor(model => model.locx) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.locx, new {  onkeyup = "isInt(this)", @class="text-box single-line" })%>
                <%: Html.ValidationMessageFor(model => model.locx) %>
            </div>     
            <div class="editor-label">
                <%: Html.LabelFor(model => model.locy) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.locy, new {  onkeyup = "isInt(this)", @class="text-box single-line" })%>
                <%: Html.ValidationMessageFor(model => model.locy) %>
            </div>     
            <div class="editor-label">
                <%: Html.LabelFor(model => model.userid) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.userid) %>
                <%: Html.ValidationMessageFor(model => model.userid) %>
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

