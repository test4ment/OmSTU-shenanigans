using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Employee> employees = new List<Employee>();

				// Создаём работу
				Order ord = new Order(DateTime.Parse("09.11.2001"), 1, "ПАО Сбебранк");
				List<Order> ords = new List<Order>();
				ords.Add(ord);
				ord = new Order(DateTime.Parse("09.11.2020"), 2, "ОАО Газбебранк");
				ords.Add(ord);

				Printing print = new Printing(DateTime.Parse("09.12.2001"), 10000);
				List<Printing> prints = new List<Printing>();
				prints.Add(print);
				print = new Printing(DateTime.Parse("09.13.2001"), 20000);
				prints.Add(print);
				print = new Printing(DateTime.Parse("09.14.2001"), 1);
				prints.Add(print);

				Work work = new Work(DateTime.Parse("09.15.2001"), 30000);
				List<Work> works = new List<Work>();
				works.Add(work);
				work = new Work(DateTime.Parse("03.07.2006"), 2);
				works.Add(work);
			
        // Добавляем сотрудников в список
        employees.Add(new Manager("Иванов Иван Иванович", "Директор", "ТК001", ords));
        employees.Add(new MainEmployee("Петров Петр Петрович", "Наборщик", "ТК002", prints));
        employees.Add(new SupportEmployee("Сидоров Сидор Сидорович", "Уборщик", "ТК003", works));
				//public Manager(string name, string position, string employmentBook, List<Order> orders) : base(name, position, employmentBook)
				//employees[0]
				
        // Вызываем нужные функции
        while (true)
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Подсчет общего стажа всех сотрудников");
            Console.WriteLine("2. Подсчет стажа работы на последнем месте");
            Console.WriteLine("3. Подсчет количества экземпляров, отпечатанных в диапазоне дат");
            Console.WriteLine("4. Подсчет выполненной работы вспомогательным составом");
            Console.WriteLine("5. Выборка приказов или распоряжений, которые выдавало определенное лицо");
            Console.WriteLine("0. Выход");

            string input = Console.ReadLine();
            if (input == "0")
            {
                break;
            }

            if (input == "1")
            {
                Console.WriteLine("Общий стаж всех сотрудников: " + CalculateTotalExperience(employees) + " лет");
            }
            else if (input == "2")
            {
                Console.WriteLine("Введите индекс сотрудника (0 - управленец, 1 - основной, 2 - вспомогательный):");
                int index = int.Parse(Console.ReadLine());

                Employee employee = employees[index];
                Console.WriteLine("Стаж работы " + employee.Name + " на текущем месте работы: " + employee.ExperienceOnCurrentJob() + " лет");
            }
            else if (input == "3")
            {
                MainEmployee mainEmployee = (MainEmployee)employees[1];
                Console.WriteLine("Введите начальную дату в формате MM.DD.YYYY:");
                DateTime startDate = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Введите конечную дату в формате MM.DD.YYYY:");
                DateTime endDate = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Количество экземпляров, отпечатанных в период с " + startDate.ToShortDateString() + " по " + endDate.ToShortDateString() + ": " + mainEmployee.PrintingsInDateRange(startDate, endDate));
            }
            else if (input == "4")
            {
                SupportEmployee supportEmployee = (SupportEmployee)employees[2];
                Console.WriteLine("Количество выполненных работ уборщиком " + supportEmployee.Name + ": " + supportEmployee.WorksDone());
            }
            else if (input == "5")
            {
                Manager manager = (Manager)employees[0];
                Console.WriteLine("Введите имя лица, выдавшего приказы:");
                string issuer = Console.ReadLine();

                Console.WriteLine("Список приказов, выданных " + issuer + ":");
                foreach (Order order in manager.GetOrdersByIssuer(issuer))
                {
                    Console.WriteLine(order);
                }
            }
        }
    }

    // Функция для подсчета общего стажа всех сотрудников
    static int CalculateTotalExperience(List<Employee> employees)
    {
        int totalExperience = 0;
        foreach (Employee employee in employees)
        {
            totalExperience += employee.Experience();
        }
        return totalExperience;
    }
}

// Класс для представления сотрудника
abstract class Employee
{
    public string Name;
    public string Position;
    public string EmploymentBook;

    public Employee(string name, string position, string employmentBook)
    {
        Name = name;
        Position = position;
        EmploymentBook = employmentBook;
    }

    // Функция для подсчета стажа работы
    public abstract int Experience();

    // Функция для получения последней даты работы
    public abstract DateTime GetLastEmploymentDate();

    // Функция для подсчета стажа на текущем месте работы
    public abstract int ExperienceOnCurrentJob();
}

// Класс для представления управленца
class Manager : Employee
{
    public List<Order> Orders;

