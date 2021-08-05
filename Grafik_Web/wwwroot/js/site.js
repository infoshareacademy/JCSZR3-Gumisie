// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

var dateAsObject;
var month = "Jul";
var year;
$(document).ready(function () {
    var dt = new Date();
    $('#todayIs tr').eq(dt.getDate() - 1).css("background-image", "linear-gradient(to right top, #ffffff, #deddeb, #bcbbd8, #989cc5, #727eb3, #5c79b1, #3f75af, #0071ab, #0082b1, #0092b1, #00a0ad, #21aea5)");
    $('#todayIs tr').eq(dt.getDate() - 1).css("color", "white");

    var month = document.getElementById("hidMonth").value;
    var year = document.getElementById("hidYear").value;


    $("#setDateForTimeSheet").datepicker({
        changeMonth: true,
        changeYear: true,
        changeDay: false,
        showButtonPanel: true,
        dateFormat: 'mm-yyyy',
        onClose: function (dateText, inst) {
            dateAsObject = $(this).datepicker('getDate'); //the getDate method
            document.getElementById("hidMonth").value = $("#ui-datepicker-div .ui-datepicker-month :selected").val();
            document.getElementById("hidYear").value = $("#ui-datepicker-div .ui-datepicker-year :selected").val();
        }
    });
    document.getElementById("hidTest").value = month;
})

var totalHours = [],
    totalMinutes = [];
var getTotalHours,
    getTotalMinutes;

function calculateTime(i) {
    var valuestart = $("#timeStart_" + i).val(),
        valuestop = $("#timeFinish_" + i).val();
    if (valuestart && valuestop) {
        var timeStart = new Date("01/01/2007 " + valuestart).getTime(),
            timeEnd = new Date("01/01/2007 " + valuestop).getTime(),
            timeDiff = new Date(timeEnd - timeStart),
            dateZero = new Date(0),
            getHours = timeDiff.getHours() - dateZero.getHours();
        totalHours[i - 1] = getHours;
        var getMinutes = timeDiff.getMinutes() - dateZero.getMinutes();
        totalMinutes[i - 1] = getMinutes;
        getTotalHours = 0,
            getTotalMinutes = 0;
        for (var j = 0; j < totalHours.length; j++) {
            if (totalHours[j] == null) totalHours[j] = 0;
            if (totalMinutes[j] == null) totalMinutes[j] = 0;
            getTotalHours += totalHours[j];
            getTotalMinutes += totalMinutes[j];
            if (getTotalMinutes / 60 >= 1) {
                getTotalHours += 1;
                getTotalMinutes = getTotalMinutes % 60;
            }
        }
        $('#total_' + i).html(getHours + "h " + getMinutes + "min");
        $('#totalTime').html(getTotalHours + "h " + getTotalMinutes + "min");
    }
}

function SetTime() {
    var valueFTstart = $("#setFTFollowin").val(),
        valueLTstop = $("#setLTFollowin").val(),
        valueFDstart = new Date($("#setFDFollowin").val()),
        valueLDstop = new Date($("#setLDFollowin").val());
    valueShiftDetails = $("#shiftDetailsF").val();

    for (var d = valueFDstart; d <= valueLDstop; d.setDate(d.getDate() + 1)) {
        var j = d.getDate();
        if (!valueFTstart && !valueLTstop) deleteTimeInRow(j);
        if (valueFTstart && valueLTstop)
        {
            document.getElementById("timeStart_" + j).value = valueFTstart;
            document.getElementById("timeFinish_" + j).value = valueLTstop;
            calculateTime(j);
        }
            document.getElementById("shiftDetails_" + j).value = valueShiftDetails;
        isApply = false;
        document.querySelector('#remove_btn').classList.replace('btn-primary', 'btn-secondary');
        document.getElementById("newTimes").checked = false;
        document.getElementById("newDetails").checked = false;
        document.getElementById("setItAll").checked = false;
    }
}

