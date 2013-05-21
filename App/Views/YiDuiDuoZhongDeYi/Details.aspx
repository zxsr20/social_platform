<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Sys.Master"Inherits="System.Web.Mvc.ViewPage<DAL.YiDuiDuoZhongDeYi>" %>
<%@ Import Namespace="Common" %>
 
<asp:Content ID="Content4" ContentPlaceHolderID="CurentPlace" runat="server">
      详细 一对多中的一
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <fieldset>
        <legend>
            <%: Html.ActionLink("返回列表", "Index") %>
        </legend>
        <div class="bigdiv">
                  
                <div class="display-label">
                      <%: Html.LabelFor(model => model.MingCheng) %>
                </div>
                <div class="display-field">
                    <%: Html.DisplayFor(model => model.MingCheng) %>
                </div>      
                <div class="display-label">
                      <%: Html.LabelFor(model => model.RenWuShuXing) %>
                </div>
                <div class="display-field">
                   <%: App.Models.SysFieldModels.GetMyTextsById(Model.RenWuShuXing)%> 
                </div>      
                <div class="display-label">
                      <%: Html.LabelFor(model => model.CaiGouLeiXing) %>
                </div>
                <div class="display-field">
                   <%: App.Models.SysFieldModels.GetMyTextsById(Model.CaiGouLeiXing)%> 
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
                    <%: Html.DisplayFor(model => model.State) %>
                </div>
                <div class="display-label">
                    <%: Html.LabelFor(model => model.ZhaoBiaoGuanLiId) %>
                </div>
                <div class="display-field">
                    <%: Html.TextAreaFor(model => model.ZhaoBiaoGuanLiId, new {  @readonly=true}) %>                  
                </div>
                <div class="display-label">
                    <%: Html.LabelFor(model => model.GongYingShangId) %>
                </div>
                <div class="display-field">
                    <%: Html.TextAreaFor(model => model.GongYingShangId, new {  @readonly=true}) %>                  
                </div>
                <div class="display-label">
                    <%: Html.LabelFor(model => model.CaiGouFangAnId) %>
                </div>
                <div class="display-field">
                    <%: Html.TextAreaFor(model => model.CaiGouFangAnId, new {  @readonly=true}) %>                  
                </div>      
                <div class="display-label">
                      <%: Html.LabelFor(model => model.SysPersonId) %>
                </div>
                <div class="display-field">
                    <%: Html.DisplayFor(model => model.SysPersonId) %>
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
                      <%: Html.LabelFor(model => model.ServiceId) %>
                </div>
                <div class="display-field">
                    <%: Html.DisplayFor(model => model.ServiceId) %>
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

