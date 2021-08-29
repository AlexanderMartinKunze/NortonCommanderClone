using System;
using System.Threading;

namespace The_lock_statement_2
{
	class MainClass
	{
		// shared private fields
		private static int value1 = 1;
		private static int value2 = 1;

		// synchronisation object
		private static object syncObj = new object ();

		// thread work method
		public static void DoWork2()
		{
			bool lockTaken = false;
			try 
			{
				// Monitor.Enter(syncObj, ref lockTaken);

				#region Monitor.TryEnter
				Monitor.TryEnter(syncObj, TimeSpan.FromMilliseconds(50), ref lockTaken);
				#endregion

				if (value2 > 0) 
				{
					Console.WriteLine (value1 / value2);
					value2 = 0;
				}
			}
			finally
			{
				if (lockTaken)
				{
					Monitor.Exit (syncObj);
				}
			}

		}

		public static void Main (string[] args)
		{
			// start two threads
			Thread t1 = new Thread (DoWork2);
			Thread t2 = new Thread (DoWork2);
			t1.Start ();
			t2.Start ();
		}
	}
}