function deleteTimeInRow(i) {
    getTotalHours -= totalHours[i - 1];
    getTotalMinutes -= totalMinutes[i - 1];
    if (getTotalMinutes < 0 && getTotalHours > 0) {
        getTotalHours -= 1;
        getTotalMinutes = 60 + getTotalMinutes;
    }
    if (getTotalMinutes < 0 && getTotalHours <= 0) {
        getTotalHours = 0;
        getTotalMinutes = 0;
    }
    totalMinutes[i - 1] = 0; totalHours[i - 1] = 0;
    $('#total_' + i).html(0 + "h " + 0 + "min");
    $('#totalTime').html(getTotalHours + "h " + getTotalMinutes + "min");
    document.getElementById("timeStart_" + i).value = null;
    document.getElementById("timeFinish_" + i).value = null;
}

function deleterow(i) {
    deleteTimeInRow(i);
    document.getElementById("shiftDetails_" + i).value = null;
}

$("#remove_btn").click(function () {
    if (isApply) {
        var valueFDstart = new Date($("#setFDFollowin").val()),
            valueLDstop = new Date($("#setLDFollowin").val());
        for (var d = valueFDstart; d <= valueLDstop; d.setDate(d.getDate() + 1)) {
            j = d.getDate();
            if (document.getElementById('newTimes').checked) {
                deleteTimeInRow(j);
            }
            if (document.getElementById('newDetails').checked) {
                document.getElementById("shiftDetails_" + j).value = null;
            }
        }
        isApply = false;
        $("#remove_btn").toggleClass('btn-primary btn-secondary');
        document.getElementById("newTimes").checked = false;
        document.getElementById("newDetails").checked = false;
        document.getElementById("setItAll").checked = false;
    }
});

var isApply = false;
function validate() {
    if (!isApply) {
        $("#remove_btn").toggleClass('btn-secondary btn-primary');
        if (document.getElementById('newTimes').checked) {
            document.getElementById("setFTFollowin").value = null;
            document.getElementById("setLTFollowin").value = null;
            isApply = true;
        }
        if (document.getElementById('newDetails').checked) {
            document.getElementById("shiftDetailsF").value = null;
            isApply = true;
        }
    }
    if (!document.getElementById('newTimes').checked && !document.getElementById('newDetails').checked) {
        if (isApply) $("#remove_btn").toggleClass('btn-primary btn-secondary');
        isApply = false;
    }
    if (!document.getElementById("newTimes").checked || !document.getElementById("newDetails").checked) {
        document.getElementById("setItAll").checked = false;
    }
}

$('[id="setItAll"]').change(function () {
    if ($(this).is(':checked')) {
        $("#newTimes").prop('checked', true);
        $("#newDetails").prop('checked', true);
        document.getElementById("setFTFollowin").value = null;
        document.getElementById("setLTFollowin").value = null;
        document.getElementById("shiftDetailsF").value = null;
        if (!isApply) {
            $("#remove_btn").toggleClass('btn-secondary btn-primary');
            isApply = true;
        }
    }
    else {
        $("#newTimes").prop('checked', false);
        $("#newDetails").prop('checked', false);
        if (isApply) {
            $("#remove_btn").toggleClass('btn-secondary btn-primary');
            isApply = false;
        }
    }
});

$('#addnext_btn').click(function () {
    var newel = $('#shift:last').clone();
    var panel = $('.panel:last').clone();
    $(newel).insertAfter("#shift:last");
    $(panel).insertAfter("#shift:last");
    $('.accordion:last').toggleClass("active");
});

var acc = document.getElementsByClassName("accordion");
for (var i = 0; i < acc.length; i++) {
    acc[i].addEventListener("click", function () {
        this.classList.toggle("active");
        var panel = this.nextElementSibling;
        if (panel.style.maxHeight) {
            panel.style.maxHeight = null;
        } else {
            panel.style.maxHeight = panel.scrollHeight + "px";
        }
    });
}


