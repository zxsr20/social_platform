﻿function bindDropDownList(thisid, parentid) {
 
    if ($(parentid).val() != "") {
        var url = "/Home/GetSysFieldByParentId/" + $(parentid).val();
	$.ajaxSetup({ cache: false });
        $.getJSON(url, function (data) {
            if (data == null) {
                return;
            }
            $.each(data, function (i, item) {
                if (item == null) {
                    return;
                }
                $("<option></option>")
                        .val(item["Value"])
                        .text(item["Text"])
                        .appendTo($(thisid));
            });
        });
    }
}
 
function returnParent(value) {//获取子窗体返回值
    var parent = window.dialogArguments; //获取父页面
    //parent.location.reload(); //刷新父页面
    if (parent != null && parent != "undefined") {
        window.returnValue = value; //返回值
        window.close(); //关闭子页面
    }
    return;
}
function menuClick(url) {
    if (url == "undefined" || url == "") { return; }
    $("#frmMain").attr("src", '../../' + url);
    return;
}
function getclick(ok) {
}
function GetEyeSize() {
    return { width: document.documentElement.clientWidth, height: document.documentElement.clientHeight };
}
//IFrame 调用页面后, 自动适应高度的代码.SetWinHeight(this);
function SetWinHeight(win, AddExtHeight) {
    //消除事件
    $(win.contentDocument || win.Document).click(function () { $(win.ownerDocument).click(); });
    AddExtHeight = AddExtHeight || 0;
    //        if ( $.browser.msie) AddExtHeight += 20 ;

    var newH = GetEyeSize().height - $(win).offset().top - parseInt($("body").css("margin-bottom")) - 5;

    win.height = newH;
    var getContentHeidht = function (win) {
        var ieHeight = 0, ffHeight = (win.contentWindow.innerHeight + win.contentWindow.scrollMaxY) || 0;
        if (win.document) ieHeight = (win.contentWindow.document.body.scrollHeight) || 0;
        return Math.max(ieHeight, ffHeight) + AddExtHeight;
    };

    var winHeight = getContentHeidht(win);

    //        if ( $.browser.msie) pHeight -= 3 ;
    win.height = Math.max(winHeight, newH);
    $(win.contentWindow.document.body).css("overflow", "hidden");
}
function AutoHeight() {

    var iWidth = window.screen.availWidth;
    var iHeight = window.screen.availHeight;
    if (Number(iHeight) < 700) { iHeight = 530; }
    document.getElementById("frmMain").style.width = ((Number)(iWidth) - 15);
    document.getElementById("frmMain").style.height = ((Number)(iHeight) - 80);
}
function deleteTable(table, hidden) { //删除table和隐藏的值
    var tableId = document.getElementById(table); //获取表格
    tableId.parentNode.removeChild(tableId); //删除table
    // tableId.style.display = "none";//table隐藏isNaN(Number())
    var hiddenValue = document.getElementById(hidden); //获取隐藏的控件

    //  hiddenValue.value+="";

    if (hiddenValue.value.indexOf(table) > -1) {
        hiddenValue.value = hiddenValue.value.replace(table, ""); //为隐藏控件赋值
    }
}
function showModalMany(me, url, dialogWidth,callback) { //弹出窗体，多选   
    if (dialogWidth == null || dialogWidth == "undefined" || dialogWidth == "") {
        dialogWidth = 968;
    }
    var reValue = window.showModalDialog(url, window, "dialogHeight:500px; dialogWidth:" + dialogWidth + "px;  status:off; scroll:auto");

    if (reValue == null || reValue == "undefined" || reValue == "") {
        return; //如果返回值为空，就返回
    }
	
    var index = reValue.split("^"); //分割符 ^ 的位置
    if (index[0] == null || index[0] == "undefined" || index[0].length < 1) {
        return;
    }
    var hid = index[0].split('&'); //为隐藏控件赋值
    var view = index[1].split('&'); //显示值
    var content = ""; //需要添加到check中的内容
    var h = "";
    for (var i = 0; i < hid.length - 1; i++) {
        if (hid[i] != "undefined" && hid[i] != "" && view[i + 1] != "undefined" && view[i + 1] != "") {
            
			var tableId = document.getElementById(hid[i] + "&" + view[i + 1]); //获取表格
			if(tableId==null)
			{
			h += "^" + hid[i] + "&" + view[i + 1];
            content += '<table  id="' + hid[i] + "&" + view[i + 1] + '" class="deleteStyle"><tr><td><img src="../../../Images/deleteimge.png" title="点击删除"  alt="删除" onclick=" deleteTable(' + "'" + hid[i] + "&" + view[i + 1] + "'," + "'" + me + "'" + ');" /></td><td>' + view[i + 1] + '</td></tr></table>';
			}
        }
    }
    var hidden = document.getElementById(me); //获取隐藏的控件
    hidden.value += h; //为隐藏控件赋值
    var c = document.getElementById("check" + me);
    c.innerHTML += content;
	if(callback!=null)
	{
		callback()
	}
}

