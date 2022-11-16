using System;

namespace AbstractFactory
{
    // AbstractProductA
    public abstract class Car
    {
        public abstract void Info();
        public void Interact(Engine engine, Transmission transmission)
        {
            Info();
            Console.Write("Engine: ");
            engine.GetPower();
            Console.Write("Transmission: ");
            transmission.SetGear();
            
        }
    }

    // ConcreteProductA1
    public class Ford : Car
    {
        public override void Info()
        {
            Console.WriteLine("Ford");
        }
    }

    // ConcreteProductA2
    public class Toyota : Car
    {
        public override void Info()
        {
            Console.WriteLine("Toyota");
        }
    }
    
    // ConcreteProductA3
    public class Mercedes : Car
    {
        public override void Info()
        {
            Console.WriteLine("Mercedes");
        }
    }

    // AbstractProductB
    public abstract class Engine
    {
        public virtual void GetPower()
        {
        }
    }

    // ConcreteProductB1
    public class FordEngine : Engine
    {
        public override void GetPower()
        {
            Console.WriteLine("Ford Engine");
        }
    }

    // ConcreteProductB2
    public class ToyotaEngine : Engine
    {
        public override void GetPower()
        {
            Console.WriteLine("Toyota Engine");
        }
    }
    
    // ConcreteProductB3
    public class MercedesEngine : Engine
    {
        public override void GetPower()
        {
            Console.WriteLine("Mercedes Engine");
        }
    }
    
    // AbstractProductC
    public abstract class Transmission
    {
        public virtual void SetGear()
        {
        }
    }

    // ConcreteProductС1
    public class FordTransmission : Transmission
    {
        public override void SetGear()
        {
            Console.WriteLine("Ford C6 Transmission");
        }
    }

    //ConcreteProductС2
    public class ToyotaTransmission : Transmission
    {
        public override void SetGear()
        {
            Console.WriteLine("Toyota RA-series Transmission");
        }
    }
    
    //ConcreteProductС3
    public class MercedesTransmission : Transmission
    {
        public override void SetGear()
        {
            Console.WriteLine("Mercedes-Benz 7G-Tronic Transmission");
        }
    }

    // AbstractFactory
    public interface ICarFactory
    {
        Car CreateCar();
        Engine CreateEngine();
        Transmission CreateTransmission();
    }

    // ConcreteFactory1
    public class FordFactory : ICarFactory
    {
        // from CarFactory
        Car ICarFactory.CreateCar()
        {
            return new Ford();
        }

        Engine ICarFactory.CreateEngine()
        {
            return new FordEngine();
        }

        public Transmission CreateTransmission()
        {
            return new FordTransmission();
        }
    }

    // ConcreteFactory2
    public class ToyotaFactory : ICarFactory
    {
        // from CarFactory
        Car ICarFactory.CreateCar()
        {
            return new Toyota();
        }

        Engine ICarFactory.CreateEngine()
        {
            return new ToyotaEngine();
        }

        public Transmission CreateTransmission()
        {
            return new ToyotaTransmission();
        }
    }

    // ConcreteFactory3
    public class MercedesFactory : ICarFactory
    {
        // form CarFactory
        Car ICarFactory.CreateCar()
        {
            return new Mercedes();
        }

        Engine ICarFactory.CreateEngine()
        {
            return new MercedesEngine();
        }

        public Transmission CreateTransmission()
        {
            return new MercedesTransmission();
        }
    }

    public class ClientFactory
    {
        private Car car;
        private Engine engine;
        private Transmission transmission;

        public ClientFactory(ICarFactory factory)
        {
            //Абстрагування процесів інстанціювання
            car = factory.CreateCar();
            engine = factory.CreateEngine();
            transmission = factory.CreateTransmission();
        }

        public void Run()
        {
            Console.WriteLine();
            //Абстрагування варіантів використання
            car.Interact(engine, transmission);
        }
    }

    class AbstractFactoryApp
    {
        static void Main(string[] args)
        {
            ICarFactory carFactory = new ToyotaFactory();
            ClientFactory client1 = new ClientFactory(carFactory);
            client1.Run();

            carFactory = new FordFactory();
            ClientFactory client2 = new ClientFactory(carFactory);
            client2.Run();
            
            carFactory = new MercedesFactory();
            ClientFactory client3 = new ClientFactory(carFactory);
            client3.Run();

            Console.ReadKey();
        }
    }
}
