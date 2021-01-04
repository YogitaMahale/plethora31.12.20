var datatable;
$(document).ready(function () {


    loadtable();
});

function loadtable() {
    datatable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/BusinessDetails/GetALL"
            // "type": "GET",
            //"datatype": "json"
        },
        "columns": [
            { "data": "companyName", "width": "20% " },
            { "data": "name", "width": "20% " },
            { "data": "phoneNumber", "width": "10%" },
            { "data": "gstno", "width": "10%" },
            { "data": "website", "width": "10%" },
            
            

            //---------------------------------
            {
                "data": {
                    id: "id"
                },
                "render": function (data) {                  
                   
                        return `
<div class="text-center">
                

  <a class="btn btn-primary btn-sm mb-1" data-toggle="tooltip" data-original-title="View" href="/Admin/BusinessDetails/Edit/${data.id}" >
                                                <i class="fa fa-edit">
                                                </i>
                                            </a>
  <a class="btn btn-danger btn-sm mb-1" data-toggle="tooltip" data-original-title="View" href="/Admin/BusinessDetails/Delete/${data.id}" >
                                                 <i class="fa fa-trash-o">

                                                </i>
                                            </a>
                                                                      

   
</div>`



                   




                }, "width": "30%"

            }

        ]
        , "bDestroy": true
    });
}
 

  //<a class="btn btn-primary btn-sm mb-1" data-toggle="tooltip" data-original-title="View" href="/Admin/User/Edit/${data.id}" >
  //                                              <i class="fa fa-edit">
  //                                              </i>
  //                                          </a>
  //                                          <a class="btn btn-danger btn-sm text-white mb-1" data-toggle="tooltip" data-original-title="Delete" 
  //                                              style="cursor:pointer" onclick=Delete("/Admin/User/Delete/${data.id}")>
  //                                              <i class="fa fa-trash-o">

  //                                              </i>