function showTreeOnlyEdit(me, url) { //弹出窗体 ,单选
    var hidden = document.getElementById(me); //获取隐藏的控件
    if (hidden.value != null && hidden.value.length > 0) {
        alert("此处为单选，请先删除已有的选项，再次尝试选择。");
        return;
    }
    var reValue = window.showModalDialog(url, window, "dialogHeight:500px; dialogWidth:987px;  status:off; scroll:auto");

    if (reValue == null || reValue == "undefined" || reValue == "") {
        return; //如果返回值为空，就返回
    }
    var index = reValue.split("&"); //分割符 ^ 的位置
    if (index[0] == null || index[0] == "undefined" || index[0].length < 1) {
        return;
    }
    if (index[1] == null || index[1] == "undefined" || index[1].length < 1) {
        return;
    }
    var hid = index[0]; //为隐藏控件赋值
    var view = index[1]; //显示值
    var content = ""; //需要添加到check中的内容

    var href = window.location.href;
    var ref = href.substr(href.lastIndexOf('/') + 1);

    if (hid != null) {
        if (ref == hid) {
            alert("请不要选择同一条数据。");
            return;
        }
        if (hid != "undefined" && hid != "" && view != "undefined" && view != "") {

            content += '<table  id="' + hid + "&" + view
            + '" class="deleteStyle"><tr><td><img src="../../../Images/deleteimge.png" title="点击删除"  alt="删除" onclick=" deleteTable('
            + "'" + hid + "&" + view
             + "'," + "'" + me + "'" + ');" /></td><td>' + view
              + '</td></tr></table>';

            hidden.value = hid; //为隐藏控件赋值
            var c = document.getElementById("check" + me);
            c.innerHTML += content;
            return;
        }
    }
    alert("请只选择一条数据。");
    return;
}

function showModalOnly(me, url) { //弹出窗体 ,单选
    var hidden = document.getElementById(me); //获取隐藏的控件
    if (hidden != null && hidden.value != null && hidden.value.length > 0) {
        alert("此处为单选，请先删除已有的选项，再次尝试选择。");
        return;
    }
    var reValue = window.showModalDialog(url, window, "dialogHeight:500px; dialogWidth:987px;  status:off; scroll:auto");

    if (reValue == null || reValue == "undefined" || reValue == "") {
        return; //如果返回值为空，就返回
    }
    var index = reValue.split("^"); //分割符 ^ 的位置
    if (index[0] == null || index[0] == "undefined" || index[0].length < 1) {
        return;
    }
    var hid = index[0].split('&'); //为隐藏控件赋值
    var view = index[1].split('&'); //显示值
    var content = ""; //需要添加到check中的内容

    if (hid != null && hid.length == 2) {
        var i = 0;

        if (hid[i] != "undefined" && hid[i] != "" && view[i + 1] != "undefined" && view[i + 1] != "") {

            content += '<table  id="' + hid[i]
            + '" class="deleteStyle"><tr><td><img src="../../../Images/deleteimge.png" title="点击删除"  alt="删除" onclick=" deleteTable('
            + "'" + hid[i] + "'," + "'" + me + "'" + ');" /></td><td>' + view[i + 1] + '</td></tr></table>';

            hidden.value = hid[i]; //为隐藏控件赋值
            var c = document.getElementById("check" + me);
            c.innerHTML += content;
            return;
        }
    }
    alert("请只选择一条数据。");
    return;
}

