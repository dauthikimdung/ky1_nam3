﻿var user = {
    init: function () {
        user.regEvents();
    },
    regEvents: function () {
        $('.btn-active').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            $.ajax({
                url: "/admins/New/ChangeStatus",
                data: { id: id },
                dataType: "json",
                type: "POST",

                success: function (response) {
                    console.log(response);
                    if (response.status === true) {
                        btn.text("kích hoạt");
                    }
                    else {
                        btn.text("khóa");
                    }

                }
            });

        })
        //Xóa 
        $('.btn-deleteNew').off('click').on('click', function (e) {
            var conf = confirm('Bạn có muốn xóa ??');
            if (conf == false)
                return;
            e.preventDefault();
            var btn = $(this);
            var id = $(this).data('id');
            $.ajax({
                url: "/New/Delete",
                data: { id: id },
                dataType: "json",
                type: "POST",
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/admins/New/Index";
                        alert('Xóa thành công!!');
                    }
                    else {
                        window.location.href = "/admins/New/Index";
                        alert('Xóa không thành công!');
                    }
                }
            });
        })
        $("#txtKeyword").autocomplete({
            minLength: 0,
            source: function (request, response) {
                $.ajax({
                    url: "/New/ListName",
                    dataType: "json",
                    data: {
                        q: request.term
                    },
                    success: function (res) {
                        response(res.data);
                    }
                });
            },
            focus: function (event, ui) {
                $("#txtKeyword").val(ui.item.label);
                return false;
            },
            select: function (event, ui) {
                $("#txtKeyword").val(ui.item.label);
                return false;
            }
        })
            .autocomplete("instance")._renderItem = function (ul, item) {
                return $("<li>")
                    .append("<a>" + item.label + "</a>")
                    .appendTo(ul);
            };
    }
}
user.init();