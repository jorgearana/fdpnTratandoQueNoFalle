




function TestDataTablesAdd(table) {
    $(document).ready(function () {
        //$(table).DataTable();
        //var x = document.getElementById("txt");
        //x.value = mensaje;

        //setTimeout(function () { x.value = "2 seconds" }, 2000);
        //setTimeout(function () { x.value = "4 seconds" }, 4000);
        //setTimeout(function () { x.value = "6 seconds" }, 6000);
        setTimeout(AplicarDataTable(table), 1000);
        $(this).prop("disabled", true);
    });
}


function AplicarDataTable(table) {
    $(table).DataTable();
}

$(document).ready(function () {


    $("#botonnavbar").click(function () {
        console.log("hizo click");
        $("#botonnavbar").toggleClass("active");
        $("#botonnavbar").toggleClass("relative");

    })


    $("#target").click(function () {
        alert("Handler for .click() called.");
    });

    $("#other").click(function () {
        $("#target").click();
    });
});