function popTextArea(jTextAreas) {

    $("textarea").each(function (i, d) {
        $(d).focus(function () {

            var ta = $('<div title="请输入内容"><textarea style="width: 478px; height: 231px">t1t</textarea></div>'.replace("t1t", $(d).val()));

            $(ta).dialog({
                autoOpen: true,
                width: 530,
                height: 401,
                buttons: {
                    "确定": function () {
                        $(d).val($("textarea", ta).val());
                        $(this).dialog("close");
                    },
                    "取消": function () {
                        $(this).dialog("close");
                    }
                }
            });
        });
    });
}
function icons(clientId) {
    var d = $("#" + clientId);
    var icons = "";
    for (var i = 1; i <= 26; i++) {
        var i0 = i < 10 ? "0" + i : i;
        for (var j = 1; j <= 20; j++) {
            var j0 = j < 10 ? "0" + j : j;
            icons += '<span class="icon tu' + j0 + i0 + '" value="' + j0 + i0 + '" style="cursor:pointer" onclick=selectimg(this,"' + d.attr("id") +'") >&nbsp;</span>';
        }
    }
    var ta = $('<div title="请选择图标">' + icons + '</div>');
    $(ta).dialog({
        autoOpen: true,
        width: 400
    });
}
function selectimg(i, d) {
    var s = $(i).attr("value");
    $("#" + d).val(s);
    $("#img" + d).removeClass();
    $("#img" + d).addClass("icon tu" + s);
    $(i + ":parent").dialog("close");
}
function isInt(t) {
    t.value = t.value.replace(/[^0-9]/g, '')
}
function dia() {
    if ($("#dialo").dialog("isOpen")) {
        $("#dialo").dialog({
            autoOpen: true,

            buttons: {
                "确定": function () {
                    $("#dialo").dialog("close");
                }
            }
        });
    }
}
function BackList(url) {

    window.location.href = '../../' + url;
}
function manyTreeChecked(node, checked, hidControl, treeId) {
    var hidArr = $('#' + hidControl).val().split(',');
    //debugger;
    //alert(hidArr.join(','));
    if (checked) {
        hidArr.push(node.id);
        var nodeChildren = $('#' + treeId).tree("getChildren", node.target);
        if (nodeChildren != null) {
            for (var i = 0; i < nodeChildren.length; i++) {
                treeChecked(nodeChildren[i].id,treeId,"tree-checkbox1");
                hidArr.push(nodeChildren[i].id);
            }
        }
    }
    else {
        //debugger;
        for (var i = 0; i < hidArr.length; i++) {
            if (hidArr[i] == node.id) {
                hidArr.splice(i, 1);
            }
        }
        var nodeChildren = $('#' + treeId).tree("getChildren", node.target);
        if (nodeChildren != null) {
            for (var i = 0; i < nodeChildren.length; i++) {
                treeChecked(nodeChildren[i].id, treeId, "tree-checkbox0");
                for (var j = 0; j < hidArr.length; j++) {
                    if (hidArr[j] == nodeChildren[i].id) {
                        hidArr.splice(j, 1);
                    }
                }
            }
        }
    }
    $('#' + hidControl).val(hidArr.join(','));
}
function bindmanyTreeChecked(checkData, hidControl, treeId) {
    if (checkData == null || checkData == "" || checkData == "undefined") {
        return;
    }
    var menuids = checkData.split(',');
    var hidArr = $('#' + hidControl).val().split(',');
    for (i = 0; i < menuids.length; i++) {
        treeChecked(menuids[i], treeId, "tree-checkbox1");
        hidArr.push(menuids[i]);
    }
    $('#' + hidControl).val(hidArr.join(','));
}
function bindSonTreeChecked(oldData, newData, treeId) {
    if (oldData == null || oldData == "" || oldData == "undefined") {
        return;
    }
    var menuids = oldData.split(',');
    var sonids = newData.split(',');
    for (i = 0; i < menuids.length; i++) {
        for (j = 0; j < sonids.length; j++) {
            if (menuids[i] == sonids[j]) {
                treeChecked(menuids[i], treeId, "tree-checkbox1");
                break;
            }
        }
    }
}
function treeChecked(node, treeId, className) {
    var nodeid = $("#" + treeId).tree("find", node);
    if (nodeid) {
        var ck = $(nodeid.target).find('.tree-checkbox');
        ck.removeClass("tree-checkbox0 tree-checkbox1 tree-checkbox2");
        ck.addClass(className);
    }
}