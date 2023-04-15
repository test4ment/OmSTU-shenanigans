using System;
using System.Collections;
using System.Collections.Generic;

class Program {
	//hashSet. 
  static void Main(){
        Console.Clear();
        int i = 0;
        Random rnd = new Random();
        Console.Write("Введите количество слов от 1 до 20: ");
        int n = Int32.Parse(Console.ReadLine());
        Console.WriteLine();

        Array array = Array.CreateInstance(typeof(string), n);
        ArrayList array_list = new ArrayList(n);
        Hashtable hash_table = new Hashtable(n);
        SortedList sorted_list = new SortedList(n);
        Stack my_steck = new Stack(n); //SKDSKJHDKSJDHKSJDHKSDHKSDHKSDK
        Queue<string> my_queue = new Queue<string>(n);
        List<string> my_list = new List<string>();
				Dictionary<string, string> my_dict = new Dictionary<string, string>();
				SortedDictionary<string, string> my_sortedDict = new SortedDictionary<string, string>();

        string[] words = { "Game", "Vpn", "Free", "Chat", "Assasins", "Creed", "Crysis", "Botle","Soda","Milk","Play","Windows","Vinner","Eat","Cat","Dog","Block","Figma","Film","End"};
        string[] value = { "YES", "NO","None"};

        while (i < words.Length && i < n)
        {
            array.SetValue(words[i], i);
            Shuffle(words);
            array_list.Add(words[i]);
            Shuffle(words);
            i++;
        }
        i = 0;
        while (i < words.Length && i < n)
        {
            int index = rnd.Next(value.Length);
            my_steck.Push(words[i]);
            hash_table.Add(words[i], value[index]);
            sorted_list.Add(words[i], value[index]);
            my_queue.Enqueue(words[i]);
            my_list.Add(words[i]);
						my_dict.Add(words[i], value[index]);
						my_sortedDict.Add(words[i], value[index]);
            i++;
        }
        Console.WriteLine("|Array|"); PrintArray(array);
        Console.WriteLine("|ArrayList|"); PrintArray(array_list);
        Console.WriteLine("|Hashtable|"); PrintArray(hash_table);
        Console.WriteLine("|SortedList|"); PrintArray(sorted_list);
        Console.WriteLine("|Stack|"); PrintArray(my_steck);
        Console.WriteLine("|Queue|"); PrintArray(my_queue);
        Console.WriteLine("|List|"); PrintArray(my_list);
				Console.WriteLine("|Dictionary|"); PrintArray(my_dict);
				Console.WriteLine("|SortedDictionary|"); PrintArray(my_sortedDict);
        
        Console.WriteLine("Меню:");
        Console.WriteLine("1. Методы Array\n2. Методы ArrayList\n3. Методы Hashtable\n4. Методы SortedList\n5. Методы Stack\n6. Методы Queue\n7. Методы List\n8. Методы Dictionary\n9. Методы SortedDictionary\n");
            Console.Write("Выберите нужное действие: ");
            string step = Console.ReadLine();
            Console.WriteLine();
            bool fl = true;
            switch (step)
            {
                case "1":
                    array_methods(array);
                    break;
                case "2":
                    array_list_methods(array_list, n);
                    break;
                case "3":
                    hash_table_methods(hash_table);
                    break;
                case "4":
                    sorted_list_methods(sorted_list);
                    break;
            case "5":
                    stack_worker(my_steck);
                    break;
            case "6":
                    queue_worker(my_queue);
                    break;
						case "7":
                    list_methods(my_list);
										break;
						case "8":
                    dict_methods(my_dict);
										break;
            case "9":
                    soted_dict_methods(my_sortedDict);
										break;
            default:
                    Console.WriteLine("Введите правильную цифру: ");
                    fl = false;
                    break;
            }
            if (fl) { Console.Clear(); break; }
        }

