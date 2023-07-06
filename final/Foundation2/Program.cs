using System;
class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        string filename = "CustomerInfoCSV.txt";
        //Grab orders from csv file and assign to a list of orders
        List<Order> orders = new List<Order>();
        FileHandler filehandler = new FileHandler(filename);
        orders = filehandler.GetOrders();

        //Display Packing Label, Shipping Label, and Payment info
        DisplayLabels(orders);
    }
    static void DisplayLabels(List<Order> orders){
        int orderNum = 0;
        foreach (Order o in orders){
            orderNum +=1;
            Console.WriteLine("\n");
            //Console.WriteLine("=================================================================");
            Console.WriteLine($"Order Number: {orderNum}");
            //step through all packinglabels to print off
            List<string> packingLabels = o.GetPackingLabel();
            foreach (string p in packingLabels){
                Console.WriteLine($"{p}");
            }
            //Create Shipping Label
            Console.WriteLine(o.GetShippingLabel());
            //Create Payment info w/ totals + shipping
            Console.WriteLine(o.GetFinalBillLabel());
            Console.WriteLine("=================================================================");
        }
        Console.WriteLine();
    }
}