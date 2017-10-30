using FDPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDPN.ViewModels.Shared
{
    public class IndexViewModels
    {
     public   List<RESULTS> resultado { get; set; }
     public   List<RESULTS> destacados { get; set; }
     public   List<Calendario> calendario { get; set; }


    }
}