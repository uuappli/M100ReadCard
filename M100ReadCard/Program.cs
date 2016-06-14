using System;
using System.IO;

namespace M100ReadCard
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ReadCardBusiness readCardBusiness = new ReadCardBusiness();
                string cardid = readCardBusiness.ReadCard();
                //string cardid = "131313123";

                string current = Directory.GetCurrentDirectory() + "/ReadCard.ini";//获取当前根目录
                INIClass inic = new INIClass(current);
                inic.IniWriteValue("ReadCardInfo", "ReadTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                inic.IniWriteValue("ReadCardInfo", "CardNo", cardid);
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }           
    }
}
