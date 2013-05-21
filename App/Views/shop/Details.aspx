<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Sys.Master"Inherits="System.Web.Mvc.ViewPage<DAL.shop>" %>
<%@ Import Namespace="Common" %>
 
<asp:Content ID="Content4" ContentPlaceHolderID="CurentPlace" runat="server">
      详细 shop
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
                <div class="display-label">
                    <%: Html.LabelFor(model => model.welcome_pic) %>
                </div>
                <div class="display-field">
                    <%: Html.TextAreaFor(model => model.welcome_pic, new {  @readonly=true}) %>                  
                </div>
                <div class="display-label">
                    <%: Html.LabelFor(model => model.home_pic) %>
                </div>
                <div class="display-field">
                    <%: Html.TextAreaFor(model => model.home_pic, new {  @readonly=true}) %>                  
                </div>      
                <div class="display-label">
                      <%: Html.LabelFor(model => model.telephone) %>
                </div>
                <div class="display-field">
                    <%: Html.DisplayFor(model => model.telephone) %>
                </div>      
                <div class="display-label">
                      <%: Html.LabelFor(model => model.mobile) %>
                </div>
                <div class="display-field">
                    <%: Html.DisplayFor(model => model.mobile) %>
                </div>      
                <div class="display-label">
                      <%: Html.LabelFor(model => model.address) %>
                </div>
                <div class="display-field">
                    <%: Html.DisplayFor(model => model.address) %>
                </div>      
                <div class="display-label">
                      <%: Html.LabelFor(model => model.fax) %>
                </div>
                <div class="display-field">
                    <%: Html.DisplayFor(model => model.fax) %>
                </div>
                <div class="display-label">
                    <%: Html.LabelFor(model => model.bus_way) %>
                </div>
                <div class="display-field">
                    <%: Html.TextAreaFor(model => model.bus_way, new {  @readonly=true}) %>                  
                </div>        
                <div class="display-label">
                    <%: Html.LabelFor(model => model.filltime) %>
                </div>
                <div class="display-field">
                    <%: String.Format("{0:d}", Model.filltime) %>
                </div>      
                <div class="display-label">
                      <%: Html.LabelFor(model => model.shop_type) %>
                </div>
                <div class="display-field">
                    <%: Html.DisplayFor(model => model.shop_type) %>
                </div>      
                <div class="display-label">
                      <%: Html.LabelFor(model => model.locx) %>
                </div>
                <div class="display-field">
                    <%: Html.DisplayFor(model => model.locx) %>
                </div>      
                <div class="display-label">
                      <%: Html.LabelFor(model => model.locy) %>
                </div>
                <div class="display-field">
                    <%: Html.DisplayFor(model => model.locy) %>
                </div>      
                <div class="display-label">
                      <%: Html.LabelFor(model => model.userid) %>
                </div>
                <div class="display-field">
                    <%: Html.DisplayFor(model => model.userid) %>
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

