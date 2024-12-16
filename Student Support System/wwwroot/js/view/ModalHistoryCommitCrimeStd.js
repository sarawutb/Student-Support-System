function initializeDataTableWithChildRows(elementId) {
    const selector = "#" + elementId;
    const table = $(selector).DataTable();

    $(selector).on('click', '.btn-delete', function () {
        //const row = $(this).closest('tr');
        //table.row(row).remove().draw(false);

        //const row = table.row($(selector + ' tbody tr:eq(1)'));
        //row.remove().draw(false);

    });
    //let lastOpenedRow = null;

    //$(selector).on("click", ".view-details", function () {
    //    const tr = $(this).closest("tr");
    //    const row = table.row(tr);

    //    const jsonData = tr.data("row");
    //    if (!jsonData) {
    //        console.error("No data found for row");
    //        return;
    //    }

    //    if (row.child.isShown()) {
    //        row.child.hide();
    //        tr.removeClass("shown");
    //        lastOpenedRow = null;
    //    } else {
    //        if (lastOpenedRow && lastOpenedRow !== row) {
    //            lastOpenedRow.child.hide();
    //            $(lastOpenedRow.node()).removeClass("shown");
    //        }

    //        const html = formatChildRow(jsonData);
    //        row.child(html).show();
    //        tr.addClass("shown");
    //        lastOpenedRow = row;
    //    }
    //});

    //function formatChildRow(jsonData) {
    //    if (!jsonData || jsonData.length === 0) {
    //        return '<div>No details available</div>';
    //    }
    //    let html = `<div class="form-row ml-5"><div class="row form-group col-9">`;
    //    jsonData.forEach(e => {
    //        html += `<div class="form-check col-3 mb-2">
    //                    <input checked type="checkbox" disabled class="form-check-input">
    //                    <label class="form-check-label"><b>${e.CheckListName}</b></label>
    //                </div>`;
    //    });
    //    html += `</div></div>`;
    //    return html;
    //}

}

function showPdfInNewTab(base64Data, fileName) {
    let pdfWindow = window.open("");
    pdfWindow.document.write("<iframe width='100%' height='100%' src='data:application/pdf;base64," + base64Data + "'></iframe>");

    //pdfWindow.document.write("<html<head><title>" + fileName + "</title><style>body{margin: 0px;}</style></head>");
    //pdfWindow.document.write("<body><embed width='100%' height='100%' src='data:application/pdf;base64, " + encodeURI(base64Data) + "#toolbar=0&navpanes=0&scrollbar=0'></embed></body></html>");
    //pdfWindow.document.close();
}
