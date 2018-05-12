var document = {
    init: function () {
        document.registerEvents();
    },
    registerEvents: function () {
        $('.btn-active').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            $.ajax({
                url: "/Admin/MDocument/StatusKD",
                data: { id: id },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    console.log(response);
                    if (response.status == true) {
                        btn.text("Kiểm duyệt");
                    }
                    else {
                        btn.text('OK');
                    }
                }
            });
        });
    }
}