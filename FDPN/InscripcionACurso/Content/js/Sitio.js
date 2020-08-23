$(document).ready(function () {
    //eso se usa en el listado por prueba en el boton quiero
    $("#CursoParticipante_DNI").change(function () {

        var DNI = $("#CursoParticipante_DNI").val();

        $.ajax({
            url: '/Inscrito/BuscarDNI',
            type: 'GET',
            contentType: 'application/json; charset=utf-8',
            data: { 'DNI': DNI },
            async: false,
            success: function (result) {
                LLenarDatosDeInscritos(result)
            },
        });
    });


    function LLenarDatosDeInscritos(result) {
        var InscritosAlEvento = $("#InscritosAlEvento");
        InscritosAlEvento.html(result);
    }

});