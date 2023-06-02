using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;

namespace Pr1T1
{
    class Program
    {
        static void addDelegates(Conference ACM, String FileName)
        {
            // Delegates read from file and added to stack

            ACM.Delegates.Clear();

            StreamReader Input = new StreamReader(FileName);
            while (!Input.EndOfStream)
            {
                String inputLine = Input.ReadLine();
                string[] data = inputLine.Split(',');
                ConfDelegate newOne = new ConfDelegate(int.Parse(data[0]), data[1], data[2], ACM.Cost, bool.Parse(data[3]));
                ACM.registerDelegate(newOne);
            }
        }

        static void processPayments(Conference ACM, String FileName)
        {

            // Payments read from file and relevant delegate payments modified

            StreamReader Input = new StreamReader(FileName);
            while (!Input.EndOfStream)
            {
                String inputLine = Input.ReadLine();
                string[] data = inputLine.Split(',');
                ACM.makePayment(int.Parse(data[0]), double.Parse(data[1]));
            }

        }

        static void Main(string[] args)
       	{
		    Conference ACM = new Conference("ACM", "Barcelona", 8, 4000);
            int choice;
            do
            {
                Console.Clear();
                Console.WriteLine("INDICATE WHICH FUNCTIONALITY YOU WISH TO TEST (subsequent methods are dependent upon each other)");
                Console.WriteLine("1. Display registered delegates (non-recursive)");
                Console.WriteLine("2. Display registered delegates (recursive)");
                Console.WriteLine("3. Make payments");
                Console.WriteLine("4. Duplicating list of delegates");
                Console.WriteLine("5. Reversing list of delegates");
                Console.WriteLine("6. Number of delegates who still owe for the conference");
                Console.WriteLine("7. Delegate cancellations (Bonus Marks in Quiz)");
                Console.WriteLine("8. Total amount due (Bonus Marks in Quiz)");
                Console.WriteLine("9. TERMINATE PROCESSING");
                choice = int.Parse(Console.ReadLine());
                Console.WriteLine();
                string DFile = "Delegates.txt";
                string CFile = "Cancellations.txt";
                string PFile = "Payments.txt";
                switch (choice)
                {
                    case 1: Console.WriteLine("METHOD displayDelegatesNR");
                        Console.WriteLine();
                        addDelegates(ACM, DFile);
                        Console.WriteLine("List of registered delegates:");
                        ACM.displayDelegatesNR();
                        Console.WriteLine("--------------------------- Check that output is as expected - press enter to continue");
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("METHOD displayDelegatesR");
                        Console.WriteLine();
                        addDelegates(ACM, DFile);
                        Console.WriteLine("List of registered delegates:");
                        ACM.displayDelegatesR();
                        Console.WriteLine("--------------------------- Check that output is as expected - press enter to continue");
                        Console.ReadLine();
                        break;
                    case 3: addDelegates(ACM, DFile); 
                        Console.WriteLine("METHOD makePayment");
                        Console.WriteLine();
                        processPayments(ACM, PFile);
                        Console.WriteLine("List of registered delegates:");
                        ACM.displayDelegatesNR();
                        Console.WriteLine("--------------------------- Check that output is as expected - press enter to continue");
                        Console.ReadLine();
                        break;
                    case 4: addDelegates(ACM, DFile); 
                        Console.WriteLine("METHOD duplicateList");
                        Console.WriteLine();

                        // Duplicated list is stored, changes made to it & contents displayed

                        Stack duplList = ACM.duplicateList();
                        if (duplList.Count > 0)
                        {
                            ConfDelegate top = (ConfDelegate)duplList.Peek();
                            top.DName = "THIS ONE HAS BEEN CHANGED";
                        }
                        Stack temp = new Stack();
                        Console.WriteLine("Registered delegates in duplicated list - note changed data:");
                        while (duplList.Count > 0)
                        {
                            ConfDelegate cur = (ConfDelegate)duplList.Pop();
                            cur.display();
                            temp.Push(cur);
                        }
                        duplList = temp;
                        Console.WriteLine();

                        Console.WriteLine("List of registered delegates in original list:");
                        ACM.displayDelegatesNR();
                        Console.WriteLine("--------------------------- Check that output is as expected - press enter to continue");
                        Console.ReadLine();
                        break;
                    case 5: addDelegates(ACM, DFile); 
                        Console.WriteLine("METHOD reverseList");
                        Console.WriteLine();

                        // List of registered delegates is reversed and displayed

                        ACM.reverseList();
                        Console.WriteLine("List of registered delegates after reversing it:");
                        ACM.displayDelegatesNR();
                        Console.WriteLine("--------------------------- Check that output is as expected - press enter to continue");
                        Console.ReadLine();
                        break;
                    case 6: addDelegates(ACM, DFile); 
                        processPayments(ACM, PFile);
                        Console.WriteLine("METHOD noStillOwing");
                        Console.WriteLine();

                        // Checking to see how many delegates owe more than 0 for conference fees

                        Console.WriteLine("Number of delegates who still owe: {0}", ACM.noStillOwing());
                        Console.WriteLine();

                        Console.WriteLine("List of registered delegates:");
                        ACM.displayDelegatesNR();
                        Console.WriteLine("--------------------------- Check that output is as expected - press enter to continue");
                        Console.ReadLine();
                        break;
                    case 7: addDelegates(ACM, DFile); 
                        Console.WriteLine("METHOD deleteDelegate");
                        Console.WriteLine();

                        // Delegate identifiers read from file and relevant delegates deleted from list

                        StreamReader Input = new StreamReader(CFile);
                        while (!Input.EndOfStream)
                        {
                            int DelID = int.Parse(Input.ReadLine());
                            if (ACM.deleteDelegate(DelID))
                                Console.WriteLine("Delegate {0} deleted", DelID);
                        }
                        Console.WriteLine("List of registered delegates after deletions:");
                        ACM.displayDelegatesNR();
                        Console.WriteLine("--------------------------- Check that output is as expected - press enter to continue");
                        Console.ReadLine();
                        break;
                    case 8: addDelegates(ACM, DFile); 
                        processPayments(ACM, PFile);
                        Console.WriteLine("METHOD totalDue");
                        Console.WriteLine();

                        // Determining total amount still owing from all delegates

                        Console.WriteLine("Total amount owing: {0}", ACM.totalDue());
                        Console.WriteLine();

                        Console.WriteLine("List of registered delegates:");
                        ACM.displayDelegatesNR();
                        Console.WriteLine("--------------------------- Check that output is as expected - press enter to continue");
                        Console.ReadLine();
                        break;
                    case 9: break;
                    default: Console.WriteLine("Incorrect selection - press enter to continue");
                        Console.ReadLine();
                        break;
                }
            } while (choice != 9);
            Console.WriteLine("Processing terminated - press enter to continue");
            Console.ReadLine();
        }
    }
}
