<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Edit.Master" Inherits="System.Web.Mvc.ViewPage<DAL.SysMenu>" %>
<%@ Import Namespace="Common" %>
 
<asp:Content ID="Content4" ContentPlaceHolderID="CurentPlace" runat="server">
     修改 模块
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <fieldset>
        <legend>
            <input type="submit" value="修改" />
            <input type="button" onclick="BackList('SysMenu')" value="返回列表" />
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
                <a class="anUnderLine" onclick="showModalOnly('ParentId','../../SysMenu');">
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
                                <%: Model.SysMenu2.Name%>
                            </td>
                        </tr>
                    </table>
                    <%}}%>
                </div>
                <%: Html.HiddenFor(model => model.ParentId)%>
            </div>     
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Url) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.Url) %>
                <%: Html.ValidationMessageFor(model => model.Url) %>
            </div>     
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Iconic) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.Iconic) %>
                <%: Html.ValidationMessageFor(model => model.Iconic) %>
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
                <%: Html.LabelFor(model => model.State) %>
            </div>
            <div class="editor-field">
                <%=Html.DropDownListFor(model => model.State,App.Models.SysFieldModels.GetSysField("SysMenu","State"),"请选择")%>  
            </div>     
            <div class="editor-label">
                <%: Html.LabelFor(model => model.CreatePerson) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.CreatePerson) %>
                <%: Html.ValidationMessageFor(model => model.CreatePerson) %>
            </div>     
            <div class="editor-label">
                <%: Html.LabelFor(model => model.CreateTime) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBox("CreateTime", ((Model != null && Model.CreateTime != null) ? Model.CreateTime.ToString().AsDateTime().ToString("yyyy-MM-dd") : ""), new { onclick = "WdatePicker()", @class="text-box single-line" })%>
                <%: Html.ValidationMessageFor(model => model.CreateTime) %>
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
            <a class="anUnderLine" onclick="showModalMany('SysRoleId','../../SysRole');">
                <%: Html.LabelFor(model => model.SysRoleId) %>
            </a>
        </div>
        <div class="editor-field">
            <div id="checkSysRoleId">
                <% string ids14 = string.Empty;
                if(Model!=null)
                {
                   foreach (var item14 in Model.SysRole)
                   {
                       string item141 = string.Empty;
                       item141 += item14.Id + "&" + item14.Name;
                       if (ids14.Length > 0)
                       {
                           ids14 += "^" + item141;
                       }
                       else
                       {
                           ids14 += item141;
                       }
                %>
                <table id="<%: item141 %>"
                    class="deleteStyle">
                    <tr>
                        <td>
                            <img  alt="删除" title="点击删除" onclick="deleteTable('<%: item141 %>','SysRoleId');"  src="../../../Images/deleteimge.png" />
                        </td>
                        <td>
                            <%: item14.Name %>
                        </td>
                    </tr>
                </table>
                <%}}%>
                <input type="hidden" value="<%= ids14 %>" name="SysRoleIdOld" id="SysRoleIdOld" />
                <input type="hidden" value="<%= ids14 %>" name="SysRoleId" id="SysRoleId" />
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

