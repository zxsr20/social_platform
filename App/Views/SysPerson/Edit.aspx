<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Edit.Master" Inherits="System.Web.Mvc.ViewPage<DAL.SysPerson>" %>
<%@ Import Namespace="Common" %>
 
<asp:Content ID="Content4" ContentPlaceHolderID="CurentPlace" runat="server">
     修改 人员
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <fieldset>
        <legend>
            <input type="submit" value="修改" />
            <input type="button" onclick="BackList('SysPerson')" value="返回列表" />
        </legend>
        <div class="bigdiv">
                 
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Name) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.Name) %>
                <%: Html.ValidationMessageFor(model => model.Name) %>
            </div>     
            <div class="editor-label">
                <%: Html.LabelFor(model => model.MyName) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.MyName) %>
                <%: Html.ValidationMessageFor(model => model.MyName) %>
            </div>     
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Password) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.Password) %>
                <%: Html.ValidationMessageFor(model => model.Password) %>
            </div>     
            <div class="editor-label">
                <%: Html.LabelFor(model => model.SurePassword) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.SurePassword) %>
                <%: Html.ValidationMessageFor(model => model.SurePassword) %>
            </div>     
            <div class="editor-label">
                <%: Html.LabelFor(model => model.MobilePhoneNumber) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.MobilePhoneNumber) %>
                <%: Html.ValidationMessageFor(model => model.MobilePhoneNumber) %>
            </div>     
            <div class="editor-label">
                <%: Html.LabelFor(model => model.PhoneNumber) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.PhoneNumber) %>
                <%: Html.ValidationMessageFor(model => model.PhoneNumber) %>
            </div>        
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Province) %>
            </div>
            <div class="editor-field">
                <%=Html.DropDownListFor(model => model.Province,App.Models.SysFieldModels.GetSysField("SysPerson","Province"),"请选择")%>  
            </div>        
            <div class="editor-label">
                <%: Html.LabelFor(model => model.City) %>
            </div>
            <div class="editor-field">
                <%=Html.DropDownListFor(model => model.City,App.Models.SysFieldModels.GetSysField("SysPerson","City",Model.Province),"请选择")%>  
            </div>        
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Village) %>
            </div>
            <div class="editor-field">
                <%=Html.DropDownListFor(model => model.Village,App.Models.SysFieldModels.GetSysField("SysPerson","Village",Model.City),"请选择")%>  
            </div>     
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Address) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.Address) %>
                <%: Html.ValidationMessageFor(model => model.Address) %>
            </div>     
            <div class="editor-label">
                <%: Html.LabelFor(model => model.EmailAddress) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.EmailAddress) %>
                <%: Html.ValidationMessageFor(model => model.EmailAddress) %>
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
             <%: Html.RadioButtonListFor(model => model.State,App.Models.SysFieldModels.GetSysField("SysPerson","State"),false) %>
            </div>      
            <div class="editor-label">
                <a class="anUnderLine" onclick="showModalOnly('SysDepartmentId','../../SysDepartment');">
                    <%: Html.LabelFor(model => model.SysDepartmentId) %>
                </a>
            </div>
            <div class="editor-field">
                <div id="checkSysDepartmentId">
                    <%  if(Model!=null)
                        {
                        if (null != Model.SysDepartmentId)                      
                        {%>
                    <table id="<%: Model.SysDepartmentId %>"
                        class="deleteStyle">
                        <tr>
                            <td>
                                <img alt="删除"  title="点击删除" onclick="deleteTable('<%: Model.SysDepartmentId %>','SysDepartmentId');" src="../../../Images/deleteimge.png" />
                            </td>
                            <td>
                                <%: Model.SysDepartment.Name%>
                            </td>
                        </tr>
                    </table>
                    <%}}%>
                </div>
                <%: Html.HiddenFor(model => model.SysDepartmentId)%>
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
        <div class="editor-label">
            <a class="anUnderLine" onclick="showModalMany('SysRoleId','../../SysRole');">
                <%: Html.LabelFor(model => model.SysRoleId) %>
            </a>
        </div>
        <div class="editor-field">
            <div id="checkSysRoleId">
                <% string ids21 = string.Empty;
                if(Model!=null)
                {
                   foreach (var item21 in Model.SysRole)
                   {
                       string item211 = string.Empty;
                       item211 += item21.Id + "&" + item21.Name;
                       if (ids21.Length > 0)
                       {
                           ids21 += "^" + item211;
                       }
                       else
                       {
                           ids21 += item211;
                       }
                %>
                <table id="<%: item211 %>"
                    class="deleteStyle">
                    <tr>
                        <td>
                            <img  alt="删除" title="点击删除" onclick="deleteTable('<%: item211 %>','SysRoleId');"  src="../../../Images/deleteimge.png" />
                        </td>
                        <td>
                            <%: item21.Name %>
                        </td>
                    </tr>
                </table>
                <%}}%>
                <input type="hidden" value="<%= ids21 %>" name="SysRoleIdOld" id="SysRoleIdOld" />
                <input type="hidden" value="<%= ids21 %>" name="SysRoleId" id="SysRoleId" />
            </div>
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
                
            
            $("#Province").change(function () { getCity("#City"); });

            
            $("#City").change(function () { getVillage("#Village"); });


            });
            
        function getCity(City) {
            $(City).empty();
            $("<option></option>")
                    .val("-1")
                    .text("请选择")
                    .appendTo($(City));
            bindDropDownList(City, "#Province");
            $(City).change();
        }

        function getVillage(Village) {
            $(Village).empty();
            $("<option></option>")
                    .val("-1")
                    .text("请选择")
                    .appendTo($(Village));
            bindDropDownList(Village, "#City");
            $(Village).change();
        }
      

    </script>
</asp:Content>

