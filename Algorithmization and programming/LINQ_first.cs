using System; // Используем систему
using System.Collections.Generic; // Коллекции могут пригодиться, но не факт
using System.Linq; // Используем LINQ

class Program { // Класс программы
  public static void Main (string[] args) { // Рабочий метод
    int[] collection = {0, 1, 3, 7, 15, 31, 63, 127, 255, 512, -2, -4, -6, -8, 116, 112, 114}; 
		// Напишем последовательность чисел состоящих из чисел Мерсена, нуля, отрицательных четных и положительных четных
		int Positive = collection.Count(num => num > 0); // Посчитаем положительные
		int Negative = collection.Count(num => num < 0); // Посчитаем отрицательные
		int Product = collection.Aggregate(1, (acc, val) => val != 0 ? acc * val : acc); // Будем перемножать все числа, если эти числа не равны нулю
		int Sum = collection.Aggregate(0, (acc, val) => val % 2 == 0 ? acc + val : acc); // Будем складывать все четные числа
		
		Console.WriteLine($"Положительных: {Positive}\nОтрицательных: {Negative}\nПроизведение ненулевых: {Product}\nСумма четных {Sum}"); // Вывод с интерполяцией
  }
}
