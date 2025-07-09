

public void Run()
{
    var stopwatch = Stopwatch.StartNew();
    var work = LotsOfLoops(1000);

    stopwatch.Stop();

    // This will display 1000000
    Console.WriteLine("Innermost count is: {0}", work);

    // The time displayed will vary based on your computer
    Console.WriteLine("Execution Time in milliseconds: {0}", stopwatch.Elapsed.TotalMilliseconds);
}

private int LotsOfLoops(int n)
{
  int total = 0;
  int count = 0; // Variable for instrumentation 

  for (int i = 0; i < n; i++)
  {
    for (int j = 0; j < n; j++)
    {
      for (int k = 0; k < n; k++)
      {
        total += (i*j*k);
        count++;  // Count the number of times in the inner-most loop
      }
    }
  }

  Console.WriteLine(total);

  return count;
}