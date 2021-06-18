using System;
using System.Collections.Generic;
using System.Text;

using ESCPOS_NET;
using ESCPOS_NET.Emitters;
using ESCPOS_NET.Utilities;
using Xamarin.Essentials;
using XamarinThermalPrintArabic.Models;

namespace XamarinThermalPrintArabic.Services
{
    public class Print 
    {
    
        public bool PrinterTestPage(string ipAddress, int poty)
        {
            NetworkPrinter printer ;
            try
            {

                printer = new NetworkPrinter(ipAddress, poty, true);

                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                ;
                var e = new EPSON();
                
                e.CodePage(CodePage.WPC1256_ARABIC);
                Encoding enc = Encoding.GetEncoding(1256);
                printer.Write(
                    ByteSplicer.Combine(
                        e.CodePage(CodePage.WPC1256_ARABIC),
                        e.CenterAlign(),
                        //    e.PrintImage(File.ReadAllBytes("images/pd-logo-300.png"), true),

                        //e.SetBarcodeHeightInDots(360),
                        //e.SetBarWidth(BarWidth.Default),
                        //e.SetBarLabelPosition(BarLabelPrintPosition.None),
                        //e.PrintBarcode(BarcodeType.ITF, "0123456789"),
                        e.PrintLine(" Test Page See the Arabic text Below"),
                  
                        enc.GetBytes("طباعة صفحة إختبار "),
                        e.PrintLine("\x1D\x56\x42\x00")

                    ));

                printer.Dispose();
                
                return true;
            }
            catch (Exception exception)
            {
                
                return false;
              
            }
        }


    }
}
