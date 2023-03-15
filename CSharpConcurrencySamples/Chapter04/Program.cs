using Chapter04;
using System;

Console.WriteLine("C# Concurrency: Asynchronous and Multithreaded Programming");
Console.WriteLine("Chapter 2");

while (true)
{
	Console.WriteLine("Please select a sample to run, type the sample number then press enter");

	Console.WriteLine(" 1. Listing 4.1 Creating a thread");
	Console.WriteLine(" 2. Listing 4.2 Creating a thread with a parameter");
	Console.WriteLine(" 3. Listing 4.3 Wait for threads to finish");
	Console.WriteLine(" 4. Listing 4.4 Running in the thread pool");
	Console.WriteLine(" 5. Listing 4.5 Running in the thread pool with a parameter");
	Console.WriteLine(" 6. Listing 4.6 Running in the thread pool with Task.Run");
	Console.WriteLine(" 7. Listing 4.7 Running async code with Task.Run");
	Console.WriteLine(" 8. Listing 4.8 Waiting for tasks to finish with Task.Run");
	Console.WriteLine(" 9. Listing 4.9 Use lambdas to create a parametrized Task.Run");
	Console.WriteLine("10. Listing 4.10 Incorrect value when accessing shared data without locking");
	Console.WriteLine("11. Listing 4.11 Adding locks to avoid simultaneous access problems");
	Console.WriteLine(" X. Exit");

	var responseText = Console.ReadLine()?.Trim()?.ToLower();
	if (responseText == null || responseText == "x") return;

	if (!int.TryParse(responseText, out var sampleNumber))
	{
		Console.WriteLine("Can't parse your response, please try again");
		continue;
	}

	switch (sampleNumber)
	{
		case 1:
			new Listing1().RunInBackground();
			Thread.Sleep(500); // wait for background thread to finish
			break;
		case 2:
			new Listing2().RunLotsOfThreads();
			Thread.Sleep(500); // wait for background thread to finish
			break;
		case 3:
			new Listing3().RunAndWait();
			break;
		case 4:
			new Listing4().RunInBackground();
			Thread.Sleep(500); // wait for background thread to finish
			break;
		case 5:
			new Listing5().RunInBackground();
			Thread.Sleep(500); // wait for background thread to finish
			break;
		case 6:
			new Listing6().RunInBackground();
			Thread.Sleep(500); // wait for background thread to finish
			break;
		case 7:
			new Listing7().RunInBackground();
			Thread.Sleep(1000); // wait for background thread to finish
			break;
		case 8:
			await new Listing8().RunInBackground();
			break;
		case 9:
			new Listing9().RunInBackground();
			Thread.Sleep(500); // wait for background thread to finish
			break;
		case 10:
			new Listing10().GetIncorrectValue();
			break;
		case 11:
			new Listing11().GetCorrectValue();
			break;
		default:
			Console.WriteLine("Not a sample number, please try again");
			break;
	}
	Console.WriteLine();
	Console.WriteLine();
}