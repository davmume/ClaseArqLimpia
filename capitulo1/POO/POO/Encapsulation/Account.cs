namespace POO.Encapsulation
{
    internal class Account
    {
        public int Number { get; private set; }
        public string Client { protected get; set; }
        public string Email { get; set; }
        public string Information() {
            return $"{Client} {Number}";      
        }
    }
}
