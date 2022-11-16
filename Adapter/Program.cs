using System;
namespace AdapterExample
{
    // Система, яку адаптуватимемо
    class OldElectricitySystem
    {
        public string MatchThinSocket()
        {
            return "old system";
        }
    }

    // Система, яку намагатимемся адаптувати...
    class DangerousElectricitySystem
    {
        public string MatchUnreliableSocket()
        {
            // працює fifty-fifty
            return DateTime.Now.Second % 2 == 0 ? "unreliable (yet still working) system" : "BOOM!!!";
        }
    }
    
    // Широковикористовуваний інтерфейс нової системи (специфікація до квартири)
    interface INewElectricitySystem
    {
        string MatchWideSocket();
    }

    // Ну і власне сама розетка у новій квартирі
    class NewElectricitySystem : INewElectricitySystem
    {
        public string MatchWideSocket()
        {
            return "new interface";
        }
    }
    
    // Адаптер назовні виглядає як нові євророзетки, шляхом наслідування прийнятного у 
    // системі інтерфейсу
    class OldSystemAdapter : INewElectricitySystem
    {
        // Але всередині він старий
        private readonly OldElectricitySystem _adaptee;
        public OldSystemAdapter(OldElectricitySystem adaptee)
        {
            _adaptee = adaptee;
        }

        // А тут відбувається вся магія: наш адаптер «перекладає»
        // функціональність із нового стандарту на старий
        public string MatchWideSocket()
        {
            // Якщо б була різниця 
            // то тут ми б помістили трансформатор
            return _adaptee.MatchThinSocket();
        }
    }
    
    class DangerousSystemAdapter : INewElectricitySystem
    {
        private readonly DangerousElectricitySystem _adaptee;
        public DangerousSystemAdapter(DangerousElectricitySystem adaptee)
        {
            _adaptee = adaptee;
        }

        public string MatchWideSocket()
        {
            return _adaptee.MatchUnreliableSocket();
        }
    }

     class  ElectricityConsumer
    {
        // Зарядний пристрій, який розуміє тільки нову систему
        public static void ChargeNotebook(INewElectricitySystem electricitySystem)
        {
            Console.WriteLine(electricitySystem.MatchWideSocket());
        }
    }

    public class AdapterDemo
    {
        static void Main()
        {
            // 1) Ми можемо користуватися новою системою без проблем
            var newElectricitySystem = new NewElectricitySystem();
            ElectricityConsumer.ChargeNotebook(newElectricitySystem);
            // 2) Адаптуємося до старої системи, використовуючи адаптер
            var oldElectricitySystem = new OldElectricitySystem();
            var adapter1 = new OldSystemAdapter(oldElectricitySystem);
            ElectricityConsumer.ChargeNotebook(adapter1); 
            // 2) Адаптуємося до ненадійної системи, використовуючи адаптер
            var dangerousElectricitySystem = new DangerousElectricitySystem();
            var adapter2 = new DangerousSystemAdapter(dangerousElectricitySystem);
            ElectricityConsumer.ChargeNotebook(adapter2); 
            
            Console.ReadKey();
        }
    }
}
