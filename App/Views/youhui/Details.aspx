<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Sys.Master"Inherits="System.Web.Mvc.ViewPage<DAL.youhui>" %>
<%@ Import Namespace="Common" %>
 
<asp:Content ID="Content4" ContentPlaceHolderID="CurentPlace" runat="server">
      详细 youhui
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
                    <%: Html.LabelFor(model => model.decription) %>
                </div>
                <div class="display-field">
                    <%: Html.TextAreaFor(model => model.decription, new {  @readonly=true}) %>                  
                </div>      
                <div class="display-label">
                      <%: Html.LabelFor(model => model.net_price) %>
                </div>
                <div class="display-field">
                    <%: Html.DisplayFor(model => model.net_price) %>
                </div>      
                <div class="display-label">
                      <%: Html.LabelFor(model => model.save_money) %>
                </div>
                <div class="display-field">
                    <%: Html.DisplayFor(model => model.save_money) %>
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
                      <%: Html.LabelFor(model => model.userid) %>
                </div>
                <div class="display-field">
                    <%: Html.DisplayFor(model => model.userid) %>
                </div>        
                <div class="display-label">
                    <%: Html.LabelFor(model => model.updatetime) %>
                </div>
                <div class="display-field">
                    <%: String.Format("{0:d}", Model.updatetime) %>
                </div>        
                <div class="display-label">
                    <%: Html.LabelFor(model => model.addtime) %>
                </div>
                <div class="display-field">
                    <%: String.Format("{0:d}", Model.addtime) %>
                </div>      
                <div class="display-label"  style="display: none">
                      <%: Html.LabelFor(model => model.pic) %>
                </div>
                <div class="display-field"  style="display: none">
                    <%: Html.DisplayFor(model => model.pic) %>
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

