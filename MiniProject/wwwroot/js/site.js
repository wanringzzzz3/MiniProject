// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$("select.select2").select2();
function setBookingRoom(room) {
    if (!room.id) { return room.text; }
    var statusString = room.element.attributes[1].nodeValue;
    var icon = "success";
    var notav = "Not available";
    if (statusString.toLowerCase() == notav.toLowerCase()) {
        icon = "danger";
    } else if (statusString.toLowerCase() == 'provisional'){
        icon = "warning";
    }
    var $room = $('<span>' + room.text + ' <div class="Ellipse-2 ' + icon + '"></div> ' + statusString + '</span>' +
        '<br/><span class="description">' + room.element.attributes[2].nodeValue + '</span>');
    return $room;
}

function setBookingRoomText(room) {
    if (!room.id) { return room.text; }
    var statusString = room.element.attributes[1].nodeValue;
    var icon = "success";
    var notav = "Not available";
    if (statusString.toLowerCase() == notav.toLowerCase()) {
        icon = "danger";
    } else if (statusString.toLowerCase() == 'provisional') {
        icon = "warning";
    }
    var $room = $('<span>' + room.text + ' <div class="Ellipse-2 ' + icon + '"></div> ' + statusString + '</span>');
    return $room;
}

$(".select-room").select2({
    placeholder: "Which room?", //placeholder
    templateResult: setBookingRoom,
    templateSelection: setBookingRoomText,
    minimumResultsForSearch: -1
});

$(function () {
    $("body #StartTime").datetimepicker({ format: 'mm/dd/yyyy hh:ii' });
    $('body #EndTime').datetimepicker({
        format: 'mm/dd/yyyy hh:ii',
        useCurrent: false 
    });
    $("body #StartTime").on("change", function (e) {
        //$('#EndTime').data("DateTimePicker").minDate(e.date);
        LoadRoomList();

    });
    $("body #EndTime").on("change", function (e) {
        //$('#StartTime').data("DateTimePicker").maxDate(e.date);
        LoadRoomList();
    });
});

function LoadRoomList() {
    var $form = $("#add-booking");
    var fd = new FormData();
    var values = $form.serializeArray();
    for (var i in values) {
        fd.append(values[i].name, values[i].value);
    }

    var $selectRoom = $(".select-room-group");
    $.ajax({
        url: "/Booking/LoadRoomByDate",
        data: fd,
        processData: false,
        contentType: false,
        type: 'POST',
        success: function (d) {
            $selectRoom.html(d);
            $selectRoom.removeClass("loading");

            ////PagePluginLoad
            
            $(".select-room").select2({
                placeholder: "Which room?", //placeholder
                templateResult: setBookingRoom,
                templateSelection: setBookingRoomText,
                minimumResultsForSearch: -1
            });
        },
        error: function (xhr, textStatus, errorThrown) {
            console.log(xhr.responseText);
            alert('Có lỗi xảy ra, vui lòng thực hiện lại. Xin cảm ơn!');
        }
    });
}

$(function () {
    var url = window.location.href;
    
    $("#menu-content a").each(function () {
        if (url == (this.href)) {
            $(this).closest("li").addClass("active");
        }
    });
});


if ($("#filter-form").length > 0) {
    //reserve search result container
    var $container = $("#filter-form").closest(".ajax-search-group").find(".Search_Result");
    var $form = $("#filter-form");
    var url = $form.attr("action");

    function FilterForm() {

        var fd = new FormData();
        var values = $form.serializeArray();
        for (var i in values) {
            fd.append(values[i].name, values[i].value);
        }

        $container.addClass("loading");
        $.ajax({
            url: url,
            data: fd,
            processData: false,
            contentType: false,
            type: 'POST',
            success: function (d) {
                $container.html(d);
                $container.removeClass("loading");

                ////PagePluginLoad
                $("body #StartTime").datetimepicker({ format: 'mm/dd/yyyy hh:ii' });
                $('body #EndTime').datetimepicker({
                    format: 'mm/dd/yyyy hh:ii',
                    useCurrent: false 
                });
                
            },
            error: function (xhr, textStatus, errorThrown) {
                console.log(xhr.responseText);
                alert('Có lỗi xảy ra, vui lòng thực hiện lại. Xin cảm ơn!');
            }
        });
    };

    $("body").on("keyup", "input[name='searchName']", function () {
        FilterForm();
    });
    $("body").on("change", "select[name='roomId']", function () {
        FilterForm();
    });
}