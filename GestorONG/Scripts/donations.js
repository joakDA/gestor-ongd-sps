$(document).ready(function () {
    window.table = $('#donations-list').DataTable({
        dom: 'lBrtip',
        "processing": true, //for showing progress indicator
        "searching": true,
        "serverSide": true,
        "filter": false,
        "orderMulti": false,
        "orderCellsTop": false,
        "ordering": true,
        "ajax": { // server side url
            "url": "/Donaciones/LoadData",
            "type": "POST",
            "datatype": "json"
        },
        "language": {
            "lengthMenu": "Mostrando _MENU_ elementos por página",
            "zeroRecords": "No se han encontrado resultados - lo lamentamos",
            "info": "Mostrando página _PAGE_ de _PAGES_",
            "infoEmpty": "No hay resultados",
            "infoFiltered": "(total de _MAX_ registros)",
            "search": "Buscar:",
            "processing": '<div id="ajax-loader" class=""><img alt="Loading spinner" src="/Content/Images/common/ajax-loader.gif" /></div>',
            "paginate": {
                "next": "Siguiente",
                "previous": "Anterior",
                "first": "Primero",
                "last": "Último"
            }, "aria": {
                "sortAscending": "Presiona para ordenar esta columna en orden ascendente",
                "sortDescending": "Presiona para ordenar esta columna en orden descendente"
            }
        },
        //show data and how to render value
        "columns": [
            {
                "data": "id", "name": "id", "autoWidth": true, "class": "id hidden", "title": "Id"
            },
            {
                "data": "amount", "name": "amount", "autoWidth": true, "title": "Cantidad"
            },
            {
                "data": "donationDate", "name": "donationDate", "autoWidth": true,
                "render": function (data, type, row) {
                    var date = moment(data);
                    return data !== null ? date.format("DD-MM-YYYY") : "";
                },
                "title": "Fecha de Alta"
            },
            {
                "data": "NIF", "name": "NIF", "autoWidth": true, "title": "CIF_NIF"
            },
            {
                "data": "collaborator", "name": "collaborator", "autoWidth": true, "title": "Colaborador"
            },
            {
                "data": "bankAccount", "name": "bankAccount", "autoWidth": true, "title": "Cuenta Bancaria"
            },
            {
                "data": "periodicity", "name": "periodicity", "autoWidth": true, "title": "Periodicidad"
            },
        ],
        "order": [[2, 'desc']],
        "colReorder": false,
        "columnDefs": [
            {
                "targets": [0],
                "visible": false
            },
            {
                "targets": [3,4,5,6],
                "orderable": false
            }
        ],
        "responsive": true,
        "scrollX": true,
        "buttons": [
            {
                extend: 'colvis',
                columns: ':not(.noVis)',
                text: '<i class="fas fa-eye" aria-hideen="true"></i> ' + "Visibilidad de Columnas",
                collectionLayout: 'three-column',
                className: 'btn btn-primary btn-lg'
            },
            {
                "extend": 'excelHtml5',
                "text": '<i class="fas fa-file-excel" aria-hidden="true"></i> ' + "Excel",
                "filename": function () {
                    var d = getFecha();
                    return 'Donations' + d;
                },
                "exportOptions": {
                    "modifier": {
                        "page": 'current'
                    },
                    "columns": ':visible'
                },
                "className": 'btn btn-primary btn-lg',
            }
        ],
        "stateSave": true,
        "pagingType": "full_numbers",
        "lengthMenu": [[10, 25, 50, 100, 250, 500, -1], [10, 25, 50, 100, 250, 500, "All"]],
        "drawCallback": function (settings) {
        },
        "initComplete": function () {
            $('#ajax-loader').hide();

            //RESET FILTERS
            $('.dt-buttons').append('<a type="button" onclick="var table1 = $(\'#donations-list\').DataTable(); table1.search(\'\').columns().search(\'\').draw();ResetSelect();" value="" class="btn btn-primary delete-filters"><i class="fas fa-filter"></i> ' + "Borrar Filtros" + '</a>')

            this.api().columns([1,3,4,6]).every(function (index) {
                var column = this;
                var title = $(column.header()).text().replace(/[\n\r]/g, '').replace(/\s/g, '');
                var elem = $('.filterhead').first();
                $(elem).removeClass('filterhead');
                var select = $('<select id="' + title + '" class="filter-select"><option value="N/A">' + "Todos" + '</option></select>')
                    .appendTo($(elem))
                    .on('change', function () {
                        var val = $.fn.dataTable.util.escapeRegex(
                            $(this).val()
                        );

                        column
                        .search(this.value)
                            .draw();


                    });
            });
            $('#donations-list_processing').removeClass('card');
            LoadSelectData(); //Load unique values on the select data making an Ajax request.
            $('.filter-select').select2({ width: 'resolve', allowClear: false });
        }
    }).on('length.dt', function (e, settings, len) {
        //console.log('New page length: ' + len);
        $('#ajax-loader').show();
    })
    .on('processing.dt', function (e, settings, processing) {
        $('#donations-list_processing').removeClass('card');
        if (processing) {
            $('#ajax-loader').show();    // **I do not get this**
        } else {
            $('#ajax-loader').hide(); // **I get this**
        };
    });

    //Register events function
    RegisterCustomEvents();
});

