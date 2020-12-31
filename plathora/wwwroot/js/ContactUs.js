var datatable;
$(document).ready(function () {


    loadtable();
});

function loadtable() {
    datatable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/ContactUs/GetALL"
            // "type": "GET",
            //"datatype": "json"
        },
        "columns": [
            { "data": "name", "width": "20% " },

            { "data": "email", "width": "20%" },
            { "data": "mobileno", "width": "20%" },
            //{ "data": "company.name", "width": "15%" },
            { "data": "address", "width": "40%" }
//            {
//                "data": {
//                    id: "id", lockoutEnd: "lockoutEnd"
//                },
//                "render": function (data) {
//                    var today = new Date().getTime();
//                    var lockout = new Date(data.lockoutEnd).getTime();
//                    if (lockout > today) {
//                        return `
//<div class="text-center">

//    <a  class="btn btn-danger text-white" style="cursor:pointer" onclick=Lockunlock('${data.id}')>
//       <i class="fas fa-lock-open"></i> 
//    </a>

//<a href="/Admin/User/Edit/${data.id}" class="btn btn-sm btn-success text-white" style="cursor:pointer">
//    <i class="fas fa-edit"></i>
         
//    </a>

 
// <a  class="btn btn-danger text-white" style="cursor:pointer" onclick=Delete("/Admin/User/Delete/${data.id}")>
//        <i class="far fa-trash-alt"></i> 
//    </a>
//</div>`



//                    }
//                    else {
//                        return `
//<div class="text-center">

//    <a  class="btn btn-success text-white" style="cursor:pointer" onclick=Lockunlock('${data.id}')>
//       <i class="fas fa-lock"></i> 
//    </a>

//<a href="/Admin/User/Edit/${data.id}" class="btn btn-sm btn-success text-white" style="cursor:pointer">
//   <i class="fas fa-edit"></i>
         
//    </a>

 
//    <a  class="btn btn-danger text-white" style="cursor:pointer" onclick=Delete("/Admin/User/Delete/${data.id}")>
//        <i class="far fa-trash-alt"></i> 
//    </a>
//</div>`
//                    }




//                }, "width": "40%"

//            }

        ]
        , "bDestroy": true
    });
}
 

//function Delete(url) {
//    swal({
//        title: "Are you sure you want to delete?",
//        text: "You will not be able to restore the data",
//        icon: "warning",
//        buttons: true,
//        dangerMode: true

//    }).then((willDelete) => {
//        if (willDelete) {
//            $.ajax({
//                type: "DELETE",
//                url: url,
//                success: function (data) {
//                    if (data.success) {
//                        toastr.success(data.message);
//                      /*  dataTable.ajax.reload()*/;
//                        $('#tblData').DataTable().ajax.reload()
//                    }
//                    else {
//                        toastr.error(data.message);
//                    }
//                }
//            });
//        }


//    });

//} 
 