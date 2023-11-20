
using Hotel_Hosting.Handlers;
using Hotel_Hosting.Models;

namespace Hotel_Hosting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int selector = 1;
            List<Room> rooms = new List<Room>();
            while (selector != 0)
            {
                Console.Clear();
                Console.WriteLine("Olá, você é cliente ou gerente?\n0-Cancelar\n1-Cliente\n2-Gerente");
                selector = int.Parse(Console.ReadLine());
                if (selector == 1)
                {
                    int i = 1;
                    while (i != 0)
                    {
                        
                        Console.Clear();
                        Console.WriteLine("Bem vindo!");
                        Console.WriteLine("O que você gostaria de fazer?\n0-Cancelar\n1-Criar reserva\n");
                        i = int.Parse(Console.ReadLine());
                        if (i == 1)
                        {
                            var host = new Host();
                            Console.WriteLine("Dia de inicio: (Formato Dia/Mes)");
                            var strDate = Console.ReadLine().Split('/');
                            int day = int.Parse(strDate[0]);
                            int month = int.Parse(strDate[1]);
                            host.StartingDay = new DateTime(2023, month, day);
                            Console.WriteLine("Dia de termino: (Formato Dia/Mes)");
                            var fstrDate = Console.ReadLine().Split('/');
                            int fday = int.Parse(fstrDate[0]);
                            int fmonth = int.Parse(fstrDate[1]);
                            host.FinishingDay = new DateTime(2023, fmonth, fday);
                            Console.WriteLine("Quantos individuos:");
                            int numberOfPeople = int.Parse(Console.ReadLine());
                            for (int x = 0; x < numberOfPeople; x++)
                            {
                                Console.WriteLine("Nome da pessoa:");
                                var name = Console.ReadLine();
                                host.AddPerson(new Person(name));
                            }
                            Console.WriteLine("Selecione o quarto:");
                            foreach (Room room in RoomHandler.Rooms)
                            {
                                Console.WriteLine($"{room.Id}-{room.Name}");
                            }
                            int selectedRoom = int.Parse(Console.ReadLine());
                            foreach (Room room in RoomHandler.Rooms)
                            {
                                if (selectedRoom == room.Id) host.Room = room;
                            }
                            Service.AddHost(host);
                            Console.WriteLine($"Preço por diaria: {host.GetPricePerDay()}");
                            Console.WriteLine($"Preço total: {host.GetTotalPrice()}");
                            Console.ReadLine();
                        }
                        else
                        {
                            i = 0;
                        }
                    }
                }
                if (selector == 2)
                {
                    int i = 1;
                    while (i != 0)
                    {
                        
                        Console.WriteLine("Bem vindo!");
                        Console.WriteLine("O que você gostaria de fazer?\n0-Cancelar\n1-Cadastrar quarto\n2-Ver registros");
                        i = int.Parse(Console.ReadLine());
                        if (i == 1)
                        {

                            Console.WriteLine("Insira o nome:");
                            var name = Console.ReadLine();
                            Console.WriteLine("Insira a quantidade de camas:");
                            var qntBeds = int.Parse(Console.ReadLine());
                            Console.WriteLine("Adicionado!");
                            rooms.Add(new Room(name, qntBeds));
                        }
                        if (i == 2)
                        {
                            foreach (Host host in Service.Hostings)
                            {
                                var strDay = ((DateTime)host.StartingDay).ToString("dd/MM/yyyy");
                                var fnsDay = ((DateTime)host.FinishingDay).ToString("dd/MM/yyyy");
                                Console.WriteLine($"Data de Inicio: {strDay}");
                                Console.WriteLine($"Data de Termino: {fnsDay}");
                                Console.WriteLine($"Quarto: {host.Room.Name}");
                                Console.WriteLine("Pessoas hospedadas:");
                                foreach (Person person in host.PeopleHosted)
                                {
                                    Console.WriteLine($"{person.FullName}");
                                }
                                Console.WriteLine("---------------------------------------------------");
                            }
                        }
                        else
                        {
                            i = 0;
                        }
                    }
                }


            }

        }
    }
}