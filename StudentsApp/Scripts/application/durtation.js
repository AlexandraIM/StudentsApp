$(document).ready(function () {
    $("#courseEndDate").on('change', function () {
        $('#durtation').val($(this).val() - $("#courseStartDate").val());
    });


    $("#courseEndDate").datepicker({
        beforeShowDay: $.datepicker.noWeekends,
        onSelect: function (date) {
            console.log(date);
            var date1 = new Date(date);
            var date2 = new Date($("#courseStartDate").val());
            var timeDiff = Math.abs(date2.getTime() - date1.getTime());
            var diffDays = Math.ceil((timeDiff / (1000 * 3600 * 24))/7); 
            $('#durtation').val(diffDays);
        }
    });

    $("#courseStartDate").datepicker({
        beforeShowDay: $.datepicker.noWeekends
    });

    $("#holidayStartDate").datepicker({
        beforeShowDay: $.datepicker.noWeekends
    });
    $("#holidayEndDate").datepicker({
        beforeShowDay: $.datepicker.noWeekends,
        onSelect: function (date) {
            console.log(date);
            var date1 = new Date(date);
            var date2 = new Date($("#holidayStartDate").val());
            var timeDiff = Math.abs(date2.getTime() - date1.getTime());
            var diffDays = Math.ceil((timeDiff / (1000 * 3600 * 24)) / 7);
            $('#durtation').val(+$('#durtation').val() + diffDays);
        }
    });
});