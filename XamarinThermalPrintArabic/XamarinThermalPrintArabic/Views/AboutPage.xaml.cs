using System;
using System.ComponentModel;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinThermalPrintArabic.Services;

namespace XamarinThermalPrintArabic.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            Print print = new Print();

            string PrinterIp = "192.168.8.111"; //Preferences.Get("PrinterIp", "");
            if (print.PrinterTestPage(PrinterIp, 9100))
            {
                DisplayAlert("نجاح العملية", "تم إرسال صفحة إختبار الي الطابعة الرجاء التحقق منها  " + PrinterIp, "OK");

            }
            else
            {
                DisplayAlert("فشل العملية", "الرجاء التحقق من اتصال الشبكة بالطابعة او من عنوان الطابعة   " + PrinterIp,
                    "OK");

            }
        }
    }
}