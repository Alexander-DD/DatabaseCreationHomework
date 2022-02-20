using System.Text;

namespace DatabaseCreation
{
    public class Card
    {
        public Card()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; } = null!;
        public string? Caption { get; set; }
        public DateOnly Date { get; set; }
        public int? Price { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<Order> Orders { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("==Карточка товара======");
            sb.Append("Id: ").AppendLine(Id.ToString());
            sb.Append("Продавец: ").AppendLine(User.ToString());
            sb.Append("Товар: ").AppendLine(Title);
            sb.Append("Описание: ").AppendLine(Caption);
            sb.Append("Дата публикации: ").AppendLine(Date.ToString());
            sb.Append("Цена: ").AppendLine(Price.ToString());
            sb.AppendLine("===========================");
            return sb.ToString();
        }
    }
}
