using System;
//TODO:  Need to provide cost information somewhere...?
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
        foreach (Order o in orders){
            Console.WriteLine();
            Console.WriteLine(o.GetShippingLabel());
            //step through all packinglabels to print off
            List<string> packingLabels = o.GetPackingLabel();
            foreach (string p in packingLabels){
                Console.WriteLine($"{p}");
            }
            //Create Payment info w/ totals + shipping
            Console.WriteLine(o.GetFinalBillLabel());
            Console.WriteLine("-------------------------------------------------------------------------");
        }
        Console.WriteLine();
    }
}