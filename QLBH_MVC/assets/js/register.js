/* 
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
$(function () {
    $("#txtNgaySinh").datepicker(
            {
                dateFormat: "d/m/yy"
            }
    );
}
);
function KTra() {
    var tenDN = $("#txtTenDN").val();
    if (tenDN.length === 0) {
        alert("Tên đăng nhập không được để trống!!!");
        return false;
    }
    else if (document.frmReg.txtTenDN.value.length < 5)
    {
        alert("Tên đăng nhập phải lớn hơn 5 kí tự.");
        return false;
    }
    else if (document.frmReg.txtMK.value !== document.frmReg.txtNLMK.value)
    {
        alert("Mật khẩu không trùng nhau!!!");
        return false;
    }
    else if (document.frmReg.txtHoTen.value.length === 0)
    {
        alert("Họ tên không được để trống!!!")
        return false;
    }
    var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/; //định nghĩa đúng dạng email
    var emailaddressVal = $("#txtEmail").val(); //lấy giá trị ở ô txtEmail
    if (emailaddressVal === '') {
        alert("Email không được để trống.");
        return false;
    }
    else if (!emailReg.test(emailaddressVal)) {
        alert("Email không hợp lê.");
        return false;

    }
    return true;
}
function changeCaptcha() {
    var captcha = document.getElementById("imgCaptcha");
    captcha.src = "cool-php-captcha-0.3.1/captcha.php?" + Math.random();
}

