using NuevaInscripcionATorneos.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NuevaInscripcionATorneos.SessionState
{
    public class UsuarioState
    {
        private readonly ServicePrincipal servicio;

        public UsuarioState(ServicePrincipal usuarioservice)
        {
            servicio = usuarioservice;
        }

        public string Rol { get; set; } = "";

        public string Iniciales { get; set; } = "";
        public int usuarioid { get; set; } = 0;
        public event EventHandler StateChanged; private void StateHasChanged()
        {
            // This will update any subscribers
            // that the counter state has changed
            // so they can update themselves
            // and show the current counter value
            StateChanged?.Invoke(this, EventArgs.Empty);
        }

            public void SetDatosLogged(string _Rol, int _usuarioid,  string _Iniciales)
            {

                Rol = _Rol;
                Iniciales = _Iniciales;
                usuarioid = _usuarioid;
                StateHasChanged();
            }

    }
}
