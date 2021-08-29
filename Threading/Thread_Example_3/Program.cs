using System;
using System.Threading;

namespace Thread_Example_3
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			// start background thread
			Thread t = new Thread (() => { 
				Console.WriteLine("Thread is starting, press ENTER to continue..");
				Console.ReadLine(); 
			});
			t.IsBackground = false;
			t.Start ();

			// main program thread ends here
		}
	}
}
