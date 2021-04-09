
$(document).ready(function () {
    $("#mostrarmodal").modal("show");
    // cada vez que se mueva el scroll del navegador se ejecutara
    // este evento
   

    $(document).ready(function () {
        $('.datatabla').DataTable({
            "pageLength": 25,
            "language": {
                "lengthMenu": "Mostrando _MENU_ registros por página",
                "zeroRecords": "No encontramos datos",
                "info": "Mostrando página _PAGE_ de _PAGES_",
                "infoEmpty": "Sin datos disponibles",
                "infoFiltered": "(filtrado de  _MAX_ registros totales)",
                "oPaginate": {
                    "sFirst": "Primera página",
                    "sLast": "Última página",
                    "sNext": "Siguiente página",
                    "sPrevious": "Página anterior",
                }
            },
        });
        $('.datatablacorta').DataTable({
            "order": [[0, "desc"]],
            "pageLength": 10,
            "language": {
                "lengthMenu": "Mostrando _MENU_ registros por página",
                "zeroRecords": "No encontramos datos",
                "info": "Mostrando página _PAGE_ de _PAGES_",
                "infoEmpty": "Sin datos disponibles",
                "infoFiltered": "(filtrado de  _MAX_ registros totales)",
                "oPaginate": {
                    "sFirst": "Primera página",
                    "sLast": "Última página",
                    "sNext": "Siguiente página",
                    "sPrevious": "Página anterior",
                }
            },
        });

        $('.datatablaReves').DataTable({
            "order": [[0, "desc"]],
            "pageLength": 20,
            "language": {
                "lengthMenu": "Mostrando _MENU_ registros por página",
                "zeroRecords": "No encontramos datos",
                "info": "Mostrando página _PAGE_ de _PAGES_",
                "infoEmpty": "Sin datos disponibles",
                "infoFiltered": "(filtrado de  _MAX_ registros totales)",
                "oPaginate": {
                    "sFirst": "Primera página",
                    "sLast": "Última página",
                    "sNext": "Siguiente página",
                    "sPrevious": "Página anterior",
                }
            },
        });
    });


});