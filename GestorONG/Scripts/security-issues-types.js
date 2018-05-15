$(document).ready(function () {
    window.table = $('#listado-tipos-incidencias').DataTable({
        dom: 'lBtip',
        "processing": false, //for showing progress indicator
        "searching": true,
        "serverSide": false,
        "orderMulti": false,
        "orderCellsTop": false,
        "ordering": true,
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
        "colReorder": false,
        "responsive": true,
        "scrollX": false,
        "buttons": [
            {
                "extend": 'excelHtml5',
                "text": '<i class="fas fa-file-excel" aria-hidden="true"></i> ' + "Excel",
                "filename": function () {
                    var d = getFecha();
                    return 'Collaborators' + d;
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
        "columnDefs": [
            {
                "targets": [0],
                "visible": false
            }
        ],
        "stateSave": false,
        "pagingType": "full_numbers",
        "lengthMenu": [[10, 25, 50, 100, 250, 500, -1], [10, 25, 50, 100, 250, 500, "Todos"]],
    });

    //Register events function
    RegisterCustomEvents();
});

function RegisterCustomEvents() {
    //Row selected
    $('#listado-tipos-incidencias tbody').on('click', 'tr', function () {
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

    $('#Edit').on('click', function (e) {
        e.preventDefault();
        var idSelected = $('.selected-row').attr('id');
        window.location.href = '/TiposIncidencias/Edit/' + idSelected;
    });

    $('#Delete').on('click', function (e) {
        e.preventDefault();
        var idSelected = $('.selected-row').attr('id');
        window.location.href = '/TiposIncidencias/Delete/' + idSelected;
    });
}