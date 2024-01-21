function AddDataTable(table) {
    $(document).ready(function () {
        $(table).DataTable({
            "columnDefs": [
                {
                    "targets": -1,  // Target the action column
                    "width": "150px"  // Adjust the width of the action column
                }
            ]
        });
    })
}
function DataTablesDispose(table) {
    $(document).ready(function () {
        $(table).DataTable().destroy();
        var element = document.querySelector(table + '_wrapper');
        element.parentNode.removeChild(element);
    })
}


