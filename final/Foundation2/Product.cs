class Product{
    private string _productName;
    private string _productID;
    private float _productPrice;
    private float _totalProductPrice;
    private int _quantity;

    public Product(string productName, string productID, float productPrice, int quanity){
        _productName = productName;
        _productID = productID;
        _productPrice = productPrice;
        _quantity = quanity;
        CalculateTotalProductPrice();
    }

    private void CalculateTotalProductPrice(){
        //simply calulate price per product price * quantity
        _totalProductPrice = _productPrice * _quantity;
    }

    public float GetTotalPrice (){
        //returns the total price of the product * quantity
        return _totalProductPrice;
    }

    public string GetPackingLabel(){
        //used to build final packing label.  this method returns info for each product to be compiled by orders
        return $"{_quantity} of: {_productName}  -\t{_productID}  -\t${_productPrice:F2} each";
    }

}