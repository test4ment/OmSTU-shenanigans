using System;
using System.Collections.Generic;
using System.Linq;

class Auto{
		public string model;
		public int speed;
		public bool isDirty;

		public Auto(string model, int speed){
			this.model = model;
			this.speed = speed;
			this.isDirty = false;
		}

		public void Drive(){
			this.isDirty = true;
		}
}
class Garage{
		public List<Auto> Cars = new List<Auto>();

		public void AddCar(Auto Car){
			this.Cars.Add(Car);
		}
}

class Washer{
		public static void WashCar(Auto Car){
			if(!Car.isDirty) Console.WriteLine($"Машина {Car.model} не загрязнена");
			else{
				Car.isDirty = false;
				Console.WriteLine($"Машина {Car.model} помыта!");
			}
		}
} 

class Program{
		public delegate void Washing(Auto Car);
	
		static void Main(string[] args){
				Washing WashCar = Washer.WashCar;
				Garage garage = new Garage();
				Auto volkswagen = new Auto("Volkswagen Beetle", 250);
				Auto lada = new Auto("Lada Largus", 220);
				garage.AddCar(volkswagen);
				garage.AddCar(lada);
	
				garage.Cars[1].Drive(); //Покатаемся на ладе
				
				foreach(Auto car in garage.Cars){
						WashCar(car);
				}
		}
}
