<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Create.Master" Inherits="System.Web.Mvc.ViewPage<DAL.SysLog>" %>
<%@ Import Namespace="Common" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CurentPlace" runat="server">
      创建 日志
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset>
        <legend>
            <input type="submit" value="创建" />
            <input type="button" onclick="BackList('SysLog')" value="返回列表" />
        </legend>
        <div class="bigdiv">
                 
            <div class="editor-label">
                <%: Html.LabelFor(model => model.PersonId) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.PersonId) %>
                <%: Html.ValidationMessageFor(model => model.PersonId) %>
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Message) %>
            </div>
            <div class="editor-field">
                <%: Html.TextAreaFor(model => model.Message) %>
                <%: Html.ValidationMessageFor(model => model.Message) %>
            </div>     
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Result) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.Result) %>
                <%: Html.ValidationMessageFor(model => model.Result) %>
            </div>     
            <div class="editor-label">
                <%: Html.LabelFor(model => model.MenuId) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.MenuId) %>
                <%: Html.ValidationMessageFor(model => model.MenuId) %>
            </div>     
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Ip) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.Ip) %>
                <%: Html.ValidationMessageFor(model => model.Ip) %>
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
                <%=Html.DropDownListFor(model => model.State,App.Models.SysFieldModels.GetSysField("SysLog","State"),"请选择")%>  
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

