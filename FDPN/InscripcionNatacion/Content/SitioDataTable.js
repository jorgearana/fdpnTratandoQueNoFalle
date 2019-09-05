$(document).ready(function () {
    $("#divLoader").hide();
    //$("#pagina").show();showNotification
    $("#pagina").fadeIn(900);

    $('.modalmarca').keypress(function (e) {
        return e.keyCode !== 13;
    });


    //Al presionar el boton inscribir en la tabla de deportistas se llena la tabla eventos
    $(document).on("click", ".BtnInscribir", function (e) {
        //Para hacer el check in de ingreso
        var deportistaid = $(e.target).data('id');
        var TorneoId = $("#TorneoId").text();
        var trid = $(e.target).data('trid'); //fila del deportista a inscribir
        var textoDelModal = $("#MarcaSinFormato");//para que salga en blanco el modal
        textoDelModal.text("");

        var deportista = $("#Deportista");
        var TRDeportista = $("#TRDeportista");
        deportista.text(deportistaid);
        TRDeportista.text(trid); // guardo este dato para colorear esta fila cuando se graba la inscripcion

        var filascoloreadas = $('#Tabladeportistas tr');
        filascoloreadas.removeClass("Inscribiendo");

        $(".GrabarInscripciones").show();

       
            $("#" + trid).addClass('Inscribiendo'); //Volver la fila verde 
            $.ajax({
                url: '../otrotorneo/ListarPruebasParaelDeportista',
                type: 'GET',

                data: {
                    TorneoId: TorneoId,
                    InscripcionId :deportistaid,
                },
                async: false,
                success: function (data) {
                    LLenarTabla(data);
                }
            });
        
    });

});





//Carga la página cuando se selecciona un evento, deportistas e inscritos
$("#PoloEventoId").change(function () {
    ResetearTablasDeDeportistasEInscritos();
    $('#loading-image').css("visibility", "visible");
    RellenarTablasDeDeportistasEInscritos();
});

function CargarListadopolo(otroeventoid) {
   
    $.ajax({
        url: '../otrotorneo/ListadoPolistas',
        type: 'GET',
        data: {
            otroeventoid: otroeventoid
        },
        success: function (data) {
            var partial = data;
            $("#ListadoPolistas").html(partial);
            $('#loading-image').css("visibility", "hidden");
        }
    });
}

function RellenarTablasDeDeportistasEInscritos() {
    var PoloEventoId = $("#PoloEventoId").val();
    CargarListadopolo(PoloEventoId);
    CargarInscritosPolo(PoloEventoId);
}

function ResetearTablasDeDeportistasEInscritos() {
    $("#ListadoPolistas").empty();
    $("#YaInscritos").empty();
}

function CargarInscritosPolo(otroeventoid) {
    $('#loading-image').css("visibility", "visible");
    $.ajax({
        url: '../otrotorneo/YaInscritosPolo',
        type: 'GET',
        data: {
            otroeventoid: otroeventoid
        },
        success: function (data) {
            var partial = data;
            $("#YaInscritos").html(partial);
            $('#loading-image').css("visibility", "hidden");
        }
    });
  
}

$(document).on("click", ".BtnInscribirPolo", function (e) {
    //Para hacer el check in de ingreso
   
    var PoloEventoId = $("#PoloEventoId").val();
    var deportistaid = $(e.target).data('id');
    $("#ModalPoloEventoId").text(PoloEventoId);
    $("#modaliddeportistapolo").text(deportistaid);
    $.ajax({
        url: '../otrotorneo/Getdeportista',
        type: 'GET',
        data: {
            id: deportistaid
        },
        success: function (data) {
            var nombre = data.Nombre;
            var apellido = data.Apellido_Paterno;
            $("#ModalNombreDeportista").text(nombre + " " + apellido);
        },
        error: function (data) {
            var mensaje = data;
            var id = deportistid;
        }
    });
    $("#ModalGorro").modal({
        closeClass: 'icon-remove',
        closeText: 'X'
    });
});

$(document).on("click", "#BtngrabarPolo", function (e) {
   
    var PoloEventoId = $("#PoloEventoId").val();
    var deportistaid = $("#modaliddeportistapolo").text();
    var numerogorro = $("#numerogorro").val();
    if (numerogorro> 0) {+
    $.ajax({
        url: '../otrotorneo/GrabarOtraEntrada',
        type: 'Post',
        data: {
            inscripcionid: deportistaid,
            otroeventoid: PoloEventoId,
            gorroid: numerogorro,
            disciplinaid: 2,
            suplente: false,
        },
        success: function (data) {
           
            CargarInscritosPolo(PoloEventoId);
            $("#ModalGorro").modal('hide');
            $("#numerogorro").val("");
        }
    });
        
    
    }
    
});


$(document).on("click", ".BtnIRetirarPolo", function (e) {
    //Para hacer el check in de ingreso

    var PoloEventoId = $("#PoloEventoId").val();
    var DataId = $(e.target).data('id');
    
    $.ajax({
        url: '../otrotorneo/RetirarOtraEntrada',
        type: 'GET',
        data: {
            DataId : DataId,
            eventoid: PoloEventoId
        },
        success: function () {
            CargarInscritosPolo(PoloEventoId);
        },
       
    });
});





//**************************** FIN  Polo acuatico *********************************
//Llena la tabla de deportistas con el partial view que viene desde el controlador
function LLenarTablaDeportists(deportistas) {
    var tabladeportistas = $("#ListadoDeDeportistasDeLaDisciplina");
    tabladeportistas.html(deportistas);
    //VolverADatatablaDeportistas();
}

