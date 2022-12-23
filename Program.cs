namespace LINQGroupBy
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = from Auto in GetCars()
                         join Salon in GetCarSalon()
                         on Auto.TypeId equals Salon.Id
                         group Auto by new { Auto.TypeId, Salon.Name };

            Console.WriteLine(">>> VEHICLES <<<");
            foreach(var auto in result)
            {
                Console.WriteLine($"\n{auto.Key.Name} | Total: {auto.Count()}");

                foreach(var item in auto)
                {
                    Console.WriteLine($"\t{item.Brand} - {item.Model}");
                }
            }
            Console.ReadLine();
        }

        private static IQueryable<Salon> GetCarSalon()
        {
            return new List<Salon>()
            {
                new Salon { Id = 1, Name = "BMW Salon"},
                new Salon { Id = 2, Name = "Honda Salon" },
                new Salon { Id = 3, Name = "Toyota Salon" },
                new Salon { Id = 4, Name = "Lexus Salon" },
            }.AsQueryable();
        }

        private static IQueryable<Auto> GetCars()
        {
            return new List<Auto>()
            {
                new Auto {Id = 1, Brand = "BMW", TypeId = 1, Model = "M5", Price = 50000},
                new Auto {Id = 2, Brand = "BMW", TypeId = 1, Model = "X6", Price = 65000},
                new Auto {Id = 3, Brand = "Toyota", TypeId = 3, Model = "RAV4", Price = 25000},
                new Auto {Id = 4, Brand = "Toyota", TypeId = 3, Model = "Land Cruiser", Price = 40000},
                new Auto {Id = 5, Brand = "Honda", TypeId = 2, Model = "CR-V", Price = 20000},
                new Auto {Id = 6, Brand = "Lexus", TypeId = 4, Model = "CT200h", Price = 15000},
                new Auto {Id = 7, Brand = "Honda", TypeId = 2, Model = "Accord", Price = 10000},
            }.AsQueryable();
        }
    }
}