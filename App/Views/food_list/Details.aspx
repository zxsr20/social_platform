<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Sys.Master"Inherits="System.Web.Mvc.ViewPage<DAL.food_list>" %>
<%@ Import Namespace="Common" %>
 
<asp:Content ID="Content4" ContentPlaceHolderID="CurentPlace" runat="server">
      详细 food_list
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <fieldset>
        <legend>
            <%: Html.ActionLink("返回列表", "Index") %>
        </legend>
        <div class="bigdiv">
                  
                <div class="display-label">
                      <%: Html.LabelFor(model => model.name) %>
                </div>
                <div class="display-field">
                    <%: Html.DisplayFor(model => model.name) %>
                </div>
                <div class="display-label">
                    <%: Html.LabelFor(model => model.description) %>
                </div>
                <div class="display-field">
                    <%: Html.TextAreaFor(model => model.description, new {  @readonly=true}) %>                  
                </div>      
                <div class="display-label"  style="display: none">
                      <%: Html.LabelFor(model => model.userid) %>
                </div>
                <div class="display-field"  style="display: none">
                    <%: Html.DisplayFor(model => model.userid) %>
                </div>
                <div class="display-label"  style="display: none">
                    <%: Html.LabelFor(model => model.pic) %>
                </div>
                <div class="display-field"  style="display: none">
                    <%: Html.TextAreaFor(model => model.pic, new {  @readonly=true}) %>                  
                </div>        
                <div class="display-label"  >
                    <%: Html.LabelFor(model => model.filltime) %>
                </div>
                <div class="display-field">
                    <%: String.Format("{0:d}", Model.filltime) %>
                </div>      
                <div class="display-label">
                      <%: Html.LabelFor(model => model.order) %>
                </div>
                <div class="display-field">
                    <%: Html.DisplayFor(model => model.order) %>
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

