<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Edit.Master" Inherits="System.Web.Mvc.ViewPage<DAL.tasktype>" %>
<%@ Import Namespace="Common" %>
 
<asp:Content ID="Content4" ContentPlaceHolderID="CurentPlace" runat="server">
     修改 tasktype
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <fieldset>
        <legend>
            <input type="submit" value="修改" />
            <input type="button" onclick="BackList('tasktype')" value="返回列表" />
        </legend>
        <div class="bigdiv">
                 
            <div class="editor-label">
                <%: Html.LabelFor(model => model.tasktypename) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.tasktypename) %>
                <%: Html.ValidationMessageFor(model => model.tasktypename) %>
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

