var TemplateLoading = `<div style="overflow-y:hidden">
                          <div class="sk-three-bounce" style="background-color:transparent;margin-top:35px">
                              <div class="sk-child sk-bounce1"></div>
                              <div class="sk-child sk-bounce2"></div>
                              <div class="sk-child sk-bounce3"></div>
                          </div>
                      </div>`;

function LoadingShow() {
    Swal.fire({
        html: TemplateLoading,
        timerProgressBar: false,
        showCancelButton: false,
        showConfirmButton: false,
        allowOutsideClick: false
    });
    SetBackgroundColorTransparent();
}

function LoadingHide() {
    Swal.close();
}

function SetBackgroundColorTransparent() {
    $(".swal2-modal").css('background-color', 'rgba(100, 100, 100, 0)');
    $(".swal2-container.in").css('background-color', ' rgba(100, 100, 100, 0.5)')
}