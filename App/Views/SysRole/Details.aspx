<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Sys.Master"Inherits="System.Web.Mvc.ViewPage<DAL.SysRole>" %>
<%@ Import Namespace="Common" %>
 
<asp:Content ID="Content4" ContentPlaceHolderID="CurentPlace" runat="server">
      详细 角色
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <fieldset>
        <legend>
            <%: Html.ActionLink("返回列表", "Index") %>
        </legend>
        <div class="bigdiv">
                  
                <div class="display-label">
                      <%: Html.LabelFor(model => model.Name) %>
                </div>
                <div class="display-field">
                    <%: Html.DisplayFor(model => model.Name) %>
                </div>
                <div class="display-label">
                    <%: Html.LabelFor(model => model.Description) %>
                </div>
                <div class="display-field">
                    <%: Html.TextAreaFor(model => model.Description, new {  @readonly=true}) %>                  
                </div>
                <div class="display-label">
                    <%: Html.LabelFor(model => model.Remark) %>
                </div>
                <div class="display-field">
                    <%: Html.TextAreaFor(model => model.Remark, new {  @readonly=true}) %>                  
                </div>        
                <div class="display-label">
                    <%: Html.LabelFor(model => model.CreateTime) %>
                </div>
                <div class="display-field">
                    <%: String.Format("{0:g}", Model.CreateTime) %>
                </div>      
                <div class="display-label">
                      <%: Html.LabelFor(model => model.CreatePerson) %>
                </div>
                <div class="display-field">
                    <%: Html.DisplayFor(model => model.CreatePerson) %>
                </div>        
                <div class="display-label">
                    <%: Html.LabelFor(model => model.UpdateTime) %>
                </div>
                <div class="display-field">
                    <%: String.Format("{0:d}", Model.UpdateTime) %>
                </div>      
                <div class="display-label">
                      <%: Html.LabelFor(model => model.UpdatePerson) %>
                </div>
                <div class="display-field">
                    <%: Html.DisplayFor(model => model.UpdatePerson) %>
                </div>    
                <div class="display-label">
                      <%: Html.LabelFor(model => model.SysPersonId) %>
                </div>
                <div class="display-field">            
                    <% string ids9 = string.Empty;
                       foreach (var item9 in Model.SysPerson)
                       {
                           ids9 += item9.Name;
                           ids9 += " , ";
                    %>               
                    <%}%>
                    <div class="display-field">
                        <%= ids9 %>   
                    </div>
                </div>    
                <div class="display-label">
                      <%: Html.LabelFor(model => model.SysMenuId) %>
                </div>
                <div class="display-field">            
                    <% string ids10 = string.Empty;
                       foreach (var item10 in Model.SysMenu)
                       {
                           ids10 += item10.Name;
                           ids10 += " , ";
                    %>               
                    <%}%>
                    <div class="display-field">
                        <%= ids10 %>   
                    </div>
                </div>
        </div>
    </fieldset>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
    <script type='text/javascript'>
        $(function () {
            $("a").button();
            popTextArea($("textarea"));
        });
    </script>
</asp:Content>

