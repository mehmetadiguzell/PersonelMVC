
using PersonelMVC.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonelMVC.ViewModels
{
    public class PersonelFormViewModel
    {
       public IEnumerable<Departman> Departmanlar { get; set; } //departmanların liste şeklinde kullanılması

       public Personel Personel{ get; set; }
    }
}