    public Manager(string name, string position, string employmentBook, List<Order> orders) : base(name, position, employmentBook)
    {
        Orders = orders;
    }

// Функция для подсчета стажа работы управленца
    public override int Experience()
    {
        int totalExperience = 0;
        foreach (Order order in Orders)
        {
            totalExperience += (DateTime.Today - order.Date).Days / 365;
        }
        return totalExperience;
    }

    // Функция для получения последней даты работы управленца
    public override DateTime GetLastEmploymentDate()
    {
        if (Orders.Count == 0)
        {
            return DateTime.MinValue;
        }
        else
        {
            return Orders[Orders.Count - 1].Date;
        }
    }

    // Функция для подсчета стажа управленца на текущем месте работы
    public override int ExperienceOnCurrentJob()
    {
        if (Orders.Count == 0)
        {
            return 0;
        }
        else
        {
            return (DateTime.Today - GetLastEmploymentDate()).Days / 365;
        }
    }

    // Функция для получения списка приказов, выданных определенным лицом
    public List<Order> GetOrdersByIssuer(string issuer)
    {
        List<Order> ordersByIssuer = new List<Order>();
        foreach (Order order in Orders)
        {
            if (order.Issuer == issuer)
            {
                ordersByIssuer.Add(order);
            }
        }
        return ordersByIssuer;
    }
}

// Класс для представления приказа
class Order
{
    public DateTime Date;
    public int Number;
    public string Issuer;

    public Order(DateTime date, int number, string issuer)
    {
        Date = date;
        Number = number;
        Issuer = issuer;
    }

    public override string ToString()
    {
        return "Приказ от " + Date.ToShortDateString() + " №" + Number + " выдан " + Issuer;
    }
}

// Класс для представления основного сотрудника
class MainEmployee : Employee
{
    public List<Printing> Printings;

    public MainEmployee(string name, string position, string employmentBook, List<Printing> printings) : base(name, position, employmentBook)
    {
        Printings = printings;
    }

    // Функция для подсчета стажа работы основного сотрудника
    public override int Experience()
    {
        if (Printings.Count == 0)
        {
            return 0;
        }
        else
        {
            return (DateTime.Today - Printings[0].Date).Days / 365;
        }
    }

    // Функция для получения последней даты работы основного сотрудника
    public override DateTime GetLastEmploymentDate()
    {
        if (Printings.Count == 0)
        {
            return DateTime.MinValue;
        }
        else
        {
            return Printings[Printings.Count - 1].Date;
        }
    }

    // Функция для подсчета стажа основного сотрудника на текущем месте работы
    public override int ExperienceOnCurrentJob()
    {
        if (Printings.Count == 0)
        {
            return 0;
        }
        else
        {
            return (DateTime.Today - GetLastEmploymentDate()).Days / 365;
        }
    }

    // Функция для подсчета количества отпечатанных экземпляров в заданном диапазоне дат
    public int PrintingsInDateRange(DateTime startDate, DateTime endDate)
    {
        int printingsInDateRange = 0;
        foreach (Printing printing in Printings)
        {
            if (printing.Date >= startDate && printing.Date <= endDate)
            {
                printingsInDateRange += printing.Quantity;
            }
        }
        return printingsInDateRange;
    }
}

// Класс для представления отпечатанного материала
class Printing
{
    public DateTime Date;
    public int Quantity;

    public Printing(DateTime date, int quantity)
    {
        Date = date;
        Quantity = quantity;
    }
}

// Класс для представления вспомогательного сотрудника
class SupportEmployee : Employee
{
    public List<Work> Works;

    public SupportEmployee(string name, string position, string employmentBook, List<Work> works) : base(name, position, employmentBook)
    {
        Works = works;
    }

    // Функция для подсчета стажа работы вспомогательного сотрудника
    public override int Experience()
    {
        if (Works.Count == 0)
        {
            return 0;
        }
        else
        {
            return (DateTime.Today - Works[0].Date).Days / 365;
        }
    }

    // Функция для получения последней даты работы вспомогательного сотрудника
    public override DateTime GetLastEmploymentDate()
    {
        if (Works.Count == 0)
        {
            return DateTime.MinValue;
        }
        else
        {
            return Works[Works.Count - 1].Date;
        }
    }

    // Функция для подсчета стажа вспомогательного сотрудника на текущем месте работы
    public override int ExperienceOnCurrentJob()
    {
        if (Works.Count == 0)
        {
            return 0;
        }
        else
        {
            return (DateTime.Today - GetLastEmploymentDate()).Days / 365;
        }
    }

    // Функция для подсчета выполненной работы вспомогательным составом
    public int WorksDone()
    {
        int worksDone = 0;
        foreach (Work work in Works)
        {
            worksDone += work.Amount;
        }
        return worksDone;
    }
}

// Класс для представления выполненной работы
class Work
{
    public DateTime Date;
    public int Amount;

    public Work(DateTime date, int amount)
    {
        Date = date;
        Amount = amount;
    }
}
