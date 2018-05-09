using System;
using MailSender;

namespace Example
{
	class A<T>
	{
		public static T Value;
	}

	class Program
	{
		static void Main()
		{
			//A<int>.Value = 5;
			//A<Int32>.Value = 10;
			//A<uint>.Value = 15;
			////Console.WriteLine(A<int>.Value);

			string value = "5";
			string value1 = "10";
			value = value1;
			value1 = "15";

			var t = $"ffdf {5} fdf fdfd";
			var t2 = String.Format("ffdf {0} fdf fdfd", 6);
			var t3 = "ffdf {0} fdf fdfd".MyFormat(6);
			Console.WriteLine(value);
			Console.ReadKey();
			return;
			new B();
			global::Test test = new global::Test();

			Console.WriteLine(test.Id);
		}
	}



	class Test
	{
		public string Id;
	}

	#region 1

	public class A
	{
		public A()
		{
			Console.WriteLine('A');
		}
	}

	public class B : A
	{
		public B()
		{
			Console.WriteLine('B');
		}
	}

	#endregion
}

class Test
{
	public int Id;
}
