using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoChemistry.Library;

namespace PhotoChemistry.Application
{
    public static class Program
    {
        public static void Main()
        {
            SerialPort p = new SerialPort("COM6", 9600);
            p.Open();
            if (p.IsOpen)
            {
                Console.WriteLine("Connection established.");
            }
            p.WriteLine("0,0,0,");
            while (true)
            {
                Console.Write("Enter a wavelength: ");
                string input = Console.ReadLine();
                double wavelength = double.Parse(input);
                byte[] rgb = WavelengthToRgbCalculator.Calc(wavelength);
                StringBuilder sb = new StringBuilder();
                foreach (byte b in rgb)
                {
                    sb.Append($"{b},");
                }
                Debug.WriteLine($"Writing {sb}");
                p.WriteLine(sb.ToString());
            }
        }
    }
}