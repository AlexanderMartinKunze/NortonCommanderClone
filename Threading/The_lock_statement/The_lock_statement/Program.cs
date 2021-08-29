using System;
using System.Threading;

namespace The_lock_statement
{
	class MainClass
	{
		// shared private fields
		private static int value1 = 1;
		private static int value2 = 1;

		#region synchronisation object
		private static object syncObj = new object ();
		#endregion

		// thread work method
		public static void DoWork()
		{
			lock (syncObj)
			{
				if (value2 > 0)
				{
					Console.WriteLine (value1 / value2);
					value2 = 0;
				}
			}
		}

		public static void Main (string[] args)
		{
			// start two threads
			Thread t1 = new Thread (DoWork);
			Thread t2 = new Thread (DoWork);
			t1.Start ();
			t2.Start ();
		}
	}
}
