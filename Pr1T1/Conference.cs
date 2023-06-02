using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Pr1T1
{
    class Conference
    {
        public String CName;
        public String City;
        public int MaxSlots;  // maximum number of presentation slots 
        public double Cost;
        public Stack Delegates;

        public Conference(String C, String Loc, int M, double Cst)
        //post: constructor
        {
            CName = C;
            City = Loc;
            MaxSlots = M;
            Cost = Cst;
            Delegates = new Stack();
        }

        // COMPULSORY TASKS - must be completed before attempting the Quiz

        public void displayDelegatesNR()
        /* pre:  Have list of delegates, possibly empty.
         * post: NON-RECURSIVELY display details for delegates on the list.  List must retain original ordering of delegates.
         */
        {
            foreach(var item in Delegates)
            {
                ConfDelegate k = (ConfDelegate)item;
                k.display();
            }
             

        }



        public void displayDelegatesR()
        /* pre:  Have list of delegates, possibly empty.
         * post: RECURSIVELY display details for delegates on the list.  List must retain original ordering of delegates.
         *       No additional data structures are to be used.
         */
        {

            Stack d = new Stack();
            d = Delegates;
            int c = 0;
            doD(c, d);

        }
        private void doD(int c,Stack d)
        {
            if(c==Delegates.Count-1)
            {
                object cc = d.Pop();
                ConfDelegate k = (ConfDelegate)cc;
                k.display();
            }
            else
            {
                if (d.Count != 0)
                {
                    object cc = d.Pop();
                    ConfDelegate k = (ConfDelegate)cc;
                    k.display();
                    c = c + 1;
                    doD(c, d);
                }
            }
        }

        public void makePayment(int D, double Amnt)
        /* pre:  Have list of delegates, possibly empty. Have delegate identifier and amount paid.
         * post: EFFICIENTLY modify the relevant property for the given delegate.  Retain the original ordering of delegates in the list.
         */
        {

            foreach (var item in Delegates)
            {
                ConfDelegate k = (ConfDelegate)item;
                if (k.DelID==D)
                {
                    k.mp(Amnt);
                }
            }

        }
 
        public Stack duplicateList()
        /* pre:  Have list of delegates, possibly empty.
         * post: Return exact copy (clone) of the list.  Original list must retain original ordering.
         */
        {
            Stack n = new Stack();
            foreach (var item in Delegates)
            {
                ConfDelegate k = (ConfDelegate)item;
               ConfDelegate kk= k.C();
                n.Push(kk);
            }
            Stack n1 = new Stack();
            foreach (var item in n)
            {
                ConfDelegate k = (ConfDelegate)item;
                n1.Push(k);
               
            }
            return n1;

        }

        public void reverseList()
        /* pre:  Have list of delegates, possibly empty.
         * post: EFFICIENTLY reverse list of delegates.
         */
        {
            Stack n = new Stack();
            foreach (var item in Delegates)
            {
                ConfDelegate k = (ConfDelegate)item;
                n.Push(k);
            }
            Delegates = n;
        }

        public int noStillOwing()
        /* pre:  Have list of delegates, possibly empty.
         * post: Calculate and return number of delegates who still owe an amount. Original list must retain original 
         *       ordering.
         */
        {
            int c = 0;
            foreach (var item in Delegates)
            {
                ConfDelegate k = (ConfDelegate)item;
                if (k.Due!=0)
                {
                    c = c + 1;
                }
            }
            return c;
        }


        // OPTIONAL TASKS: BONUS MARKS IN THE QUIZ

        public bool deleteDelegate(int D)
        /* pre:  Have list of delegates, possibly empty.  Have identifier of delegate to remove
         * post: Remove the specified delegate from the list of delegates and return true.  If delegate is not in the list, 
         *       return false. If the removed delegate is also a presenter, display an appropriate warning message.
         *       NOTE: The list of delegates must retain the original ordering of the remaining delegates after processing 
         *       has been completed.
         */
        {
            foreach (var item in Delegates)
            {
                ConfDelegate k = (ConfDelegate)item;
                if (k.DelID == D)
                {
                   if(k.Presenter==true)
                    {
                        Console.WriteLine("Delegate {0} is a present",D);
                       
                    }
                    else
                    {
                        Console.WriteLine("Delegate {0} deleted",D);
                       
                    }
                }
            }

            return false;

        }

        public double totalDue()
        /* pre:  Have list of delegates, possibly empty.
         * post: Calculate and return total amount outstanding for all delegates. Original list must retain original 
         *       ordering.
         */
        {

            // ADD CODE FOR totalDue BELOW  

            return int.MinValue;
        }

        // NO CHANGES REQUIRED TO THE METHODS BELOW

        private int availSlots()
        /* pre:  Have list of delegates which could be empty.  Not all delegates in the list are necessarily presenting.
         * post: Compute and return a count of the number of presentation slots available. 
         */
        {

            int totSlots = 0;
            Stack temp = new Stack();
            ConfDelegate cur;
            while (Delegates.Count > 0)
            {
                cur = (ConfDelegate)Delegates.Pop();
                temp.Push(cur);
                if (cur.Presenter)
                    totSlots++;
            }
            while (temp.Count > 0)
                Delegates.Push(temp.Pop());
            return (MaxSlots - totSlots);
        }

        public void registerDelegate(ConfDelegate newOne)
        /* pre:  Have a list of delegates which could be empty. For the new delegate, have delegate identifier, name, topic 
         *       and whether presenting (true) or not (false).
         * post: Register a delegate by adding him/her to the top of the delegates stack. A delegate may only be a presenter
         *       if there is a presentation slot available (use availSlots), otherwise just register the delegate. 
         *       NO DUPLICATE DELEGATES ARE REGISTERED (on delegate identifier),
         */
        {

            Stack temp = new Stack();
            ConfDelegate cur;
            bool foundPos = false;
            while ((Delegates.Count > 0) && (!foundPos))
            {
                cur = (ConfDelegate)Delegates.Pop();
                temp.Push(cur);
                if (cur.Equals(newOne))
                    foundPos = true;
            }
            while (temp.Count > 0)
                Delegates.Push(temp.Pop());
            if (!foundPos)
            {
                if (newOne.Presenter)
                    if (availSlots() < 1)
                        newOne.Presenter = false;
               Delegates.Push(newOne);
            }
        }


    }
}
