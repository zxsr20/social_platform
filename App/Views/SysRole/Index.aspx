<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<DAL.SysRole>" %>

<!DOCTYPE html>
<html>
<head id="Head1">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>角色</title>
    <script src="<%: Url.Content("~/Scripts/jquery.min.js") %>" type="text/javascript"></script>
    <link href="<%: Url.Content("~/Content/StyleSheet.css") %>" rel="stylesheet" type="text/css" />
    <script src="<%: Url.Content("~/Res/flexigrid/flexigrid.js") %>" type="text/javascript"></script>
    <link href="<%: Url.Content("~/Res/flexigrid/css/flexigrid/flexigrid.css") %>" rel="stylesheet"
        type="text/css" />
        <link href="<%: Url.Content("~/Res/easyui/themes/icon.css") %>" rel="stylesheet"
        type="text/css" />
    <script src="<%: Url.Content("~/Res/easyui/easyloader.js") %>" type="text/javascript"></script>
    <script src="<%: Url.Content("~/Scripts/JScriptCommon.js") %>" type="text/javascript"></script>
    <script type="text/javascript">

        $(function () {         
                 
            //按钮操作函数
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
                            $("#flexigridDataSef").flexReload(); //刷新
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

              });
             
              grid.doDaoChu("../SysRole/GetDaoChu");
          };
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
                    alert("请不要在弹出框中新建，可以转到列表中查看！");return;
                }
                window.location.href = "../SysRole/Details/" + arr[0];
                window.event.returnValue = false; //兼容IE6
                return;
                }
            }

            function flexiCreate() {
                var parent = window.dialogArguments; //获取父页面
                if (parent != null && parent != "undefined") {//如果是父页面就不许操作
                    alert("请不要在弹出框中新建，可以转到列表中新建！");return;
                }
                window.location.href = "../SysRole/Create/" + $("#hidtreeid").val();
                window.event.returnValue = false; //兼容IE6
                return;
            }

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
                    window.location.href = "../SysRole/Edit/" + arr[0];
                    window.event.returnValue = false; //兼容IE6
                    return;
                }
            };

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
      
                $.post("../SysRole/Delete", { query: arr.join(",") }, function (res) {
                    if (res == "OK") {
                        $("#flexigridDataSef").flexReload();
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
			
			
            flexiSetSysMenu = function (ids, grid) {
                var parent = window.dialogArguments; //获取父页面
                if (parent != null && parent != "undefined") {//如果是父页面就不许操作
                    alert("请不要在弹出框中设置，可以转到列表中设置！"); return;
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
                    alert("请只选择一条需要设置的数据!");
                    return;
                }
                if (arr.length == 1) {
                    //window.location.href = "../SysRole/SetSysMenu/" + arr[0];
                    ShowManyTree(arr[0]);
                    return;
                }
            };
			
            $("#flexigridDataSef").flexigrid(
			{
			    url: '../SysRole/FlexigridList',
			    colModel: [
				   { display: '<%: Html.LabelFor(model => model.Id) %>', name: 'Id', width: 205, hide: true, sortable: false, align: 'left' }
					, { display: '序号', name: 'MySeq', width: 26, sortable: false, align: 'left' }
					, { display: '<%: Html.LabelFor(model => model.Name) %>', name: 'Name', width: 150, sortable: true, align: 'left' }
					, { display: '<%: Html.LabelFor(model => model.Description) %>', name: 'Description', width: 150, sortable: true, align: 'left' }
					, { display: '<%: Html.LabelFor(model => model.Remark) %>', name: 'Remark', width: 150, sortable: true, align: 'left' }
					, { display: '<%: Html.LabelFor(model => model.CreateTime) %>', name: 'CreateTime', width: 150, sortable: true, align: 'left' }
					, { display: '<%: Html.LabelFor(model => model.CreatePerson) %>', name: 'CreatePerson', width: 150, sortable: true, align: 'left' }
					, { display: '<%: Html.LabelFor(model => model.UpdateTime) %>', name: 'UpdateTime', width: 150, sortable: true, align: 'left' }
					, { display: '<%: Html.LabelFor(model => model.UpdatePerson) %>', name: 'UpdatePerson', width: 150, sortable: true, align: 'left' }
					, { display: '<%: Html.LabelFor(model => model.Version) %>', name: 'Version', hide: true, width: 150, sortable: false, align: 'left' }
					//, { display: '<%: Html.LabelFor(model => model.SysPersonId) %>', name: 'SysPersonId', width: 150, sortable: false, align: 'left' }
					//, { display: '<%: Html.LabelFor(model => model.SysMenuId) %>', name: 'SysMenuId', width: 150, sortable: false, align: 'left' }

                   	],
			      buttons: [
                    { name: '查询', bclass: 'searchcss', onpress: flexiQuery },
                    
                    { name: '详细', bclass: 'detailcss', onpress: flexiView },
                    
                    { name: '创建', bclass: 'addcss', onpress: flexiCreate },
                    
				    { name: '删除', bclass: 'deletecss', onpress: flexiDelete },
                    
                    { name: '修改', bclass: 'editcss', onpress: flexiModify },
                   
                    { name: '导出', bclass: 'excelcss', onpress: flexiOut },
				    
					{ name: '设置模块', bclass: 'excelcss', onpress: flexiSetSysMenu },
					
                    { name: '选择', bclass: 'selectcss', onpress: flexiSelect }

				    
				],
			    sortname: "CreateTime",
			    sortorder: "asc",
			    title: '角色',
                usepager: true,
				useRp: true,
			    showTableToggleBtn: true,
			    height: 320,
			    width:935
			});
            var parent = window.dialogArguments; //获取父页面
            if (parent == "undefined" || parent == null) {
                $(".fbutton:last").hide();
            } else {
                $(".fbutton").hide();
                $(".fbutton:first").show();
                $(".fbutton:last").show();
            }
            easyloader.locale = "zh_CN"; // 本地化设置
            //easyloader.theme = "gray"; // 设置主题
            using('tree', function () {
                $('#myTree').tree({
                    url: '../SysMenuTree/GetTree',
                    onClick: function (node) {                        
                        if (node != null && node.id != null && node.id != "undefined") {
                            if (node.iconCls != null) {//&& node.iconCls == 'icon-ok'
                                $("#hidtreeid").val('');
                                $("#flexigridDataSef").flexReload(''); //根目录刷新  
                            } else {
                                $("#hidtreeid").val(node.id);
                                $("#flexigridDataSef").flexReload(node.id); //子节点刷新
                            }

                        }                       
                    },
                    onBeforeLoad: function (node, param) {
                        if (node) {
                            param.parentid = node.id;
                        }
                    }
                });
            });
        });
        function ShowManyTree(id) {           
            //获取角色的模块
            $.ajaxSetup({ cache: false });
            data = { id: id };
            $.ajax({ type: "POST", dataType: "json",
                url: "/SysRole/GetManyData",
                async: false,
                data: data,
                success: function (msg) {
                    $("#SysMenuIdOld").val(msg);                    
                }
            });
            //异步获取模块
            $('#myTreeControl').tree({
                checkbox: true,
                url: '../SysMenuTree/GetTree', // + roleId,
                onLoadSuccess: function (node, data) {
                    if (data != "") {
                        var newId = "";
                        var nodes = eval(data);
                        for (i = 0; i < nodes.length; i++) {
                            if (newId != "") newId += ",";
                            newId += nodes[i].id;
                        }
                        var oldId = $('#SysMenuIdOld').val();
                        bindSonTreeChecked(oldId, newId, 'myTreeControl');
                    }
                },
                onBeforeLoad: function (node, param) {
                    $(this).tree('options').url = "../SysMenuTree/GetTree"; // + roleId;
                    if (node) {
                        param.parentid = node.id;
                    }
                }
            });
            //显示树控件
            $('#divManyTree').dialog({
                height: 350,
                width: 400,
                autoOpen: true,
                modal: false,
                cache: false,
                buttons: [
                {
                    text: "确定",
                    handler: function () {
                        //保存角色的模块
                        var r = getchecked();
                        data = { SysMenuId: r };
                        $.ajax({ type: "POST", dataType: "json",
                            url: "/SysRole/SetSysMenu/" + id,
                            async: false,
                            data: data,
                            success: function (msg) {
                                $('#divManyTree').dialog("close");
                            },
                            error: function (ex) { alert("查询错误。详细：" + ex.responseText); }
                        });
                    }
                },
                {
                    text: "关闭",
                    handler: function () {
                        $('#divManyTree').dialog("close");
                    }
                }]
            });
        }
        function getchecked() {
            //取得所有选中的节点，返回节点对象的集合
            var s = '';
            var nodes = $("#myTreeControl").tree("getChecked");
            for (var i = 0; i < nodes.length; i++) {
                if (s != '') s += ',';
                s += nodes[i].id;
            }

            return s;
        }
    </script>
</head>
<body class="easyui-layout">
    <div region="west" split="true" title="模块" style="width: 150px;">
        <ul id="myTree">
        </ul>
    </div>
    <div id="content" region="center" fit="true" title="角色" style="padding: 5px;">
        <table id="flexigridDataSef">
        </table>
    </div>
    <div id="divManyTree" title="选择模块" style="padding: 5px; background: #fafafa;display:block">
        <ul id="myTreeControl"></ul>
    </div>
    <div id="divQuery" title="查询列表" class="easyui-dialog" closed="true" modal="false"
        style="padding: 5px; background: #fafafa;" iconcls="icon-search">
         
            <div class="input">
                <div class="editor-label">
                    <%: Html.LabelFor(model => model.Name) %>
                </div>
                <div class="editor-field-Search">
                <input type='text' id='Name'/>
                </div>
            </div>
            <br style="clear:both;" />
    </div>
    <input id="hidtreeid" type="hidden" />
    <input id="SysMenuIdOld" type="hidden"/>
    <div id="dialo" title="操作">
    </div>
</body>
</html>

