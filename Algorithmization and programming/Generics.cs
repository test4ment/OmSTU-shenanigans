using System;

class Program {

	public class Array<T>{
		public int Length;
		public T[] arr = new T[0];
		
		public Array(int Length){
			this.Length = Length >= 0 ? Length : 0;
			this.arr = new T[Length];	
		}
		
		public void Set(T obj, int pos){
			if((pos < 0 && -pos > Length) || pos >= Length) throw new ArgumentOutOfRangeException();
			if(pos < 0) pos = Length + pos;
			arr[pos] = obj;
		}

		public void Remove(int pos){
			if((pos < 0 && -pos > Length) || pos >= Length) throw new ArgumentOutOfRangeException();
			if(pos < 0) pos = Length + pos;
			arr[pos] = default(T);
		}

		public T GetByIndex(int pos){
			if((pos < 0 && -pos > Length) || pos >= Length) throw new ArgumentOutOfRangeException();
			if(pos < 0) pos = Length + pos;
			return arr[pos];
		}
	}
	
  public static void Main (string[] args) {
    Array<string> ar = new Array<string>(5);
		for(var i = 0; i < ar.Length; i++){
			ar.Set("ae", i);
		}
		ar.Remove(3);
		Console.WriteLine(ar.GetByIndex(2));
  }
}
