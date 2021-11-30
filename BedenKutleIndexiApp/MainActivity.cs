using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Widget;
using BedenKutleIndexiApp.Adapters;
using BedenKutleIndexiApp.Model;

namespace BedenKutleIndexiApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Button hesaplaBtnControl = null, temizleBtnControl = null;
        private EditText yasTxtControl = null, kiloTxtControl = null, boyTxtControl = null;
        private RadioGroup cinsiyetRdgControl = null;
        private RadioButton erkekRdBtnControl = null, kadinRdBtnControl = null;
        private ListView sonucListViewControl = null;
        private List<Saglik> saglikList = null;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            Tanimla();
        }

        private void Tanimla()
        {
            hesaplaBtnControl = FindViewById<Button>(Resource.Id.hesaplaBtn);
            temizleBtnControl = FindViewById<Button>(Resource.Id.temizleBtn);
            yasTxtControl = FindViewById<EditText>(Resource.Id.yasTxt);
            kiloTxtControl = FindViewById<EditText>(Resource.Id.kiloTxt);
            boyTxtControl = FindViewById<EditText>(Resource.Id.boyTxt);
            cinsiyetRdgControl = FindViewById<RadioGroup>(Resource.Id.cinsiyetRdg);
            erkekRdBtnControl = FindViewById<RadioButton>(Resource.Id.erkekRdBtn);
            kadinRdBtnControl = FindViewById<RadioButton>(Resource.Id.kadinRdBtn);
            sonucListViewControl = FindViewById<ListView>(Resource.Id.sonucListView);

            hesaplaBtnControl.Click += HesaplaBtnControl_Click;
            temizleBtnControl.Click += TemizleBtnControl_Click;
        }

        private void TemizleBtnControl_Click(object sender, System.EventArgs e)
        {
            sonucListViewControl.Adapter = null;
            yasTxtControl.Text = "";
            kiloTxtControl.Text = "";
            boyTxtControl.Text = "";
            erkekRdBtnControl.Checked = false;
            kadinRdBtnControl.Checked = false;
        }

        private void HesaplaBtnControl_Click(object sender, System.EventArgs e)
        {
            sonucListViewControl.Adapter = null;
            string cinsiyet = "";

            if (cinsiyetRdgControl.CheckedRadioButtonId == erkekRdBtnControl.Id)
            {
                cinsiyet = "Erkek";
            }
            else if (cinsiyetRdgControl.CheckedRadioButtonId == kadinRdBtnControl.Id)
            {
                cinsiyet = "Kadın";
            }

            saglikList = new List<Saglik>();
            saglikList.Add(new Saglik
            {
                Boy = decimal.Parse(boyTxtControl.Text),
                Kilo = decimal.Parse(kiloTxtControl.Text),
                Yas = int.Parse(yasTxtControl.Text),
                Cinsiyet = cinsiyet
            });

            SaglikAdapter adapter = new SaglikAdapter(this, saglikList);
            sonucListViewControl.Adapter = adapter;
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}