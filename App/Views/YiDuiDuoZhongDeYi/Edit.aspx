<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Edit.Master" Inherits="System.Web.Mvc.ViewPage<DAL.YiDuiDuoZhongDeYi>" %>
<%@ Import Namespace="Common" %>
 
<asp:Content ID="Content4" ContentPlaceHolderID="CurentPlace" runat="server">
     修改 一对多中的一
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <fieldset>
        <legend>
            <input type="submit" value="修改" />
            <input type="button" onclick="BackList('YiDuiDuoZhongDeYi')" value="返回列表" />
        </legend>
        <div class="bigdiv">
                 
            <div class="editor-label">
                <%: Html.LabelFor(model => model.MingCheng) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.MingCheng) %>
                <%: Html.ValidationMessageFor(model => model.MingCheng) %>
            </div>        
            <div class="editor-label">
                <%: Html.LabelFor(model => model.RenWuShuXing) %>
            </div>
            <div class="editor-field">
                <%=Html.DropDownListFor(model => model.RenWuShuXing,App.Models.SysFieldModels.GetSysField("YiDuiDuoZhongDeYi","RenWuShuXing"),"请选择")%>  
            </div>        
            <div class="editor-label">
                <%: Html.LabelFor(model => model.CaiGouLeiXing) %>
            </div>
            <div class="editor-field">
                <%=Html.DropDownListFor(model => model.CaiGouLeiXing,App.Models.SysFieldModels.GetSysField("YiDuiDuoZhongDeYi","CaiGouLeiXing"),"请选择")%>  
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Remark) %>
            </div>
            <div class="editor-field">
                <%: Html.TextAreaFor(model => model.Remark) %>
                <%: Html.ValidationMessageFor(model => model.Remark) %>
            </div>     
            <div class="editor-label">
                <%: Html.LabelFor(model => model.State) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.State) %>
                <%: Html.ValidationMessageFor(model => model.State) %>
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(model => model.ZhaoBiaoGuanLiId) %>
            </div>
            <div class="editor-field">
                <%: Html.TextAreaFor(model => model.ZhaoBiaoGuanLiId) %>
                <%: Html.ValidationMessageFor(model => model.ZhaoBiaoGuanLiId) %>
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(model => model.GongYingShangId) %>
            </div>
            <div class="editor-field">
                <%: Html.TextAreaFor(model => model.GongYingShangId) %>
                <%: Html.ValidationMessageFor(model => model.GongYingShangId) %>
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(model => model.CaiGouFangAnId) %>
            </div>
            <div class="editor-field">
                <%: Html.TextAreaFor(model => model.CaiGouFangAnId) %>
                <%: Html.ValidationMessageFor(model => model.CaiGouFangAnId) %>
            </div>     
            <div class="editor-label">
                <%: Html.LabelFor(model => model.SysPersonId) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.SysPersonId) %>
                <%: Html.ValidationMessageFor(model => model.SysPersonId) %>
            </div>     
            <div class="editor-label">
                <%: Html.LabelFor(model => model.CreateTime) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBox("CreateTime", ((Model != null && Model.CreateTime != null) ? Model.CreateTime.ToString().AsDateTime().ToString("yyyy-MM-dd") : ""), new { onclick = "WdatePicker()", @class="text-box single-line" })%>
                <%: Html.ValidationMessageFor(model => model.CreateTime) %>
            </div>     
            <div class="editor-label">
                <%: Html.LabelFor(model => model.CreatePerson) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.CreatePerson) %>
                <%: Html.ValidationMessageFor(model => model.CreatePerson) %>
            </div>     
            <div class="editor-label">
                <%: Html.LabelFor(model => model.ServiceId) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.ServiceId) %>
                <%: Html.ValidationMessageFor(model => model.ServiceId) %>
            </div>     
            <div class="editor-label">
                <%: Html.LabelFor(model => model.UpdateTime) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBox("UpdateTime", ((Model != null && Model.UpdateTime != null) ? Model.UpdateTime.ToString().AsDateTime().ToString("yyyy-MM-dd") : ""), new { onclick = "WdatePicker()", @class="text-box single-line" })%>
                <%: Html.ValidationMessageFor(model => model.UpdateTime) %>
            </div>     
            <div class="editor-label">
                <%: Html.LabelFor(model => model.UpdatePerson) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.UpdatePerson) %>
                <%: Html.ValidationMessageFor(model => model.UpdatePerson) %>
            </div><%: Html.HiddenFor(model => model.Version) %>
        </div>
    </fieldset> 

   <%-- <%: Html.HiddenFor(model => model.CreateTime) %>
    <%: Html.HiddenFor(model => model.CreatePerson) %>--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
    
                               <script src="<%: Url.Content("~/Res/My97DatePicker/WdatePicker.js") %>" type="text/javascript"></script>
                                 
        <script type="text/javascript">

            $(function () {
                

            });
                  

    </script>
</asp:Content>

