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