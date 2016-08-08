﻿using System;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using Jint;

namespace ConsoleApplication1
{
    class Program
    {
        public static Process proc { get; set; }
        static void Main(string[] args)
        {
            Console.Title = "Discord Bot";
            Console.WriteLine("Welcome to Discord Automated Bot");
            Thread.Sleep(500);
            Console.WriteLine("Loading Bot...");
            Thread.Sleep(500);
            String testing = "node 'C:/Users/Luis/Documents/Visual Studio 2015/Projects/ConsoleApplication1/ConsoleApplication1/CoreBot.js'".Replace("'", "\"");
            ExecuteCommandSync(testing);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Bot Has Successfully Started");
            Console.ForegroundColor = ConsoleColor.White;
            new Program().StopBot(proc);
        }
        private void OnApplicationExit(object sender, EventArgs e)
        {
            proc.Kill();
             
        }
        public void StopBot(System.Diagnostics.Process p)
        {
            Console.Write(@"Type Commands Here: ");
            String str = Console.ReadLine();
            if (str.Equals("stop")||str.Equals("Stop"))
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Stopping Bot...");
                Thread.Sleep(1000);
                p.Kill();
            } else if (str.Equals("ban")||str.Equals("Ban"))
            {
                JintEngine engine = new JintEngine();
                string file = File.ReadAllText(@"C:\Users\Luis\Documents\Visual Studio 2015\Projects\ConsoleApplication1\ConsoleApplication1\CoreBot.js");
                engine.Run(file);
                engine.CallFunction("ban");
                StopBot(p);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Input");
                Console.ForegroundColor = ConsoleColor.White;
                StopBot(p);
            }


        }
        public static async Task Start()
        {
       

        
        }
        public static void ExecuteCommandSync(object command)
        {
            try
            {
                // create the ProcessStartInfo using "cmd" as the program to be run,
                // and "/c " as the parameters.
                // Incidentally, /c tells cmd that we want it to execute the command that follows,
                // and then exit.
                System.Diagnostics.ProcessStartInfo procStartInfo =
                new System.Diagnostics.ProcessStartInfo("cmd", "/k " + command);

                // The following commands are needed to redirect the standard output.
                // This means that it will be redirected to the Process.StandardOutput StreamReader.
                // Do not create the black window.
                // don't execute on shell
                procStartInfo.UseShellExecute = false;
                procStartInfo.CreateNoWindow = true;
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.RedirectStandardError = true;
                // don't show window
                procStartInfo.WindowStyle = ProcessWindowStyle.Minimized;
                // Now we create a process, assign its ProcessStartInfo and start it
                proc = new System.Diagnostics.Process();
                proc.StartInfo = procStartInfo;

                proc.Start();
                StringBuilder outputString = new StringBuilder();
                StringBuilder errorString = new StringBuilder();

                proc.OutputDataReceived += (sender, e) =>
                {
                    if (e.Data != null)
                    {
                        outputString.AppendLine("Info " + e.Data);
                    }
                };

                proc.ErrorDataReceived += (sender, e) =>
                {
                    if (e.Data != null)
                    {
                        errorString.AppendLine("EEEE " + e.Data);
                    }
                };

            }
            catch (Exception objException)
            {
                Console.WriteLine(objException);
            }
        }
    }
}

