using System;
using System.Linq;

public delegate double OpEventHandler(double a, double b);

class Program{
	
	public static event OpEventHandler Operation;
	
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
			if(b == 0){
				throw new DivideByZeroException();
			}
			return a / b;
		}
	}
	
	static Operations ops = new Operations();
	static OpEventHandler add = new OpEventHandler(ops.add);
	static OpEventHandler subtract = new OpEventHandler(ops.subtract);
	static OpEventHandler multiply = new OpEventHandler(ops.multiply);
	static OpEventHandler divide = new OpEventHandler(ops.divide);
	
	public static void Main (string[] args) {
		double a = 0;
		double b = 0;
		OpEventHandler[] array = new OpEventHandler[4];
		array[0] += add;
		array[1] += subtract;
		array[2] += multiply;
		array[3] += divide;
		for (var i = 0; i < 4; i++){
			Operation += array[i];
			try{
				Console.WriteLine(Operation(a, b));
				}
			catch (DivideByZeroException){
				Console.WriteLine("На ноль делить нельзя, многоуважаемая, вагоноуважатая, Ирина Викторовна!");
			}
		}
	}
}
