<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Index.Master" Inherits="System.Web.Mvc.ViewPage<DAL.activity>" %>
<%@ Import Namespace="Common" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    activity
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="divQuery" title="查询列表" class="easyui-dialog" closed="true" modal="false"
        style="padding: 5px; background: #fafafa;" iconCls="icon-search">
         
            <div class="input">
                <div class="editor-label">
                    <%: Html.LabelFor(model => model.description) %>
                </div>
                <div class="editor-field-Search">
                <input type='text' id='description'/>
                </div>
            </div>
            <br style="clear:both;" />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
    
    <script type="text/javascript">

        $(function () {         
            //按钮操作函数
            //“选择”按钮，在其他（与此页面有关联）的页面中，此页面以弹出框的形式出现，选择页面中的数据
            flexiSelect = function (ids, grid) {
                //主键列和显示列之间用 ^ 分割   每一项用 , 分割
                var arr = new Array(0);
                $('.trSelected  td:nth-child(1) div', grid.gDiv).each(function () {
                    //遍历选中行对象，获取值第一列（Id）
                    arr.push($(this).text());
                })
                $('.trSelected  td:nth-child(3) div', grid.gDiv).each(function (i) {
                    //遍历选中行对象，获取值第三列（ Name）
                    if (i == 0) {
                        arr.push("^"); //主键列和显示列的分割符 ^ 
                        i++;
                    }
                    arr.push($(this).text()); //将值插入数组
                })

                if (arr.length < 3) {//少于一条
                    alert("请选择数据!");
                    return;
                }
//                if (arr.length > 3) {//多于一条
//                    alert("请只选择一条数据!");
//                    return;
//                }
                 if (arr.length >= 3) {//一条数据和多于一条
                    returnParent(arr.join("&")); //每一项用 & 分割
                }
            }
            //“查询”按钮，弹出查询框
            flexiQuery = function (ids, grid) {
                $('#divQuery').dialog({
//                    width: 701,                   
                    buttons: [{
                        text: '查询',
                        iconCls: 'icon-ok',
                        handler: function () {
                            var search = "";
                            $('#divQuery').find(":text,:selected,select,textarea,:hidden,:checked,:password").each(function () {
                                search = search + this.id + "&" + this.value + "^";
                            });
                            grid.doSearch(search); //执行查询
                            $("#flexigridData").flexReload(); //刷新
//                            $('#divQuery').dialog("close");
                        }
                    },
                     {
                         text: '取消',
                         iconCls: 'icon-cancel',
                         handler: function () {
                             $('#divQuery').dialog("close");
                         }
                     }]
                });
                 $('#divQuery').dialog("open");
            };
            //将查询结果数据导出到excle
            flexiOut = function (ids, grid) {
              var queryJDiv = $(".divQuery:last"); //选择div中的数据

              var search = "";
              queryJDiv.find(":text,:selected,textarea,:hidden,:checked,:password").each(function () {
                  search = search + this.id + "&" + this.value + "^";

              });//收集查询条件
             
              grid.doDaoChu("../activity/GetDaoChu");//导出数据
          };
          //导航到查看详细的按钮
            flexiView = function (ids, grid) {
                var arr = new Array(0);
                $('.trSelected  td:nth-child(1) div', grid.gDiv).each(function (i) {
                    //遍历选中行对象，获取值第一列（id）
                    arr.push($(this).text());
                })
                if (arr.length == 0) {
                    alert("请选择数据!");
                    return;
                }
                if (arr.length > 1) {
                    alert("请只选择一条需要查看的数据!");
                    return;
                }
                if (arr.length == 1) {
                 var parent = window.dialogArguments; //获取父页面
                if (parent != null && parent != "undefined") {//如果是父页面就不许操作
                    alert("请不要在弹出框中新建，可以转到列表中查看！");
                    return;
                }
                window.location.href = "../activity/Details/" + arr[0];
                return;
                }
            }
              //导航到创建的按钮
            function flexiCreate() {
                var parent = window.dialogArguments; //获取父页面
                if (parent != null && parent != "undefined") {//如果是父页面就不许操作
                    alert("请不要在弹出框中新建，可以转到列表中新建！");
                    return;
                }
                window.location.href = "../activity/Create";
                return;
            }
               //导航到修改的按钮
            flexiModify = function (ids, grid) {
                var parent = window.dialogArguments; //获取父页面
                if (parent != null && parent != "undefined") {//如果是父页面就不许操作
                    alert("请不要在弹出框中修改，可以转到列表中修改！");return;
                }
                var arr = new Array(0);
                $('.trSelected  td:nth-child(1) div', grid.gDiv).each(function (i) {
                    //遍历选中行对象，获取值第一列（id）
                    arr.push($(this).text());
                })
                if (arr.length == 0) {
                    alert("请选择数据!");
                    return;
                }
                if (arr.length > 1) {
                    alert("请只选择一条需要修改的数据!");
                    return;
                }
                if (arr.length == 1) {
                    window.location.href = "../activity/Edit/" + arr[0];
                    return;
                }
            };
               //删除的按钮
            flexiDelete = function (ids, grid) {
                var parent = window.dialogArguments; //获取父页面
                if (parent != null && parent != "undefined") {//如果是父页面就不许操作
                    alert("请不要在弹出框中删除，可以转到列表中删除！");return;
                }
                var arr = new Array(0);
                $('.trSelected  td:nth-child(1) div', grid.gDiv).each(function (i) {
                    //主要的一列，遍历选中行对象，获取值第一列（id）
                    arr.push($(this).text());
                })
                if (arr.length == 0) {
                    alert("请选择数据!");
                    return;
                }
                if (!confirm("确认删除这 " + arr.length + " 项吗？"))
                    return;
                $.post("../activity/Delete", { query: arr.join(",") }, function (res) {
                    if (res == "OK") {
                        $("#flexigridData").flexReload();//重新加载列表的数据
                        alert("删除成功!");
                    }
                    else {
                        if (res == "") {
                            alert("删除失败!请查看该数据与其他模块下的信息的关联，或联系管理员。");
                        }
                        else {
                            alert(res);
                        }
                    }
                }); 
              
            };
            //加载列表
            $("#flexigridData").flexigrid(
			{
			    url: '../activity/FlexigridList',//获取数据的url
			    colModel: [
				   { display: '<%: Html.LabelFor(model => model.id) %>', name: 'id', width: 205, hide: true, sortable: false, align: 'left' }
					, { display: '序号', name: 'MySeq', width: 26, sortable: false, align: 'left' }
					, { display: '<%: Html.LabelFor(model => model.name) %>', name: 'name', width: 251, sortable: true, align: 'left' }
					, { display: '<%: Html.LabelFor(model => model.description) %>', name: 'description', width: 251, sortable: true, align: 'left' }
					
					, { display: '<%: Html.LabelFor(model => model.filltime) %>', name: 'filltime', width: 251, sortable: true, align: 'left' }
					, { display: '<%: Html.LabelFor(model => model.order) %>', name: 'order', width: 251, sortable: true, align: 'left' }

                   	],
			      buttons: [
                    { name: '查询', bclass: 'searchcss', onpress: flexiQuery },
                    
                    { name: '详细', bclass: 'detailcss', onpress: flexiView },
                    
                    { name: '创建', bclass: 'addcss', onpress: flexiCreate },
                    
				    { name: '删除', bclass: 'deletecss', onpress: flexiDelete },
                    
                    { name: '修改', bclass: 'editcss', onpress: flexiModify },
                    
                    { name: '导出', bclass: 'excelcss', onpress: flexiOut },
				    
                    { name: '选择', bclass: 'selectcss', onpress: flexiSelect }
				    
				],
			    sortname: "id",//排序字段
			    sortorder: "asc",//排序升
			    title: 'activity',//列表的标题
                usepager: true,//分页
				useRp: true,//分页中的下拉框
			    showTableToggleBtn: true,//显示按钮
			    height: 288//高度
			});
            //如果列表页出现在弹出框中，则只显示选择按钮，选择按钮是该行按钮的最后一个
            var parent = window.dialogArguments; //获取父页面
            if (parent == "undefined" || parent == null) {
                $(".fbutton:last").hide();//隐藏选择按钮
            } else {
                $(".fbutton").hide();//隐藏所以按钮
                $(".fbutton:first").show();//显示查询按钮
                $(".fbutton:last").show();//显示选择按钮
            }
            easyloader.locale = "zh_CN"; // 本地化设置
            //easyloader.theme = "gray"; // 设置主题
            using('dialog', function () {});//加载引用的css和js
        });
    </script>
</asp:Content>

