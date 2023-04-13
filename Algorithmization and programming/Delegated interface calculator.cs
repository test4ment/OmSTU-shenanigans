using System;
using System.Linq;

interface IMath{
	double add(double a, double b);
	double subtract(double a, double b);
	double multiply(double a, double b);
	double divide(double a, double b);
}

public class OperationsDelegate{
	public delegate double operations(double a, double b);

	public class Operations{
		public double add(double a, double b){
			return a + b;
		}

		public double subtract(double a, double b){
			return a - b;
		}

		public double multiply(double a, double b){
			return a * b;
		}

		public double divide(double a, double b){
			return a / b;
		}
	}

	class Program : IMath{
		static Operations ops = new Operations();
		static operations Add = new operations(ops.add);
		static operations Subtract = new operations(ops.subtract);
		static operations Multiply = new operations(ops.multiply);
		static operations Divide = new operations(ops.divide);
		
		double IMath.add(double a, double b){
			return Add(a, b);
		}

		double IMath.subtract(double a, double b){
			return Subtract(a, b);
		}

		double IMath.multiply(double a, double b){
			return Multiply(a, b);
		}

		double IMath.divide(double a, double b){
			return Divide(a, b);
		}
	}
	
	public static void Main (string[] args) {
		Console.WriteLine ("Введите выражение в виде A+B");
		IMath operations = new Program();
		string input = Console.ReadLine(); 
		string[] numbers;
		if (input.Contains('+')){
			numbers = input.Split('+');
			Console.WriteLine(operations.add(Int32.Parse(numbers[0]), Int32.Parse(numbers[1])));
		}
		else if (input.Contains('-')){
			numbers = input.Split('-');
			Console.WriteLine(operations.subtract(Int32.Parse(numbers[0]), Int32.Parse(numbers[1])));
		}
		else if (input.Contains('*')){
			numbers = input.Split('*');
			Console.WriteLine(operations.multiply(Int32.Parse(numbers[0]), Int32.Parse(numbers[1])));
		}
		else if (input.Contains('/')){
			numbers = input.Split('/');
			Console.WriteLine(operations.divide(Int32.Parse(numbers[0]), Int32.Parse(numbers[1])));
		}
	}
}

