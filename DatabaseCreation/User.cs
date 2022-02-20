namespace DatabaseCreation
{
    public class User
    {
        public User()
        {
            Cards = new HashSet<Card>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Phone { get; set; } = null!;

        public virtual ICollection<Card> Cards { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

        public override string ToString()
        {
            return $"{Id}.{Name} - {Phone}";
        }
    }
}
