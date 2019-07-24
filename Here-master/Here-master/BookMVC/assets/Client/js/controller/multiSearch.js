// Tự động bỏ chọn các ô còn lại
function autouncheck(type) {
     var type_class = '.checkbox-' + type;
     $(type_class).change(function () {
          if ($(this).prop('checked')) {
               $(type_class).prop('checked', false);
          }
          $(this).prop('checked', true);
          var ID = $(this).data('id');
          var input = '#select_' + type;
          $(input).val(ID);
     });
}
// Bỏ chọn
function uncheckall(type) {
     var btn = '#clear-' + type;
     $(btn).on('click', function () {
          var type_class = '.checkbox-' + type;
          $(type_class).prop('checked', false);
          var input = '#select_' + type;
          $(input).val('0');
     });
}
// Lấy khung giá
function getprice(type) {
     var box = "#input_" + type;
     $(box).on('keyup click', function () {
          var badge = '#badge_' + type;
          var price = $(this).val();
          var input = '#' + type;
          $(input).val(price);
          if (price == "") price = 0;
          $.ajax({
               url: '/ChangeForView/Currency',
               method: 'Post',
               data: { value: price },
               dataType: 'json',
               success: function (r) {
                    $(badge).text(r);
               }
          });
     });
}
$(document).ready(function () {
     // auto uncheck
     autouncheck('author');
     autouncheck('bookcate');
     uncheckall('author');
     uncheckall('bookcate');
     getprice('lowprice');
     getprice('highprice');

     $('input[type="date"]').on('click blur', function () {
          var date = $(this).val();
          if (new Date(date) < new Date("1800-01-01")) {
               date = "1800-01-01";
               $(this).val(date);
          }
          else if (new Date(date) > new Date("2020-01-01")) {
               date = "2020-01-01";
               $(this).val(date);
          }
          $("#publishdate").val(date);
     });
     $('#clear_date').off('click').on('click', function (e) {
          e.preventDefault();
          $('input[type="date"]').val("");
          $("#publishdate").val("");
     });
     $('#clear_price').off('click').on('click', function (e) {
          e.preventDefault();
          $('#input_lowprice').val('');
          $('#badge_lowprice').text('0');
          $('#lowprice').val('0');
          $('#input_highprice').val('');
          $('#badge_highprice').text('0');
          $('#highprice').val('0');
     });
     $('#apply').off('click').on('click', function (e) {
          e.preventDefault();
          var form = $('form#filter').serialize();
          $.ajax({
               url: '/BookBy/Filtered',
               method: 'POST',
               data: form,
               dataType: "html",
               success: function (r) {
                    $('#here').html(r);
               }
          });
     });
});