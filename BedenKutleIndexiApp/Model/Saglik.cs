using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BedenKutleIndexiApp.Model
{
    public class Saglik
    {
        public decimal Boy { get; set; }
        public decimal Kilo { get; set; }
        public string Cinsiyet { get; set; }
        public int Yas { get; set; }
    }
}