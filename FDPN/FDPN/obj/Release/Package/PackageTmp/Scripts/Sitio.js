 $(document).ready(function(){
 
            // cada vez que se mueva el scroll del navegador se ejecutara
            // este evento
            $(document).scroll(function(){
 
                // si la posicion del scroll es superior a 55 pixels...
                if($(window).scrollTop()>45)
                {
                    // indicamos que el header tiene una posicion fija a -47 pixels
                    $("navBar").css({"position":"fixed", "top":-47});
                    // definimos el margen superior al contenido cuando queda fijado
                    $("container").css({"margin-top":80});
                }else{
                    $("navBar").css({"position":"inherit", "top":"inherit"});
                    $("container").css({"margin-top":0});
                }
            });
});

 $('#example tbody').on('click', 'tr', function () {
     $(this).toggleClass('selected');
 });