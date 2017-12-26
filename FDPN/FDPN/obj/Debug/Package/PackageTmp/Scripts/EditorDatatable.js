


 
$(document).ready(function () {

    var botonActualizarCalendario = $("#actualizar");

    botonActualizarCalendario.on("click", function () {
        
        $.ajax({
            url: "/Administrador/TablaCalendario",
            type: "GET",
             }
        })
            .done(function (partialViewResult) {
                $("#TablaCalendario").html(partialViewResult);
            });
    });
} );