using System;
using System.Linq;
using System.Collections.Generic;
/*
Класс машин номер у машины
Класс водителей (характеристика водителя, айди)
С использование Linq
Необходимо сгрупировать водителей по машине
Вывести водителей фамилия которых на какую-то букву
*/

class Program {
	public class CarModel{
		string name {get;}

		public CarModel(string name){
			this.name = name;
		}
	}
	
	public class Car{
		public string ID {get;}
		string region;
		string country;
		public CarModel model;

		public Car(string ID, string region, string country, CarModel model){
			this.ID = ID;
			this.region = region;
			this.country = country;
			this.model = model;
		}
	}
	
	public class Citizen{
		public string name; 

		public Citizen(string name){
			this.name = name;
		}
	}
	public class Driver : Citizen{
		public List<string> Owns = new List<string>();
		
		public Driver(string name) : base(name) {}

		public void AddCar(string id){
			Owns.Add(id);
		}
	}
	public static string IDGen(){
		Random rnd = new Random();
		string alpha = "ABCEHKMOPTX";
		string id = "";
		id = Convert.ToString(rnd.Next(0, 10)) + Convert.ToString(rnd.Next(0, 10));
		for (int i = 0; i<3; i++){
			id = id + alpha[rnd.Next(alpha.Length)];
		}
		id += Convert.ToString(rnd.Next(0, 10));
		return id;
	}

  public static void Main (string[] args) {
		Random rnd = new Random();
		rnd.Next();
		
		List<Driver> Drivers = new List<Driver>();
    Drivers.Add(new Driver("Больжедор Вседорогович Овсянников"));
		Drivers.Add(new Driver("Всеволод Базирович Гребеньков"));
		Drivers.Add(new Driver("Евстахий Святославович Кузнецов"));
		Drivers.Add(new Driver("Лаврентий Абрамович Кац"));

		List<CarModel> CarTypes = new List<CarModel>();
		CarTypes.Add(new CarModel("Hyundai Creta 2018"));
		CarTypes.Add(new CarModel("Honda Civic 2020"));
		CarTypes.Add(new CarModel("ВАЗ 2107"));
		CarTypes.Add(new CarModel("Лада Нива 2007"));
		CarTypes.Add(new CarModel("BMW 3-Series 2008"));
		CarTypes.Add(new CarModel("Lexus ES250 2019"));

		List<Car> CarList = new List<Car>();
		
		for(int _ = 0; _ < rnd.Next(5, 10); _++){
			Car Car = new Car(IDGen(), Convert.ToString(rnd.Next(1, 86)), "RUS", CarTypes[rnd.Next(CarTypes.Count)]);
			CarList.Add(Car);
			for(int __ = 0; __ < rnd.Next(1, 2); __++){
				Drivers[rnd.Next(Drivers.Count)].AddCar(Car.ID);
			}
		}
		Drivers[rnd.Next(Drivers.Count)].AddCar(CarList[rnd.Next(CarList.Count)].ID);
		
		foreach(var i in Drivers){
			Console.WriteLine(i.name);
			foreach(var j in i.Owns){
				Console.WriteLine(j);
			}
		}

		Console.WriteLine();
		string temp = CarList[rnd.Next(CarList.Count)].ID;
		Console.WriteLine($"Владельцы автомобиля {temp}");
		var ChosenByCar = from i in Drivers where i.Owns.Contains(temp) select i.name;
		foreach(var i in ChosenByCar) Console.WriteLine(i);

		Console.WriteLine();
		char letter = 'К';
		Console.WriteLine($"Водители с фамилией на букву {letter}");
		var DriversNameStartWith = from i in Drivers where i.name.Split()[2][0] == letter select i.name;
		foreach(var i in DriversNameStartWith) Console.WriteLine(i);
  }
}
