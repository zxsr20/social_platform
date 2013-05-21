<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Edit.Master" Inherits="System.Web.Mvc.ViewPage<DAL.YiDuiDuoZhongDeDuo>" %>
<%@ Import Namespace="Common" %>
 
<asp:Content ID="Content4" ContentPlaceHolderID="CurentPlace" runat="server">
     修改 一对多中的多
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <fieldset>
        <legend>
            <input type="submit" value="修改" />
            <input type="button" onclick="BackList('YiDuiDuoZhongDeDuo')" value="返回列表" />
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
                <%: Html.LabelFor(model => model.ShuLiang) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.ShuLiang, new {  onkeyup = "isInt(this)", @class="text-box single-line" })%>
                <%: Html.ValidationMessageFor(model => model.ShuLiang) %>
            </div>     
            <div class="editor-label">
                <%: Html.LabelFor(model => model.ChanPinMuLu) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.ChanPinMuLu) %>
                <%: Html.ValidationMessageFor(model => model.ChanPinMuLu) %>
            </div>     
            <div class="editor-label">
                <%: Html.LabelFor(model => model.GuiGeXingHao) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.GuiGeXingHao) %>
                <%: Html.ValidationMessageFor(model => model.GuiGeXingHao) %>
            </div>      
            <div class="editor-label">
                <a class="anUnderLine" onclick="showModalOnly('MyCaiGouXuQiouJiHuaId','../../YiDuiDuoZhongDeYi');">
                    <%: Html.LabelFor(model => model.MyCaiGouXuQiouJiHuaId) %>
                </a>
            </div>
            <div class="editor-field">
                <div id="checkMyCaiGouXuQiouJiHuaId">
                    <%  if(Model!=null)
                        {
                        if (null != Model.MyCaiGouXuQiouJiHuaId)                      
                        {%>
                    <table id="<%: Model.MyCaiGouXuQiouJiHuaId %>"
                        class="deleteStyle">
                        <tr>
                            <td>
                                <img alt="删除"  title="点击删除" onclick="deleteTable('<%: Model.MyCaiGouXuQiouJiHuaId %>','MyCaiGouXuQiouJiHuaId');" src="../../../Images/deleteimge.png" />
                            </td>
                            <td>
                                <%: Model.YiDuiDuoZhongDeYi.MingCheng%>
                            </td>
                        </tr>
                    </table>
                    <%}}%>
                </div>
                <%: Html.HiddenFor(model => model.MyCaiGouXuQiouJiHuaId)%>
            </div>        
            <div class="editor-label">
                <%: Html.LabelFor(model => model.JiLiangDanWei) %>
            </div>
            <div class="editor-field">
                <%=Html.DropDownListFor(model => model.JiLiangDanWei,App.Models.SysFieldModels.GetSysField("YiDuiDuoZhongDeDuo","JiLiangDanWei"),"请选择")%>  
            </div>     
            <div class="editor-label">
                <%: Html.LabelFor(model => model.JiaoHuoQiXian) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBox("JiaoHuoQiXian", ((Model != null && Model.JiaoHuoQiXian != null) ? Model.JiaoHuoQiXian.ToString().AsDateTime().ToString("yyyy-MM-dd") : ""), new { onclick = "WdatePicker()", @class="text-box single-line" })%>
                <%: Html.ValidationMessageFor(model => model.JiaoHuoQiXian) %>
            </div>     
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Currency) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Currency, new {  onkeyup = "isInt(this)", @class="text-box single-line" })%>
                <%: Html.ValidationMessageFor(model => model.Currency) %>
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

