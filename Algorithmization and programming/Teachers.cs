using System;
using System.Linq;
using System.Collections.Generic;

class Program {
	public class Teacher{
		public string name;
		public string DoB;
		public string graduated;
		public List<string[]> work; 
		public string subject;

		public Teacher(string name, string DoB, string graduated, List<string[]> work, string subject){
			this.name = name;
			this.DoB = DoB;
			this.graduated = graduated;
			this.work = work;
			this.subject = subject;
		}
	}
	
  public static void Main (string[] args) {
		List<Teacher> BD = new List<Teacher>();

		string choice;
		Console.WriteLine("База данных учителей");
		while(true){
			Console.WriteLine("1. Добавить учителей\n2. Узнать стаж\n3. Список учителей\n4. Выход");
			choice = Console.ReadLine();
			switch (choice){
			case "1":
				Console.WriteLine("1. Воспользоваться примером БД\n2. Задать БД вручную");
				choice = Console.ReadLine();
				if (choice == "1"){
					List<string[]> worked = new List<string[]>();
					
					string[] text = new string[] {"15.01.1990", "УрФУ", "12.12.1991"};
					worked.Add(text);
					text = new string[] {"13.01.1992", "ТГУ", "03.04.2008"};
					worked.Add(text);
					
			    Teacher teacher = new Teacher("Вырыпаев Леонид Семёнович", "06.09.1961", "ЧелГУ", worked, "Философия");
					BD.Add(teacher);
					
					text = new string[] {"15.02.2010", "НГТУ", "23.02.2022"};
					worked = new List<string[]>();
					worked.Add(text);
					
					teacher = new Teacher("Сырых Антонина Фёдоровна", "01.12.1978", "МГУ", worked, "Черчение");
					BD.Add(teacher);
				}
				else{
					Console.WriteLine("Последовательно вводите данные учителей с новой строчки: имя, дата рождения, образование, предмет, количество мест работы; описание каждого места работы: дата начала, место работы, окончание работы - разделены через пробел; 0 - окончание последовательности");
					while(true){
						string name = Console.ReadLine();
						if (name == "0") break;
						string DoB = Console.ReadLine();
						string graduated = Console.ReadLine();
						string subject = Console.ReadLine();
						List<string[]> jobs = new List<string[]>();
						var i = Int32.Parse(Console.ReadLine());
						for(var _ = 0; _ < i; _++){
							jobs.Add(Console.ReadLine().Split());
						}
						BD.Add(new Teacher(name, DoB, graduated, jobs, subject));
						Console.WriteLine("Учитель добавлен");
					}
				}
				break;
			case "2":
				Console.WriteLine("1. Узнать стаж на последнем месте работы\n2. Узнать общий стаж");
				if(Console.ReadLine() == "1" && BD.Count > 0) ExpLast(BD);
				else if (BD.Count > 0) ExpAll(BD);
				else Console.WriteLine("База данных пуста");
				break;
			case "3":
				if(BD.Count > 0) PrintAll(BD);
				else Console.WriteLine("База данных пуста");
				break;
			case "4":
				Environment.Exit(0);
				break;
			default:
				Console.WriteLine("Неверный ввод");
				break;
			}
		}
		
	}

	static void SubjectFind(List<Teacher> DB, string subject){
		foreach(var i in DB){
			if (i.subject == subject) Console.WriteLine(i.name);
		}
	}

	static void ExpLast(List<Teacher> DB){
		foreach (var i in DB){
			string date1 = i.work[i.work.Count - 1][0];
			string date2 = i.work[i.work.Count - 1][2];
			int days = Int32.Parse(date2[0..2]) - Int32.Parse(date1[0..2]);
			int months = Int32.Parse(date2[3..5])*30 - Int32.Parse(date1[3..5])*30;
			int years = Int32.Parse(date2[6..])*360 - Int32.Parse(date1[6..])*360;
			days = days + months + years;
			Console.WriteLine($"{i.name}, стаж на последнем месте работы: {days%360%30} дней {days%360/30} месяцев {days/360} лет");
		}
	}

	static void ExpAll(List<Teacher> DB){
		foreach (var i in DB){
			 int daysn = 0;
			for(var j = 0; j < i.work.Count; j++){
				string date1 = i.work[j][0];
				string date2 = i.work[j][2];
				int days = Int32.Parse(date2[0..2]) - Int32.Parse(date1[0..2]);
				int months = Int32.Parse(date2[3..5])*30 - Int32.Parse(date1[3..5])*30;
				int years = Int32.Parse(date2[6..])*360 - Int32.Parse(date1[6..])*360;
				daysn += days + months + years;
				}
			Console.WriteLine($"{i.name}, общий стаж: {daysn%360%30} дней {daysn%360/30} месяцев {daysn/360} лет");
		}
	}

	static void PrintAll(List<Teacher> DB){
		foreach(var i in DB){
			Console.WriteLine($"{i.name} {i.DoB}. Образование: {i.graduated}, предмет: {i.subject}");
		}
	} 
}
