////function CreateDataTable(element) {
////    return new Promise((resolve) => {
////        $(document).ready(function () {
////            // Check if DataTable is already initialized on this element
////            if ($.fn.DataTable.isDataTable('#' + element)) {
////                // If initialized, destroy the existing DataTable instance
////                $('#' + element).DataTable().clear().destroy();
////            }

////            // Initialize or reinitialize the DataTable
////            $('#' + element).DataTable();

////            // Resolve the promise when complete
////            resolve();
////        });
////    });
////}

//function DataTablesAdd(table) {
//    return new Promise((resolve) => {
//        if (!$.fn.DataTable.isDataTable('#' + table)) {
//            $('#' + table).DataTable();
//        }
//        resolve();
//    });
//}

//function DataTablesRemove(table) {
//    return new Promise((resolve) => {
//        if ($.fn.DataTable.isDataTable('#' + table)) {
//            $('#' + table).DataTable().clear().destroy();
//        }
//        resolve();
//    });
//}

