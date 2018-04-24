$(document).ready(function(){
        $('#listado-colaboradores').DataTable({
            dom: 'lBrtip',
            "processing": true, //for showing progress indicator
            "searching": true,
            "serverSide": true,
            "filter": false,
            "orderMulti": false,
            "orderCellsTop": false,
            "ordering": true,
            "ajax": { // server side url
                "url": "/VistaColaboradores/LoadData",
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
                "paginate": {
                    "next": "Siguiente",
                    "previous": "Anterior",
                    "first": "Primero",
                    "last": "Último"
                }
            },
            "columnDefs": [
        {
            "targets": [2],
            "visible": false,
            "searchable": false
        },
        {
            "targets": [3],
            "visible": false,
            "searchable": false
        },
        {
            "targets": [4],
            "visible": false,
            "searchable": false
        },
        {
            "targets": [5],
            "visible": false,
            "searchable": false
        },
        {
            "targets": [8],
            "visible": false,
            "searchable": false
        },
        {
            "targets": [10],
            "visible": false,
            "searchable": false
        }],
            "initComplete": function () {
                this.api().columns([6,14,16]).every(function () {
                    var column = this;
                    var select = $('<select class="selectpicker" data-live-search="true" data-show-tick="true"><option value="" selected>Selecciona un valor</option></select>')
                    .appendTo($(column.footer()).empty())
                    .on('change', function () {
                        var val = $.fn.dataTable.util.escapeRegex(
                            $(this).val()
                        );

                        column
                            .search(val ? '^' + val + '$' : '', true, false)
                            .draw();
                    });

                    column.data().unique().sort().each(function (d, j) {
                        select.append('<option value="' + d + '">' + d + '</option>')
                    });
                });
            }
        });
        $('#listado-colaboradores_length').val(5);
    });
}