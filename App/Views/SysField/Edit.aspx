<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Edit.Master" Inherits="System.Web.Mvc.ViewPage<DAL.SysField>" %>
<%@ Import Namespace="Common" %>
 
<asp:Content ID="Content4" ContentPlaceHolderID="CurentPlace" runat="server">
     修改 数据字典
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <fieldset>
        <legend>
            <input type="submit" value="修改" />
            <input type="button" onclick="BackList('SysField')" value="返回列表" />
        </legend>
        <div class="bigdiv">
                 
            <div class="editor-label">
                <%: Html.LabelFor(model => model.MyTexts) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.MyTexts) %>
                <%: Html.ValidationMessageFor(model => model.MyTexts) %>
            </div>       
            <div class="editor-label">
                <a class="anUnderLine" onclick="showModalOnly('ParentId','../../SysField');">
                    <%: Html.LabelFor(model => model.ParentId) %>
                </a>
            </div>
            <div class="editor-field">
                <div id="checkParentId">
                    <% if(Model!=null)
                        {
                        if (!string.IsNullOrWhiteSpace(Model.ParentId))
                        {%>
                    <table  id="<%: Model.ParentId %>"
                        class="deleteStyle">
                        <tr>
                            <td>
                                <img  alt="删除"  title="点击删除" src="../../../Images/deleteimge.png" onclick="deleteTable('<%: Model.ParentId %>','ParentId');"/>
                            </td>
                            <td>
                                <%: Model.SysField2.MyTexts%>
                            </td>
                        </tr>
                    </table>
                    <%}}%>
                </div>
                <%: Html.HiddenFor(model => model.ParentId)%>
            </div>     
            <div class="editor-label">
                <%: Html.LabelFor(model => model.MyTables) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.MyTables) %>
                <%: Html.ValidationMessageFor(model => model.MyTables) %>
            </div>     
            <div class="editor-label">
                <%: Html.LabelFor(model => model.MyColums) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.MyColums) %>
                <%: Html.ValidationMessageFor(model => model.MyColums) %>
            </div>     
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Sort) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Sort, new {  onkeyup = "isInt(this)", @class="text-box single-line" })%>
                <%: Html.ValidationMessageFor(model => model.Sort) %>
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Remark) %>
            </div>
            <div class="editor-field">
                <%: Html.TextAreaFor(model => model.Remark) %>
                <%: Html.ValidationMessageFor(model => model.Remark) %>
            </div>     
            <div class="editor-label">
                <%: Html.LabelFor(model => model.CreateTime) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBox("CreateTime", ((Model != null && Model.CreateTime != null) ? Model.CreateTime.ToString().AsDateTime().ToString("yyyy-MM-dd") : ""), new { onclick = "WdatePicker()", @class="text-box single-line" })%>
                <%: Html.ValidationMessageFor(model => model.CreateTime) %>
            </div>     
            <div class="editor-label">
                <%: Html.LabelFor(model => model.CreatePerson) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.CreatePerson) %>
                <%: Html.ValidationMessageFor(model => model.CreatePerson) %>
            </div>     
            <div class="editor-label">
                <%: Html.LabelFor(model => model.UpdateTime) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBox("UpdateTime", ((Model != null && Model.UpdateTime != null) ? Model.UpdateTime.ToString().AsDateTime().ToString("yyyy-MM-dd") : ""), new { onclick = "WdatePicker()", @class="text-box single-line" })%>
                <%: Html.ValidationMessageFor(model => model.UpdateTime) %>
            </div>     
            <div class="editor-label">
                <%: Html.LabelFor(model => model.UpdatePerson) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.UpdatePerson) %>
                <%: Html.ValidationMessageFor(model => model.UpdatePerson) %>
            </div><%: Html.HiddenFor(model => model.Version) %>
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

