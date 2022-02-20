namespace DatabaseCreation // Note: actual namespace depends on the project name.
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                // Получаем список пользователей и выводим на консоль.
                var users = db.Users.ToList();
                Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++");
                Console.WriteLine("Список пользователей:");
                Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++");
                foreach (User user in users)
                {
                    Console.WriteLine(user);
                }

                Console.WriteLine();

                // Получаем список карт товара и выводим на консоль.
                var cards = db.Cards.ToList();

                Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++");
                Console.WriteLine("Список карточек товаров:");
                Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++");
                foreach (Card card in cards)
                {
                    Console.WriteLine(card);
                }

                // Получаем список заказов и выводим на консоль.
                var orders = db.Orders.ToList();
                
                Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++");
                Console.WriteLine("Список заказов:");
                Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++");
                foreach (Order order in orders)
                {
                    Console.WriteLine(order);
                }
            }

            Console.ReadKey();
        }
    }
}