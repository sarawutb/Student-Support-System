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
                $('#' + table).DataTable().clear().destroy();
            }
        resolve();
    });
}

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
    $(elementId).modal('hide');
    $('.modal-backdrop').remove();
}

function UnCheckBoxModalAddCommitCrimeStd(className) {
    const checkboxes = document.querySelectorAll('.' + className);
    checkboxes.forEach(checkbox => checkbox.checked = false);
}
