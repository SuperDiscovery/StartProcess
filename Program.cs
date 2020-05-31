using System;
using System.Diagnostics;

namespace StartProcess
{
    class Program
    {
        static void Main(string[] args)
        {
            string strCheckName;
            string strStartName;
            bool blnFind=false;
            Process[] processes = Process.GetProcesses();
 
            if(args.Length==0) {
                Console.Write("Usage: StartProcess {Process Name}");
                return; 
            }

            strStartName=args[0]+" ";
            strCheckName=args[0];
            if(args.Length>1) strCheckName=args[2];
            strCheckName=strCheckName+" ";
            strCheckName=strCheckName.Split(" ")[0];
            foreach (Process process in processes)
            {
                if (process.ProcessName==strCheckName){
                    // Console.WriteLine("Process Name: {0}, Responding: {1}", process.ProcessName, process.Responding);
                    if(process.Responding!=true) process.Kill();
                    else {
                        blnFind=true;
                        break;}
                }
            }
 
            if((args.Length>1 && blnFind) || (args.Length==1 && !blnFind))
                Process.Start(strStartName.Split(" ")[0],strStartName.Split(" ")[1]);
        }
    }
}
