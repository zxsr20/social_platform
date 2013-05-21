<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Sys.Master"Inherits="System.Web.Mvc.ViewPage<DAL.SysLog>" %>
<%@ Import Namespace="Common" %>
 
<asp:Content ID="Content4" ContentPlaceHolderID="CurentPlace" runat="server">
      详细 日志
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <fieldset>
        <legend>
            <%: Html.ActionLink("返回列表", "Index") %>
        </legend>
        <div class="bigdiv">
                  
                <div class="display-label">
                      <%: Html.LabelFor(model => model.PersonId) %>
                </div>
                <div class="display-field">
                    <%: Html.DisplayFor(model => model.PersonId) %>
                </div>
                <div class="display-label">
                    <%: Html.LabelFor(model => model.Message) %>
                </div>
                <div class="display-field">
                    <%: Html.TextAreaFor(model => model.Message, new {  @readonly=true}) %>                  
                </div>      
                <div class="display-label">
                      <%: Html.LabelFor(model => model.Result) %>
                </div>
                <div class="display-field">
                    <%: Html.DisplayFor(model => model.Result) %>
                </div>      
                <div class="display-label">
                      <%: Html.LabelFor(model => model.MenuId) %>
                </div>
                <div class="display-field">
                    <%: Html.DisplayFor(model => model.MenuId) %>
                </div>      
                <div class="display-label">
                      <%: Html.LabelFor(model => model.Ip) %>
                </div>
                <div class="display-field">
                    <%: Html.DisplayFor(model => model.Ip) %>
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

