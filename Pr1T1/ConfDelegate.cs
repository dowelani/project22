using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr1T1
{
    class ConfDelegate
    {
        public int DelID;
        public String DName;
        public String Subj;
        public double Due;
        public bool Presenter;

        public ConfDelegate(int D, String N, String Sub, double Cost, bool P)
        {
            DelID = D;
            DName = N;
            Subj = Sub;
            Due = Cost;
            Presenter = P;
        }

        public bool Equals(ConfDelegate obj)
        {
            return this.DelID == obj.DelID;
        }

        public void processPayment(double Amnt)
        {
            Due -= Amnt;
        }

        public void display()
        {
            Console.Write("DelID: {0} Name: {1} Due: {2}", DelID, DName, Due);
            if (Presenter)
                Console.WriteLine(" is presenting");
            else
                Console.WriteLine();
        }

        // ADD ANY ADDITIONAL CODE FOR CLASS ConfDelegate BELOW
        public void mp(double p)
        {
            Due =Due-p;
        }
        public ConfDelegate C()
        {
            ConfDelegate co = new ConfDelegate(this.DelID,this.DName,this.Subj,this.Due,this.Presenter);
            return co;
        }


    }

}
