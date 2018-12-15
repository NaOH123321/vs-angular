namespace vstaskmgr.Model
{
    public class Address
    {
        public Address()
        { }
        public Address(string province, string city, string district, string street)
        {
            this.Province = province;
            this.City = city;
            this.District = district;
            this.Street = street;
        }
        public string Province { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Street { get; set; }
    }
}

