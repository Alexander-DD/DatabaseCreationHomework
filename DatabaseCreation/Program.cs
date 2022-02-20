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


                string? input = null;
                do
                {
                    Console.WriteLine("Хотите добавить нового пользователя? Y - yes, E - exit");
                    Console.Write("Введите символ: ");
                    input = Console.ReadLine();

                    if (input == "Y")
                    {
                        string? name, phone;

                        Console.WriteLine("Введите имя: ");
                        name = Console.ReadLine();

                        Console.WriteLine("Введите телефон: ");
                        phone = Console.ReadLine();

                        if (name == null || phone == null)
                        {
                            Console.WriteLine("Поле не может быть пустым");
                        }
                        else
                        {
                            User newUser = new User { Name = name, Phone = phone };

                            db.Users.Add(newUser);
                            Console.WriteLine($"Пользователь {newUser} добавлен.");
                            db.SaveChanges();
                        }
                    }
                }
                while (input != null && input == "Y");
            }
        }
    }
}