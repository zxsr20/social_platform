<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Sys.Master"Inherits="System.Web.Mvc.ViewPage<DAL.YiDuiDuoZhongDeDuo>" %>
<%@ Import Namespace="Common" %>
 
<asp:Content ID="Content4" ContentPlaceHolderID="CurentPlace" runat="server">
      详细 一对多中的多
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
                      <%: Html.LabelFor(model => model.ShuLiang) %>
                </div>
                <div class="display-field">
                    <%: Html.DisplayFor(model => model.ShuLiang) %>
                </div>      
                <div class="display-label">
                      <%: Html.LabelFor(model => model.ChanPinMuLu) %>
                </div>
                <div class="display-field">
                    <%: Html.DisplayFor(model => model.ChanPinMuLu) %>
                </div>      
                <div class="display-label">
                      <%: Html.LabelFor(model => model.GuiGeXingHao) %>
                </div>
                <div class="display-field">
                    <%: Html.DisplayFor(model => model.GuiGeXingHao) %>
                </div>        
                <div class="display-label">
                      <%: Html.LabelFor(model => model.MyCaiGouXuQiouJiHuaId) %>
                </div>
                <div class="display-field">
                    <% if (Model.YiDuiDuoZhongDeYi != null && !string.IsNullOrEmpty(Model.YiDuiDuoZhongDeYi.MingCheng))
                       { %>
                    <%: Model.YiDuiDuoZhongDeYi.MingCheng%>
                    <%} %>
                </div>      
                <div class="display-label">
                      <%: Html.LabelFor(model => model.JiLiangDanWei) %>
                </div>
                <div class="display-field">
                   <%: App.Models.SysFieldModels.GetMyTextsById(Model.JiLiangDanWei)%> 
                </div>        
                <div class="display-label">
                    <%: Html.LabelFor(model => model.JiaoHuoQiXian) %>
                </div>
                <div class="display-field">
                    <%: String.Format("{0:d}", Model.JiaoHuoQiXian) %>
                </div>      
                <div class="display-label">
                      <%: Html.LabelFor(model => model.Currency) %>
                </div>
                <div class="display-field">
                    <%: Html.DisplayFor(model => model.Currency) %>
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

