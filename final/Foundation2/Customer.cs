class Customer{
    private string _customerName;
    private Address _customerAddress;
    private bool _isUSAAddress;

    public Customer(string customerName, Address customerAddress){
        _customerName = customerName;
        _customerAddress = customerAddress;
        SetUSAAddress();
    }

    public void SetUSAAddress(){
        //get the boolean from the Address class
        _isUSAAddress = _customerAddress.GetIsUSAAddress();
    }

    public bool GetIsUSAAddress(){
        //returns back the boolean
        return _isUSAAddress;
    }
    public string GetCustomerName(){
        //returns customer name
        return _customerName;
    }
    public string GetCustomerAddress(){
        //returns the address info
        return _customerAddress.GetStreetAddress();
    }

}