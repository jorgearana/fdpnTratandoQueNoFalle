using FDPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDPN.ViewModels.Masters
{
    public class TopRankingMastersViewModel
    {
        public List<RESULTSMasters> resultado { get; set; }
        public int maxima { get; set; }
        public int minima { get; set; }
    }
}