    static void array_methods(Array arr)
    {
        Console.Clear();
        while (true)
        {
            
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Узнать длину массива\n2. Побитовый поиск\n3. Удаление части массива\n4. Проверка существования элемента\n5. Заполнение массива\n6. Поиск первого вхождения элемента\n7. Поиск последнего вхождения элемнта\n8. Узнать тип элементов в массиве\n9. Развернуть массив\n10. Сортировка массива\n11. Начать заново");
            Console.Write("\nВыберите метод: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine($"Длина массива: {arr.Length}\n");
                    Console.Write("Введите y для выхода: ");
                    if (Console.ReadLine().ToLower() == "y") Console.Clear();
                    break;
                case "2":
                    Console.Clear();
                    Array.Sort(arr);
                    Console.Write("Введите объект: ");
                    var response = Console.ReadLine();
                    var get = Array.BinarySearch(arr, response);
                    Console.WriteLine(get);
                    Console.Write("\nВведите y для выхода: ");
                    if (Console.ReadLine().ToLower() == "y") Console.Clear();
                    break;
                case "3":
                    Console.Clear();
                    Console.Write("Введите левую границу: ");
                    int p1 = Int32.Parse(Console.ReadLine());
                    Console.Write("Введите правую границу: ");
                    int p2 = Int32.Parse(Console.ReadLine());
                    ///Array.Clear(arr,p1,p2); Это короче альтернатива, но мне не нравится она 
                    for (var index = 0; index < arr.Length; index++)
                    {
                        if (index >= p1 && index <= p2)
                            continue;
                        else                       
                            Console.WriteLine(arr.GetValue(index));                     
                    } 
                    Console.WriteLine("\nВыполнено!\n");
                    Console.Write("\nВведите y для выхода: ");
                    if (Console.ReadLine().ToLower() == "y") Console.Clear();
                    break;
                case "4":
                    Console.Clear();
                    Console.Write("Введите слово для поиска: ");
                    string request = Console.ReadLine();
                    if (Array.Exists((string[])arr, element => element == request))                
                        Console.WriteLine("Такое слово существует!");
                    else
                        Console.WriteLine("Такое слово не существует!");
                    Console.Write("\nВведите y для выхода: ");
                    if (Console.ReadLine().ToLower() == "y") Console.Clear();
                    break;
                case "5":
                    Console.Clear();
                    Console.Write("Введите элемент: ");
                    string word = Console.ReadLine();
                    Array.Fill((string[])arr, word);
                    Console.Write("Ваш массив:");
                    PrintArray(arr);
                    Console.Write("\nВведите y для выхода: ");
                    if (Console.ReadLine().ToLower() == "y") Console.Clear();
                    break;
                case "6":
                    Console.Clear();
                    Console.Write("Введите слово для поиска: ");
                    string request_1 = Console.ReadLine();
                    int enter = Array.IndexOf(arr, request_1);
                    if (enter != -1)
                        Console.WriteLine($"Такое слово существует. Его индекс {enter}");
                    else
                        Console.WriteLine("Такое слово не существует!");
                    Console.Write("\nВведите y для выхода: ");
                    if (Console.ReadLine().ToLower() == "y") Console.Clear();
                    break;
                case "7":
                    Console.Clear();
                    Console.Write("Мы будем искать слова по заданной длине. Пожалуйста, введите её: ");
                    int length;
                    if (!int.TryParse(Console.ReadLine(), out length))
                    {
                        Console.WriteLine("Неправильный ввод. Пожалуйста, введите цифру");
                    }
                    else
                    {
                        string[] result = Array.FindAll((string[]) arr, word => word.Length == length);
                        Console.WriteLine("Слова с длиной {0}: ", length);
                        PrintArray(result);
                    }
                    Console.Write("\nВведите y для выхода: ");
                    if (Console.ReadLine().ToLower() == "y") Console.Clear();
                    break;
                case "8":
                    Console.Clear();
                    Console.Write($"Тип элементов: {arr.GetType().GetElementType()}\n\n");
                    Console.Write("\nВведите y для выхода: ");
                    if (Console.ReadLine().ToLower() == "y") Console.Clear();
                    break;
                case "9":
                    Console.Clear();
                    Console.Write("Массив:\n");
                    PrintArray(arr);
                    Console.Write("\nВведите y для выхода: ");
                    if (Console.ReadLine().ToLower() == "y") Console.Clear();
                    break;
                case "10":
                    Console.Clear();
                    Console.WriteLine("Отсортированный массив:");
                    Array.Sort(arr);
                    PrintArray(arr);
                    Console.Write("Введите y для выхода: ");
                    if (Console.ReadLine().ToLower() == "y") Console.Clear();
                    break;
                case "11":
                    Main();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Неверный ввод данных. Пожалуйста, повторите попытку!");
                    break;
            }

        }
    }

