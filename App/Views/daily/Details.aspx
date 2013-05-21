<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Sys.Master"Inherits="System.Web.Mvc.ViewPage<DAL.daily>" %>
<%@ Import Namespace="Common" %>
 
<asp:Content ID="Content4" ContentPlaceHolderID="CurentPlace" runat="server">
      详细 daily
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <fieldset>
        <legend>
            <%: Html.ActionLink("返回列表", "Index") %>
        </legend>
        <div class="bigdiv">
                  
                <div class="display-label">
                      <%: Html.LabelFor(model => model.title) %>
                </div>
                <div class="display-field">
                    <%: Html.DisplayFor(model => model.title) %>
                </div>
                <div class="display-label">
                    <%: Html.LabelFor(model => model.content) %>
                </div>
                <div class="display-field">
                    <%: Html.TextAreaFor(model => model.content, new {  @readonly=true}) %>                  
                </div>        
                <div class="display-label">
                      <%: Html.LabelFor(model => model.tasktype) %>
                </div>
                <div class="display-field">
                    <% if (Model.tasktype != null && !string.IsNullOrEmpty(Model.tasktype.tasktypename))
                       { %>
                    <%: Model.tasktype.tasktypename%>
                    <%} %>
                </div>      
                <div class="display-label">
                      <%: Html.LabelFor(model => model.tag) %>
                </div>
                <div class="display-field">
                    <%: Html.DisplayFor(model => model.tag) %>
                </div>        
                <div class="display-label">
                      <%: Html.LabelFor(model => model.status) %>
                </div>
                <div class="display-field">
                    <% if (Model.status != null && !string.IsNullOrEmpty(Model.status.statusname))
                       { %>
                    <%: Model.status.statusname%>
                    <%} %>
                </div>      
                <div class="display-label">
                      <%: Html.LabelFor(model => model.percent) %>
                </div>
                <div class="display-field">
                    <%: Html.DisplayFor(model => model.percent) %>
                </div>        
                <div class="display-label">
                    <%: Html.LabelFor(model => model.starttime) %>
                </div>
                <div class="display-field">
                    <%: String.Format("{0:d}", Model.starttime) %>
                </div>        
                <div class="display-label">
                    <%: Html.LabelFor(model => model.endtime) %>
                </div>
                <div class="display-field">
                    <%: String.Format("{0:d}", Model.endtime) %>
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
                    <%: Html.LabelFor(model => model.updatetime) %>
                </div>
                <div class="display-field">
                    <%: String.Format("{0:d}", Model.updatetime) %>
                </div>
                <div class="display-label">
                    <%: Html.LabelFor(model => model.filelink) %>
                </div>
                <div class="display-field">
                    <%: Html.TextAreaFor(model => model.filelink, new {  @readonly=true}) %>                  
                </div>
                <div class="display-label">
                    <%: Html.LabelFor(model => model.remark) %>
                </div>
                <div class="display-field">
                    <%: Html.TextAreaFor(model => model.remark, new {  @readonly=true}) %>                  
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

