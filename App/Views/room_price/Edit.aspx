<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Edit.Master" Inherits="System.Web.Mvc.ViewPage<DAL.room_price>" %>
<%@ Import Namespace="Common" %>
 
<asp:Content ID="Content4" ContentPlaceHolderID="CurentPlace" runat="server">
     修改 room_price
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <fieldset>
        <legend>
            <input type="submit" value="修改" />
            <input type="button" onclick="BackList('room_price')" value="返回列表" />
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
            <div class="editor-label"  style="display: none">
                <%: Html.LabelFor(model => model.userid) %>
            </div>
            <div class="editor-field"  style="display: none">
                <%: Html.EditorFor(model => model.userid) %>
                <%: Html.ValidationMessageFor(model => model.userid) %>
            </div>
            <div class="editor-label" >
                <%: Html.LabelFor(model => model.pic) %>
            </div>
            <div class="editor-field"  >

                 <input type="image" id="upload" name="upload"  src="/Images/tpsc.png"
                    onclick='javascript:window.open("/upload?type=5&bid=<%=Html.Encode(Model.id)%>    ");return false;'

                <%--<%: Html.TextAreaFor(model => model.pic) %>
                <%: Html.ValidationMessageFor(model => model.pic) %>--%>
            </div>     
            <div class="editor-label"  style="display: none">
                <%: Html.LabelFor(model => model.filltime) %>
            </div>
            <div class="editor-field"  style="display: none">
                <%: Html.TextBox("filltime", ((Model != null && Model.filltime != null) ? Model.filltime.ToString().AsDateTime().ToString("yyyy-MM-dd") : ""), new { onclick = "WdatePicker()", @class="text-box single-line" })%>
                <%: Html.ValidationMessageFor(model => model.filltime) %>
            </div>     
            <div class="editor-label">
                <%: Html.LabelFor(model => model.order) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.order, new {  onkeyup = "isInt(this)", @class="text-box single-line" })%>
                <%: Html.ValidationMessageFor(model => model.order) %>
            </div>
        </div>
    </fieldset> 

   <%-- <%: Html.HiddenFor(model => model.CreateTime) %>
    <%: Html.HiddenFor(model => model.CreatePerson) %>--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
    
                               <script src="<%: Url.Content("~/Res/My97DatePicker/WdatePicker.js") %>" type="text/javascript"></script>
                                 
        <script type="text/javascript">

            $(function () {
                

            });
                  

    </script>
</asp:Content>

