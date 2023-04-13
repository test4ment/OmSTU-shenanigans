using System;
using System.Collections.Generic;

class Program {
  delegate double LambdaDeleg(double a, double b, double c);

  public class Operations{
    static public double Minimal(double a, double b, double c){
      Func<double, double, double, double> min = (double a, double b, double c) => (a <= b && a <= c) ? a : ((b <= a && b <= c) ? b : c);
      return min(a, b, c);
    }
    static public double Maximal(double a, double b, double c){
      Func<double, double, double, double> max = (double a, double b, double c) => (a >= b && a >= c) ? a : ((b >= a && b >= c) ? b : c);
      return max(a, b, c);
    }
    static public double Total(double a, double b, double c){
      Func<double, double, double, double> sum = (double a, double b, double c) => a + b + c;
      return sum(a, b, c);
    }
    static public double Product(double a, double b, double c){
      Func<double, double, double, double> prod = (double a, double b, double c) => a * b * c;
      return prod(a, b, c);
    }
    static public double Average(double a, double b, double c){
      Func<double, double, double, double> aver = (double a, double b, double c) => (a + b + c)/3;
      return aver(a, b, c);
    }
  }
  public static void Main (string[] args) {
    List<LambdaDeleg> a = new List<LambdaDeleg>();
    a.Add(Operations.Minimal);
    a.Add(Operations.Maximal);
    a.Add(Operations.Total);
    a.Add(Operations.Product);
    a.Add(Operations.Average);
    double b, c, d;
    Console.WriteLine("Введите три числа через пробел:");
    string input = Console.ReadLine();
    b = Int32.Parse(input.Split()[0]);
    c = Int32.Parse(input.Split()[1]);
    d = Int32.Parse(input.Split()[2]);
    foreach(var i in a){
      Console.WriteLine(i(b, c, d));
    }
  }
}
