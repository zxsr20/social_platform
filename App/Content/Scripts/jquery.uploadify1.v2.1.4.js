/*
Uploadify v2.1.4
Release Date: November 8, 2010

Copyright (c) 2010 Ronnie Garcia, Travis Nickels

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
*/

if (jQuery) (
	function (jQuery) {
	    jQuery.extend(jQuery.fn, {
	        uploadify: function (options) {
	            jQuery(this).each(function () {
	                var settings = jQuery.extend({
	                    id: jQuery(this).attr('id'), // The ID of the object being Uploadified
	                    uploader: 'uploadify.swf', // The path to the uploadify swf file
	                    script: 'uploadify.php', // The path to the uploadify backend upload script
	                    expressInstall: null, // The path to the express install swf file
	                    folder: '', // The path to the upload folder
	                    height: 30, // The height of the flash button
	                    width: 120, // The width of the flash button
	                    cancelImg: 'cancel.png', // The path to the cancel image for the default file queue item container
	                    wmode: 'opaque', // The wmode of the flash file
	                    scriptAccess: 'sameDomain', // Set to "always" to allow script access across domains
	                    fileDataName: 'Filedata', // The name of the file collection object in the backend upload script
	                    method: 'POST', // The method for sending variables to the backend upload script
	                    queueSizeLimit: 999, // The maximum size of the file queue
	                    simUploadLimit: 1, // The number of simultaneous uploads allowed
	                    queueID: false, // The optional ID of the queue container
	                    displayData: 'speed', // Set to "speed" to show the upload speed in the default queue item
	                    removeCompleted: true, // Set to true if you want the queue items to be removed when a file is done uploading
	                    onInit: function () { }, // Function to run when uploadify is initialized
	                    onSelect: function () { }, // Function to run when a file is selected
	                    onSelectOnce: function () { }, // Function to run once when files are added to the queue
	                    onQueueFull: function () { }, // Function to run when the queue reaches capacity
	                    onCheck: function () { }, // Function to run when script checks for duplicate files on the server
	                    onCancel: function () { }, // Function to run when an item is cleared from the queue
	                    onClearQueue: function () { }, // Function to run when the queue is manually cleared
	                    onError: function () { }, // Function to run when an upload item returns an error
	                    onProgress: function () { }, // Function to run each time the upload progress is updated
	                    onComplete: function () { }, // Function to run when an upload is completed
	                    onAllComplete: function () { }  // Function to run when all uploads are completed
	                }, options);
	                jQuery(this).data('settings', settings);
	                var pagePath = location.pathname;
	                pagePath = pagePath.split('/');
	                pagePath.pop();
	                pagePath = pagePath.join('/') + '/';
	                var data = {};
	                data.uploadifyID = settings.id;
	                data.pagepath = pagePath;
	                if (settings.buttonImg) data.buttonImg = escape(settings.buttonImg);
	                if (settings.buttonText) data.buttonText = escape(settings.buttonText);
	                if (settings.rollover) data.rollover = true;
	                data.script = settings.script;
	                data.folder = escape(settings.folder);
	                if (settings.scriptData) {
	                    var scriptDataString = '';
	                    for (var name in settings.scriptData) {
	                        scriptDataString += '&' + name + '=' + settings.scriptData[name];
	                    }
	                    data.scriptData = escape(scriptDataString.substr(1));
	                }
	                data.width = settings.width;
	                data.height = settings.height;
	                data.wmode = settings.wmode;
	                data.method = settings.method;
	                data.queueSizeLimit = settings.queueSizeLimit;
	                data.simUploadLimit = settings.simUploadLimit;
	                if (settings.hideButton) data.hideButton = true;
	                if (settings.fileDesc) data.fileDesc = settings.fileDesc;
	                if (settings.fileExt) data.fileExt = settings.fileExt;
	                if (settings.multi) data.multi = true;
	                if (settings.auto) data.auto = true;
	                if (settings.sizeLimit) data.sizeLimit = settings.sizeLimit;
	                if (settings.checkScript) data.checkScript = settings.checkScript;
	                if (settings.fileDataName) data.fileDataName = settings.fileDataName;
	                if (settings.queueID) data.queueID = settings.queueID;
	                if (settings.onInit() !== false) {
	                    jQuery(this).css('display', 'none');
	                    jQuery(this).after('<div id="' + jQuery(this).attr('id') + 'Uploader"></div>');
	                    swfobject.embedSWF(settings.uploader, settings.id + 'Uploader', settings.width, settings.height, '9.0.24', settings.expressInstall, data, { 'quality': 'high', 'wmode': settings.wmode, 'allowScriptAccess': settings.scriptAccess }, {}, function (event) {
	                        if (typeof (settings.onSWFReady) == 'function' && event.success) settings.onSWFReady();
	                    });
	                    if (settings.queueID == false) {
	                        jQuery("#" + jQuery(this).attr('id') + "Uploader").after('<div id="' + jQuery(this).attr('id') + 'Queue" class="uploadifyQueue"></div>');
	                    } else {
	                        jQuery("#" + settings.queueID).addClass('uploadifyQueue');
	                    }
	                }
	                if (typeof (settings.onOpen) == 'function') {
	                    jQuery(this).bind("uploadifyOpen", settings.onOpen);
	                }
	                jQuery(this).bind("uploadifySelect", { 'action': settings.onSelect, 'queueID': settings.queueID }, function (event, ID, fileObj) {
	                    if (event.data.action(event, ID, fileObj) !== false) {
	                        var byteSize = Math.round(fileObj.size / 1024 * 100) * .01;
	                        var suffix = 'KB';
	                        if (byteSize > 1000) {
	                            byteSize = Math.round(byteSize * .001 * 100) * .01;
	                            suffix = 'MB';
	                        }
	                        var sizeParts = byteSize.toString().split('.');
	                        if (sizeParts.length > 1) {
	                            byteSize = sizeParts[0] + '.' + sizeParts[1].substr(0, 2);
	                        } else {
	                            byteSize = sizeParts[0];
	                        }
	                        if (fileObj.name.length > 17) {
	                            fileName = fileObj.name.substr(0, 17) + '...';
	                        } else {
	                            fileName = fileObj.name;
	                        }
	                        queue = '#' + jQuery(this).attr('id') + 'Queue';
	                        if (event.data.queueID) {
	                            queue = '#' + event.data.queueID;
	                        }
	                        //						jQuery(queue).append('<div id="' + jQuery(this).attr('id') + ID + '" class="uploadifyQueueItem">\
	                        //								<div class="cancel">\
	                        //									<a href="javascript:jQuery(\'#' + jQuery(this).attr('id') + '\').uploadifyCancel(\'' + ID + '\')"><img src="' + settings.cancelImg + '" border="0" /></a>\
	                        //								</div>\
	                        //                                 <span class="icon ppt"></span>\
	                        //								<span class="fileName">' + fileName + ' (' + byteSize + suffix + ')</span><span class="percentage"></span>\
	                        //								<div class="uploadifyProgress">\
	                        //									<div id="' + jQuery(this).attr('id') + ID + 'ProgressBar" class="uploadifyProgressBar"><!--Progress Bar--></div>\
	                        //								</div>\
	                        //							</div>');


	                        var gsid = fileObj.name.substring(fileObj.name.lastIndexOf(".") + 1);
	                        var docclass = "";
	                        if (gsid == "doc" || gsid == "docx") {
	                            docclass = "icon doc";
	                        }
	                        else if (gsid == "ppt" || gsid == "pptx") {
	                            docclass = "icon ppt";
	                        }
	                        else if (gsid == "xls" || gsid == "xlsx") {
	                            docclass = "icon xls";
	                        }
	                        else {
	                            docclass = "icon " + gsid;
	                        }


	                        jQuery(queue).append('<ul id="' + jQuery(this).attr('id') + ID + '" class="upload-list">\
                                <li>\
                                <div class="upload-cont">\
                                <span id=span' + ID + '  class=\"' + docclass + '\"></span>\
									<h3>\
								<a id=docurl' + ID + ' href=#div' + ID + ' onclick="writedoc(\'' + ID + '\')">' + fileName + ' (' + byteSize + suffix + ')</a>\
                                </h3>\
                                <div class="uploadifyProgress">\
								  <a class="upload1" href="javascript:jQuery(\'#' + jQuery(this).attr('id') + '\').uploadifyCancel(\'' + ID + '\')">放弃上传</a>\
                                <a id=writea' + ID + ' href=#div' + ID + ' onclick="writedoc(\'' + ID + '\')"  style="display: none;">填写信息</a>\
                                </div>\
                                 <br>\
                                <div id="' + jQuery(this).attr('id') + ID + 'ProgressBar" class="uploadifyProgressBar"></div>\
                                </div>\
							</li>\
                            </ul>');


	                    }
	                });
	                jQuery(this).bind("uploadifySelectOnce", { 'action': settings.onSelectOnce }, function (event, data) {
	                    event.data.action(event, data);
	                    $("#uploadingmsg").text("正在上传:" + data.fileCount + "份");
	                    if (settings.auto) {
	                        if (settings.checkScript) {
	                            jQuery(this).uploadifyUpload(null, false);
	                        } else {
	                            jQuery(this).uploadifyUpload(null, true);
	                        }
	                    }
	                });
	                jQuery(this).bind("uploadifyQueueFull", { 'action': settings.onQueueFull }, function (event, queueSizeLimit) {
	                    if (event.data.action(event, queueSizeLimit) !== false) {
	                        alert('最大上传文件数 ' + queueSizeLimit + '.');
	                    }
	                });
	                jQuery(this).bind("uploadifyCheckExist", { 'action': settings.onCheck }, function (event, checkScript, fileQueueObj, folder, single) {
	                    var postData = new Object();
	                    postData = fileQueueObj;
	                    postData.folder = (folder.substr(0, 1) == '/') ? folder : pagePath + folder;
	                    if (single) {
	                        for (var ID in fileQueueObj) {
	                            var singleFileID = ID;
	                        }
	                    }
	                    jQuery.post(checkScript, postData, function (data) {
	                        for (var key in data) {
	                            if (event.data.action(event, data, key) !== false) {
	                                var replaceFile = confirm("Do you want to replace the file " + data[key] + "?");
	                                if (!replaceFile) {
	                                    document.getElementById(jQuery(event.target).attr('id') + 'Uploader').cancelFileUpload(key, true, true);
	                                }
	                            }
	                        }
	                        if (single) {
	                            document.getElementById(jQuery(event.target).attr('id') + 'Uploader').startFileUpload(singleFileID, true);
	                        } else {
	                            document.getElementById(jQuery(event.target).attr('id') + 'Uploader').startFileUpload(null, true);
	                        }
	                    }, "json");
	                });
	                jQuery(this).bind("uploadifyCancel", { 'action': settings.onCancel }, function (event, ID, fileObj, data, remove, clearFast) {
	                    if (event.data.action(event, ID, fileObj, data, clearFast) !== false) {
	                        if (remove) {
	                            var fadeSpeed = (clearFast == true) ? 0 : 250;
	                            jQuery("#" + jQuery(this).attr('id') + ID).fadeOut(fadeSpeed, function () { jQuery(this).remove() });
	                            $("#uploadingmsg").text("正在上传:" + data.fileCount + "份");

	                            //在网速慢的时候测试
	                            if (data.fileCount == 0) {
	                                if ($("#listul").find(".form-ed").length > 1) {
	                                    var batchp = document.getElementById("batchp");
	                                    if (batchp == null) {
	                                        var batchhtml = "<p class='upload-tip' id='batchp'>为了方便资料被更多用户浏览和下载,请耐心补充以下信息.如果您上传提一系列文件,可以<a href='#' onclick='javascript:batch();'>一起填写信息</a></p>";
	                                        $("#documentmsg").prepend(batchhtml);

	                                        //生成全部展开的按钮，点击该按钮时切换成全部收缩按钮。
	                                        var qbzk = "<span class='zk' id='qbzk' onclick='javascript:qbzk();'>全部展开</span>";
	                                        $("#writedocdiv").append(qbzk);
	                                    }


	                                }

	                            }
	                        }
	                    }
	                });
	                jQuery(this).bind("uploadifyClearQueue", { 'action': settings.onClearQueue }, function (event, clearFast) {
	                    var queueID = (settings.queueID) ? settings.queueID : jQuery(this).attr('id') + 'Queue';
	                    if (clearFast) {
	                        jQuery("#" + queueID).find('.uploadifyQueueItem').remove();
	                    }
	                    if (event.data.action(event, clearFast) !== false) {
	                        jQuery("#" + queueID).find('.uploadifyQueueItem').each(function () {
	                            var index = jQuery('.uploadifyQueueItem').index(this);
	                            jQuery(this).delay(index * 100).fadeOut(250, function () { jQuery(this).remove() });
	                        });
	                    }
	                });
	                var errorArray = [];
	                jQuery(this).bind("uploadifyError", { 'action': settings.onError }, function (event, ID, fileObj, errorObj) {
	                    if (event.data.action(event, ID, fileObj, errorObj) !== false) {
	                        var fileArray = new Array(ID, fileObj, errorObj);
	                        errorArray.push(fileArray);
	                        //jQuery("#" + jQuery(this).attr('id') + ID).find('.percentage').text(" - " + errorObj.type + " Error");

	                        var errormsg = "";
	                        if (errorObj.type == "File Size") {
	                            errormsg = "<p class='upload-fail'>" + "该文件过大！" + "</p>";
	                        }
	                        else {
	                            errormsg = "<p class='upload-fail'>" + errorObj.type + "发生错误" + "</p>";
	                        }
	                        jQuery("#" + jQuery(this).attr('id') + ID).find('.upload1').html(errormsg)

	                        $("#writea" + ID).hide();
	                        //jQuery("#" + jQuery(this).attr('id') + ID).find('.uploadifyProgress').hide();
	                        //jQuery("#" + jQuery(this).attr('id') + ID).addClass('uploadifyError');//错误是改变样式

	                        //获取已失败数量，然后+1
	                        var failval = parseInt($("#failmsg").text()) + 1;
	                        $("#failmsg").text(failval);
	                        //上传失败还没做


	                    }
	                });
	                if (typeof (settings.onUpload) == 'function') {
	                    jQuery(this).bind("uploadifyUpload", settings.onUpload);
	                }
	                jQuery(this).bind("uploadifyProgress", { 'action': settings.onProgress, 'toDisplay': settings.displayData }, function (event, ID, fileObj, data) {
	                    if (event.data.action(event, ID, fileObj, data) !== false) {
	                        jQuery("#" + jQuery(this).attr('id') + ID + "ProgressBar").animate({ 'width': data.percentage + '%' }, 250, function () {
	                            if (data.percentage == 100) {
	                                jQuery(this).closest('.uploadifyProgress').fadeOut(250, function () { jQuery(this).remove() });
	                            }
	                        });
	                        //用于速度显示
	                        //if (event.data.toDisplay == 'percentage') displayData = ' - ' + data.percentage + '%';
	                        //if (event.data.toDisplay == 'speed') displayData = ' - ' + data.speed + 'KB/s';
	                        //if (event.data.toDisplay == null) displayData = ' ';
	                        //jQuery("#" + jQuery(this).attr('id') + ID).find('.percentage').text(displayData);
	                    }
	                });
	                jQuery(this).bind("uploadifyComplete", { 'action': settings.onComplete }, function (event, ID, fileObj, response, data) {
	                    if (event.data.action(event, ID, fileObj, unescape(response), data) !== false) {
	                        //jQuery("#" + jQuery(this).attr('id') + ID).find('.percentage').text('文件上传成功');

	                        if (response == "isexist") {
	                            //jQuery("#" + jQuery(this).attr('id') + ID).find('.upload1').replaceWith("<p class='upload-select'>文档已存在</p>");
	                            var errormsg = "";
	                            errormsg = "<p class='upload-fail'>" + "文档已存在！" + "</p>"+"<a href='/upload?taskid='" + $("#taskid").val() + "'>上传其他</a>";
	                            var reupload = "<a href='/upload?taskid=" + $("#taskid").val() + ">上传其他</a>";
	                            jQuery("#" + jQuery(this).attr('id') + ID).find('.upload1').html(errormsg)
	                            //jQuery("#" + jQuery(this).attr('id') + ID).find('.upload1').append(reupload);
	                            $("#writea" + ID).hide();
	                            //获取已失败数量，然后+1
	                            var failval = parseInt($("#failmsg").text()) + 1;
	                            $("#failmsg").text(failval);

	                            $("#upload" + ID + "ProgressBar").remove();


	                        }
	                        else {
	                            jQuery("#" + jQuery(this).attr('id') + ID).find('.upload1').replaceWith("<p class='upload-select'>文档上传成功，请填写文档信息</p>");
	                            jQuery("#" + jQuery(this).attr('id') + ID).find('#writea' + ID).show();
	                            var failval = parseInt($("#successgs").text()) + 1;
	                            $("#successgs").text(failval);
	                        }


	                        //$("#successmsg").text("上传成功:" + data.filesUploaded + "份");
	                        if (settings.removeCompleted) {
	                            jQuery("#" + jQuery(event.target).attr('id') + ID).fadeOut(250, function () { jQuery(this).remove() });
	                        }
	                        jQuery("#" + jQuery(event.target).attr('id') + ID).addClass('completed');
	                        $("#uploadingmsg").text("正在上传:" + data.fileCount + "份");

	                        var uploadwidth = 0;
	                        if (parseInt($("#successgs").text()) != 0) {
	                            uploadwidth = parseInt($("#successgs").text()) / (parseInt($("#successgs").text()) + data.fileCount);
	                        }
	                        uploadwidth = uploadwidth * 100;
	                        var persent = uploadwidth + "%";
	                        $(".upload-lc").find("i").css('width', persent);
	                        //获取已成功数量，然后+1
	                        
	                        if (response != "isexist") {
	                            //生成html流程
	                            //首先页面加载时把一起填写的div隐藏，完成一个文件时先把第一个填写的html隐藏，
	                            //完成一个后就生成一个html的div，是收缩的放在下面，把标题放到里面，并且给这个div的id赋予一个新值，放置一个展开的标记
	                            //点击展开标记时，把隐藏的div复制一份放到该div中
	                            var filename = fileObj.name.substring(0, fileObj.name.lastIndexOf("."));

	                            $("#hiddendiv").hide();
	                            var liid = "li" + ID;
	                            var divid = "div" + ID;
	                            var divid2 = "div2" + ID;
	                            var dochiddenid = "hidden" + ID;
	                            //$("#oncehiddendiv").find(".zk").attr("onclick", "ss(\"" + ID + "\")");
	                            var spanclass = $("#span" + ID).attr("class");

	                            var documenthtml = $("#hiddendiv").html();
	                            var docidhidden = "<input id=\"" + dochiddenid + "\"  type='hidden' class='hiddendocidclass' value=\"" + response + "\" />";
	                            var html = "<li id=\"" + liid + "\"><div id=\"" + divid2 + "\"><span class=\"" + spanclass + "\"></span><a href='javascript:void(0)' onclick='javascript:zk(\"" + ID + "\",\"" + filename + "\");'>" + filename + "</a><p><span class='zk' onclick='javascript:zk(\"" + ID + "\",\"" + filename + "\");'>展开</span></p></div>" + documenthtml + "</li>";


	                            //把文档单行和多行放进去
	                            $("#listul").append(html);
	                            //alert(html);
	                            //alert($("#listul").html());
	                            //alert($("#listul").find("#oncehiddendiv").attr("ID"));
	                            //$("#listul").append(docidhidden);
	                            $("#listul").find("#oncehiddendiv").hide();
	                            $("#listul").find("#oncehiddendiv").append(docidhidden);
	                            $("#listul").find("#oncehiddendiv").find(".documentname").val(filename);
	                            alert("UploadFiles/" + response);
	                            alert($("#listul").find("#oncehiddendiv").find(".uploadimg"));
	                            $("#listul").find("#oncehiddendiv").find(".uploadimg").attr("src", "/UploadFiles/" + $("#userid_hidden").val()+"/" + response);
	                            $("#listul").find("#oncehiddendiv").find(".zk").click(function () { ssdiv("" + ID + ""); }); //.attr("onclick", "javascript:ssdiv(\'" + ID + "\');");
	                            $("#listul").find("#oncehiddendiv").find(".mainselectclass").change(function () { changeselect(ID, this.options[this.options.selectedIndex].value) });
	                            //alert($("#listul").find("#oncehiddendiv").attr("ID"));
	                            //alert($("#listul").find("#oncehiddendiv").attr("ID"));
	                            //alert(divid);

	                            $("#listul").find("#oncehiddendiv").attr("id", divid);
	                        }



	                    }
	                });
	                if (typeof (settings.onAllComplete) == 'function') {
	                    jQuery(this).bind("uploadifyAllComplete", { 'action': settings.onAllComplete }, function (event, data) {
	                        $("#msg").text("所有文档上传完毕，请填写下方的文档信息");
	                        //$("#successmsg").text("上传成功:" + data.filesUploaded + "份");

	                        //生成html流程，
	                        //如果文档数大于1，则生成一起填写模式的html，点击该链接，将把隐藏的一起填写的div放到该div的首部。
	                        if (data.filesUploaded > 1) {

	                            var batchp = document.getElementById("batchp");
	                            if (batchp == null) {
	                                //var batchhtml = "<p class='upload-tip' id='batchp'>为了方便资料被更多用户浏览和下载,请耐心补充以下信息.如果您上传提一系列文件,可以<a href='#' onclick='javascript:batch();'>一起填写信息</a></p>";
	                                //$("#documentmsg").prepend(batchhtml);

	                                //生成全部展开的按钮，点击该按钮时切换成全部收缩按钮。
	                                var qbzk = "<span class='zk' id='qbzk' onclick='javascript:qbzk();'>全部展开</span>";
	                                $("#writedocdiv").append(qbzk);
	                            }

	                        }
	                        else {
	                            //自动把单个div展开，并且隐藏收缩按钮
	                            $("#listul").find(".form-ed").each(function () {
	                                var divid = $(this).attr("id");
	                                var newdivid = divid.substring(3);
	                                $("#div" + newdivid).show();
	                                $("#div2" + newdivid).hide();
	                                $(this).find(".zk").hide();
	                            });


	                        }
	                        var buttonhtml = "<div class='form-btn'><button onclick='submitdocuments()'></button></div>";






	                        $("#documentmsg").append(buttonhtml);

	                        if (event.data.action(event, data) !== false) {
	                            errorArray = [];
	                        }
	                    });
	                }
	            });
	        },
	        uploadifySettings: function (settingName, settingValue, resetObject) {
	            var returnValue = false;
	            jQuery(this).each(function () {
	                if (settingName == 'scriptData' && settingValue != null) {
	                    if (resetObject) {
	                        var scriptData = settingValue;
	                    } else {
	                        var scriptData = jQuery.extend(jQuery(this).data('settings').scriptData, settingValue);
	                    }
	                    var scriptDataString = '';
	                    for (var name in scriptData) {
	                        scriptDataString += '&' + name + '=' + scriptData[name];
	                    }
	                    settingValue = escape(scriptDataString.substr(1));
	                }
	                returnValue = document.getElementById(jQuery(this).attr('id') + 'Uploader').updateSettings(settingName, settingValue);
	            });
	            if (settingValue == null) {
	                if (settingName == 'scriptData') {
	                    var returnSplit = unescape(returnValue).split('&');
	                    var returnObj = new Object();
	                    for (var i = 0; i < returnSplit.length; i++) {
	                        var iSplit = returnSplit[i].split('=');
	                        returnObj[iSplit[0]] = iSplit[1];
	                    }
	                    returnValue = returnObj;
	                }
	            }
	            return returnValue;
	        },
	        uploadifyUpload: function (ID, checkComplete) {
	            jQuery(this).each(function () {
	                if (!checkComplete) checkComplete = false;
	                document.getElementById(jQuery(this).attr('id') + 'Uploader').startFileUpload(ID, checkComplete);
	            });
	        },
	        uploadifyCancel: function (ID) {
	            jQuery(this).each(function () {
	                document.getElementById(jQuery(this).attr('id') + 'Uploader').cancelFileUpload(ID, true, true, false);
	            });
	        },
	        uploadifyClearQueue: function () {
	            jQuery(this).each(function () {
	                document.getElementById(jQuery(this).attr('id') + 'Uploader').clearFileUploadQueue(false);
	            });
	        }
	    })
	})(jQuery);