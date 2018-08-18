using FDPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDPN.ViewModels.Masters
{
    public class NadadoresMastersOrdenadosViewModel
    {
        public List<String> alphabet { get; set; }
        public PagedList.IPagedList<AthleteMasters> nadadores { get; set; }
    }
}