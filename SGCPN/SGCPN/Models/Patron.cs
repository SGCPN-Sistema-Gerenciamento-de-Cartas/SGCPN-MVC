namespace SGCPN.Models
{
    public class Patron
    {
        public int Id { get; set; }
        public string PatronName { get; set; }
        public string Password { get; set; }
        public string RgOrCnpj { get; set; }
        public string Email { get; set; }
        public string Sex { get; set; }
        public string Telephone { get; set; }
        public string Cellphone { get; set; }
        public string Address { get; set; }
        public string County { get; set; }
        public string State { get; set; }
        public string AddressComplement { get; set; }
        public string ZipCode { get; set; }
     
    }
}
