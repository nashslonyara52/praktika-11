using System;

namespace ConsoleApp42
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Инициализация объекта продукта с пустым названием и ценой 0
            Product product = new Product("Без названия", 0, 10);

            // Запрашиваем у пользователя ввести цену товара
            Console.Write("Введите цену товара: ");
            int priceInput;
            if (int.TryParse(Console.ReadLine(), out priceInput))
            {
                product.Price = priceInput; // Устанавливаем введенную цену
            }
            else
            {
                Console.WriteLine("Некорректный ввод цены товара, установлена цена 0."); // Если ввод некорректный
            }

            // Запрашиваем у пользователя ввести скидку
            Console.Write("Введите скидку на товар (%): ");
            int discountInput;
            if (int.TryParse(Console.ReadLine(), out discountInput))
            {
                product.Discount = discountInput; // Устанавливаем введённую скидку
            }
            else
            {
                Console.WriteLine("Некорректный ввод скидки, установлено значение скидки 10%.");
            }

            // Вычисляем итоговую стоимость товара
            product.Final();

            // Показываем продукт
            product.Show();
        }
    }

    class Product
    {
        private string _name;
        private int _price;
        private int _discount;
        private int _finalPrice;

        // Конструктор класса
        public Product(string ProductName, int ProductPrice, int ProductDiscount)
        {
            _name = ProductName;
            _price = ProductPrice;
            _discount = ProductDiscount;
            _finalPrice = CalculateFinalPrice(); // Рассчитываем финальную цену сразу при создании экземпляра
        }

        // Свойства
        public string Name
        {
            get => _name;
            set => _name = value ?? "Без названия";
        }

        public int Price
        {
            get => _price;
            set => _price = value >= 0 ? value : 0;
        }

        public int Discount
        {
            get => _discount;
            set => _discount = Math.Max(Math.Min(value, 100), 0);
        }

        // Метод расчета финальной стоимости товара
        private int CalculateFinalPrice()
        {
            return _price > 0 ? (_price * (100 - _discount)) / 100 : 0;
        }

        // Методы вычисления финальной цены и отображения результата
        public void Final()
        {
            _finalPrice = CalculateFinalPrice();
        }

        public void Show()
        {
            Console.WriteLine($"{_name}: {_finalPrice} руб. (скидка: {_discount}%)");
        }
    }
}