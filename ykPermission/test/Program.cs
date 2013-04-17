using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            string FruitName = Console.ReadLine();
            IFruit MyFruit = null;
            FruitFactory MyFruitFactory = new FruitFactory();

            switch (FruitName)
            {
                case "Orange":
                    MyFruit = MyFruitFactory.MakeOrange();
                    break;
                case "Apple":
                    MyFruit = MyFruitFactory.MakeApple();
                    break;
                default:
                    break;
            }
            Console.ReadLine();
        }
    }
    //水果接口
    public interface IFruit
    {
    }
    //橙子
    public class Orange : IFruit
    {
        public Orange()
        {
            Console.WriteLine("An orange is got!");
        }
    }
    //苹果
    public class Apple : IFruit
    {
        public Apple()
        {
            Console.WriteLine("An apple is got!");
        }
    }
    //工厂
    public class FruitFactory
    {
        public Orange MakeOrange()
        {
            return new Orange();
        }
        public Apple MakeApple()
        {
            return new Apple();
        }
    }
}
