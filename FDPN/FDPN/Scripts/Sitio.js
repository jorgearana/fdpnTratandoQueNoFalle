$(document).ready(function () {

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
    $(document).ready(function () {
        $('.datatabla').DataTable({
            "order": [[0, "desc"]],
            "pageLength": 20
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
        if (valordrop === "3")
        {           
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
        var arrayRecords = [];
        

        SLen = filas.length;
        for (i = 0; i < SLen; i++) {
            var celda = filas[i].cells[0].innerHTML;
            Ids.push(celda);
            var nada = "nada";
        }
       
        
    }
    if (filas.length = 0) {
        var Ids = new Array();
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



