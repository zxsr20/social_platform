<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Sys.Master"Inherits="System.Web.Mvc.ViewPage<DAL.tasktype>" %>
<%@ Import Namespace="Common" %>
 
<asp:Content ID="Content4" ContentPlaceHolderID="CurentPlace" runat="server">
      详细 tasktype
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <fieldset>
        <legend>
            <%: Html.ActionLink("返回列表", "Index") %>
        </legend>
        <div class="bigdiv">
                  
                <div class="display-label">
                      <%: Html.LabelFor(model => model.tasktypename) %>
                </div>
                <div class="display-field">
                    <%: Html.DisplayFor(model => model.tasktypename) %>
                </div>        
                <div class="display-label">
                      <%: Html.LabelFor(model => model.userid) %>
                </div>
                <div class="display-field">
                    <% if (Model.SysPerson != null && !string.IsNullOrEmpty(Model.SysPerson.Name))
                       { %>
                    <%: Model.SysPerson.Name%>
                    <%} %>
                </div>        
                <div class="display-label">
                    <%: Html.LabelFor(model => model.addtime) %>
                </div>
                <div class="display-field">
                    <%: String.Format("{0:d}", Model.addtime) %>
                </div>      
                <div class="display-label">
                      <%: Html.LabelFor(model => model.isdel) %>
                </div>
                <div class="display-field">
                    <%: Html.DisplayFor(model => model.isdel) %>
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

