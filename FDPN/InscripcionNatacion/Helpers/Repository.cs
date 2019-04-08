using FDPN.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InscripcionNatacion.Helpers
{
    public class Repository
    {
        public bool validarUsuario()
        {
            if (HttpContext.Current.Session["Rol"] != null)
            {
                Rol rol = HttpContext.Current.Session["Rol"] as Rol;

                return (rol.Rol1 == "fdpn" || rol.Rol1 == "meet" || rol.Rol1 == "admin" || rol.Rol1 == "entre" || rol.Rol1 == "secre");
            }
            return false;
        }

        public bool validarMeet()
        {
            if (HttpContext.Current.Session["Rol"] != null)
            {
                Rol rol = HttpContext.Current.Session["Rol"] as Rol;

                return (rol.Rol1 == "meet" ||  rol.Rol1 == "admin");
            }
            return false;
        }
    }
}