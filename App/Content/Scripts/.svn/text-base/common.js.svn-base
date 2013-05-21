//开始结束的计时器js
//时间间隔
var interval = 1000;
//now 当前时间 startDate 开始时间 endDate 结束时间
function getTimerHtml(now, startDate, start, endDate, isShowBeginText) {
//    if (now >= startDate && now <= endDate) {
//        return ""
//    }
    var leftTime = endDate - now - start;
    var leftsecond = parseInt(leftTime / 1000);
    var day1 = Math.floor(leftsecond / (60 * 60 * 24));
    var hour = Math.floor((leftsecond - day1 * 24 * 60 * 60) / 3600);
    var minute = Math.floor((leftsecond - day1 * 24 * 60 * 60 - hour * 3600) / 60);
    var second = Math.floor(leftsecond - day1 * 24 * 60 * 60 - hour * 3600 - minute * 60);
    //        start += interval;
    if (leftTime > 0) {
        return (isShowBeginText == 1 ? "<span>剩余时间：</span><p>" : "") + "<em>" + day1 + "</em>天<em>" + hour + "</em>小时<em>" + minute + "</em>分<em>" + second + "</em>秒</p>";
    }
    else {
        return "该期任务已经结束";
    }
}
function timer() {
    $(".J_juItemTimer").each(function () {

        $(this).html(getTimerHtml($(this).attr("data-servertime"), $(this).attr("data-targettime"), parseInt($(this).attr("data-start")), $(this).attr("data-endtime"), $(this).attr("data-isShowBeginText")));
        //每个倒计时显示 都要有独立的倒计时计数器
        $(this).attr("data-start", parseInt($(this).attr("data-start")) + interval);

    })
    setTimeout("timer()", interval);
}