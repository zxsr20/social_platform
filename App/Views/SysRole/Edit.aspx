<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Edit.Master" Inherits="System.Web.Mvc.ViewPage<DAL.SysRole>" %>
<%@ Import Namespace="Common" %>
 
<asp:Content ID="Content4" ContentPlaceHolderID="CurentPlace" runat="server">
     修改 角色
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <fieldset>
        <legend>
            <input type="submit" value="修改" />
            <input type="button" onclick="BackList('SysRole')" value="返回列表" />
        </legend>
        <div class="bigdiv">
                 
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Name) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.Name) %>
                <%: Html.ValidationMessageFor(model => model.Name) %>
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Description) %>
            </div>
            <div class="editor-field">
                <%: Html.TextAreaFor(model => model.Description) %>
                <%: Html.ValidationMessageFor(model => model.Description) %>
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
        <div class="editor-label">
            <a class="anUnderLine" onclick="showModalMany('SysPersonId','../../SysPerson');">
                <%: Html.LabelFor(model => model.SysPersonId) %>
            </a>
        </div>
        <div class="editor-field">
            <div id="checkSysPersonId">
                <% string ids10 = string.Empty;
                if(Model!=null)
                {
                   foreach (var item10 in Model.SysPerson)
                   {
                       string item101 = string.Empty;
                       item101 += item10.Id + "&" + item10.Name;
                       if (ids10.Length > 0)
                       {
                           ids10 += "^" + item101;
                       }
                       else
                       {
                           ids10 += item101;
                       }
                %>
                <table id="<%: item101 %>"
                    class="deleteStyle">
                    <tr>
                        <td>
                            <img  alt="删除" title="点击删除" onclick="deleteTable('<%: item101 %>','SysPersonId');"  src="../../../Images/deleteimge.png" />
                        </td>
                        <td>
                            <%: item10.Name %>
                        </td>
                    </tr>
                </table>
                <%}}%>
                <input type="hidden" value="<%= ids10 %>" name="SysPersonIdOld" id="SysPersonIdOld" />
                <input type="hidden" value="<%= ids10 %>" name="SysPersonId" id="SysPersonId" />
            </div>
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

