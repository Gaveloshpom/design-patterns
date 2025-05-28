class WashingMachine
{
    private bool isRunning = false;
    private readonly object lockObj = new();

    public void Start()
    {
        lock (lockObj)
        {
            if (isRunning)
            {
                Console.WriteLine("Already running! Balking...");
                return;
            }
            isRunning = true;
        }

        Run();
    }

    private void Run()
    {
        Console.WriteLine("Washing started...");
        Thread.Sleep(2000);
        Console.WriteLine("Washing finished.");

        lock (lockObj)
        {
            isRunning = false;
        }
    }
}

class Balking_Template
{
    static void Main()
    {
        WashingMachine machine = new WashingMachine();

        Thread t1 = new Thread(machine.Start);
        Thread t2 = new Thread(machine.Start);

        t1.Start();
        t2.Start();

        t1.Join();
        t2.Join();
    }
}
