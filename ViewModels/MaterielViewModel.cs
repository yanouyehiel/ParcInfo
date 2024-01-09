using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcInfo.ViewModels
{
    public class MaterielViewModel : ViewModelBase
    {
        public MaterielViewModel() { }

        public string Nom { get; set; }
        public string DateMiseService { get; set; }
    }
}
