var clock;
$(document).ready(function () {
    //Esto muestra el reloj en cada torneo
    var clocks = [];

    $('.clock').each(function () {
        var clock = $(this),
            //date = (new Date(clock.data('countdown')).getTime() - new Date().getTime()) / 1000;
        diafinal = clock.data('countdown');
        clock = (jQuery)(this).FlipClock(diafinal,{
            clockFace: 'DailyCounter',
            autoStart: false,
            callbacks: {
                stop: function () {
                    $('.message').html('El evento está cerrado')
                }
            }
        });
        //clock.setTime(diafinal);
        clock.setCountdown(true);
        clock.start();

        clocks.push(clock);
        
    });

   
  
});




$(document).ready(function () { //Al inicio cuando se recarga la página de inscripciones en si
    var table = $('#dataTables1').DataTable({
        pageLength: 50,
        responsive: true,

    });
    var sesion = new Array();
    var pruebasXsesion = $("#pruebasXsesion").text();
    var pruebasXtorneo = $("#pruebasXtorneo").text();
    var pruebasSinMarca = $("#pruebasSinMarca").text();
    var resultadoDeMarcarUnaPrueba = false;



    //eso se usa en el listado por prueba en el boton quiero
    $("#EventoId").change(function () {

        var EventId = $("#EventoId").val();

        $.ajax({
            url: '/Inscrito/DatosDelEvento',
            type: 'GET',
            contentType: 'application/json; charset=utf-8',
            dataType: 'html',
            data: { 'EventId': EventId},
            async: false,
            success: function (result) {
                llenardatosdelevento(result)
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("Ha habido un error: comuníquese con el administrador del sistema, 'código de error " + errorThrown + "'");
            }
        });
        $.ajax({
            url: '/Inscrito/InscritosAlEvento',
            type: 'GET',
            contentType: 'application/json; charset=utf-8',
            dataType: 'html',
            data: { 'EventId': EventId },
            async: false,
            success: function (result) {
                llenarinscritosalevento(result);
            },
            error: function () {
                alert("Status: " + textStatus);
                alert("Error: " + errorThrown);
            }
        });
    });
    function llenardatosdelevento(result) {
        var DatosDelEvento = $("#DatosDelEvento");
        DatosDelEvento.html(result);
    }

    function llenarinscritosalevento(result) {
        var InscritosAlEvento = $("#InscritosAlEvento");
        InscritosAlEvento.html(result);
    }

    //Al hacer click en una fila de la tabla
    $('.seleccion tbody').on('click', 'tr', function () {
       
        //Convierte toda la fila en un array de texto
        var cumple = ($(this).find('td.nocumplemarca').length) <1;
        var tdValue = $(this).children('td').map(function (index, val) {
            return $(this).text();
        }).toArray();
        //Aquí se ve si está seleccionada la fila
            
        if ($(this).hasClass("selected")) {
            resultadoDeMarcarUnaPrueba = DeSeleccionarPrueba(tdValue, cumple);
        }
        else //Si no está seleccionada se procesa y se le quia 
        {
            resultadoDeMarcarUnaPrueba= SeleccionarPrueba(tdValue, cumple);

        }
        if (resultadoDeMarcarUnaPrueba)
        {
            $(this).toggleClass('selected');
        }

       
       

        
    });

    $('#buttonGrabarInscripciones').click(function () {
        //alert(table.rows('.selected').data().length + ' row(s) selected');

        MostrarAvisoInicial("Se está grabando las inscripciones");
        var InscripcionId = $("#InscripcionId").text();
        var MeetId = $("#MeetId").text();
        var Piscina = $("#Piscina").text();
        var YaestaInscrito = $("#YaestaInscrito").text();
        var selectedRows = table.rows('.selected').data();
      
        if (selectedRows.length > 0) {
            // build array of records           
            var Inscripciones = new Array();
            $.each(selectedRows, function (i, val) {
                var celdasseleccionadas = new Array();
                for (var j = 0; j < val.length ; j++) {
                    if (j == 1 || j == 5 || j == 6) {
                        celdasseleccionadas.push(val[j])
                    }
                }
                Inscripciones.push(celdasseleccionadas);
            });
            var listado = JSON.stringify(Inscripciones);


            $.ajax({
                url: '/Inscrito/GrabarPruebasParaElNadador',
                type: 'GET',
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                data: { 'listado': listado, 'MeetString': MeetId, 'InscripcionId': InscripcionId, 'Piscina': Piscina, 'YaestaInscritoString': YaestaInscrito },
                async: false,
                success: function (result) {
                    MostrarMensaje(result);
                },
                error: function (result) {
                    console.log("Salió un error");
                }
            });

        }
        else {
           
            RetirarDeportista(InscripcionId, MeetId);
        }
    });

    //Cuando hacen click en este botón se agrega al nadador solo en postas
    $(document).on("click", ".Postas", function (e) {
  
        //alert(table.rows('.selected').data().length + ' row(s) selected');
        var afiliadoId = $(e.target).data('afiliado');
        var MeetId = $(e.target).data('meet');
            $.ajax({
                url: '/Inscrito/SoloParaPostas',
                type: 'GET',
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                data: { 'afiliadoId': afiliadoId, 'MeetId': MeetId },
                async: false,
                success: function (result) {
                    MostrarMensaje(result);
                },               
            });
    });

    function RetirarDeportista(InscripcionId, MeetId) {
        MostrarMensaje("Si deja al deportista sin pruebas se le borrará completamente de la competencia");
        $.ajax({
            url: '/Inscrito/BorrarInscripciones',
            type: 'GET',
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            data: { 'InscripcionId': InscripcionId, 'meetid': MeetId },
            async: false,
            success: function (result) {
                MostrarMensaje(result);
            },
            error: function (result) {
                console.log("Salió un error");
            }
        });
    }

    


    function SeleccionarPrueba(fila, cumple) {
        var resultado = false;
        var setup = $("#setuptorneo").text();

        if(setup == "Div 1")
        {
            resultado=    seleccionarUnaPruebaDivision1(fila, cumple);
        }
        else {
            resultado=    seleccionarUnaPruebaDivision2(fila, cumple);
        }
        return resultado;
    }

    function seleccionarUnaPruebaDivision1(fila, cumple) {
        var tiempo = ConvertirASegundos(fila[5]); //recuerda que el indice empieza en el cero
        var largas = ConvertirASegundos(fila[7]);
        var corta = ConvertirASegundos(fila[8]);
        var piscina = $("#Piscina").text();
        var resultado = false;

        var prueba = fila[1];
        var sesion = fila[0];
        //1.- ver si pasó el número máximo de esta sesión muestro un error si no es así se suma uno a la inscripcion total del nadador
        var inscrito = parseInt($("#inscrito" + sesion).text(), 10);
        var permitido = parseInt($("#permitido").text(), 10);

        inscrito += 1;
        if (inscrito > permitido) {
            MostrarError("Ha sobrepasado el máximo de pruebas de esta sesión");
            return false;
        }
        //2.- ver si paso el número máximo de pruebas por torneo
        var PruebasTotales = parseInt($("#PruebasTotales").text(), 10);
        var inscripciontotal = parseInt($("#inscripciontotal").text(), 10);
        inscripciontotal += 1;

        if (inscripciontotal > PruebasTotales) {
            MostrarError("Ha sobrepasado el máximo de pruebas por torneo");
            return false;
        }
        //3.- ver si pasó el máximo de pruebas sin marca  inscripcionPruebasSinMarca
        if (!cumple) {
            var inscripcionPruebasSinMarca = parseInt($("#inscripcionPruebasSinMarca").text(), 10);
            var MaximoSinMarca = parseInt($("#MaximoSinMarca").text(), 10);

            inscripcionPruebasSinMarca += 1;

            if (inscripcionPruebasSinMarca > MaximoSinMarca) {
                MostrarError("Ha superado el límite de pruebas sin marca");
                return false;
            }
            $("#inscripcionPruebasSinMarca").text(inscripcionPruebasSinMarca);
        }
        $("#inscrito" + sesion).text(inscrito);
        $("#inscripciontotal").text(inscripciontotal);

        resultado = true;
        return resultado;
    }

    function seleccionarUnaPruebaDivision2(fila, cumple) {
        var tiempo = ConvertirASegundos(fila[5]); //recuerda que el indice empieza en el cero
        var largas = ConvertirASegundos(fila[7]);
        var corta = ConvertirASegundos(fila[8]);
        var piscina = $("#Piscina").text();
        var resultado = false;

        var prueba = fila[1];
        var sesion = fila[0];
        //1.- ver si pasó el número máximo de esta sesión muestro un error si no es así se suma uno a la inscripcion total del nadador
        var inscrito = parseInt($("#inscrito" + sesion).text(), 10);
        var permitido = parseInt($("#permitido").text(), 10);

        inscrito += 1;
        if (inscrito > permitido) {
            MostrarError("Ha sobrepasado el máximo de pruebas de esta sesión");
            return false;
        }
        //2.- ver si paso el número máximo de pruebas por torneo
        var PruebasTotales = parseInt($("#PruebasTotales").text(), 10);
        var inscripciontotal = parseInt($("#inscripciontotal").text(), 10);
        inscripciontotal += 1;

        if (inscripciontotal > PruebasTotales) {
            MostrarError("Ha sobrepasado el máximo de pruebas por torneo");
            return false;
        }
        //3.- ver si pasó el máximo de pruebas con marca  inscripcionPruebasSinMarca
        if (!cumple) {
            var inscripcionPruebasSinMarca = parseInt($("#inscripcionPruebasSinMarca").text(), 10);
            var MaximoSinMarca = parseInt($("#MaximoSinMarca").text(), 10);

            inscripcionPruebasSinMarca += 1;

            if (inscripcionPruebasSinMarca > MaximoSinMarca) {
                MostrarError("No se puede inscribir en pruebas que sean mejores que la marca mínima");
                return false;
            }
            $("#inscripcionPruebasSinMarca").text(inscripcionPruebasSinMarca);
        }
        $("#inscrito" + sesion).text(inscrito);
        $("#inscripciontotal").text(inscripciontotal);

        resultado = true;
        return resultado;
    }

    function CompararConLarga(fila) {

    }

    function DeSeleccionarPrueba(fila, cumple) {
        var tiempo = ConvertirASegundos(fila[5]); //recuerda que el indice empieza en el cero
        var largas = ConvertirASegundos(fila[7]);
        var corta = ConvertirASegundos(fila[8]);
        var piscina = $("#Piscina").text();
        var resultado = false;


        var prueba = fila[1];
        var sesion = fila[0];


        //1.- Quitar una unidad a inscrito de la sesión
        var inscrito = parseInt($("#inscrito" + sesion).text(), 10);
       
        inscrito -= 1;
        if (inscrito < 0) {
            inscrito = 0;
        }
        $("#inscrito" + sesion).text(inscrito);
        //2.- Quitar una unidad a la inscripción total
         var inscripciontotal = parseInt($("#inscripciontotal").text(), 10);
        inscripciontotal -= 1;

        if (inscripciontotal <0) {
            inscripciontotal = 0;
        }
        $("#inscripciontotal").text(inscripciontotal);

        //3.- Quitar una unidad a pruebas sin marca
        if (!cumple)
        {
            var InscritosSinMarca = parseInt($("#InscritosSinMarca").text(), 10);
            //var MaximoSinMarca = parseInt($("#MaximoSinMarca").text(), 10);

            InscritosSinMarca -= 1;
            if (InscritosSinMarca <0) {
                InscritosSinMarca = 0;
            }
           
          

            var inscripcionPruebasSinMarca = parseInt($("#inscripcionPruebasSinMarca").text(), 10);

            inscripcionPruebasSinMarca -= 1;
            if (inscripcionPruebasSinMarca <0)
            {
                inscripcionPruebasSinMarca = 0;
            }

            $("#inscripcionPruebasSinMarca").text(inscripcionPruebasSinMarca);;


            
        }
      
        resultado = true;
        return resultado;
    }



    function ConvertirASegundos(tiempo) {
        var segundos;

        $.ajax({
            type: 'POST',
            url: ('JsonConvertirASegundos'),
            async: false,
            dataType: 'text json',
            data: { tiempo },   
            success: function (data) {
               
                segundos = data;
            },
           
        })
        return segundos
    };


    function MostrarError(mensaje) {
        setTimeout(function () {
            Command: toastr["error"](mensaje)
           toastr.options = {
               closeButton: false,
               progressBar: true,
               showMethod: 'slideDown',
               timeOut: 6000
           };
        
        }, 1300);
    }

    function MostrarMensaje(mensaje) {
        setTimeout(function () {
            Command: toastr["success"](mensaje)
          toastr.options = {
              closeButton: false,
              progressBar: true,
              showMethod: 'slideDown',
              timeOut: 1300
          };    
           

        }, 1300);
    }

    function MostrarAvisoInicial(mensaje) {
        setTimeout(function () {
            Command: toastr["info"](mensaje)
           toastr.options = {
               "closeButton": false,
               "debug": false,
               "newestOnTop": false,
               "progressBar": true,
               "positionClass": "toast-top-right",
               "preventDuplicates": false,
               "onclick": null,
               "showDuration": "300",
               "hideDuration": "1000",
               "timeOut": "5000",
               "extendedTimeOut": "1000",
               "showEasing": "swing",
               "hideEasing": "linear",
               "showMethod": "fadeIn",
               "hideMethod": "fadeOut"
           };
         

        }, 0);
    }
    
    //********************** esto se usa en el controlador entrenadores *************************

    //************* Agregar entrenador **************
    $(document).on("click", ".agregarentrenador", function (e) {

        //alert(table.rows('.selected').data().length + ' row(s) selected');
        var EntrenadorId = $(e.target).data('entrenadorid');
        var MeetId = $(e.target).data('meetid');
        $.ajax({
            url: '/Entrenador/InscribirEntrenador',
            type: 'GET',
            contentType: 'application/json; charset=utf-8',
            dataType: 'html',
            data: { 'EntrenadorId': EntrenadorId, 'MeetId': MeetId },
            async: false,
            success: function (result) {
                if(result==='"OK"')
                {
                    $.ajax({
                        url: '/Entrenador/ListarEntrenadores',
                        type: 'GET',
                        contentType: 'application/json; charset=utf-8',
                        dataType: 'html',
                        data: { 'MeetId': MeetId },
                        success: function (data) {
                            var EntrenadoresYaInscritos = $("#EntrenadoresYaInscritos")
                            EntrenadoresYaInscritos.html(data);
                        }
                    });
                }
                
            },
        });
    });

    $(document).on("click", ".retirarentrenador", function (e) {

        //alert(table.rows('.selected').data().length + ' row(s) selected');
        var EntrenadorId = $(e.target).data('entrenadorid');
        var MeetId = $(e.target).data('meetid');
        $.ajax({
            url: '/Entrenador/RetirarEntrenador',
            type: 'GET',
            contentType: 'application/json; charset=utf-8',
            dataType: 'html',
            data: { 'EntrenadorId': EntrenadorId, 'MeetId': MeetId },
            async: false,
            success: function (result) {
                if (result === '"OK"') {
                    $.ajax({
                        url: '/Entrenador/ListarEntrenadores',
                        type: 'GET',
                        contentType: 'application/json; charset=utf-8',
                        dataType: 'html',
                        data: { 'MeetId': MeetId },
                        success: function (data) {
                            var EntrenadoresYaInscritos = $("#EntrenadoresYaInscritos")
                            EntrenadoresYaInscritos.html(data);
                        }
                    });
                }
            },
        });
    });


    //*************************Esto es para CRUD de delegados *************************
    $(document).on("click", "#AgregarDelegado", function (e) {

        //alert(table.rows('.selected').data().length + ' row(s) selected');
        var Nombre = $("#Nombre").val();
        var Apellido = $("#Apellido").val();
        var MeetId = document.getElementById("ID").innerHTML;
       
        $.ajax({
            url: '/Entrenador/IngresarNuevoDelegado',
            type: 'GET',
            contentType: 'application/json; charset=utf-8',
            dataType: 'html',
            data: { 'Nombre': Nombre, 'Apellido': Apellido, 'Meetid': MeetId },
            async: false,
            success: function (result) {
                if (result === '"OK"') {
                    $.ajax({
                        url: '/Entrenador/ListadoDeDelegados',
                        type: 'GET',
                        contentType: 'application/json; charset=utf-8',
                        dataType: 'html',
                        data: { 'MeetId': MeetId },
                        success: function (data) {
                            var DelegadosYaInscritos = $("#DelegadosYaInscritos")
                            DelegadosYaInscritos.html(data);
                        }
                    });
                    $.ajax({
                        url: '/Entrenador/FormularioDelegados',
                        type: 'GET',
                        contentType: 'application/json; charset=utf-8',
                        dataType: 'html',
                        
                        success: function (data) {
                            var FormularioDelegados = $("#FormularioDelegados")
                            FormularioDelegados.html(data);
                        }
                    });
                }
            },
        });
    });

    $(document).on("click", ".retirardelegado", function (e) {

        //alert(table.rows('.selected').data().length + ' row(s) selected');
        var delegadoid = $(e.target).data('delegadoid');
        var MeetId = document.getElementById("ID").innerHTML;
        $.ajax({
            url: '/Entrenador/RetirarDelegado',
            type: 'GET',
            contentType: 'application/json; charset=utf-8',
            dataType: 'html',
            data: { 'delegadoid': delegadoid, 'MeetId': MeetId },
            async: false,
            success: function (result) {
                if (result === '"OK"') {
                    $.ajax({
                        url: '/Entrenador/ListadoDeDelegados',
                        type: 'GET',
                        contentType: 'application/json; charset=utf-8',
                        dataType: 'html',
                        data: { 'MeetId': MeetId },
                        success: function (data) {
                            var DelegadosYaInscritos = $("#DelegadosYaInscritos")
                            DelegadosYaInscritos.html(data);
                        }
                    });                   
                }
            },
        });
    });

    //***************************exportar los delegados y entreandores *****************
    $(document).on("click", "#btnExportarDelegados", function (e)   
    {
        var MeetId = $(e.target).data('meetid');
        $.ajax({
            url: '../Exportar/ExportarEntrenadoresyDelegados',
            type: 'POST',
            //dataType: 'JsonSendAfiliar',
            data: { MeetId: MeetId },
            async: false,
            success: function (data) {
                //var response = JSON.parse(data);
                var path = '/Exportar/Download?fileGuid=' + data.FileGuid + '&filename=' + data.FileName;
                window.location = path;
            },
        });
    });
}); 