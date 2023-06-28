class Order{
    private List<Product> _productsList = new List<Product>();
    private Customer _customer; // = new Customer();
    private bool _isUSAAddress = true;
    private float _sumOfProductPrices = 0;
    private float _shippingCost = 0;
    private float _totalPrice = 0;

    public Order(List<Product> productsList, Customer customer){
        _productsList = productsList;
        _customer = customer;
        _isUSAAddress = _customer.GetIsUSAAddress();
        GetTotalPrice();
    }
    
    private void GetTotalPrice(){
        //calculate the total price of all products ordered
        CalculateSumOfProductPrices();
        //get shipping (based on country)
        CalculateShipping();
        //tally it all up
        _totalPrice = _shippingCost + _sumOfProductPrices;
    }
    private void CalculateSumOfProductPrices(){
        //step through each product and call the Product method to return total price (price * quanitity)
        foreach (Product p in _productsList){
            _sumOfProductPrices += p.GetTotalPrice();
        }
    }
    private void CalculateShipping(){
        //simply return based on US vs International shipping
        switch (_isUSAAddress){
            case true:
                _shippingCost = 5;
                break;
            case false:
                _shippingCost = 35;
                break;
        }   
    }
    public string GetShippingLabel(){
        //method to build the Shipping label
        string shippingLabel;
        shippingLabel = $"-------------\nSHIPPING LABEL\n-------------\n{_customer.GetCustomerName()}\n{_customer.GetCustomerAddress()}";
        return shippingLabel;
    }
    public List<string> GetPackingLabel(){
        //method to build packing label.  lists all items ordered, item id, quantity and price each
        List<string> packingLabel = new List<string>();
        packingLabel.Add("-------------\nPACKING LABEL\n-------------");
        //step through all products to get packing label from the product class
        foreach (Product p in _productsList){
            packingLabel.Add($"{p.GetPackingLabel()}");
        }
        return packingLabel;
    }

    public string GetFinalBillLabel(){
        //method to build final bill info
        string total = $"-------------\nPAYMENT INFORMATION\n-------------\nItem(s) Subtotal: \t${_sumOfProductPrices:F2}\nShipping & Handling:  \t${_shippingCost:F2}\nGrand Total:  \t\t${_totalPrice:F2}";
        return total;
    }
}