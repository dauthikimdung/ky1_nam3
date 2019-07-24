function check(id) {
    var x = document.getElementById(id).value;
    var er_x = document.getElementById(`er_${id}`);
    if (x==null || x.length == 0 ) {
        er_x.classList.remove("o-0");
    }
    else if (!er_x.classList.contains("o-0")) // neu khong co thi them, co thi thoi
        er_x.classList.add("o-0");
}
// var pattern =/^([0-9]{2})\/([0-9]{2})\/([0-9]{4})$/;