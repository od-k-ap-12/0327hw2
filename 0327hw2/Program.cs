using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0327hw2
{
    public class CDROM
    {
        public void Start()
        {
            Console.WriteLine("Запуск");
        }
        public void Check()
        {
            Console.WriteLine("Проверка наличия дисков");
        }
        public void Stop()
        {
            Console.WriteLine("Вернуть в исходную позицию");
        }
    }
    public class GraphicsCard
    {
        public void Start()
        {
            Console.WriteLine("Запуск");
        }
        public void Check()
        {
            Console.WriteLine("Проверка связи с монитором");
        }
        public void PrintRAMInfo()
        {
            Console.WriteLine("Вывод информации об оперативной памяти");
        }
        public void PrintHDDInfo()
        {
            Console.WriteLine("Вывод информации о винчестере");
        }
        public void PrintCDROMInfo()
        {
            Console.WriteLine("Вывод информации об устройстве чтения дисков");
        }
        public void PrintGoodbye()
        {
            Console.WriteLine("Вывод прощального сообщения");
        }
    }

    public class HDD
    {
        public void Start()
        {
            Console.WriteLine("Запуск");
        }
        public void Check()
        {
            Console.WriteLine("Проверка загрузочного сектора");
        }
        public void Stop()
        {
            Console.WriteLine("Остановка устройства");
        }
    }
    public class Sensors
    {
        public void CheckVoltage()
        {
            Console.WriteLine("Проверить напряжение");
        }
        public void CheckTempPowerUnit()
        {
            Console.WriteLine("Проверить температуру в блоке питания");
        }
        public void CheckTempGraphicsCard()
        {
            Console.WriteLine("Проверить температуру в видеокарте");
        }
        public void CheckTempRAM()
        {
            Console.WriteLine("Проверить температуру в оперативной памяти");
        }
        public void CheckTempAll()
        {
            Console.WriteLine("Проверить температуру всех систем");
        }
    }

    public class PowerUnit
    {
        public void Power()
        {
            Console.WriteLine("Подать питание");
        }
        public void GraphicsCardPower()
        {
            Console.WriteLine("Подать питание на видеокарту");
        }
        public void RAMPower()
        {
            Console.WriteLine("Подать питание на оперативную память");
        }
        public void CDROMPower()
        {
            Console.WriteLine("Подать питание на устройство чтения дисков");
        }
        public void HDDPower()
        {
            Console.WriteLine("Подать питание на винчестер");
        }
        public void GraphicsCardPowerStop()
        {
            Console.WriteLine("Прекратить питание на видеокарту");
        }
        public void RAMPowerStop()
        {
            Console.WriteLine("Прекратить питание на оперативную память");
        }
        public void CDROMPowerStop()
        {
            Console.WriteLine("Прекратить питание на устройство чтения дисков");
        }
        public void HDDPowerStop()
        {
            Console.WriteLine("Прекратить питание на винчестер");
        }
        public void PowerStop()
        {
            Console.WriteLine("Выключение");
        }
    }

    public class RAM
    {
        public void Start()
        {
            Console.WriteLine("Запуск");
        }
        public void Analysis()
        {
            Console.WriteLine("Анализ памяти");
        }
        public void Erase()
        {
            Console.WriteLine("Очистка памяти");
        }

    }
    public class PCFacade
    {
        protected CDROM CDROM;
        protected Sensors Sensors;
        protected PowerUnit PowerUnit;
        protected RAM RAM;
        protected GraphicsCard GraphicsCard;
        protected HDD HDD;

        public PCFacade(CDROM _CDROM, Sensors _Sensors, PowerUnit _PowerUnit, RAM _RAM, GraphicsCard _GraphicsCard, HDD _HDD)
        {
            CDROM = _CDROM;
            Sensors = _Sensors;
            PowerUnit = _PowerUnit;
            RAM = _RAM;
            GraphicsCard = _GraphicsCard;
            HDD = _HDD;
        }

        public void StartPC()
        {
            PowerUnit.Power();
            Sensors.CheckVoltage();
            Sensors.CheckTempPowerUnit();
            Sensors.CheckTempGraphicsCard();
            PowerUnit.GraphicsCardPower();
            GraphicsCard.Start();
            GraphicsCard.Check();
            Sensors.CheckTempRAM();
            PowerUnit.RAMPower();
            RAM.Start();
            RAM.Analysis();
            GraphicsCard.PrintRAMInfo();
            PowerUnit.CDROMPower();
            CDROM.Start();
            CDROM.Check();
            GraphicsCard.PrintCDROMInfo();
            PowerUnit.HDDPower();
            HDD.Start();
            HDD.Check();
            GraphicsCard.PrintHDDInfo();
            Sensors.CheckTempAll();

        }
        public void ShutdownPC()
        {
            HDD.Stop();
            RAM.Erase();
            RAM.Analysis();
            GraphicsCard.PrintGoodbye();
            CDROM.Stop();
            PowerUnit.CDROMPowerStop();
            PowerUnit.RAMPowerStop();
            PowerUnit.HDDPowerStop();
            PowerUnit.GraphicsCardPowerStop();
            Sensors.CheckVoltage();
            PowerUnit.PowerStop();
        }
    }

    class Client
    {
        public static void StartPC(PCFacade facade)
        {
            facade.StartPC();
        }
        public static void ShutdownPC(PCFacade facade)
        {
            facade.ShutdownPC();
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
