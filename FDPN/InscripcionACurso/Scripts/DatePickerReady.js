$(function () {
    $.datepicker.regional['es'] = {
        closeText: 'Cerrar',
        prevText: 'Previo',
        nextText: 'Próximo',
        monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
        monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
        monthStatus: 'Ver otro mes',
        yearStatus: 'Ver otro año',
        dayNames: ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado'],
        dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mie', 'Jue', 'Vie', 'Sáb'],
        dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sa'],
        dateFormat: 'yy-mm-dd',
        firstDay: 0,
        initStatus: 'Fecha de nacimiento',
        isRTL: false,
        changeMonth: true,
        changeYear: true,
        yearRange: "-100:+0",
        //currentText: "Now",
        showAnim: "fold"
    }; $(".datefield").datepicker($.datepicker.regional["es"]);
});