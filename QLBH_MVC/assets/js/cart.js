/* 
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */


window.onload = function () {
    var tfrow = document.getElementById('tfhover').rows.length;
    var tbRow = [];
    for (var i = 1; i < tfrow; i++) {
        tbRow[i] = document.getElementById('tfhover').rows[i];
        tbRow[i].onmouseover = function () {
            this.style.backgroundColor = '#f3f8aa';
        };
        tbRow[i].onmouseout = function () {
            this.style.backgroundColor = '#ffffff';
        };
    }
};

