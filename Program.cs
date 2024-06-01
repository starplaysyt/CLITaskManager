using System.Diagnostics;

namespace CLITaskManager;

class Program
{
    static void Main(string[] args)
    {
        Console.ReadKey();
        doTestRender();
        Console.ReadKey();
        
    }

    public static void doTestRender()
    {
        Console.WriteLine("╔════════════════════════════════════════════════════════════════════════════════════╦══════╦══╗");
        Console.WriteLine("║                                                                                    ║      ║  ║");
        Console.WriteLine("║                                                                                    ║      ║  ║");
        Console.WriteLine("║                                                                                    ║      ║  ║");
        Console.WriteLine("║                                                                                    ║      ║  ║");
        Console.WriteLine("║                                                                                    ║      ║  ║");
        Console.WriteLine("║                                                                                    ║      ║  ║");
        Console.WriteLine("║                                                                                    ║      ║  ║");
        Console.WriteLine("║                                                                                    ║      ║  ║");
        Console.WriteLine("║                                                                                    ║      ║  ║");
        Console.WriteLine("║                                                                                    ║      ║  ║");
        Console.WriteLine("║                                                                                    ║      ║  ║");
        Console.WriteLine("║                                                                                    ║      ║  ║");
        Console.WriteLine("║                                                                                    ║      ║  ║");
        Console.WriteLine("║                                                                                    ║      ║  ║");
        Console.WriteLine("║                                                                                    ║      ║  ║");
        Console.WriteLine("║                                                                                    ║      ║  ║");
        Console.WriteLine("║                                                                                    ║      ║  ║");
        Console.WriteLine("║                                                                                    ║      ║  ║");
        Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════════╩══════╩══╝");

        var processes = Process.GetProcesses();
        List<List<Process>> lists = new List<List<Process>>();

        for (int i = 0; i < processes.Length; i++)
        {
            bool isTargetFound = false;
            for (int j = 0; j < lists.Count; j++)
            {
                if (lists[j][0].ProcessName == processes[i].ProcessName)
                {
                    lists[j].Add(processes[i]);
                    isTargetFound = true;
                }
            }

            if (!isTargetFound)
            {
                lists.Add(new List<Process>());
                lists[^1].Add(processes[i]);
            }
        }

        int maxLenght = 0;
        
        for (int i = 0; i < lists.Count; i++)
        {
            for (int j = 0; j < lists[i].Count; j++)
            {
                if (lists[i][j].ProcessName.Length > maxLenght) maxLenght = lists[i][j].ProcessName.Length;
            }
        }
        

        for (int i = 0; i < lists.Count; i++)
        {
            for (int j = 0; j < lists[i].Count; j++)
            {
                Console.WriteLine();
                Console.Write(String.Format("{0,30}", lists[i][j].ProcessName) + " | ");
                Console.Write(String.Format("{0,10:0.0}", (double)lists[i][j].WorkingSet64/1024/1024) + " Mb |");
                //Console.Write(String.Format("{0,10:0.0}", (double)lists[i][j].Threads[0].) + " % |");
            }
        }

        Console.WriteLine("=========================================");
        
        for (int i = 0; i < processes.Length; i++)
        {
            Console.WriteLine(processes[i].ProcessName + " | " + String.Format("{0,5:N}", (double)processes[i].WorkingSet64/1024/1024) + " Mb |");
        }
    }
}