    static void array_list_methods(ArrayList arr, int n)
    {
        Console.Clear();
        while (true)
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Узнать длину списка\n2. Побитовый поиск\n3. Удаление части списка\n4. Проверка на существование элемента\n5. Заполнение списка одним элементом.\n6. Поиск первого вхождения элемента\n7. Поиск элементов с конца\n8. Узнать тип элементов в списке\n9. Печать списка\n10. Сортировка списка\n11. Начать заново");
            Console.Write("\nВыберите метод: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine($"Длина списка: {arr.Count}\n");
                    Console.Write("Введите y для выхода: ");
                    if (Console.ReadLine().ToLower() == "y") Console.Clear();
                    break;

                case "2":
                    Console.Clear();
                    Console.Write("Введите объект: ");
                    var response_binary_search = Console.ReadLine();
                    arr.Sort();
                    Console.WriteLine(arr.BinarySearch(response_binary_search));
                    Console.Write("\nВведите y для выхода: ");
                    if (Console.ReadLine().ToLower() == "y") Console.Clear();
                    break;

                case "3":
                    Console.Clear();
                    Console.Write("Введите левую границу: ");
                    int p1 = Int32.Parse(Console.ReadLine());
                    Console.Write("Введите правую границу: ");
                    int p2 = Int32.Parse(Console.ReadLine());
                    try
                    {
                        arr.RemoveRange(p1, p2);
                        PrintArray(arr);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine($"Ошибка: {ex.Message}");
                    }
                    
                    Console.Write("\nВведите y для выхода: ");
                    if (Console.ReadLine().ToLower() == "y") Console.Clear();
                    break;

                case "4":
                    Console.Clear();
                    Console.Write("Введите слово для поиска: ");
                    string word_search = Console.ReadLine();
                    if (arr.Contains(word_search))
                        Console.WriteLine("Такое слово существует!");
                    else
                        Console.WriteLine("Такое слово не существует!");
                    Console.Write("\nВведите y для выхода: ");
                    if (Console.ReadLine().ToLower() == "y") Console.Clear();
                    break;

                case "5":
                    Console.Clear();
                    Console.Write("Введите ваше слово: ");
                    string word_list = Console.ReadLine();
                    ArrayList new_arr = new ArrayList(n);
                    for (int i = 0; i < n; i++)
                    {
                        new_arr.Add(word_list);
                    }
                    Console.WriteLine("Ваш массив:");
                    PrintArray(new_arr);
                    Console.Write("\nВведите y для выхода: ");
                    if (Console.ReadLine().ToLower() == "y") Console.Clear();
                    break;

                case "6":
                    Console.Clear();
                    Console.Write("Введите ваше слово для поиска: ");
                    string myString = Console.ReadLine();
                    int myIndex = arr.IndexOf(myString);
                    if (myIndex != -1)
                        Console.WriteLine($"Такое слово существует. Его индекс {myIndex}");
                    else
                        Console.WriteLine("Такое слово не существует!");
                    Console.Write("\nВведите y для выхода: ");
                    if (Console.ReadLine().ToLower() == "y") Console.Clear();
                    break;

                case "7":
                    Console.Clear();
                    Console.Write("Мы будем искать первое вхождение слова с конца. Пожалуйста, введите его: ");
                    string word = Console.ReadLine();
                    int result = arr.LastIndexOf(word);
                    if (result != -1)
                        Console.WriteLine($"Такое слово существует. Его индекс {arr.LastIndexOf(word)}");
                    else
                        Console.WriteLine("Такое слово не существует!");

                    Console.Write("\nВведите y для выхода: ");
                    if (Console.ReadLine().ToLower() == "y") Console.Clear();
                    break;
                case "8":
                    Console.Clear();
                    Console.Write($"Тип элементов: {arr.GetType()}\n\n");
                    Console.Write("\nВведите y для выхода: ");
                    if (Console.ReadLine().ToLower() == "y") Console.Clear();
                    break;
                case "9":
                    Console.Clear();
                    Console.Write("Массив:\n");
                    PrintArray(arr);
                    Console.Write("\nВведите y для выхода: ");
                    if (Console.ReadLine().ToLower() == "y") Console.Clear();
                    break;

                case "10":
                    Console.Clear();
                    Console.WriteLine("Отсортированный массив:");
                    arr.Sort();
                    PrintArray(arr);
                    Console.Write("\nВведите y для выхода: ");
                    if (Console.ReadLine().ToLower() == "y") Console.Clear();
                    break;
                case "11":
                    Main();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Неверный ввод данных. Пожалуйста, повторите попытку!");
                    break;
            }

        }
    }


    static void hash_table_methods(Hashtable arr){
        Console.Clear();
        while (true)
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Узнать длину словаря\n2. Вывести ключи\n3. Вывести значения\n4. Проверить, содержит ли объект Hashtable указанный ключ(1)\n5. Проверить, содержит ли объект Hashtable указанный ключ(2)\n6. Проверка существования значения\n7. Удаление элемента\n8. Очищение словаря\n9. Добавление элементов\n10. Начать заново");
            Console.Write("\nВыберите метод: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine($"Длина Хэш-таблицы: {arr.Count}\n");
                    Console.Write("Введите y для выхода: ");
                    if (Console.ReadLine().ToLower() == "y") Console.Clear();
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("Ключи: ");
                    foreach (var key in arr.Keys)
                    {
                        Console.WriteLine(key);
                    }
                    Console.Write("\nВведите y для выхода: ");
                    if (Console.ReadLine().ToLower() == "y") Console.Clear();
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("Значения: ");
                    foreach (var value in arr.Values)
                    {
                        Console.WriteLine(value);
                    }
                    Console.Write("\nВведите y для выхода: ");
                    if (Console.ReadLine().ToLower() == "y") Console.Clear();
                    break;
                case "4":
                    Console.Clear();
                    Console.Write("Введите ключ для поиска: ");
                    var key_search_version_1 = Console.ReadLine();
                    if (arr.Contains(key_search_version_1))
                        Console.WriteLine("Такой ключ существует!");
                    else
                        Console.WriteLine("Такой ключ не существует!");
                    Console.Write("\nВведите y для выхода: ");
                    if (Console.ReadLine().ToLower() == "y") Console.Clear();
                    break;
                case "5":
                    Console.Clear();
                    Console.Write("Введите ключ для поиска: ");
                    var key_search_version_2 = Console.ReadLine();
                    if (arr.ContainsKey(key_search_version_2))
                        Console.WriteLine("Такой ключ существует!");
                    else
                        Console.WriteLine("Такой ключ не существует!");
                    Console.Write("\nВведите y для выхода: ");
                    if (Console.ReadLine().ToLower() == "y") Console.Clear();
                    break;
                case "6":
                    Console.Clear();
                    Console.Write("Введите значение для поиска: ");
                    var value_search = Console.ReadLine();
                    if (arr.ContainsValue(value_search))
                        Console.WriteLine("Такое значение существует!");
                    else
                        Console.WriteLine("Такой значение не существует!");
                    Console.Write("\nВведите y для выхода: ");
                    if (Console.ReadLine().ToLower() == "y") Console.Clear();
                    break;
                case "7":
                    Console.Clear();
                    Console.Write("Ключи: ");
                    foreach (var key in arr.Keys){Console.Write($"{key} ");}
                    Console.Write("\nВведите ключ для удаления: ");
                    var key_delete= Console.ReadLine();
                    arr.Remove(key_delete);
                    Console.WriteLine($"Выполнено! {key_delete} удалено из Hashtable\nРезультат:");
                    PrintArray(arr);
                    Console.Write("Введите y для выхода: ");
                    if (Console.ReadLine().ToLower() == "y") Console.Clear();
                    break;
                case "8":
                    Console.Clear();
                    Console.Write("Вы действительно хотите отчистить Hashtable? yES/NO: ");
                    if (Console.ReadLine().ToLower() == "yes")
                    {
                        arr.Clear();
                        Console.WriteLine("Hashtable отчищена!");

                    }
                    Console.Write("\nВведите y для выхода: ");
                    if (Console.ReadLine().ToLower() == "y") Console.Clear();
                    break;
                case "9":
                    Console.Clear();
                    Console.Write("Сколько элементов вы хотите доавбить: ");
                    try
                    {
                        int num = Int32.Parse(Console.ReadLine());
                        for (int i = 0; i < num; i++)
                        {
                            Console.Write("Введите ключ: ");
                            var key = Console.ReadLine();
                            Console.Write("Введите значение: ");
                            var value = Console.ReadLine();
                            arr.Add(key, value);
                            Console.Write("Пара добавлена!\n");
                        }
                        Console.WriteLine();
                        Console.WriteLine("SortedList:");
                        PrintArray(arr);
                    }
                    catch
                    {
                        Console.WriteLine("Ошибка! Вы вввели не число!");
                    }
                    Console.Write("\nВведите y для выхода: ");
                    if (Console.ReadLine().ToLower() == "y") Console.Clear();
                    break;
                case "10":
                    Main();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Неверный ввод данных. Пожалуйста, повторите попытку!");
                    break;
          }
        }
      }

    static void sorted_list_methods(SortedList arr)
    {
        Console.Clear();
        while (true)
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Узнать длину словаря\n2. Вывести ключи\n3. Вывести значения\n4. Вызов элемента по индексу\n5. Проверка существования ключа\n6. Проверка существования значения\n7. Удаление элемента\n8. Очищение словаря\n9. Добавление элементов\n10. Замена значения по индексу\n11. Начать заново");
            Console.Write("Выберите метод: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine($"Длина SortedList: {arr.Count}\n");
                    Console.Write("Введите y для выхода: ");
                    if (Console.ReadLine().ToLower() == "y") Console.Clear();
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("Ключи: ");
                    foreach (var key in arr.Keys)
                    {
                        Console.WriteLine(key);
                    }
                    Console.Write("\nВведите y для выхода: ");
                    if (Console.ReadLine().ToLower() == "y") Console.Clear();
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("Значения: ");
                    foreach (var value in arr.Values)
                    {
                        Console.WriteLine(value);
                    }
                    Console.Write("\nВведите y для выхода: ");
                    if (Console.ReadLine().ToLower() == "y") Console.Clear();
                    break;
                case "4":
                    Console.Clear();
                    Console.Write("Введите индекс: ");
                    
                    try
                    {
                        int index = Int32.Parse(Console.ReadLine());
                        Console.WriteLine($"{arr.GetKey(index)}: {arr.GetByIndex(index)}");
                    }
                    catch
                    {
                        Console.Write("Такого индекса не существует!");
                    }
                    Console.Write("\nВведите y для выхода: ");
                    if (Console.ReadLine().ToLower() == "y") Console.Clear();
                    break;
                case "5":
                    Console.Clear();
                    Console.Write("Введите ключ для поиска: ");
                    var key_search = Console.ReadLine();
                    if (arr.ContainsKey(key_search))
                        Console.WriteLine("Такой ключ существует!");
                    else
                        Console.WriteLine("Такой ключ не существует!");
                    Console.Write("\nВведите y для выхода: ");
                    if (Console.ReadLine().ToLower() == "y") Console.Clear();
                    break;
                case "6":
                    Console.Clear();
                    Console.Write("Введите значение для поиска: ");
                    var value_search = Console.ReadLine();
                    if (arr.ContainsValue(value_search))
                        Console.WriteLine("Такое значение существует!");
                    else
                        Console.WriteLine("Такой значение не существует!");
                    Console.Write("\nВведите y для выхода: ");
                    if (Console.ReadLine().ToLower() == "y") Console.Clear();
                    break;
                case "7":
                    Console.Clear();
                    Console.Write("Ключи: ");
                    foreach (var key in arr.Keys) { Console.Write($"{key} "); }
                    Console.Write("\nВведите ключ для удаления: ");
                    var key_delete = Console.ReadLine();
                    arr.Remove(key_delete);
                    Console.WriteLine($"Выполнено! {key_delete} удалено из SortedList\nРезультат:");
                    PrintArray(arr);
                    Console.Write("Введите y для выхода: ");
                    if (Console.ReadLine().ToLower() == "y") Console.Clear();
                    break;
                case "8":
                    Console.Clear();
                    Console.Write("Вы действительно хотите отчистить SortedList? yES/NO: ");
                    if (Console.ReadLine().ToLower() == "yes")
                    {
                        arr.Clear();
                        Console.WriteLine("SortedList отчищена!");

                    }
                    Console.Write("\nВведите y для выхода: ");
                    if (Console.ReadLine().ToLower() == "y") Console.Clear();
                    break;
                case "9":
                    Console.Clear();
                    Console.Write("Сколько элементов вы хотите доавбить: ");
                    try
                    {
                        int num = Int32.Parse(Console.ReadLine());
                        for (int i = 0; i < num; i++)
                        {
                            Console.Write("Введите ключ: ");
                            var key = Console.ReadLine();
                            Console.Write("Введите значение: ");
                            var value = Console.ReadLine();
                            arr.Add(key, value);
                            Console.Write("Пара добавлена!\n");
                        }
                        Console.WriteLine();
                        Console.WriteLine("SortedList:");
                        PrintArray(arr);
                    }
                    catch
                    {
                        Console.WriteLine("Ошибка! Вы вввели не число!");
                    }               
                    Console.Write("\nВведите y для выхода: ");
                    if (Console.ReadLine().ToLower() == "y") Console.Clear();
                    break;
                case "10":
                    Console.Clear();
                    Console.Write("Введите индекс: ");
                    int number = Int32.Parse(Console.ReadLine());
                    Console.Write("Введите значение: ");
                    var value_new = Console.ReadLine();
                    arr.SetByIndex(number, value_new);
                    Console.WriteLine($"Готово! Значение в индексе {number} заменено на {value_new}");
                    Console.Write("\nВведите y для выхода: ");
                    if (Console.ReadLine().ToLower() == "y") Console.Clear();
                    break;
                case "11":
                    Main();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Неверный ввод данных. Пожалуйста, повторите попытку!");
                    break;
            }

        }
    }
  	
		static void stack_worker(Stack arr){
    Console.Clear();
    while (true)
        {
          Console.WriteLine("Меню:");
          Console.WriteLine("1. Узнать длину Stack\n2. Определить, входит ли элемент в коллекцию Stack.\n3. Удалить объект, находящийся в самом начале Stack\n4. Добавить элемент в верхушку стека\n5. Вывести первый элемент из стека без его удаления\n6. Проверить предложение на баланс скобок\n7. Узнать тип данных в Stack\n8. Начать заново");
          Console.Write("Выберите метод: ");
          string choice = Console.ReadLine();
          switch (choice){
          case "1":
              Console.Clear();
              Console.WriteLine($"Длина Stack: {arr.Count}\n");
              Console.Write("Введите y для выхода: ");
              if (Console.ReadLine().ToLower() == "y") Console.Clear();
              break;
          case "2":
             Console.Clear();
             Console.Write("Введите значение для поиска: ");
             var value_search = Console.ReadLine();
             if (arr.Contains(value_search))
                 Console.WriteLine("Такое значение существует!");
             else
                 Console.WriteLine("Такой значение не существует!");
            Console.Write("\nВведите y для выхода: ");
            if (Console.ReadLine().ToLower() == "y") Console.Clear();
            break;
          case "3":
            Console.Clear();
            var word_delete = arr.Pop();
            Console.WriteLine($"Слово {word_delete} удалено из начала Stack!");
            Console.Write("\nВведите y для выхода: ");
            if (Console.ReadLine().ToLower() == "y") Console.Clear();
            break;
          case "4":
            Console.Clear();
            Console.Write("Введите слово, которые Вы хотите добавить: ");
            string word_insert = Console.ReadLine();
            arr.Push(word_insert);
            Console.WriteLine($"Слово {word_insert} добавлено в Stack!");
            Console.WriteLine("\nНовый Stack:\n");
            PrintArray(arr);
            Console.Write("Введите y для выхода: ");
            if (Console.ReadLine().ToLower() == "y") Console.Clear();
            break;
          case "5":
            Console.Clear();
            Console.WriteLine(arr.Peek());
            Console.Write("\nВведите y для выхода: ");
            if (Console.ReadLine().ToLower() == "y") Console.Clear();
            break;
          case "6":
            Console.Clear();
            Console.Write("Введите предложение со скобками: ");
            string sentence = Console.ReadLine();
            if (Brackets(sentence)) Console.WriteLine("Количесвто скобок совпадает!");      
            else Console.WriteLine("Количесвто скобок не совпадает!");
            Console.Write("\nВведите y для выхода: ");
            if (Console.ReadLine().ToLower() == "y") Console.Clear();
            break;
          case "7":
            Console.Clear();
            Console.Write($"Тип элементов: {arr.GetType()}\n\n");
            Console.Write("Введите y для выхода: ");
            if (Console.ReadLine().ToLower() == "y") Console.Clear();
            break;
          case "8":
            Main();
            break;
          default:
            Console.Clear();
            Console.WriteLine("Неверный ввод данных. Пожалуйста, повторите попытку!");
            break;
              
          }
          
        }
    }
    static void queue_worker(Queue<string> arr)
    {
      Console.Clear();
      while (true)
          {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Узнать длину Queue\n2. Определить, входит ли элемент в коллекцию Queue.\n3. Отчистить очередь\n4. Удалить первый элемент очереди\n5. Добавить объект в конец коллекции Queue\n6. Вывести первый элемент из очереди без его удаления.\n7. Узнать тип данных в Queue\n8. Вывести очередь\n9. Начать заново");
            Console.Write("Выберите метод: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
            case "1":
              Console.Clear();
              Console.WriteLine($"Длина Queue: {arr.Count}\n");
              Console.Write("Введите y для выхода: ");
              if (Console.ReadLine().ToLower() == "y") Console.Clear();
              break;
            case "2":
              Console.Clear();
              Console.Write("Введите значение для поиска: ");
              var value_search = Console.ReadLine();
              if (arr.Contains(value_search))
                  Console.WriteLine("Такое значение существует!");
              else
                  Console.WriteLine("Такой значение не существует!");
              Console.Write("\nВведите y для выхода: ");
              if (Console.ReadLine().ToLower() == "y") Console.Clear();
              break;
            case "3":
              Console.Clear();
              arr.Clear();
              Console.Write("Очередь теперь пуста!");
              Console.Write("\nВведите y для выхода: ");
              if (Console.ReadLine().ToLower() == "y") Console.Clear();
              break;
            case "4":
              Console.Clear();
              var word_delete = arr.Dequeue();
              Console.WriteLine($"Слово {word_delete} удалено из начала Queue!");
              Console.Write("\nВведите y для выхода: ");
              if (Console.ReadLine().ToLower() == "y") Console.Clear();
              break;
            case "5":
              Console.Clear();
              Console.Write("Введите слово, которые Вы хотите добавить: ");
              string word_insert = Console.ReadLine();
              arr.Enqueue(word_insert);
              Console.WriteLine($"Слово {word_insert} добавлено в Queue!");
              Console.WriteLine("\nНовый Stack:");
              PrintArray(arr);
              Console.Write("Введите y для выхода: ");
              if (Console.ReadLine().ToLower() == "y") Console.Clear();
            break;
            case "6":
              Console.Clear();
              Console.WriteLine(arr.Peek());
              Console.Write("\nВведите y для выхода: ");
              if (Console.ReadLine().ToLower() == "y") Console.Clear();
            break;
            case "7":
              Console.Clear();
              Console.Write($"Тип элементов: {arr.GetType()}\n\n");
              Console.Write("Введите y для выхода: ");
              if (Console.ReadLine().ToLower() == "y") Console.Clear();
              break;
            case "8":
              Console.Clear();
              Console.Write("Очередь:\n");
              PrintArray(arr);
              Console.Write("\nВведите y для выхода: ");
              if (Console.ReadLine().ToLower() == "y") Console.Clear();
              break;
            case "9":
              Main();
              break;
            default:
              Console.Clear();
              Console.WriteLine("Неверный ввод данных. Пожалуйста, повторите попытку!");
              break;
          }
    }       

    static void list_methods(List<string> arr)
    {
        Console.Clear();
        while (true)
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Узнать длину списка\n2. Добавить элемент в конец списка\n3. Проверка существования объекта\n4. Узнать тип данных в списке\n5. Поиск первого вхождения элемента \n6. Поиск последнего вхождения элемента \n7. Удалить первое вхождение элемента \n8. Очищение списка\n9. Удаление по индексу\n10. Начать заново");
            Console.Write("Выберите метод: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine($"Длина SortedList: {arr.Count}\n");
                    Console.Write("Введите y для выхода: ");
                    if (Console.ReadLine().ToLower() == "y") Console.Clear();
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("\nВведите элемент, который хотите добавить:");
                    arr.Add(Console.ReadLine());
                    Console.WriteLine("Получившийся список:", arr );
                    Console.Write("\nВведите y для выхода: ");
                    if (Console.ReadLine().ToLower() == "y") Console.Clear();
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("\nВведите элемент, который вы хотите найти:");
                    if (arr.Contains(Console.ReadLine())) {
                      Console.WriteLine("\nЭлемент находится в списке");
                    }
                    else{
                      Console.WriteLine("\nЭлемент не входит в список");
                    }
                    Console.Write("\nВведите y для выхода: ");
                    if (Console.ReadLine().ToLower() == "y") Console.Clear();
                    break;
                case "4":
                    Console.Clear();
                    Console.Write($"Тип элементов: {arr.GetType()}\n\n");
                    Console.Write("\nВведите y для выхода: ");
                    if (Console.ReadLine().ToLower() == "y") Console.Clear();
                    break;
                case "5":
                    Console.Clear();
                    Console.WriteLine("\nВведите элемент:");
                    Console.WriteLine($"Номер элемента: {arr.IndexOf(Console.ReadLine())}\n\n");
                    Console.Write("\nВведите y для выхода: ");
                    if (Console.ReadLine().ToLower() == "y") Console.Clear();
                    break;
                case "6":
                    Console.Clear();
                    Console.WriteLine("\nВведите элемент:");
                    Console.WriteLine($"Номер элемента: {arr.LastIndexOf(Console.ReadLine())}\n\n");
                    Console.Write("\nВведите y для выхода: ");
                    if (Console.ReadLine().ToLower() == "y") Console.Clear();
                    break;
                case "7":
                    Console.Clear();
                    Console.WriteLine("\nВведите элемент:");
                    Console.WriteLine($"Номер элемента: {arr.Remove(Console.ReadLine())}\n\n");
                    Console.Write("Введите y для выхода: ");
                    if (Console.ReadLine().ToLower() == "y") Console.Clear();
                    break;
                case "8":
                    Console.Clear();
                    Console.Write("Вы действительно хотите отчистить SortedList? yES/NO: ");
                    if (Console.ReadLine().ToLower() == "yes")
                    {
                        arr.Clear();
                        Console.WriteLine("List отчищена!");
                    }
                    Console.Write("\nВведите y для выхода: ");
                    if (Console.ReadLine().ToLower() == "y") Console.Clear();
                    break;
                case "9":
                    Console.Clear();
                    Console.WriteLine("\nВведите индекс:");
                    int nummmm = Int32.Parse(Console.ReadLine());
                    arr.RemoveAt(nummmm);
                    Console.Write("\nВведите y для выхода: ");
                    if (Console.ReadLine().ToLower() == "y") Console.Clear();
                    break;
                case "10":
                    Main();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Неверный ввод данных. Пожалуйста, повторите попытку!");
                    break;
            }

        }
    }
		static void dict_methods(Dictionary<string, string> arr){
      Console.Clear();
      string choice;
      while (true)
      {       
        Console.WriteLine("Меню:");
        Console.WriteLine("1. Количество элементов\n2. Вывести значения\n3. Вывести ключи\n4. Добавить элемент\n5. Очистить словарь\n6. Поиск по ключу\n7. Поиск по значению\n8. Вывод строки со всеми элементами");
        choice = Console.ReadLine();
        switch(choice)
          {
          case "1":
              Console.Clear();
              Console.WriteLine($"Количество пар ключ-значение: {arr.Count}");
              Console.Write("\nВведите y для выхода: ");
              if (Console.ReadLine().ToLower() == "y") Console.Clear();
                break;
          case "2":
              Console.Clear();
              Console.WriteLine("Значения: ");
              Dictionary<string, string>.ValueCollection valueColl = arr.Values;
                foreach(string s in valueColl)
                {
                Console.WriteLine($"{s}");
                }
              Console.Write("\nВведите y для выхода: ");
              if (Console.ReadLine().ToLower() == "y") Console.Clear();
              break;
          case "3":
              Console.Clear();
              Console.WriteLine("Ключи: ");
              Dictionary<string, string>.KeyCollection keyColl = arr.Keys;
              foreach(string s in keyColl)
              {
              Console.WriteLine($"{s}");
              }
              Console.Write("\nВведите y для выхода: ");
              if (Console.ReadLine().ToLower() == "y") Console.Clear();
                break;
          case "4":
              Console.Clear();
              Console.WriteLine("Введите ключ, а затем значение");
              string a = Console.ReadLine();
              string b = Console.ReadLine();
              arr.TryAdd(a, b);
              Console.WriteLine("Выполнено!");
              Console.Write("\nВведите y для выхода: ");
              if (Console.ReadLine().ToLower() == "y") Console.Clear();
                break;
          case "5":
              Console.Clear();
              arr.Clear();
              Console.WriteLine("Словарь очищен!");
              Console.Write("\nВведите y для выхода: ");
              if (Console.ReadLine().ToLower() == "y") Console.Clear();
                break;
          case "6":
              Console.Clear();
              Console.Write("Введите ключ для поиска: ");
              var key_search_version_2 = Console.ReadLine();
              if (arr.ContainsKey(key_search_version_2))
                  Console.WriteLine("Такой ключ существует!");
              else
                  Console.WriteLine("Такой ключ не существует!");
              Console.Write("\nВведите y для выхода: ");
              if (Console.ReadLine().ToLower() == "y") Console.Clear();
              break;
          case "7":
               Console.Clear();
               Console.Write("Введите значение для поиска: ");
               var value_search = Console.ReadLine();
               if (arr.ContainsValue(value_search))
                  Console.WriteLine("Такое значение существует!");
               else
                  Console.WriteLine("Такой значение не существует!");
                  Console.Write("\nВведите y для выхода: ");
               if (Console.ReadLine().ToLower() == "y") Console.Clear();
                  break;
          case "8":
              Console.Clear();
              Console.WriteLine(arr.ToString());
              Console.Write("\nВведите y для выхода: ");
              if (Console.ReadLine().ToLower() == "y") Console.Clear();
                break;
          case "9":
              Main();
              break;
          default:
              Console.Clear();
              Console.WriteLine("Неверный ввод данных. Пожалуйста, повторите попытку!");
              break;
    		 }
      }
			}
			
		}
		static void soted_dict_methods(SortedDictionary<string, string> arr){
			string choice;
			Console.WriteLine("1. Количество элементов\n2. Вывести значения\n3. Вывести ключи\n4. Добавить элемент\n5. Очистить словарь\n6. Поиск по ключу\n7. Поиск по значению\n8. Вывод строки со всеми элементами");
			choice = Console.ReadLine();
			switch(choice){
			case "1":
				Console.WriteLine($"Количество элементов: {arr.Count}");
				break;
			case "2":
				Console.WriteLine("Ключи: ");
				Dictionary<string, string>.ValueCollection keysColl = arr.Keys;
				foreach(string s in valueColl)
					{
					Console.WriteLine($"{s}");
					}
				break;
			case "3":
				Console.WriteLine("Значения: ");
				Dictionary<string, string>.ValueCollection valueColl = arr.Values;
				foreach(string s in valueColl)
					{
					Console.WriteLine($"{s}");
					}
				break;
			case "4":
				Console.Clear();
              Console.WriteLine("Введите ключ, а затем значение");
              string a = Console.ReadLine();
              string b = Console.ReadLine();
              arr.TryAdd(a, b);
              Console.Write("\nВведите y для выхода: ");
              if (Console.ReadLine().ToLower() == "y") Console.Clear();
        break;
			case "5":
				arr.Clear();
				Console.WriteLine("Словарь очищен");
				break;
			case "6":
              Console.Clear();
              Console.Write("Введите ключ, который надо найти: ");
              string c = Console.ReadLine();
              Console.WriteLine(arr.ContainsKey(c));
              Console.Write("\nВведите y для выхода: ");
              if (Console.ReadLine().ToLower() == "y") Console.Clear();
                break;
          case "7":
              Console.Clear();
              Console.WriteLine("Введите значение, который надо найти");
              string d = Console.ReadLine();
              Console.WriteLine(arr.ContainsValue(d));
              Console.Write("\nВведите y для выхода: ");
              if (Console.ReadLine().ToLower() == "y") Console.Clear();
                break;
			case "8":
              Console.Clear();
              Console.WriteLine(arr.ToString());
              Console.Write("\nВведите y для выхода: ");
              if (Console.ReadLine().ToLower() == "y") Console.Clear();
                break;
      case "9":
        Main();
        break;
      default:
				Console.Clear();
				Console.WriteLine("Неверный ввод данных. Пожалуйста, повторите попытку!");
				break;
			}
		}
  	static void PrintArray(Stack a)
    {
        foreach (var el in a)
        {
            Console.WriteLine(el);
        }
        Console.WriteLine();
    }
  	static void PrintArray(Array a)
    {
        foreach (var el in a)
        {
            Console.WriteLine(el);
        }
        Console.WriteLine();
    }
		static void PrintArray(List<string> a)
    {
        foreach (var el in a)
        {
            Console.WriteLine(el);
        }
        Console.WriteLine();
    }
  	static void PrintArray(ArrayList arr)
    {
        foreach (var el in arr)
        {
            Console.WriteLine(el);
        }
        Console.WriteLine();
    }
    static void PrintArray(SortedList arr)
    {
        foreach (DictionaryEntry kvp in arr)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }
        Console.WriteLine();
    }
    static void PrintArray(Hashtable arr)
    {
        foreach (DictionaryEntry de in arr)
        {
            Console.WriteLine($"{de.Key}: {de.Value}");
        }
        Console.WriteLine();
    }
		static void PrintArray(Dictionary<string, string> arr)
    {
        foreach (KeyValuePair<string, string> de in arr)
        {
            Console.WriteLine($"{de.Key}: {de.Value}");
        }
        Console.WriteLine();
    }
		static void PrintArray(Queue<string> arr){
			foreach (var obj in arr) Console.Write( "{0} ", obj);
      Console.WriteLine();
		}
		static void PrintArray(SortedDictionary<string, string> arr){
			foreach (KeyValuePair<string, string> de in arr)
        {
            Console.WriteLine($"{de.Key}: {de.Value}");
        }
        Console.WriteLine();
		}
    static void Shuffle<T>(T[] array){
        var random = new Random();
        for (int i = array.Length - 1; i > 0; i--)
        {
            int j = random.Next(i + 1);
            T temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
		static bool Brackets(string a){
		Stack b = new Stack();
		char[] OpenBrackets = {'(', '{', '[', '<'};
		char[] CloseBrackets = {')', '}', ']', '>'};
		char e = ' ';
		foreach(char i in a){
			if (Array.Exists(OpenBrackets, element => element == i)){
				b.Push(i);
			}
			else if (b.Count > 0 && Array.Exists(CloseBrackets, element => element == i)){
				e = (char)b.Pop();
				if (CloseBrackets[Array.FindIndex(OpenBrackets, element => element == e)] != i){
					return false;
					}
				}
			}
			if (b.Count > 0){
				return false;
				}
			return true;
			}
}
