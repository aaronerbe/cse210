class Address{
    private string _eventAddress;

    //Simply pass address to the Address Class
    public Address(string address){
        _eventAddress = address;
    }
    //Return the address
    public string GetAddress(){
        return _eventAddress;
    }
}