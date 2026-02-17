var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/book",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "name", "width": "20%" },
            { "data": "author", "width": "20%" },
            { "data": "isbn", "width": "20%" },
            {   
                "data": "id",
                "render": function (data) {
                    return `    
                        <div class="text-center">
                            <a href="/BookList/Edit?id=${data}" class="btn btn-success text-white" style="cursor:pointer; width:70px;">
                                Edit
                                </a>
                                &nbsp;
                                <a  class="btn btn-danger text-white" style="cursor:pointer; width:70px;"
                                onclick="Delete(${data})">
                                Delete
                                </a>
                                </div>
                                `;
                }, "width": "30%"
            }
        ],
        "language": {
            "emptyTable": "No data found."
        },
        "width": "100%"
    });
}
function Delete(id) {
    swal({
        title: "Are you sure you want to delete?",
        text: "You will not be able to restore the data!",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: "/api/book?id=" + id,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}
