<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Sys.Master"Inherits="System.Web.Mvc.ViewPage<DAL.SysDepartment>" %>
<%@ Import Namespace="Common" %>
 
<asp:Content ID="Content4" ContentPlaceHolderID="CurentPlace" runat="server">
      详细 部门
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
                      <%: Html.LabelFor(model => model.MyParentId) %>
                </div>
                <div class="display-field">
                    <% if (Model.SysDepartment2 != null && !string.IsNullOrEmpty(Model.SysDepartment2.Name))
                       { %>
                    <%: Model.SysDepartment2.Name%>
                    <%} %>
                </div>      
                <div class="display-label">
                      <%: Html.LabelFor(model => model.Sort) %>
                </div>
                <div class="display-field">
                    <%: Html.DisplayFor(model => model.Sort) %>
                </div>      
                <div class="display-label">
                      <%: Html.LabelFor(model => model.PhoneNumber) %>
                </div>
                <div class="display-field">
                    <%: Html.DisplayFor(model => model.PhoneNumber) %>
                </div>      
                <div class="display-label">
                      <%: Html.LabelFor(model => model.FaxPhoneNumber) %>
                </div>
                <div class="display-field">
                    <%: Html.DisplayFor(model => model.FaxPhoneNumber) %>
                </div>      
                <div class="display-label">
                      <%: Html.LabelFor(model => model.Address) %>
                </div>
                <div class="display-field">
                    <%: Html.DisplayFor(model => model.Address) %>
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

