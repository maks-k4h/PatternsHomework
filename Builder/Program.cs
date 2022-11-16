using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    class Program
    {
        class Pizza
        {
            string dough;
            string sauce;
            string topping;
            string boxing;
            public Pizza() { }
            public void SetDough(string d) { dough = d; }
            public void SetSauce(string s) { sauce = s; }
            public void SetTopping(string t) { topping = t; }
            public void SetBoxing(string b) { boxing = b; }
            public void Info()
            {
                Console.WriteLine("Dough: {0}\nSause: {1}\nTopping: {2}\nBoxing: {3}", dough, sauce, topping, boxing);
            }
        }

        //Abstract Builder
        abstract class PizzaBuilder
        {
            protected Pizza pizza;
            public PizzaBuilder() { }
            public Pizza GetPizza() { return pizza; }
            public void CreateNewPizza() { pizza = new Pizza(); }

            public abstract void BuildDough();
            public abstract void BuildSauce();
            public abstract void BuildTopping();
            public abstract void BuildBoxing();
        }
        //Concrete Builder
        class HawaiianPizzaBuilder : PizzaBuilder
        {
            public override void BuildDough() { pizza.SetDough("cross"); }
            public override void BuildSauce() { pizza.SetSauce("mild"); }
            public override void BuildTopping() { pizza.SetTopping("ham+pineapple"); }
            public override void BuildBoxing() { pizza.SetBoxing("standard"); }
        }
        //Concrete Builder
        class SpicyPizzaBuilder : PizzaBuilder
        {
            public override void BuildDough() { pizza.SetDough("pan baked"); }
            public override void BuildSauce() { pizza.SetSauce("hot"); }
            public override void BuildTopping() { pizza.SetTopping("pepparoni+salami"); }
            public override void BuildBoxing() { pizza.SetBoxing("standard"); }
        }
        //Concrete Builder
        class MargheritaPizzaBuilder : PizzaBuilder
        {
            public override void BuildDough() { pizza.SetDough("stretched"); }
            public override void BuildSauce() { pizza.SetSauce("sweet"); }
            public override void BuildTopping() { pizza.SetTopping("tomato+mozzarella+basil"); }
            public override void BuildBoxing() { pizza.SetBoxing("premium"); }
        }
        /** "Director" */
        class Waiter
        {
            private PizzaBuilder pizzaBuilder;
            public void SetPizzaBuilder(PizzaBuilder pb) { pizzaBuilder = pb; }
            public Pizza GetPizza() { return pizzaBuilder.GetPizza(); }
            public void ConstructPizza()
            {
                pizzaBuilder.CreateNewPizza();
                pizzaBuilder.BuildDough();
                pizzaBuilder.BuildSauce();
                pizzaBuilder.BuildTopping();
                pizzaBuilder.BuildBoxing();
            }
        }
        /** A customer ordering a pizza. */
        class BuilderExample
        {
            public static void Main(String[] args)
            {
                Waiter waiter = new Waiter();
                PizzaBuilder hawaiianPizzaBuilder = new HawaiianPizzaBuilder();
                PizzaBuilder spicyPizzaBuilder = new SpicyPizzaBuilder();
                PizzaBuilder margheritaPizzaBuilder = new MargheritaPizzaBuilder();

                waiter.SetPizzaBuilder(hawaiianPizzaBuilder);
                waiter.ConstructPizza();
                Console.WriteLine("\nHawaiian Pizza");
                Pizza hawaiianPizza = waiter.GetPizza();
                hawaiianPizza.Info();
                
                waiter.SetPizzaBuilder(spicyPizzaBuilder);
                waiter.ConstructPizza();
                Console.WriteLine("\nSpicy Pizza");
                Pizza spicyPizza = waiter.GetPizza();
                spicyPizza.Info();
                
                waiter.SetPizzaBuilder(margheritaPizzaBuilder);
                waiter.ConstructPizza();
                Console.WriteLine("\nMargherita Pizza");
                Pizza margheritaPizza = waiter.GetPizza();
                margheritaPizza.Info();

                Console.ReadKey();
            }
        }

    }
}
