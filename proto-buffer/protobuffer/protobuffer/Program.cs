using System;
using System.IO;
using Google.Protobuf;

namespace protobuffer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //creating an instance of Popup
            Popup popup = new Popup
            {
                BackgroundColorTheme = "#5DADE2",
                EnableCancel = true,
                Id = 1,
                Message = "Welcome to this world!"
            };

            byte[] popupBytes;

            //write to a stream
            using(MemoryStream stream = new MemoryStream())
            {
                popup.WriteTo(stream);
                popupBytes = stream.ToArray();
            }

            var pop = Popup.Parser.ParseFrom(popupBytes);

            Console.WriteLine(pop.Message);

            //read from a stream of bytes
            using (Stream output = File.OpenWrite("data.data"))
            {
                popup.WriteTo(output);
            }




        }
    }
}
