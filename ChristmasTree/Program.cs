using System;

namespace ChristmasTree
{
    internal class Program
    {
        protected static void Main()
        { 
            var myTree = new ChristmasTree();
            var lightsDecorator = new ChristmasLightsDecorator();
            var ornamentsDecorator = new ChristmasOrnamentsDecorator();
            
            lightsDecorator.SetComponent(myTree);
            ornamentsDecorator.SetComponent(lightsDecorator);
            
            lightsDecorator.AddChristmasLights();
            lightsDecorator.AddChristmasLights();
            ornamentsDecorator.HangSeveralOrnaments();
            ornamentsDecorator.HangSeveralOrnaments();
            ornamentsDecorator.HangSeveralOrnaments();

            ornamentsDecorator.DoSomeChristmas();

            Console.ReadKey();
        }
    }

    // Component
    abstract class ChristmasComponent
    {
        public abstract void DoSomeChristmas();
    }
    
    // Concrete component
    class ChristmasTree : ChristmasComponent
    {
        public override void DoSomeChristmas()
        {
            Console.WriteLine("This christmas tree is staggering!");
        }
    }

    // Decorator
    class ChristmasDecorator : ChristmasComponent
    {
        protected ChristmasComponent _component;

        public void SetComponent(ChristmasComponent component)
        {
            _component = component;
        }

        public override void DoSomeChristmas()
        {
            _component?.DoSomeChristmas();
        }
    }
    
    // Concrete decorator
    class ChristmasLightsDecorator : ChristmasDecorator
    {
        private int _numberOfLights = 0;

        public override void DoSomeChristmas()
        {
            base.DoSomeChristmas();

            if (_numberOfLights == 0)
            {
                Console.WriteLine("Shall we put some christmas lights on?");
            }
            else if (_numberOfLights < 10)
            {
                Console.WriteLine("The tree is shining!");
            }
            else
            {
                Console.WriteLine("The tree is probably burning!!!");
            }
        }

        public void AddChristmasLights()
        {
            ++_numberOfLights;
        }
    }
    
    // Concrete decorator
    class ChristmasOrnamentsDecorator : ChristmasDecorator
    {
        private int _numberOfOrnaments = 0;

        public override void DoSomeChristmas()
        {
            base.DoSomeChristmas();
            Console.WriteLine($"This tree has {_numberOfOrnaments} ornaments!");
        }

        public void HangSeveralOrnaments()
        {
            _numberOfOrnaments += 5;
        }
    }
}