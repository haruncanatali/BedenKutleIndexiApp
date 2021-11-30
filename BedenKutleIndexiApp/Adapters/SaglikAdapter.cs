using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using BedenKutleIndexiApp.Model;

namespace BedenKutleIndexiApp.Adapters
{
    public class SaglikAdapter : BaseAdapter<Saglik>
    {
        private Context context;
        private List<Saglik> saglikList;

        public SaglikAdapter(Context context, List<Saglik> saglikList)
        {
            this.context = context;
            this.saglikList = saglikList;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View? GetView(int position, View? convertView, ViewGroup? parent)
        {
            View v = convertView;
            v = LayoutInflater.From(context).Inflate(Resource.Layout.sonuc_satir, null, false);

            TextView bedenKutleIndexiControl = v.FindViewById<TextView>(Resource.Id.kutleIndexiTxt);
            TextView sonucControl = v.FindViewById<TextView>(Resource.Id.sonucTxt);

            bedenKutleIndexiControl.Text = VucutKitleIndexiHesaplama(double.Parse(saglikList[position].Boy.ToString()),
                double.Parse(saglikList[position].Kilo.ToString())).ToString("0.00") + " kg/metrekare";
            sonucControl.Text = SonucHesapla(VucutKitleIndexiHesaplama(double.Parse(saglikList[position].Boy.ToString()), double.Parse(saglikList[position].Kilo.ToString())));


            return v;
        }

        private string SonucHesapla(double bki)
        {
            if (bki<20)
            {
                return "Zayıfsınız.";
            }
            else if (bki>= 20 && bki <=25)
            {
                return "Normalsiniz.";
            }
            else if (bki > 25 && bki <= 30)
            {
                return "Fazla kilolusunuz.";
            }
            else if (bki > 30)
            {
                return "Obezsiniz.";
            }
            else
            {
                return null;
            }
        }

        private double IdealKiloHesapla(double boy, int yas,string cinsiyet)
        {
            if (cinsiyet == "Erkek")
            {
                return (boy - 100 + yas / 10) * 0.9;
            }
            else if (cinsiyet == "Kadın")
            {
                return (boy - 100 + yas / 10) * 0.8;
            }
            else
            {
                return 0;
            }
        }

        private double YagsizKiloHesapla(string cinsiyet, double boy, double kilo, int yas)
        {
            if (cinsiyet == "Erkek")
            {
                return kilo - ((1.39 * VucutKitleIndexiHesaplama(boy, kilo)) + (0.16 * yas) - (10.34 * 1) - 9);
            }
            else if (cinsiyet == "Kadın")
            {
                return kilo - ((1.39 * VucutKitleIndexiHesaplama(boy, kilo)) + (0.16 * yas) - (10.34 * 0) - 9);
            }
            else
            {
                return 0;
            }
        }

        private double VucutKitleIndexiHesaplama(double boy, double kilo)
        {
            return kilo / Math.Pow(boy, 2);
        }

        private double YuzeyAlaniHesapla(double boy, double kilo)
        {
            return Math.Pow((boy * kilo / 360), (0.5));
        }

        public override int Count
        {
            get { return saglikList.Count(); }
        }

        public override Saglik this[int position]
        {
            get { return saglikList[position]; }
        }
    }
}