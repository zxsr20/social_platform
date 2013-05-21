<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Edit.Master" Inherits="System.Web.Mvc.ViewPage<DAL.daily>" %>
<%@ Import Namespace="Common" %>
 
<asp:Content ID="Content4" ContentPlaceHolderID="CurentPlace" runat="server">
     修改 daily
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <fieldset>
        <legend>
            <input type="submit" value="修改" />
            <input type="button" onclick="BackList('daily')" value="返回列表" />
        </legend>
        <div class="bigdiv">
                 
            <div class="editor-label">
                <%: Html.LabelFor(model => model.title) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.title) %>
                <%: Html.ValidationMessageFor(model => model.title) %>
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(model => model.content) %>
            </div>
            <div class="editor-field">
                <%: Html.TextAreaFor(model => model.content) %>
                <%: Html.ValidationMessageFor(model => model.content) %>
            </div>      
            <div class="editor-label">
                <a class="anUnderLine" onclick="showModalOnly('tasktype','../../tasktype');">
                    <%: Html.LabelFor(model => model.tasktype) %>
                </a>
            </div>
            <div class="editor-field">
                <div id="checktasktype">
                    <%  if(Model!=null)
                        {
                        if (null != Model.tasktype)                      
                        {%>
                    <table id="<%: Model.tasktype %>"
                        class="deleteStyle">
                        <tr>
                            <td>
                                <img alt="删除"  title="点击删除" onclick="deleteTable('<%: Model.tasktype %>','tasktype');" src="../../../Images/deleteimge.png" />
                            </td>
                            <td>
                                <%: Model.tasktype.tasktypename%>
                            </td>
                        </tr>
                    </table>
                    <%}}%>
                </div>
                <%: Html.HiddenFor(model => model.tasktype)%>
            </div>     
            <div class="editor-label">
                <%: Html.LabelFor(model => model.tag) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.tag) %>
                <%: Html.ValidationMessageFor(model => model.tag) %>
            </div>      
            <div class="editor-label">
                <a class="anUnderLine" onclick="showModalOnly('status','../../status');">
                    <%: Html.LabelFor(model => model.status) %>
                </a>
            </div>
            <div class="editor-field">
                <div id="checkstatus">
                    <%  if(Model!=null)
                        {
                        if (null != Model.status)                      
                        {%>
                    <table id="<%: Model.status %>"
                        class="deleteStyle">
                        <tr>
                            <td>
                                <img alt="删除"  title="点击删除" onclick="deleteTable('<%: Model.status %>','status');" src="../../../Images/deleteimge.png" />
                            </td>
                            <td>
                                <%: Model.status.statusname%>
                            </td>
                        </tr>
                    </table>
                    <%}}%>
                </div>
                <%: Html.HiddenFor(model => model.status)%>
            </div>     
            <div class="editor-label">
                <%: Html.LabelFor(model => model.percent) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.percent, new {  onkeyup = "isInt(this)", @class="text-box single-line" })%>
                <%: Html.ValidationMessageFor(model => model.percent) %>
            </div>     
            <div class="editor-label">
                <%: Html.LabelFor(model => model.starttime) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBox("starttime", ((Model != null && Model.starttime != null) ? Model.starttime.ToString().AsDateTime().ToString("yyyy-MM-dd") : ""), new { onclick = "WdatePicker()", @class="text-box single-line" })%>
                <%: Html.ValidationMessageFor(model => model.starttime) %>
            </div>     
            <div class="editor-label">
                <%: Html.LabelFor(model => model.endtime) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBox("endtime", ((Model != null && Model.endtime != null) ? Model.endtime.ToString().AsDateTime().ToString("yyyy-MM-dd") : ""), new { onclick = "WdatePicker()", @class="text-box single-line" })%>
                <%: Html.ValidationMessageFor(model => model.endtime) %>
            </div>      
            <div class="editor-label">
                <a class="anUnderLine" onclick="showModalOnly('userid','../../SysPerson');">
                    <%: Html.LabelFor(model => model.userid) %>
                </a>
            </div>
            <div class="editor-field">
                <div id="checkuserid">
                    <%  if(Model!=null)
                        {
                        if (null != Model.userid)                      
                        {%>
                    <table id="<%: Model.userid %>"
                        class="deleteStyle">
                        <tr>
                            <td>
                                <img alt="删除"  title="点击删除" onclick="deleteTable('<%: Model.userid %>','userid');" src="../../../Images/deleteimge.png" />
                            </td>
                            <td>
                                <%: Model.SysPerson.Name%>
                            </td>
                        </tr>
                    </table>
                    <%}}%>
                </div>
                <%: Html.HiddenFor(model => model.userid)%>
            </div>     
            <div class="editor-label">
                <%: Html.LabelFor(model => model.addtime) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBox("addtime", ((Model != null && Model.addtime != null) ? Model.addtime.ToString().AsDateTime().ToString("yyyy-MM-dd") : ""), new { onclick = "WdatePicker()", @class="text-box single-line" })%>
                <%: Html.ValidationMessageFor(model => model.addtime) %>
            </div>     
            <div class="editor-label">
                <%: Html.LabelFor(model => model.updatetime) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBox("updatetime", ((Model != null && Model.updatetime != null) ? Model.updatetime.ToString().AsDateTime().ToString("yyyy-MM-dd") : ""), new { onclick = "WdatePicker()", @class="text-box single-line" })%>
                <%: Html.ValidationMessageFor(model => model.updatetime) %>
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(model => model.filelink) %>
            </div>
            <div class="editor-field">
                <%: Html.TextAreaFor(model => model.filelink) %>
                <%: Html.ValidationMessageFor(model => model.filelink) %>
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(model => model.remark) %>
            </div>
            <div class="editor-field">
                <%: Html.TextAreaFor(model => model.remark) %>
                <%: Html.ValidationMessageFor(model => model.remark) %>
            </div>     
            <div class="editor-label">
                <%: Html.LabelFor(model => model.isdel) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.isdel) %>
                <%: Html.ValidationMessageFor(model => model.isdel) %>
            </div>
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

