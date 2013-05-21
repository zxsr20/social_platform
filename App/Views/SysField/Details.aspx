<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Sys.Master"Inherits="System.Web.Mvc.ViewPage<DAL.SysField>" %>
<%@ Import Namespace="Common" %>
 
<asp:Content ID="Content4" ContentPlaceHolderID="CurentPlace" runat="server">
      详细 数据字典
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <fieldset>
        <legend>
            <%: Html.ActionLink("返回列表", "Index") %>
        </legend>
        <div class="bigdiv">
                  
                <div class="display-label">
                      <%: Html.LabelFor(model => model.MyTexts) %>
                </div>
                <div class="display-field">
                    <%: Html.DisplayFor(model => model.MyTexts) %>
                </div>        
                <div class="display-label">
                      <%: Html.LabelFor(model => model.ParentId) %>
                </div>
                <div class="display-field">
                    <% if (Model.SysField2 != null && !string.IsNullOrEmpty(Model.SysField2.MyTexts))
                       { %>
                    <%: Model.SysField2.MyTexts%>
                    <%} %>
                </div>      
                <div class="display-label">
                      <%: Html.LabelFor(model => model.MyTables) %>
                </div>
                <div class="display-field">
                    <%: Html.DisplayFor(model => model.MyTables) %>
                </div>      
                <div class="display-label">
                      <%: Html.LabelFor(model => model.MyColums) %>
                </div>
                <div class="display-field">
                    <%: Html.DisplayFor(model => model.MyColums) %>
                </div>      
                <div class="display-label">
                      <%: Html.LabelFor(model => model.Sort) %>
                </div>
                <div class="display-field">
                    <%: Html.DisplayFor(model => model.Sort) %>
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

