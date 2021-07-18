let tran = {
    init: function () {
        tran.registerEvent();
    },
    registerEvent: function () {
        tran.printClick();
    },

    getWaitBill: function () {
        $.ajax({
            url: '/Admin/Transaction/GetWaitBills',
            get: 'GET',
            datatype: 'json',
        }).done(function (response) {
            if (response) {
                $('#renderBody').html(response);
            }
        })
    },

    printClick: function () {
        $('.btnPrint').click(function () {
            let url = '/Admin/Transaction/Print/' + $(this).data("id");
            window.open(url, '_blank');
        })
    },
}
tran.init();