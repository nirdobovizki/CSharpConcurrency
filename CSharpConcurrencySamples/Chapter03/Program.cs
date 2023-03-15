using Chapter03;
using System;
using System.Runtime.ConstrainedExecution;

Console.WriteLine("C# Concurrency: Asynchronous and Multithreaded Programming");
Console.WriteLine("Chapter 2");

while (true)
{
	Console.WriteLine("Please select a sample to run, type the sample number then press enter");

	Console.WriteLine("1. Listing 3.1 reading BMP width, non-async version");
	Console.WriteLine("2. Mechanical translation of listing 3.1 to use ContinueWith");
	Console.WriteLine("3. Listing 3.2 reading BMP width, async version");
	Console.WriteLine("4. Compiler transformation of listing 3.2");
	Console.WriteLine("X. Exit");

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
			Console.WriteLine(new Listing1().GetBitmapWidth("Image1.bmp"));
			break;
		case 2:
			new Listing1_ContinueWith().GetBitmapWidth("Image1.bmp");
			break;
		case 3:
			Console.WriteLine(await new Listing2().GetBitmapWidth("Image1.bmp"));
			break;
		case 4:
			new Listing2_CompilerTransfromation().GetBitmapWidth("Image1.bmp",
				result => Console.WriteLine(result), error => Console.WriteLine(error));
			Thread.Sleep(500); // wait for GetBitmapWidth to finish
			break;
		/*case 3:
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
			break;*/
		default:
			Console.WriteLine("Not a sample number, please try again");
			break;
	}
	Console.WriteLine();
	Console.WriteLine();
}