function CArgarResultados(resultados) {
    var tablaresultados = $("#ListadoParaMostrar");
    tablaresultados.html(resultados);
}

//Llena la tabla con el partial view que viene desde el controlador
function LLenarTabla(mensaje) {
    var eventos = $("#eventoinscrito");
    eventos.html(mensaje);
    VolverADatatablaEventos();
}

//Esto hace que se marque las filas de color al ser seleccionadas
//en caso sea en natación abre el modal para agregar la marca
function VolverADatatablaEventos() {
  
    var celdavacia = "00.00";
   

    $('#modificable tbody').on('click', 'tr', function () {
        var fila = $(this);
        var cellId = fila[0].cells[0]; // This is a DOM "TD" element
        var celdatexto = $(cellId).text(); // Now it's a jQuery object.
        var IdCheckPrueba = "#" + $.trim(celdatexto) + "checkredondo";
        var idDeLaCelda = "#" + $.trim(celdatexto);

        var celdacheckprueba = $(IdCheckPrueba);
        celdacheckprueba.toggleClass('oculto');
        var myClass = celdacheckprueba.attr("class");

        if ($(this).hasClass('selected')) {
            $(this).removeClass('selected');
            $(idDeLaCelda).text(celdavacia);
        }
        else {
            $(this).addClass('selected');
            
                $('#IngresarMarcas').modal('show');
                $("#fila").text(celdatexto);
                $('#MarcaSinFormato').focus();
           
        }
    });
}



type = ['', 'info', 'success', 'warning', 'danger'];
function showNotification(message, tipo) {

    $("body").overhang({
        type: type[tipo],
        message: "Grabado",
        duration: 2
    });

}

//grabar las inscripciones
$('.GrabarInscripciones').on('click', function (e) {

    $('.GrabarInscripciones').hide();
    e.preventDefault();
    e.stopPropagation();

  
    //var direccion = '../inscripcion/GrabarLasInscripciones';
    var direccion = '../inscripcion/GrabarLasInscripcionesParaNatacion';
    
    var table = $('#modificable');
    var selectedRows = table.find('> tbody > tr.selected');// .rows('.selected');
    var deportistaid = $("#Deportista").text();

    // build array of records
    var arrayRecords = [];
    var Ids = new Array();
    var marcas = new Array();

    SLen = selectedRows.length;
    for (i = 0; i < SLen; i++) {
        //Ids.push(selectedRows[i].cells[0]);
        var cellId = selectedRows[i].cells[0]; // This is a DOM "TD" element
        var celdaId = $(cellId).text(); // Now it's a jQuery object.
        var cellMarca = selectedRows[i].cells[3]; // This is a DOM "TD" element
        var celdaMarca = $(cellMarca).text(); // Now it's a jQuery object.
        Ids.push(celdaId);
        marcas.push(celdaMarca);
    }
    $.ajax({
        url: direccion,
        type: 'POST',
        //dataType: 'JsonSendAfiliar',
        data: { deportistaid: deportistaid, Ids: Ids, marcas: marcas },
        async: false,
        success: function (result) {
            if (result === "Hubo un error") {
                showNotification("Hubo un error, por favor recargue la página para verificar si se grabaron los cambios", 4);
            }
            else {
                AceptarInscripcion(result, deportistaid);
            }
        },
        error: function (result) {
        }
    });
});

function AceptarInscripcion(result, deportistaid) {
    var TRDeportista = $("#TRDeportista");
    var eventos = $("#eventoinscrito");

    var check = "#" + deportistaid + "check";
    var checkDeportista = $(check);

    eventos.empty();
    showNotification("Grabado", 3);
    var filadeportista = $("#TRDeportista").text();
    $("#" + filadeportista).removeClass('Inscribiendo'); //Volverla verde


    if (result === "Sin") {
        $("#" + filadeportista).removeClass('TieneInscripcion');
        checkDeportista.addClass('oculto');
    }
    else {
        $("#" + filadeportista).addClass('TieneInscripcion');
        checkDeportista.removeClass('oculto');
    }

}



//Al presionar el botón de ingresar la marca del modal, se convierte el dato que está en números a marca

$('.BtnIngresarMarca').on('click', function (e) {
    var sinformato = $('#MarcaSinFormato').val();
    var fila = $("#fila").text();
   
    $.ajax({
        url: '/inscripcion/DarFormatoALaMarcaSinFormato',
        type: 'POST',
        //dataType: 'JsonSendAfiliar',
        data: { sinformato: sinformato },
        async: false,
        success: function (result) {
            $('#IngresarMarcas').modal('hide');
            var celda = "#" + fila;
            $(celda).html(result);
            $('#MarcaSinFormato').val("");
        },
        error: function (result) {
        }
    });
});

$('.BtnIngresarSuplente').on('click', function (e) {
    var Suplente = $('#Suplente').prop("checked");
    var fila = $("#fila").text();
    $('#IngresarSuplente').modal('hide');
    var celda = "#" + fila;
    if (Suplente) {
        $(celda).html("Suplente");
    }

    $('#Suplente').prop("checked", false);


});

//$(document).keypress(function (e) {
//    if (e.which === 13) {
//        alert('Si presiona enter, la página se va a recargar y no se van a grabar las inscripciones. Para evitar esto presione las teclas Control + F5 en windows o Command + F5 en Mac');
//    }
//});


