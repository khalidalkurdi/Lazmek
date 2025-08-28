﻿var dataTable;
$(document).ready(
    function () {
        var url = window.location.search
        if (url.includes("inprocess")) {
            loadDataTable("inprocess")
        }
        else{
            if (url.includes("completed")) {
                loadDataTable("completed")
            }
            else {
                if (url.includes("pending")) {
                    loadDataTable("pending")
                }
                else {
                    if (url.includes("approved")) {
                        loadDataTable("approved")
                    }
                    else {
                        loadDataTable("all");
                    }
                }
            }
        }
    }
);
function loadDataTable(status) {
    dataTable = $('#tabledata').DataTable({
        ajax: {
            url: "/Admin/Order/GetAll?status=" + status
        },
        columns: [
            { data: 'id', "width": "5%" },
            { data: 'name', "width": "20%" },
            { data: 'phoneNumber', "width": "15%" },
            { data: 'user.email', "width": "25%" },
            { data: 'orderStatus', "width": "10%" },
            { data: 'orderTotal', "width": "10%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75">
                        <a href="/Admin/order/details?orderId=${data}" class="btn btn-primary mx-2"><i class="bi bi-info-circle"></i> Details</a>
                    </div>`;
                },
                "width": "15%"
            }
        ]
    });
}