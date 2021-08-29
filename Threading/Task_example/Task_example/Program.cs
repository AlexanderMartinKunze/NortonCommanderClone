using System;
using System.Threading.Tasks;
using System.Threading;

namespace Task_example
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			// start task
			var task = Task<string>.Factory.StartNew ( () => {
				Thread.Sleep(2000);
				return "Mark";
			});

			// use result
			Console.Write ("Your name is ");
			Console.Write (task.Result);
		}
	}
}
