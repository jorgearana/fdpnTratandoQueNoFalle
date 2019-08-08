
$(document).ready(function () {
    $("#mostrarmodal").modal("show");
    // cada vez que se mueva el scroll del navegador se ejecutara
    // este evento
    $(document).scroll(function () {

        // si la posicion del scroll es superior a 55 pixels...
        if ($(window).scrollTop() > 45) {
            // indicamos que el header tiene una posicion fija a -47 pixels
            $("navBar").css({ "position": "fixed", "top": -47 });
            // definimos el margen superior al contenido cuando queda fijado
            $("container").css({ "margin-top": 80 });
        } else {
            $("navBar").css({ "position": "inherit", "top": "inherit" });
            $("container").css({ "margin-top": 0 });
        }
    });

    $(".dropdown-toggle").dropdown();

    $('.carrusel').slick({
        lazyLoad: 'ondemand',
        infinite: true,
        slidesToShow: 3,
        slidesToScroll: 3,
        dots: true,
        speed: 300,
        adaptiveHeight: true,
        autoplay: true,
        autoplaySpeed: 4000,

        responsive: [
            {
                breakpoint: 1024,
                settings: {
                    slidesToShow: 3,
                    slidesToScroll: 3,
                    infinite: true,
                    dots: true
                }
            },
            {
                breakpoint: 600,
                settings: {
                    slidesToShow: 2,
                    slidesToScroll: 2
                }
            },
            {
                breakpoint: 480,
                settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1
                }
            }
            // You can unslick at a given breakpoint now by adding:
            // settings: "unslick"
            // instead of a settings object
        ]
    });

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
                "sPrevious": "Página anterior"
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
                "sPrevious": "Página anterior"
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
                "sPrevious": "Página anterior"
            }
        },
    });
    $('.datatablaLarga').DataTable({
        "pageLength": 100,
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
                "sPrevious": "Página anterior"
            }
        },
    });


    $(function () {
        $('.item').matchHeight({
            byRow: true,
            property: 'height',
            target: null,
            remove: false
        });
    });


});

$('#tablaDeshabilitada tbody').on('click', 'tr', function () {
    $(this).toggleClass('selected');
});




$("#periodoid")
    .change(function () {
        var valordrop = $("#periodoid").val();

        var tabla = $('#tablaDeshabilitada');
        if (valordrop === "3") {
            tabla.css('visibility', 'visible');
        }
        else {
            tabla.css('visibility', 'hidden');
        }

    })
    .change();

$('#buscarRankingFINA').on('click', function (e) {
    e.preventDefault();
    e.stopPropagation();

    var table = $('#tablaDeshabilitada');
    //var selectedRows = table.rows('.selected').data();
    var filas = $(".selected");
    var selectedRows = filas.data();
    if (filas.length > 0) {
        // build array of records

        var Ids = new Array();

        SLen = filas.length;
        for (i = 0; i < SLen; i++) {
            var celda = filas[i].cells[0].innerHTML;
            Ids.push(celda);
            var nada = "nada";
        }


    }
    if (filas.length === 0) {
        Ids = new Array();
        Ids.push(0);
    }
    var periodoid = $("#periodoid").val();
    var edadminima = $("#edadminima").val();
    var edadmaxima = $("#edadmaxima").val();

    $.ajax({
        url: '/Resultados/CalcularRankignFina',
        type: 'POST',
        //dataType: 'JsonSendAfiliar',
        data: { torneosid: Ids, periodoid: periodoid, edadminima, edadmaxima },
                async: false,
        success: function (result) {
            $('#rankingPuntoFINA').html(result);
        },

    });
});


$("#descargarranking").click(function (e) {


    var id = $.parseJSON($(this).attr('data-clubid'));
    $.ajax({
        type: 'POST',
        url: "../../Director/Index",
        async: false,
        //dataType: 'text json',
        data: { id: id },
        success: function (data) {
            //var response = JSON.parse(data);
            var path = '/Director/Download?fileGuid=' + data.FileGuid + '&filename=' + data.FileName;
            window.location = path;
        }
    });

});

//var table = $('#tablaActualizarCalendario').DataTable();

//$('#tablaActualizarCalendario tbody').on('click', 'tr', function () {
//    console.log(table.row(this).data());
//});


