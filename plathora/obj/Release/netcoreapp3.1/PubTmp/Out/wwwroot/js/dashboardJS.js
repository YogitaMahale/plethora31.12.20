var datatable;
$(document).ready(function () {


    loadtable();
    loadtableAffilateList();
});



function loadtable() {
    datatable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/Admindashboard/GetALLCustomer"
            
        },
        "columns": [
            { "data": "uniqueId", "width": "30% " },

            { "data": "name", "width": "10%" },
            { "data": "middleName", "width": "10%" },
            { "data": "lastName", "width": "10%" },
            { "data": "email", "width": "10%" },
            { "data": "phoneNumber", "width": "10%" },
            

        ]
        , "bDestroy": true
    });
}
function loadtableAffilateList() {
    datatable = $('#tblDataAffilate').DataTable({
        "ajax": {
            "url": "/Admin/Admindashboard/GetALLAffilate"

        },
        "columns": [
            { "data": "uniqueId", "width": "30% " },

            { "data": "name", "width": "10%" },
            { "data": "middleName", "width": "10%" },
            { "data": "lastName", "width": "10%" },
            { "data": "email", "width": "10%" },
            { "data": "phoneNumber", "width": "10%" },


        ]
        , "bDestroy": true
    });
}


//$(function (e) {
//	'use strict'
//	alert("barchart");


//	//var Customermarkers = $('#' + '@(ViewBag.Customermarkers)').val();
//	//var Affilatemarkers = $('#' + '@(ViewBag.Affilatemarkers)').val();
//	//var Labelsmarkers = $('#' + '@(ViewBag.Labelsmarkers)').val();
//	//alert(Customermarkers);

//	var Customermarkers = @Html.Raw(ViewBag.Customermarkers);
//	var Affilatemarkers = @Html.Raw(ViewBag.Affilatemarkers);
//	var Labelsmarkers = @Html.Raw(ViewBag.Labelsmarkers);
//	/* chartjs (#sales-status) */
	
//	alert(Customermarkers);

//	var ctx = $('#sales-status');
//	var myChart = new Chart(ctx, {
//		type: 'bar',
//		data: {
//			labels: ["P1-6", "p1-8", "p2-6"],
//			type: 'bar',
//			datasets: [{
//				label: "Customer Register",
//				data: [20000, 25000,50000],
//				backgroundColor: '#00148e',
//				borderColor: '#00148e',
//				borderWidth: 3,
//				pointStyle: 'circle',
//				pointRadius: 5,
//				pointBorderColor: 'transparent',
//				pointBackgroundColor: '#00148e',
//			}, {
//				label: "Affilate Register",
//				data: [25000, 32000,45000],
//				backgroundColor: '#ff8819',
//				borderColor: '#ff8819',
//				borderWidth: 3,
//				pointStyle: 'circle',
//				pointRadius: 5,
//				pointBorderColor: 'transparent',
//				pointBackgroundColor: '#ff8819',
//			}]
//		},
//		options: {
//			responsive: true,
//			maintainAspectRatio: false,
//			tooltips: {
//				mode: 'index',
//				titleFontSize: 12,
//				titleFontColor: '#000',
//				bodyFontColor: '#000',
//				backgroundColor: '#fff',
//				cornerRadius: 3,
//				intersect: false,
//			},
//			legend: {
//				display: true,
//				labels: {
//					usePointStyle: false,
//				},
//			},
//			scales: {
//				xAxes: [{
//					ticks: {
//						fontColor: "#605e7e",
//					},
//					display: true,
//					gridLines: {
//						display: true,
//						color: 'rgba(96, 94, 126, 0.1)',
//						drawBorder: false
//					},
//					scaleLabel: {
//						display: false,
//						labelString: 'Month',
//						fontColor: 'transparent'
//					}
//				}],
//				yAxes: [{
//					ticks: {
//						fontColor: "#605e7e",
//					},
//					display: true,
//					gridLines: {
//						display: true,
//						color: 'rgba(96, 94, 126, 0.1)',
//						drawBorder: false
//					},
//					scaleLabel: {
//						display: false,
//						labelString: 'sales',
//						fontColor: 'transparent'
//					}
//				}]
//			},
//			title: {
//				display: false,
//				text: 'Normal Legend'
//			}
//		}
//	});
//	/* chartjs (#sales-status) closed */

//});
