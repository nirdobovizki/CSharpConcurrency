using Chapter02;

Console.WriteLine("C# Concurrency: Asynchronous and Multithreaded Programming");
Console.WriteLine("Chapter 2");

while (true)
{
	Console.WriteLine("Please select a sample to run, type the sample number then press enter");

	Console.WriteLine("1. Listing 2.1 - Using Lambda functions");
	Console.WriteLine("2. Compiler transformation of listing 2.1");
	Console.WriteLine("3. Listing 2.2 - Lambda function that uses local variables");
	Console.WriteLine("4. Compiler transformation of listing 2.2");
	Console.WriteLine("5. Listing 2.3 - Using a list"); 
	Console.WriteLine("6. Listing 2.4 - Using yield return"); 
	Console.WriteLine("7. Compiler transformation of listing 2.4"); 
	Console.WriteLine("X. Exit");

	var responseText = Console.ReadLine()?.Trim()?.ToLower();
	if (responseText == null || responseText == "x") return;

	if(!int.TryParse(responseText, out var sampleNumber))
	{
		Console.WriteLine("Can't parse your response, please try again");
		continue;
	}

	switch(sampleNumber)
	{
		case 1:
			new LambdaDemo1().InitTimer();
			Console.WriteLine("This code will run forever, press X to stop");
			if (Console.ReadKey().Key == ConsoleKey.X) Environment.Exit(0);
			break;
		case 2:
			new LambdaDemo2().InitTimer();
			Console.WriteLine("This code will run forever, press X to stop");
			if (Console.ReadKey().Key == ConsoleKey.X) Environment.Exit(0);
			break;
		case 3:
			new LambdaDemo3().InitTimer();
			Console.WriteLine("This code will run forever, press X to stop");
			if (Console.ReadKey().Key == ConsoleKey.X) Environment.Exit(0);
			break;
		case 4:
			new LambdaDemo4().InitTimer();
			Console.WriteLine("This code will run forever, press X to stop");
			if (Console.ReadKey().Key == ConsoleKey.X) Environment.Exit(0);
			break;
		case 5:
			new YieldDemo1().UseNoYieldDemo();
			break;
		case 6:
			new YieldDemo2().UseYieldDemo();
			break;
		case 7:
			new YieldDemo3().UseYieldDemo();
			break;
		default:
			Console.WriteLine("Not a sample number, please try again");
			break;
	}
	Console.WriteLine();
	Console.WriteLine();
}