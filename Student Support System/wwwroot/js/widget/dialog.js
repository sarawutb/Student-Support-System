﻿var _title = "แจ้งเตือนระบบ";
var _confirmButtonText = "ตกลง";
var _cancelButtonText = "ไม่";
function DialogYesOrNo(msg) {
    return new Promise((resolve) => {
        Swal.fire({
            title: _title,
            text: msg,
            icon: 'question',
            showCancelButton: true,
            allowOutsideClick: false,
            allowEscapeKey: true,
            confirmButtonColor: "#4425cb",
            cancelButtonColor: "#d33",
            confirmButtonText: _confirmButtonText,
            cancelButtonText: _cancelButtonText,
            reverseButtons: false,
        }).then((result) => {
            if (result.isConfirmed) {
                resolve(true);
            } else {
                resolve(false);
            }
        });
    });
}
function DialogError(msgError) {
    return new Promise((resolve) => {
        Swal.fire({
            icon: "error",
            title: _title,
            text: msgError,
            showCancelButton: false,
            confirmButtonColor: "#4425cb",
            confirmButtonText: _confirmButtonText,
            customClass: {
                popup: 'custom-swal'
            }
        }).then((result) => {
            if (result.isConfirmed) {
                resolve();
            } else {
                resolve();
            }
        });
    });
}
function DialogInfoAsync(msg) {
    return new Promise((resolve) => {
        Swal.fire({
            icon: "info",
            title: _title,
            text: msg,
            showCancelButton: false,
            confirmButtonColor: "#4425cb",
            confirmButtonText: _confirmButtonText
        }).then((result) => {
            if (result.isConfirmed) {
                resolve();
            } else {
                resolve();
            }
        });
    });
}
function DialogWarningAsync(msg) {
    return new Promise((resolve) => {
        Swal.fire({
            icon: "warning",
            title: _title,
            text: msg,
            showCancelButton: false,
            confirmButtonColor: "#4425cb",
            confirmButtonText: _confirmButtonText
        }).then((result) => {
            if (result.isConfirmed) {
                resolve();
            } else {
                resolve();
            }
        });
    });
}
function DialogSuccessAsync(msg) {
    return new Promise((resolve) => {
        Swal.fire({
            icon: "success",
            title: _title,
            text: msg,
            showCancelButton: false,
            confirmButtonColor: "#4425cb",
            confirmButtonText: _confirmButtonText
        }).then((result) => {
            if (result.isConfirmed) {
                resolve();
            } else {
                resolve();
            }
        });
    });
}
function DialogSuccess(msg) {
    Swal.fire({
        icon: "success",
        title: _title,
        text: msg,
        showCancelButton: false,
        confirmButtonColor: "#4425cb",
        confirmButtonText: _confirmButtonText
    });
}
function DialogInfo(msg) {
    Swal.fire({
        icon: "info",
        title: _title,
        text: msg,
        showCancelButton: false,
        confirmButtonColor: "#4425cb",
        confirmButtonText: _confirmButtonText
    });
}
function DialogWarning(msg) {
    Swal.fire({
        icon: "warning",
        title: _title,
        text: msg,
        showCancelButton: false,
        confirmButtonColor: "#4425cb",
        confirmButtonText: _confirmButtonText
    });
}