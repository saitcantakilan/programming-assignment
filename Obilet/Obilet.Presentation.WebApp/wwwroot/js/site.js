let calendar;
$(document).ready(function () {
    $('.obilet-select').select2({
        ajax: {
            url: "Home/GetBusLocationList",
            dataType: 'json',
            delay: 250,
            data: function (params) {
                return {
                    search: params.term,
                };
            },
            processResults: function (data, params) {
                return {
                    results: $.map(data, function (item) {
                        return {
                            id: item.value,
                            text: item.text,
                        };
                    })
                };
            },
            cache: true,
            allowHtml: true,
            allowClear: true
        },
        language: "tr",
        placeholder: 'İl veya ilçe adı yazın',
        minimumInputLength: 3,
    });

    calendar = $('#DepartureDate').flatpickr({
        altInput: true,
        locale: "tr",
        allowInput: false,
        altFormat: "d F Y l",
        dateFormat: "Y-m-d",
    });

});

$('#todayButton').click(function () {
    let today = moment(Date.now()).format('Y-M-D');
    calendar.setDate(today);
    if (!$('#todayButton').hasClass("btn-secondary")) {
        $('#todayButton').addClass("btn-secondary")
        $('#todayButton').removeClass("btn-outline-secondary")

        if ($('#tomorrowButton').hasClass("btn-secondary"))
            $('#tomorrowButton').removeClass("btn-secondary")

        if (!$('#tomorrowButton').hasClass("btn-outline-secondary"))
            $('#tomorrowButton').addClass("btn-outline-secondary")

    }
});
$('#tomorrowButton').click(function () {
    let tomorrow = moment(Date.now()).add(1, 'days').format('Y-M-D');
    calendar.setDate(tomorrow);
    if (!$('#tomorrowButton').hasClass("btn-secondary")) {
        $('#tomorrowButton').addClass("btn-secondary")
        $('#tomorrowButton').removeClass("btn-outline-secondary")


        if ($('#todayButton').hasClass("btn-secondary"))
            $('#todayButton').removeClass("btn-secondary")

        if (!$('#todayButton').hasClass("btn-outline-secondary"))
            $('#todayButton').addClass("btn-outline-secondary")


    }
});

$('#locationSwap').click(function () {
    var origin = $('#OriginId').val();
    var destination = $('#DestinationId').val();

    $('#OriginId').val(destination).trigger('change');
    $('#DestinationId').val(origin).trigger('change');
});

$('#goBack').click(function (event) {
    event.preventDefault();
    window.history.back();
});
