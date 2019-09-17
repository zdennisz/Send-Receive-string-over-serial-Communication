using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SendDataOverCom
{
    class Program
    {
        static void Main(string[] args)
        {

            SerialPort s1=new SerialPort();
            string strTosend= "Helo";

            byte[] arrayTosend = Encoding.ASCII.GetBytes(strTosend);
            s1.PortName = "COM3";
            s1.Parity = Parity.None;
            s1.BaudRate = 2400;
            s1.DataBits = 8;
            s1.StopBits =StopBits.One;
            s1.Handshake = Handshake.None;

            while (true)
            {
                try
            {

                if (!s1.IsOpen)
                {
                    s1.Open();
                }
                    s1.Write(arrayTosend, 0, arrayTosend.Length);
                    Console.WriteLine("Sending Data...");
                    Thread.Sleep(2500);
                } catch(Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                Console.ReadKey();
                s1.Close();
            }
                
            }
        }
    }
}
