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


});