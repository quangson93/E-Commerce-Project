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
    var MKCu = $("#txtMKCu").val();
    if (MKCu.length === 0) {
        alert("Mật khẩu không được để trống!!!");
        return false;
    }
    else if (document.frmReg.txtMKMoi.value !== document.frmReg.txtNLMK.value)
    {
        alert("Mật khẩu không trùng nhau!!!");
        return false;
    }
    else if(document.frmReg.txtHoTen.value === '')
    {
        alert("Họ tên không được để trống.");
    }
    var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
    var emailaddressVal = $("#txtEmail").val();
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

