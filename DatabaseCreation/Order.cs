using System.Text;

namespace DatabaseCreation
{
    public partial class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int CardId { get; set; }
        public DateOnly Date { get; set; }

        public virtual Card Card { get; set; } = null!;
        public virtual User Customer { get; set; } = null!;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("===========Заказ===========");
            sb.Append("Id карточки товара: ").AppendLine(Card.Id.ToString());
            sb.Append("Что купил: ").AppendLine(Card.Title);
            sb.Append("Покупатель: ").AppendLine(Customer.ToString());
            sb.Append("Дата заказа: ").AppendLine(Date.ToString());
            sb.AppendLine("===========================");
            return sb.ToString();
        }
    }
}
