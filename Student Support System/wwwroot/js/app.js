function DataTablesAdd(table) {
    return new Promise((resolve) => {
        if ($.fn.DataTable != undefined)
            if (!$.fn.DataTable?.isDataTable('#' + table)) {
                $('#' + table).DataTable();
            }
        resolve();
    });
}

function DataTablesRemove(table) {
    return new Promise((resolve) => {
        if ($.fn.DataTable != undefined)
            if ($.fn.DataTable.isDataTable('#' + table)) {
                $('#' + table).DataTable().destroy();
            }
        resolve();
    });
}

$(document).on('hidden.bs.modal', function () {
    $('.modal-backdrop').remove();
});

function CloseModalByClassName(className) {
    if (!className.includes(".")) {
        className = "." + className;
    }
    $(className).modal('hide');
    $('.modal-backdrop').remove();
}

function CloseModalById(elementId) {
    if (!elementId.includes("#")) {
        elementId = "#" + elementId;
    }
    document.querySelector(elementId).click();
}

function OpenModalById(elementId) {
    if (!elementId.includes("#")) {
        elementId = "#" + elementId;
    }
    $(elementId).modal('show');
}

function UnCheckBoxModalAddCommitCrimeStd(className) {
    const checkboxes = document.querySelectorAll('.' + className);
    checkboxes.forEach(checkbox => checkbox.checked = false);
}

const unitQtyInput = document.getElementById('unit-qty');
if (unitQtyInput != undefined) {
    unitQtyInput.addEventListener('input', function () {
        if (this.value < 1) {
            this.value = 1;
        } else if (this.value >= 3)
            this.value = 3;

    });
}

function triggerClickByClass(btnClass) {
    const button = document.querySelector(`.${btnClass}`);
    if (button) {
        button.click();
    }
};

function triggerClickById(btnId) {
    const button = document.querySelector(`#${btnId}`);
    if (button) {
        button.click();
    }
};
