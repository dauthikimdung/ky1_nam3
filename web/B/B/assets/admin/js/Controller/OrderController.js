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
                url: "/admins/Order/ChangeStatus",
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
        $('.btn-deleteOrder').off('click').on('click', function (e) {
            var conf = confirm('Bạn có muốn xóa sách  này??');
            if (conf == false)
                return;
            e.preventDefault();
            var btn = $(this);
            var id = $(this).data('id');
            $.ajax({
                url: "/Order/Delete",
                data: { id: id },
                dataType: "json",
                type: "POST",
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/admins/Order/Index";
                        alert('Xóa thành công!!');
                    }
                    else {
                        window.location.href = "/admins/Order/Index";
                        alert('Xóa không thành công!');
                    }
                }
            });
        });
       
    }
}
user.init();