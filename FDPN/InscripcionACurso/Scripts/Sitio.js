$(function () {
    // Invoke the plugin
    $('input, textarea').placeholder();
});
$("#count-down").TimeCircles(
    {
        circle_bg_color: "#639094",
        use_background: true,
        bg_width: 1,
        fg_width: 0.02,
        time: {
            Days: { color: "#fefeee" },
            Hours: { color: "#fefeee" },
            Minutes: { color: "#fefeee" },
            Seconds: { color: "#fefeee" }
        }
    }
);
$(document).ready(function () {

    var $valFn = $.fn.val;
    $.fn.extend({
        val: function () {
            var valCatch = $valFn.apply(this, arguments);
            var placeholder = $(this).attr("placeholder");

            // To check this val is called to set value and the val is for datePicker element 
            if (!arguments.length && this.hasClass('datefield')) {
                if (valCatch.indexOf(placeholder) != -1) {
                    return valCatch.replace(placeholder, "");
                }
            }
            return valCatch;
        }
    });
    //$(function () {
    // This will make every element with the class "date-picker" into a DatePicker element
    //$('.date-picker').datepicker(
    //    {
    //        changeMonth: true,
    //        changeYear: true,
    //        showButtonPanel: true,
    //        yearRange: "-100:+0",
    //        dateFormat: 'dd/mm/yy'
    //    }
    //);
    //})
    $.validator.addMethod(
        "email",
        function (value, element) {
            return this.optional(element) || /^[a-zA-Z0-9.!#$%&'*+\/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$/.test(value);
        },
        "This e-mail is not valid"
    );

    $.validator.methods.email = function (value, element) {
        return this.optional(element) || /[a-z]+@[a-z]+\.[a-z]+/.test(value);
    }

    $("#CursoParticipante_DNI").change(function () {

        var DNI = $("#CursoParticipante_DNI").val();

        $.ajax({
            url: '/Inscripcion/BuscarDNI',
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

        var Nombres = result.Nombres;
        var Paterno = result.Paterno;
        var Materno = result.Materno;
        var Nacimiento = result.Nacimiento;
        var DNI = result.DNI;
        var Celular = result.Celular;
        var Nacionalidad = result.Nacionalidad;
        var Actividad = result.Actividad;
        var Email = result.Email;

        $("#CursoParticipante_Nombres").val(Nombres);
        $("#CursoParticipante_Paterno").val(Paterno);
        $("#CursoParticipante_Materno").val(Materno);
        $("#CursoParticipante_DNI").val(DNI);
        $("#CursoParticipante_Celular").val(Celular);
        $("#CursoParticipante_Nacionalidad").val(Nacionalidad);
        $("#CursoParticipante_Actividad").val(Actividad);
        $("#CursoParticipante_Email").val(Email);

        //Esto convierte el valor de json en formato de fecha
        var parsed = new Date(parseInt(Nacimiento.substr(6)));
        var newFormattedDate = $.datepicker.formatDate('dd/mm/yy', parsed);
        $("#CursoParticipante_Nacimiento").val(newFormattedDate);
    }


});
