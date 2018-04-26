using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRegisterApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Dictionary<string,double>> items = new List<Dictionary<string, double>>();
            bool done = false;
            while (!done)
            {
                ListDict(items);

                Console.WriteLine("Please choose an option below" + Environment.NewLine);

                Console.Write("1. Add an item to the total" + Environment.NewLine);
                Console.Write("2. Void an item off the total" + Environment.NewLine);
                Console.Write("3. Quit" + Environment.NewLine);


                int.TryParse(Console.ReadLine(), out int input);

                switch (input)
                {
                    case 1:
                        items.Add(AddItem());
                        Console.WriteLine("Item Added");
                        Console.ReadLine();
                        break;

                    case 2:
                        try
                        {
                            items.RemoveAt(VoidItem(items));
                            Console.WriteLine("Item Removed");
                            Console.ReadLine();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("invalid input");
                        }

                        break;

                    case 3:
                        done = true;
                        break;

                    default:
                        Console.WriteLine("that is not an option; try again");
                        break;
                }



                Console.WriteLine();

                Console.WriteLine(input);


                Console.Clear();

            }
        }

        private static void ListDict(List<Dictionary<string, double>> items)
        {
            double val = 0;
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine((i + 1).ToString() + " " + items[i].Keys.First()+" "+items[i].Values.First().ToString());
                val += items[i].Values.First();
            }
            if (items.Count() != 0)
            {
                Console.WriteLine("TOTAL: " + val);
                Console.WriteLine();
            }
        }

        public static Dictionary<string, double> AddItem()
        {
            Console.WriteLine("enter the name of the item");
            var name = Console.ReadLine();
            Console.WriteLine("enter the price");
            double.TryParse(Console.ReadLine(), out double price);
            var dictOut = new Dictionary<string, double>();
            dictOut.Add(name, price);
            return dictOut;
        }
        public static int VoidItem(List<Dictionary<string,double>> dictIn)
        {
            bool ret = false;

            while (true)
            {

                Console.Clear();

                ListDict(dictIn);
                Console.WriteLine("0. CANCEL");
                Console.WriteLine();
                Console.WriteLine("Void which item?");

                int.TryParse(Console.ReadLine(), out int input);

                if (-1 < input && input < dictIn.Count+1)
                {
                    return input - 1;
                }
            }

        }
    }
}
