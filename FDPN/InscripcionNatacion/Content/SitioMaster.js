$(document).ready(function () { //Al inicio cuando se recarga la página de inscripciones en si
    var table = $('#dataTablesmasters').DataTable({
        pageLength: 50,
        responsive: true,

    });
});

$('.Modificarinscripcionmasters').click(function () {
    var afiliadoId = $(e.target).data('afiliado');
});



//    $(document).on("click", ".BtnInscribirMaster", function (e) {
//        var MeetId = $("#MeetId").text();
//        var afiliadoId = $(e.target).data('inscripcionid');
//    $.ajax({
//        url: '/Masters/ListarPruebasParaElNadadorMaster',
//        type: 'GET',

//        data: {
//            MeetId: MeetId,
//            afiliadoId: afiliadoId,
//            sinDNI: false
//        },
//        async: false,
//        success: function (data) {
//            LlenarPruebasDeMaster(data);
//        },
//        error: function (result) {
//            alert("Data not found");
//        }
//    });
//});

//$(document).on("click", ".btnInscribirSinDNI", function (e) {
//    var MeetId = $("#MeetId").text();
//    var afiliadoId = $("#IdDelAfiliado").text();
//    $.ajax({
//        url: '/Masters/ListarPruebasParaElNadadorMaster',
//        type: 'GET',

//        data: {
//            MeetId: MeetId,
//            afiliadoId: afiliadoId,
//            sinDNI: true
//        },
//        async: false,
//        success: function (data) {
//            LlenarPruebasDeMaster(data);
//        },
//        error: function (result) {
//            alert("Data not found");
//        }
//    });
//});



function LlenarPruebasDeMaster(data) {
    $("#modalInscripcionMaster").modal('show');
    $("#cuerpoInscripcionMaster").html(data);
}