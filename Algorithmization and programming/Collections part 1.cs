using System;
using System.Collections;
using System.Collections.Generic;
//using System.Random;

static class RandomExtensions
{
    public static void Shuffle<T> (this Random rng, T[] array)
    {
        int n = array.Length;
        while (n > 1) 
        {
            int k = rng.Next(n--);
            T temp = array[n];
            array[n] = array[k];
            array[k] = temp;
        }
    }
}
class Program {
  public static void Main (string[] args) {
		var rng = new Random();
		
		Console.WriteLine("Задайте длину всех массивов для работы программы:");
		int n = Int32.Parse(Console.ReadLine());
		
    Array array = Array.CreateInstance(typeof(string), n);
		ArrayList arrayList = new ArrayList(n);
		Hashtable hashtable = new Hashtable(n);
		SortedList sortedList = new SortedList(n);

		string[] words = {"salmon", "turtle", "giraffe", "whale", "dolphin", "monkey", "cat", "dog", "pig", "hog", "parrot"};
		string[] values = {"tasty", "not tasty", "ambiguous"};
		rng.Shuffle(words);
		
		var i = 0;
		while(i < n && i < words.Length){
			array.SetValue(words[i], i);
			rng.Shuffle(words);
			arrayList.Add(words[i]);
			rng.Shuffle(words);
			i++;
		}
		i = 0;
		while(i < n && i < words.Length){
			hashtable.Add(words[i], values[rng.Next(3)]);
			sortedList.Add(words[i], values[rng.Next(3)]);
			i++;
		}
		//
		PrintArray(array);
		PrintArray(arrayList);
		PrintArray(hashtable);
		PrintArray(sortedList);
		
		Console.WriteLine("1. Методы Array\n2. Методы ArrayList\n3. Методы Hashtable\n4. Методы SortedList");
		string choice = Console.ReadLine();
		switch (choice){
		case "1":
			while(true){ArrayWorker(array);}
			break;
		case "2":
			while(true){ArrayListWorker(arrayList);}
			break;
		case "3":
			while(true){HashtableWorker(hashtable);}
			break;
		case "4":
			while(true){SortedListWorker(sortedList);}
			break;
		default:
			Console.WriteLine("Неправильный ввод");
			break;
		}
  }
	static void ArrayWorker(Array a){
		Console.WriteLine("Выберите действие:");
		Console.WriteLine($"1. Узнать длину массива\n2. Побитовый поиск\n3. Удаление части массива\n4. Проверка существования элемента\n5. Заполнение массива одним элементом\n6. Поиск первого вхождения элемента\n7. Множественный поиск элементов\n8. Узнать тип элементов в массиве\n9. Развернуть массив\n10. Сортировка массива");
		int choice = Int32.Parse(Console.ReadLine());
		switch (choice){
		case 1:
			Console.WriteLine(a.Length);
			break;
		case 2:
			Console.WriteLine("Введите объект для поиска:");
			string b = Console.ReadLine();
			Console.WriteLine(Array.BinarySearch(a, b));
			break;
		case 3:
			int c, d;
			Console.WriteLine("Введите индекс начала и количество элементов для удаления:");
			c = Int32.Parse(Console.ReadLine());
			d = Int32.Parse(Console.ReadLine());
			Array.Clear(a, c, d);
			PrintArray(a);
			break;
		case 4:
			Console.WriteLine("Введите элемент:");
			b = Console.ReadLine();
			Console.WriteLine(Array.Exists((string[])a, element => element == b));
			break;
		case 5:
			Console.WriteLine("Введите элемент:");
			b = Console.ReadLine();
			Array.Fill((string[])a, b);
			PrintArray(a);
			break;
		case 6:
			Console.WriteLine("Введите объект для поиска:");
			b = Console.ReadLine();
			Console.WriteLine(Array.FindIndex((string[])a, element => element == b));
			break;
		case 7:
			Console.WriteLine("Введите объект для поиска (Введите len N, где N - число, для поиска слов по длине)");
			b = Console.ReadLine();
			if (b.Split(" ")[0] == "len"){
				PrintArray(Array.FindAll((string[])a, element => element.Length == Int32.Parse((b.Split(" ")[1]))));
			}
			else{
				Console.WriteLine(Array.FindIndex((string[])a, element => element == b));
			}
			break;
		case 8:
			Console.WriteLine(a.GetType());
			break;
		case 9:
			Array.Reverse(a);
			PrintArray(a);
			break;
		case 10:
			Array.Sort(a);
			PrintArray(a);
			break;
		}
	}
	static void ArrayListWorker(ArrayList a){
		Console.WriteLine("Выберите действие:");
		Console.WriteLine($"1. Узнать длину массива\n2. Побитовый поиск\n3. Удаление части массива\n4. Проверка существования элемента\n5. Заполнение массива\n6. Поиск первого вхождения элемента\n7. Поиск последнего вхождения элемнта\n8. Узнать тип элементов в массиве\n9. Развернуть массив\n10. Сортировка массива");
		int choice = Int32.Parse(Console.ReadLine());
		switch (choice){
		case 1:
			Console.WriteLine(a.Count);
			break;
		case 2:
			Console.WriteLine("Введите объект для поиска:");
			string b = Console.ReadLine();
			Console.WriteLine(a.BinarySearch(b));
			break;
		case 3:
			int c, d;
			Console.WriteLine("Введите индекс начала и количество элементов для удаления:");
			c = Int32.Parse(Console.ReadLine());
			d = Int32.Parse(Console.ReadLine());
			a.RemoveRange(c, d);
			PrintArray(a);
			break;
		case 4:
			Console.WriteLine("Введите элемент:");
			b = Console.ReadLine();
			Console.WriteLine(a.Contains(b));
			break;
		case 5:
			Console.WriteLine("Последовательно вводите элементы: (%END% - конец последовательности)");
			b = Console.ReadLine();
			while(b != "%END%"){
				a.Add(b);
				b = Console.ReadLine();
				}
			PrintArray(a);
			break;
		case 6:
			Console.WriteLine("Введите объект для поиска:");
			b = Console.ReadLine();
			Console.WriteLine(a.IndexOf(b));
			break;
		case 7:
			Console.WriteLine("Введите объект для поиска с конца:");
			b = Console.ReadLine();
			Console.WriteLine(a.LastIndexOf(b));
			break;
		case 8:
			Console.WriteLine(a.GetType());
			break;
		case 9:
			a.Reverse();
			PrintArray(a);
			break;
		case 10:
			a.Sort();
			PrintArray(a);
			break;
		}
	}
	static void HashtableWorker(Hashtable a){
		Console.WriteLine("Выберите действие:");
		Console.WriteLine($"1. Узнать длину словаря\n2. Вывести ключи\n3. Вывести значения\n4. Проверка существования ключа\n5. Проверка существования ключа (другое)\n6. Проверка существования значения\n7. Удаление элемента\n8. Очищение словаря\n9. Добавление элементов");
		int choice = Int32.Parse(Console.ReadLine());
		switch (choice){
		case 1:
			Console.WriteLine(a.Count);
			break;
		case 2:
			PrintArray(a.Keys);
			break;
		case 3:
			PrintArray(a.Values);
			break;
		case 4:
			Console.WriteLine("Введите ключ:");
			Console.WriteLine($"{a.Contains(Console.ReadLine())}");
			break;
		case 5:
			Console.WriteLine("Введите ключ:");
			Console.WriteLine($"{a.ContainsKey(Console.ReadLine())}");
			break;
		case 6:
			Console.WriteLine("Введите значение:");
			Console.WriteLine($"{a.ContainsValue(Console.ReadLine())}");
			break;
		case 7:
			Console.WriteLine("Введите ключ для удаления:");
			string b = Console.ReadLine();
			a.Remove(b);
			PrintArray(a);
			break;
		case 8:
			a.Clear();
			Console.WriteLine("Словарь очищен");
			break;
		case 9:
			Console.WriteLine("Введите пару слов в виде Ключ:Значение");
			b = Console.ReadLine();
			a.Add(b.Split(":")[0], b.Split(":")[1]);
			PrintArray(a);
			break;
		}
	}
	static void SortedListWorker(SortedList a){
		Console.WriteLine("Выберите действие:");
		Console.WriteLine($"1. Узнать длину словаря\n2. Вывести ключи\n3. Вывести значения\n4. Вызов элемента по индексу\n5. Проверка существования ключа\n6. Проверка существования значения\n7. Удаление элемента\n8. Очищение словаря\n9. Добавление элементов\n10. Замена значения по индексу");
		int choice = Int32.Parse(Console.ReadLine());
		switch (choice){
		case 1:
			Console.WriteLine(a.Count);
			break;
		case 2:
			PrintArray(a.Keys);
			break;
		case 3:
			PrintArray(a.Values);
			break;
		case 4:
			Console.WriteLine("Введите индекс:");
			int c = Int32.Parse(Console.ReadLine());
			Console.WriteLine($"{a.GetKey(c)}: {a.GetByIndex(c)}");
			break;
		case 5:
			Console.WriteLine("Введите ключ:");
			Console.WriteLine($"{a.ContainsKey(Console.ReadLine())}");
			break;
		case 6:
			Console.WriteLine("Введите значение:");
			Console.WriteLine($"{a.ContainsValue(Console.ReadLine())}");
			break;
		case 7:
			Console.WriteLine("Введите ключ для удаления:");
			string b = Console.ReadLine();
			a.Remove(b);
			PrintArray(a);
			break;
		case 8:
			a.Clear();
			Console.WriteLine("Словарь очищен");
			break;
		case 9:
			Console.WriteLine("Введите пару слов в виде Ключ:Значение");
			b = Console.ReadLine();
			a.Add(b.Split(":")[0], b.Split(":")[1]);
			PrintArray(a);
			break;
		case 10:
			Console.WriteLine("Введите индекс и значение через пробел:");
			b = Console.ReadLine();
			a.SetByIndex(Int32.Parse(b.Split()[0]), b.Split()[1]);
			PrintArray(a);
			break;
		}
	}
	static void PrintArray(string[] a){
		foreach(var i in a){
			Console.Write($"{i} ");
		}
		Console.WriteLine();
	}
	static void PrintArray(ArrayList a){
		foreach(var i in a){
			Console.Write($"{i} ");
		}
		Console.WriteLine();
	}
	static void PrintArray(Hashtable a){
		foreach(DictionaryEntry i in a){
			Console.Write($"{i.Key}: {i.Value}, ");
		}
		Console.WriteLine();
	}
	static void PrintArray(SortedList a){
		foreach(DictionaryEntry i in a){
			Console.Write($"{i.Key}: {i.Value}, ");
		}
		Console.WriteLine();
	}
	static void PrintArray(ICollection a){
		foreach(var i in a){
			Console.Write($"{i} ");
		}
		Console.WriteLine();
	}
}
