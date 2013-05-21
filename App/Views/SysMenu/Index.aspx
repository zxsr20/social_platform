<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title>模块</title>
    <script src="<%: Url.Content("~/Scripts/jquery.min.js") %>" type="text/javascript"></script>
    <link href="<%: Url.Content("~/Res/easyui/themes/icon.css") %>" rel="stylesheet"
        type="text/css" />
    <script src="<%: Url.Content("~/Res/easyui/easyloader.js") %>" type="text/javascript"></script>
    <script src="<%: Url.Content("~/Scripts/JScriptCommon.js") %>" type="text/javascript"></script>
    <style type="text/css">
        body
        {
            font-size: 12px;
            font-family: 微软雅黑,新宋体;
            margin: 0;
            padding: 0;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            easyloader.locale = "zh_CN"; // 本地化设置
//            easyloader.theme = "gray"; // 设置主题
            using('treegrid', function () {
                $('#test').treegrid({
                    title: '模块',
//                    url: '../SysMenu/GetAllMetadata',
                    idField: 'Id',
                    treeField: 'Name',
                    rownumbers: true,
                    toolbar: [
                    {
                        text: '详细',
                        iconCls: 'icon-search',
                        handler: function () {
                            getView();
                        }
                    }, {
                        text: '创建',
                        iconCls: 'icon-add',
                        handler: function () {
                            flexiCreate();
                        }
                    },  {
                        text: '删除',
                        iconCls: 'icon-remove',
                        handler: function () {
                            flexiDelete();
                        }
                    }, {
                        text: '修改',
                        iconCls: 'icon-edit',
                        handler: function () {
                            flexiModify();
                        }
                    }, {
                        text: '选择',
                        iconCls: 'icon-ok',
                        handler: function () {
                            flexiSelect();
                        }
                    }],
                    frozenColumns: [[
	                    { field: 'ck', checkbox: true }
                        ,{ field: 'Name', title: '名称', width: 150 }
				    ]],
                    columns: [[
                    
					{ field: 'Url', title: '网址', width: 83 }
					,{ field: 'Iconic', title: '图标', width: 83 }
					,{ field: 'Sort', title: '排序', width: 83 }
					,{ field: 'Remark', title: '备注', width: 83 }
					,{ field: 'State', title: '状态', width: 83 }
					,{ field: 'CreatePerson', title: '创建人', width: 83 }
					,{ field: 'CreateTime', title: '创建时间', width: 83 }
					,{ field: 'UpdateTime', title: '编辑时间', width: 83 }
					,{ field: 'UpdatePerson', title: '编辑人', width: 83 }
					,{ field: 'Version', title: '时间戳', width: 83 }
				    ]]
                     ,
                    onBeforeLoad: function (row, param) {
                       
                        if (row) {
                            $(this).treegrid('options').url = '../SysMenu/GetAllMetadata/' + row.id;
                        } else {
                            $(this).treegrid('options').url = '../SysMenu/GetAllMetadata';
                        }
                    }
                });
          
                var parent = window.dialogArguments; //获取父页面
                if (parent == "undefined" || parent == null) {
                    $(".l-btn.l-btn-plain:last").hide();
                } else {
                    $(".l-btn.l-btn-plain").hide();
                    $(".datagrid-btn-separator").hide();
                    $(".l-btn.l-btn-plain:last").show();
                }
            }); 
         });
            function flexiSelect() {
            var node = $('#test').treegrid('getSelected');
            if (!node) {
                alert("请选择数据!");
                return;
            }
            var arr = new Array(0);
            arr.push(node.Id);
            arr.push("^"); //主键列和显示列的分割符 ^ 
            arr.push(node.Name);
            //主键列和显示列之间用 ^ 分割   每一项用 , 分割
            if (arr.length == 3) {//一条数据和多于一条
                returnParent(arr.join("&")); //每一项用 & 分割
            }
        }
        function getView() {

            var node = $('#test').treegrid('getSelected');
            if (!node) {
                alert("请选择数据!");
                return;
            }
            var arr = new Array(0);
            arr.push(node.Id);

            if (arr.length == 1) {
                var parent = window.dialogArguments; //获取父页面
                if (parent != null && parent != "undefined") {//如果是父页面就不许操作
                    alert("请不要在弹出框中新建，可以转到列表中查看！"); return;
                }
                window.location.href = "../SysMenu/Details/" + arr[0];
                return;
            }
        }
        function flexiCreate() {
            var parent = window.dialogArguments; //获取父页面
            if (parent != null && parent != "undefined") {//如果是父页面就不许操作
                alert("请不要在弹出框中新建，可以转到列表中新建！"); return;
            }
            window.location.href = "../SysMenu/Create";
            return;
        }

        function flexiModify() {
            var node = $('#test').treegrid('getSelected');
            if (!node) {
                alert("请选择数据!");
                return;
            }
            var arr = new Array(0);
            arr.push(node.Id);

            if (arr.length == 1) {
                var parent = window.dialogArguments; //获取父页面
                if (parent != null && parent != "undefined") {//如果是父页面就不许操作
                    alert("请不要在弹出框中新建，可以转到列表中查看！"); return;
                }
                window.location.href = "../SysMenu/Edit/" + arr[0];
                return;
            }
        };

        function flexiDelete() {
            var parent = window.dialogArguments; //获取父页面
            if (parent != null && parent != "undefined") {//如果是父页面就不许操作
                alert("请不要在弹出框中删除，可以转到列表中删除！"); return;
            }
            var node = $('#test').treegrid('getSelected');
            if (!node) {
                alert("请选择数据!");
                return;
            }
            var arr = new Array(0);
            arr.push(node.Id);
      
            if (!confirm("确认删除这 1 项吗？"))
                return;
            $.post("../SysMenu/Delete", { query: arr.join(",") }, function (res) {
                if (res == "OK") {
                    remove();
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
        function reload() {
            var node = $('#test').treegrid('getSelected');
            if (node) {
                $('#test').treegrid('reload', node.code);
            } else {
                $('#test').treegrid('reload');
            }
        }
        function remove() {
            var node = $('#test').treegrid('getSelected');
            if (node) {
                $('#test').treegrid('remove', node.Id);
            }
        }
    </script>
</head>
<body>
    <table id="test">
    </table>
    <div id="dialo" title="操作">
    </div>
</body>
</html>

