using System;
using System.Linq;
using System.Collections.Generic;

class Program {
	public class Product{
		public string name {get;}
		public string type {get;}
		public string comment {get;}
		
		public Product(string name, string type, string comment = ""){
			this.name = name;
			this.type = type;
			this.comment = comment;
		}
	}

	public class Provider{
		public string name {get;}

		public Provider(string name){
			this.name = name;
		}
	}

	public class Supply{
		public Provider provider {get;}
		public Product product {get;}
		public double quantity {get;}
		public string unit {get;}
		public string date {get; set;}

		public Supply(Provider provider, Product product, double quantity, string unit, string date){
			this.provider = provider;
			this.product = product;
			this.quantity = quantity;
			this.unit = unit;
			this.date = date;
		}
	}
	
  public static void Main (string[] args) {
    List<Product> Products = new List<Product>();
		Products.Add(new Product("Молочный коктейль Чудо", "Молочная продукция", "Упаковка 200мл"));
		Products.Add(new Product("Молочный коктейль Чудо", "Молочная продукция", "Упаковка 900мл"));
		Products.Add(new Product("Пиво Budweiser", "Слабоалкогольная продукция", "Банка 0.33л"));
		Products.Add(new Product("Яблоки Белый налив", "Фрукты", ""));
		Products.Add(new Product("Яблоки Макинтош", "Фрукты", ""));
		Products.Add(new Product("Чеснок", "Овощи", ""));
		Products.Add(new Product("Сыр Ламбер", "Молочная продукция", "Головка 1кг"));

		List<Provider> Providers = new List<Provider>();
		Providers.Add(new Provider("ООО Рога и копыта"));
		Providers.Add(new Provider("ООО Вектор"));
		Providers.Add(new Provider("ACME Ltd."));

		List<Supply> Supplies = new List<Supply>();
		Supplies.Add(new Supply(Providers[1], Products[0], 100, "шт", "1.06.2023"));
		Supplies.Add(new Supply(Providers[1], Products[1], 50, "шт", "1.06.2023"));
		Supplies.Add(new Supply(Providers[1], Products[6], 50, "шт", "1.06.2023"));
		Supplies.Add(new Supply(Providers[1], Products[2], 75, "шт", "2.06.2023"));
		Supplies.Add(new Supply(Providers[0], Products[3], 100, "кг", "14.06.2023"));
		Supplies.Add(new Supply(Providers[0], Products[4], 50, "кг", "14.06.2023"));
		Supplies.Add(new Supply(Providers[0], Products[5], 30, "кг", "14.06.2023"));
		Supplies.Add(new Supply(Providers[0], Products[2], 80, "шт", "16.06.2023"));
		Supplies.Add(new Supply(Providers[2], Products[2], 350, "шт", "11.06.2023"));

		//Поставки по дням
		string date = "14.06.2023";
		string output = "";
		foreach(Supply i in Supplies){
			if(i.date == date) output += $"{i.provider.name} {i.product.name} {i.quantity} {i.unit}\n";
		}
		if(output == "") Console.WriteLine("В этот день ничего не поставлялось");
		else Console.WriteLine(output);

		//Поставки по продуктам
		Random rnd = new Random();
		Product random_product = Products[rnd.Next(Products.Count)];
		output = "";
		Console.WriteLine(random_product.name);
		foreach(Supply i in Supplies){
			if(i.product == random_product) output += $"{i.provider.name} {i.date}\n";
		}
		if(output == "") Console.WriteLine("Этот продукт не поставлялся");
		else Console.WriteLine(output);

		//Поставки от поставщика
		Provider provider = Providers[1];
		output = "";
		Console.WriteLine(provider.name);
		foreach(Supply i in Supplies){
			if(i.provider == provider) output += $"{i.product.name} {i.quantity} {i.unit} {i.date}\n";
		}
		if(output == "") Console.WriteLine("Этот поставщик ничего не поставлял");
		else Console.WriteLine(output);
  }
}
