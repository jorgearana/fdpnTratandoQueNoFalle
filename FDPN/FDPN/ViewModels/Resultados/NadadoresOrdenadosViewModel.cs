using FDPN.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDPN.ViewModels.Resultados
{
    public class NadadoresOrdenadosViewModel
    {
     
        public PagedList.IPagedList<Athlete> nadadores { get; set; }
    }
}