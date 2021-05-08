$(document).ready(function () {
    $("#mostrarmodal").modal("show"),
        $(document).scroll(function () {
            $(window).scrollTop() > 45 ? ($("navBar").css({
                position: "fixed",
                top: -47
            }), $("container").css({
                "margin-top": 80
            })) : ($("navBar").css({
                position: "inherit",
                top: "inherit"
            }), $("container").css({
                "margin-top": 0
            }))
        }),

        $(".dropdown-toggle").dropdown(),


        $(".datatabla").DataTable({
            pageLength: 25,
            language: {
                lengthMenu: "Mostrando _MENU_ registros por página",
                zeroRecords: "No encontramos datos",
                info: "Mostrando página _PAGE_ de _PAGES_",
                infoEmpty: "Sin datos disponibles",
                infoFiltered: "(filtrado de  _MAX_ registros totales)",
                oPaginate: {
                    sFirst: "Primera página",
                    sLast: "Última página",
                    sNext: "Siguiente página",
                    sPrevious: "Página anterior"
                }
            }
        });
    $(".datatablareves").DataTable({
        "order": [[0, 'desc']],
        pageLength: 25,
        language: {
            lengthMenu: "Mostrando _MENU_ registros por página",
            zeroRecords: "No encontramos datos",
            info: "Mostrando página _PAGE_ de _PAGES_",
            infoEmpty: "Sin datos disponibles",
            infoFiltered: "(filtrado de  _MAX_ registros totales)",
            oPaginate: {
                sFirst: "Primera página",
                sLast: "Última página",
                sNext: "Siguiente página",
                sPrevious: "Página anterior"
            }
        }
    });

       
}),
    


    $("#periodoid").change(function () {
    var a = $("#periodoid").val(),
        i = $("#tablaDeshabilitada");
    "3" === a ? i.css("visibility", "visible") : i.css("visibility", "hidden")
}).change(), $("#buscarRankingFINA").on("click", function (a) {
    a.preventDefault(), a.stopPropagation();
    $("#tablaDeshabilitada");
    var e = $(".selected");
    e.data();
    if (e.length > 0) {
        var o = new Array;
        for (SLen = e.length, i = 0; i < SLen; i++) {
            var t = e[i].cells[0].innerHTML;
            o.push(t)
        }
    }
    0 === e.length && (o = new Array).push(0);
    var n = $("#periodoid").val(),
        s = $("#edadminima").val(),
        r = $("#edadmaxima").val(),
        d = $("#Sexo").val();
    "" === n && (n = "1"), "" === d && (d = "1"), $.ajax({
        url: "/Resultados/CalcularRankignFina",
        type: "POST",
        data: {
            torneosid: o,
            periodoid: n,
            edadminima: s,
            edadmaxima: r,
            sexo: d
        },
        async: !1,
        success: function (a) {
            $("#rankingPuntoFINA").html(a)
        }
    })
}), $("#descargarranking").click(function (a) {
    var i = $.parseJSON($(this).attr("data-clubid"));
    $.ajax({
        type: "POST",
        url: "../../Director/Index",
        async: !1,
        data: {
            id: i
        },
        success: function (a) {
            var i = "/Director/Download?fileGuid=" + a.FileGuid + "&filename=" + a.FileName;
            window.location = i
        }
    })
});