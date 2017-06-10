using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GestorONG.DataModel;
using System.Web.Mvc;

namespace GestorONG.ViewModel
{
    public class VoluntariosViewModel
    {
        public voluntario vol { get; set; }
        public IEnumerable<SelectListItem> delegacion { get; set; }
    }
}