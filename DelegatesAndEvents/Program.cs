using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    public delegate int BizRulesDelegate(int x, int y);
    class Program
    {
        static void Main(string[] args)
        {
            BizRulesDelegate addDel = (x, y) => x + y;
            BizRulesDelegate multiplyDel = (x, y) => x * y;

            Func<int, int, int> funcAddDel = (x, y) => x + y;
            
            var data = new ProcessData();

            data.ProcessFunc(3, 2, funcAddDel);
            data.Process(2, 3, addDel);
            
            Action<int, int> myAction = (x, y) => Console.WriteLine(x + y);
            data.ProcessAction(2, 3, myAction);


            //WorkPerformedHandler del1 = new WorkPerformedHandler(WorkPerformed1);
            //WorkPerformedHandler del2 = new WorkPerformedHandler(WorkPerformed2);
            //WorkPerformedHandler del3 = new WorkPerformedHandler(WorkPerformed3);

            //del1 += del2 + del3;

            //int finalHours = del1(10, WorkType.GenerateReports);
            //Console.WriteLine(finalHours);
            var worker = new Worker();
            worker.WorkPerformed += (s, e) =>
            {
                Console.WriteLine(e.Hours + " " + e.workType);
            };
            // worker.WorkCompleted += Worker_WorkCompleted;
            worker.WorkCompleted += (s, e) => Console.WriteLine("Worker is done");
            worker.DoWork(8, WorkType.GenerateReports);

            ////////////
            var custs = new List<Customer>
           {
               new Customer { City = "Phoenix", FirstName = "John", LastName = "Pizzoro", Id = 1},
               new Customer { City = "Phoenix", FirstName = "Steward", LastName = "F", Id = 2},
               new Customer { City = "California", FirstName = "Andrew", LastName = "R", Id = 3}
           };

            var phxCusts = custs
                .Where(c => c.City == "Phoenix")
                .OrderBy(c => c.FirstName);
            foreach (var cust in phxCusts)
            {
                Console.WriteLine(cust.FirstName);
            }

            Console.Read();
        }
         
        private static void Worker_WorkPerformed(object sender, WorkPerformedEventArgs e)
        {
            Console.WriteLine(e.Hours + " " + e.workType);
        }

        static void Worker_WorkCompleted(object sender, EventArgs e)
        {
            Console.WriteLine("Worker is done");
        }

    //    static void DoWork(WorkPerformedHandler del)
    //    {
    //        del(5, WorkType.GoToMeetings);
    //    }

    //    static int WorkPerformed1(int hours, WorkType workType)
    //    {
    //        Console.WriteLine("WorkPerformed1 called " + hours.ToString());
    //        return hours + 1;
    //    }

    //    static int WorkPerformed2(int hours, WorkType workType)
    //    {
    //        Console.WriteLine("WorkPerformed2 called " + hours.ToString());
    //        return hours + 2;
    //    }

    //    static int WorkPerformed3(int hours, WorkType workType)
    //    {
    //        Console.WriteLine("WorkPerformed3 called " + hours.ToString());
    //        return hours + 3;
    //    }
    }

    public enum WorkType
    {
        GoToMeetings,
        Golf,
        GenerateReports

    }
}
