var dataTable;

$(document).ready(function () {
    LoadDataTable();
});


function LoadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/Admin/Product/getall' },
        "columns": [
            {
                data: 'imageUrl',
                "render": function (data) {
                    return `<img src="${data}" alt="Product Image" width="50" height="50" class="img-thumbnail"/>`;
                },
             "width": "10%" },
            { data: 'title', "width": "25%" },
            { data: 'isbn', "width": "10%" },
            { data: 'listPrice', "width": "10%" },
            { data: 'author', "width": "20%" },
            { data: 'category.name', "width": "10%" },
            {
                data: 'proId',
                "render": function (data) {
                    return `  <div class="w-75 btn-group" role="group" role="group" > 
                    <a href="/admin/product/upsert?id=${data}" class="btn btn-primary mx-2">
                                        <i class="bi bi-pencil-square"></i>Edit
                                    </a>
                                    <a onClick=Delete('/admin/product/delete/${data}')  class="btn btn-danger mx-2">
                                        <i class="bi bi-trash"></i>Delete
                                    </a>
                   </div>`
                },
                "width": "25%"
            }


        ]
    });
}

function Delete(url) {
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    dataTable.ajax.reload();
                    toastr.success(data.message)

                }
            });
        }
    });
}
