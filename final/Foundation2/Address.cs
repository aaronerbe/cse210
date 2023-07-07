class Address{
    private string _streetAddress;
    private string _country;
    private bool _isUSAAddress;

    public Address(string streetAddress){
        //let the function grab the country and put address in right format
        BuildAddressFormat(streetAddress);
        //then set the boolean
        SetCountryBoolean();
    }
    private void BuildAddressFormat(string streetAddress){
        string[] address = streetAddress.Split(",");
        //set the country variable
        _country = address[4].Trim();
        //rebuild _streetaddress so we can put it in the right format
        _streetAddress = $"{address[0].Trim()}\n{address[1].Trim()}, {address[2].Trim()} {address[3].Trim()}\n{_country.Trim()}";
    }
    private void SetCountryBoolean(){
        //sets boolean based on country information.  used to determine shipping costs
        //Check if country contains usa.  OR if usa contains the country.  So it works if they say US
        if (_country.ToLower().Contains("usa") || ("usa".Contains(_country.ToLower()))){
            _isUSAAddress = true;
        }
        else{
            _isUSAAddress = false;
        }
    }
    public bool GetIsUSAAddress(){
        //returns back the boolean info
        return _isUSAAddress;
    }
    public string GetStreetAddress(){
        //returns the street address
        return $"{_streetAddress}";
    }
}