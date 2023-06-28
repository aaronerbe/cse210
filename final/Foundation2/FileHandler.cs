class FileHandler {
    private string _filename;
    private List<Order> _orders = new List<Order>();
    private string _csvDelimiter = "~~";
    public FileHandler(string filename){
        _filename = filename;
        ReadFile();
    }

    public void ReadFile(){
        //Read in a file containing the video title, author, length, and all comments with names of commenters.  
        //Format:  CustomerName~~CustomerAddress~~CustomerCountry~~Item1Name~~Item1ID~~Item1Price~~Item1Quantity
        using (StreamReader reader = new StreamReader(_filename)){
            //line is used to store each line in the csv
            string line;
            //lineList is used to store each entry on the line (seperated by delimiter)
            string[] lineList;

            //while not at the end of the file, read in a new line
            while ((line = reader.ReadLine()) != null){
                //then break up by delimiter and save in a list
                lineList = line.Split(_csvDelimiter);  

                //capture address and customer.  create classes.
                List<Product> products = new List<Product>();
                Address address = new Address(lineList[1]);//,lineList[2]);
                Customer customer = new Customer(lineList[0],address);

                //only proceed catching products if there are products (count > 2)
                if (lineList.Count()>2){
                    //step through from 2 + to capture each product
                    for (int i = 2; i< lineList.Count()-1; i++){
                        string ProductName = lineList[i];
                        string ProductID = lineList[i+1];
                        float ProductPrice = float.Parse(lineList[i+2]);
                        int ProductQuantity = int.Parse(lineList[i+3]);

                        //Add them to a product class
                        Product product = new Product(ProductName, ProductID, ProductPrice, ProductQuantity);
                        //Add the product class to a list of products
                        products.Add(product);
                        i+=3;
                    }
                }
                //take all the customer info and products ordered and put them in an order class
                Order order = new Order(products,customer);
                //Add that order to the list of Order classes
                _orders.Add(order);
            }
        }
    }
    public List<Order> GetOrders(){
        //simply return the orders
        return _orders;
    }
}