<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Sys.Master"Inherits="System.Web.Mvc.ViewPage<DAL.SysPerson>" %>
<%@ Import Namespace="Common" %>
 
<asp:Content ID="Content4" ContentPlaceHolderID="CurentPlace" runat="server">
      详细 人员
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
                      <%: Html.LabelFor(model => model.MyName) %>
                </div>
                <div class="display-field">
                    <%: Html.DisplayFor(model => model.MyName) %>
                </div>      
                <div class="display-label">
                      <%: Html.LabelFor(model => model.Password) %>
                </div>
                <div class="display-field">
                    <%: Html.DisplayFor(model => model.Password) %>
                </div>      
                <div class="display-label">
                      <%: Html.LabelFor(model => model.SurePassword) %>
                </div>
                <div class="display-field">
                    <%: Html.DisplayFor(model => model.SurePassword) %>
                </div>      
                <div class="display-label">
                      <%: Html.LabelFor(model => model.MobilePhoneNumber) %>
                </div>
                <div class="display-field">
                    <%: Html.DisplayFor(model => model.MobilePhoneNumber) %>
                </div>      
                <div class="display-label">
                      <%: Html.LabelFor(model => model.PhoneNumber) %>
                </div>
                <div class="display-field">
                    <%: Html.DisplayFor(model => model.PhoneNumber) %>
                </div>      
                <div class="display-label">
                      <%: Html.LabelFor(model => model.Province) %>
                </div>
                <div class="display-field">
                   <%: App.Models.SysFieldModels.GetMyTextsById(Model.Province)%> 
                </div>      
                <div class="display-label">
                      <%: Html.LabelFor(model => model.City) %>
                </div>
                <div class="display-field">
                   <%: App.Models.SysFieldModels.GetMyTextsById(Model.City)%> 
                </div>      
                <div class="display-label">
                      <%: Html.LabelFor(model => model.Village) %>
                </div>
                <div class="display-field">
                   <%: App.Models.SysFieldModels.GetMyTextsById(Model.Village)%> 
                </div>      
                <div class="display-label">
                      <%: Html.LabelFor(model => model.Address) %>
                </div>
                <div class="display-field">
                    <%: Html.DisplayFor(model => model.Address) %>
                </div>      
                <div class="display-label">
                      <%: Html.LabelFor(model => model.EmailAddress) %>
                </div>
                <div class="display-field">
                    <%: Html.DisplayFor(model => model.EmailAddress) %>
                </div>
                <div class="display-label">
                    <%: Html.LabelFor(model => model.Remark) %>
                </div>
                <div class="display-field">
                    <%: Html.TextAreaFor(model => model.Remark, new {  @readonly=true}) %>                  
                </div>      
                <div class="display-label">
                      <%: Html.LabelFor(model => model.State) %>
                </div>
                <div class="display-field">
                   <%: App.Models.SysFieldModels.GetMyTextsById(Model.State)%> 
                </div>        
                <div class="display-label">
                      <%: Html.LabelFor(model => model.SysDepartmentId) %>
                </div>
                <div class="display-field">
                    <% if (Model.SysDepartment != null && !string.IsNullOrEmpty(Model.SysDepartment.Name))
                       { %>
                    <%: Model.SysDepartment.Name%>
                    <%} %>
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
                      <%: Html.LabelFor(model => model.SysRoleId) %>
                </div>
                <div class="display-field">            
                    <% string ids20 = string.Empty;
                       foreach (var item20 in Model.SysRole)
                       {
                           ids20 += item20.Name;
                           ids20 += " , ";
                    %>               
                    <%}%>
                    <div class="display-field">
                        <%= ids20 %>   
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

