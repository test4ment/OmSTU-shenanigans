using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

static class Program {
	static Random rand = new Random();
	
  public static void Main (string[] args) {
		Menu();
  }
	
	public static void Game(Options options){
		Restart:
		Console.Clear();
		
		string number = "";
		
		List<char> guesser = new List<char>();
		char[] guessed = new char[options.Length];
		Populate(guessed, '-');
		
		string input;
		
		for(int i = 0; i < options.Length; i++){ //Придумаем число, и если цифры должны быть уникальными, сделаем их уникальными
			if(options.Uniquness){
				while(true){
				  string a = Convert.ToString(rand.Next(0, 10));
					if (!number.Contains(a)){
						number += a;
						break;
					}
				}
			}
			else number += Convert.ToString(rand.Next(0, 10));
		}
		
		for(int t = options.Tries; t > 0; t--){ //Дадим человеку t попыток
			Console.WriteLine(guessed); //Будем помнить за человека, что он угадал
			Console.Write(guesser.Count > 0 ? $"Угаданы цифры не на своих местах: {Printgen(guesser)}" : "\n"); //И подскажем, если человек угадал что-то не на месте
			guesser.Clear();
			while(true){ //Мы будем требовать правильный ввод до тех пор, пока его не получим
			input = Console.ReadLine();
			if (input.Length > options.Length) Console.WriteLine("Длина строки не должна превышать длину числа"); //Впрочем, вводить можно что угодно, игрок может испортить жизнь лишь самому себе
			else break;
				}

			for(int i = 0; i < input.Length; i++){ //Проберем циклом сопадения..
				guessed[i] = number[i] == input[i] ? input[i] : guessed[i];
			}
			for(int i = 0; i < input.Length; i++){
				if(guessed[i] != input[i] && number.Contains(input[i]) && !guesser.Exists(x => x == input[i])){ //Из цифр, которые не оказались угаданы, но присутствующих в числе, сформируем список
					 PopulateList(guesser, input[i], number.Count(x => x == input[i]) - guessed.Where(x => x == input[i]).Count() < input.Count(x => x == input[i]) ? number.Count(x => x == input[i]) - guessed.Where(x => x == input[i]).Count() : input.Count(x => x == input[i]));}
					//Смешная конструкция, которая добавляет в список либо количество неугаданных цифр, либо количество написанных игроком (меньшее из перечисленного)
				}
			Console.Clear(); //Очистка экрана
			if(new string(guessed) == number) break; //Выйдем из цикла, если мы победили
		}
		string choice;
		if(new string(guessed) == number){
			Console.WriteLine(number);
			Console.WriteLine("Вы победили!");
			Console.WriteLine("1. Играть заново\n2. В меню");
			choice = Console.ReadLine();
			switch (choice){
			case "1": goto Restart;
			default: 
				Console.Clear();
				Console.WriteLine("Угадывание чисел - меню\n");
				return;
			}
		}
		else{
			Console.WriteLine(guessed);
			Console.WriteLine("Игра окончена");
			Console.WriteLine($"Задуманное число: {number}");
			Console.WriteLine("1. Играть заново\n2. В меню");
			choice = Console.ReadLine();
			switch (choice){
			case "1": goto Restart;
			default:
				Console.Clear();
				Console.WriteLine("Угадывание чисел - меню\n");
				return;
			}
		}
		//Console.WriteLine(number);
	}
	public static void Menu(){
		Options options = new Options();
		string choice;
		Menu:
		Console.Clear();
		Console.WriteLine("Угадывание чисел - меню\n");
		while(true){
			Console.WriteLine("1. Начать игру\n2. Настройки\n3. Об авторе\n4. Выход\n");
			choice = Console.ReadLine();
			switch (choice){
			case "1":
				Game(options);
				break;
			case "2":
				while(true){
					Console.Clear();
					Console.WriteLine("Угадывание чисел - настройки");
					L1:
					Console.WriteLine($"Что вы хотите изменить?\n1. Длина числа (текущая {options.Length})\n2. Уникальность цифр (сейчас {(options.Uniquness ? "включено" : "выключено")}) (невозможно при длине числа > 10)\n3. Число попыток (текущее {options.Tries})\n4. Вернутся в меню\n");
					choice = Console.ReadLine();
					switch(choice){
					case "1":
						Console.WriteLine("Введите новую длину:");
						try{
							options.Length = Int32.Parse(Console.ReadLine());
							goto L1;
						}
						catch(ArgumentException){
								Console.WriteLine("Длина числа должна быть натуральным числом");
						}
						catch(FormatException){
				      	Console.WriteLine("Неправильный формат ввода");
						}
						break;
					case "2":
						options.Uniquness = !options.Uniquness;
						goto L1;
						break;
					case "3":
						Console.WriteLine("Введите новое количество попыток:");
						try{
							options.Tries = Int32.Parse(Console.ReadLine());
							goto L1;
						}
						catch (ArgumentException){
							Console.WriteLine("Число попыток должно быть натуральным числом");
							}
						catch(FormatException){
			       Console.WriteLine("Неправильный формат ввода");
							}
						break;
					case "4": goto Menu;
					default: 
						Console.WriteLine("Неправильный ввод");
						break;
						}
					}
				//break;
			case "3":
				Console.WriteLine("Выполнил Никита Калицкий, студент 1 курса ФИТ221\n");
				break;
			case "4":
				Environment.Exit(0);
				break;
			default:
				Console.WriteLine("Неправильный ввод");
				break;
			}
		}
	}

	static void Print(char[] word){
		foreach(var i in word){
			Console.Write(i);
		}
		Console.WriteLine();
	}
	static void Print(List<char> word){
		word.Sort();
		foreach(var i in word){
			Console.Write(i);
		}
		Console.WriteLine();
	}
	static string Printgen(List<char> word){
		string str = "";
		word.Sort();
		foreach(var i in word){
			str += i;
		}
		return str + "\n";
	}
	
	public static void Populate<T>(this T[] arr, T value ) {
  for(int i = 0; i < arr.Length; ++i){
    arr[i] = value;
  	}
	}
	public static void PopulateList<T>(List<T> arr, T value, int n) {
  for(int i = 0; i < n; ++i){
		arr.Add(value);
		}
	}
}

public class Options{
	public int length; //{get; set;}
	bool uniquness; //{get; set;}
	public int tries; //{get; set;}
	
	public Options(int len, bool uni, int tri){
		length = len > 0 ? len : throw new ArgumentException();
		if (len > 10 && uni){
			uniquness = false;
			Console.WriteLine("Невозможно задать число более чем из десяти уникальных цифр");
		}
		else uniquness = uni;
		tries = tri > 0 ? len : throw new ArgumentException();
	}

	public Options(){
		length = 4;
		uniquness = true;
		tries = 4;
	}

	public bool Uniquness{
		get{return uniquness;}
		set{
			if (length > 10 && value){
			uniquness = false;
			Console.WriteLine("Невозможно задать число более чем из десяти уникальных цифр");
			}
			else uniquness = value;
		}
	}

	public int Length{
		get{return length;}
		set{
			if (value > 10 && uniquness){
    	Console.WriteLine("Невозможно задать число более чем из десяти уникальных цифр");
			}
		else length = value > 0 ? value : throw new ArgumentException();
		}
	}
	public int Tries{
		get{return tries;}
		set{
			tries = value > 0 ? value : throw new ArgumentException();
		}
	}
}