/*
* Reset the placeholder of each select when "Delete Filters" button is clicked.
*/
function ResetSelect() {
    $('thead select').each(function () {
        $(this).val('N/A').trigger('change')
    });
}

/*
* Load unique values on the select data making an Ajax request.
*/
function LoadSelectData() {
    $.ajax({
        url: '/Donaciones/GetSelectData',
        type: 'POST',
        contentType: "application/json; charset=utf-8",
        beforeSend: function () {
        },
        complete: function () {
        },
        success: function (response) {
            LoadSelectDataSuccess(response);
        },
        error: function (response) {
            LoadSelectDataFail(response);
        },
        processData: false,
        async: false
    });
}

/*
* Success callback from LoadSelectData request
*/
function LoadSelectDataSuccess(response) {
    //console.log("Success on loading values in filter selects.");
    var data = JSON.parse(response);

    var table2 = window.table;

    $.each(data.Amount, function (val, text) {
        var column = table2.column(1);
        if (column
                        .search(this.value) === text && column.search(this.value) !== "") {
            $('#Cantidad').append('<option value="' + text + '" selected>' + text + '</option>')
        }
        else {
            $('#Cantidad').append('<option value="' + text + '">' + text + '</option>')
        }
    });

    $.each(data.NIF, function (val, text) {
        var column = table2.column(3);
        if (column
                        .search(this.value) === text && column.search(this.value) !== "") {
            $('#CIF_NIF').append('<option value="' + text + '" selected>' + text + '</option>')
        } else {
            $('#CIF_NIF').append('<option value="' + text + '">' + text + '</option>')
        }
    });

    $.each(data.Collaborator, function (val, text) {
        var column = table2.column(4);
        if (column
                        .search(this.value) === text && column.search(this.value) !== "") {
            $('#Colaborador').append('<option value="' + text + '" selected>' + text + '</option>')
        } else {
            $('#Colaborador').append('<option value="' + text + '">' + text + '</option>')
        }
    });

    $.each(data.Periodicity, function (val, text) {
        var column = table2.column(6);
        if (column
                        .search(this.value) === text && column.search(this.value) !== "") {
            $('#Periodicidad').append('<option value="' + text + '" selected>' + text + '</option>')
        } else {
            $('#Periodicidad').append('<option value="' + text + '">' + text + '</option>')
        }
    });
}

/*
* Fail callback from LoadSelectData request
*/
function LoadSelectDataFail(response) {
    console.log("Fail executing ajax request for loading values in filter selects.");
}


function RegisterCustomEvents() {
    //Row selected
    $('#donations-list tbody').on('click', 'tr', function () {
        if ($(this).hasClass('selected-row')) {
            $(this).removeClass('selected-row');
        }
        else {
            table.$('tr.selected-row').removeClass('selected-row');
            $(this).addClass('selected-row');
        }
        $('#rowSelectedModal').modal({
            keyboard: false,
        });
    });

    $('#rowSelectedModal').on('hidden.bs.modal', function (e) {
        $('.selected-row').removeClass('selected-row');
    });

    //Details
    $('#Details').on('click', function (e) {
        e.preventDefault();
        var idSelected = window.table.row('.selected-row').data().id;
        window.location.href = '/Donaciones/Details/' + idSelected;
    });

    $('#Edit').on('click', function (e) {
        e.preventDefault();
        var idSelected = window.table.row('.selected-row').data().id;
        window.location.href = '/Donaciones/Edit/' + idSelected;
    });

    $('#Delete').on('click', function (e) {
        e.preventDefault();
        var idSelected = window.table.row('.selected-row').data().id;
        window.location.href = '/Donaciones/Delete/' + idSelected;
    });
}