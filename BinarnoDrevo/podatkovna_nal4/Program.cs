
using System;
using System.Collections.Generic;

namespace naloga4
{
    // razred IskalnoDrevo
    public class IskalnoDrevo
    {
        // razred Vozlisce
        class Vozlisce
        {
            private double podatek;
            private Vozlisce levo;
            private Vozlisce desno;

            public Vozlisce(double podatek)
            {
                levo = null;
                desno = null;
                this.podatek = podatek;
            }

            public Vozlisce(Vozlisce original)
            {
                this.podatek = original.podatek;
                levo = null;
                desno = null;

                if (original.levo != null)
                    levo = new Vozlisce(original.levo);
                if (original.desno != null)
                    desno = new Vozlisce(original.desno);
            }


            public void vstavi(double podatek)
            {
                if (podatek < this.podatek)
                {
                    if (levo == null)
                        levo = new Vozlisce(podatek);
                    else
                        levo.vstavi(podatek);
                }
                else
                {
                    if (desno == null)
                        desno = new Vozlisce(podatek);
                    else
                        desno.vstavi(podatek);
                }
            }

            public int steviloVozlisc()
            {
                int st = 1;
                if (this == null)
                    return 0;

                if (this.levo != null)
                    st = st + levo.steviloVozlisc();

                if (this.desno != null)
                    st = st + desno.steviloVozlisc();

                return st;
            }

            public int visinaDrevesa(int globina)
            {
                Vozlisce eno = this;
                globina = 0;
                int proti = 1;

                if(eno != null)
                {
                    Queue<Vozlisce> vrst = new Queue<Vozlisce>();
                    vrst.Enqueue(eno);

                    while (vrst.Count != 0)
                    {
                        Vozlisce drugo = vrst.Dequeue();
                        proti -= 1;
                        if (drugo.levo != null)
                        {
                            vrst.Enqueue(drugo.levo);
                        }
                        if(drugo.desno != null)
                        {
                            vrst.Enqueue(drugo.desno);
                        }
                        if(proti == 0)
                        {
                            globina += 1;
                            proti = vrst.Count;
                        }
                    }
                }
                return globina;
            }

            public double najvecji()
            {
                double a = this.podatek;
                Vozlisce eno = this;
                while (eno.desno != null)
                {
                    eno = eno.desno;
                    a = eno.podatek;
                }
                return a;

            }

            public double najmanjsi()
            {
                double a = this.podatek;
                Vozlisce eno = this;
                while (eno.levo != null)
                {
                    eno = eno.levo;
                    a = eno.podatek;
                }
                return a;
            }

            public void premi(Queue<double> vrsta)
            {
                Vozlisce eno = this;
                if(eno == null)
                {
                    return;
                }
                Stack<Vozlisce> aa = new Stack<Vozlisce>();
                aa.Push(eno);

                while (aa.Count != 0)
                {
                    Vozlisce bb = aa.Pop();
                    vrsta.Enqueue(bb.podatek);

                    if (bb.desno!=null)
                    {
                        aa.Push(bb.desno);
                    }
                    if (bb.levo != null)
                    {
                        aa.Push(bb.levo);
                    }
                }
            }

            public void vmesni(Queue<double> vrsta)
            {
                Vozlisce eno = this;
                Stack<Vozlisce> stack = new Stack<Vozlisce>();
                if(eno == null)
                {
                    return;
                }
                while (true)
                {
                    while (eno != null)
                    {
                        stack.Push(eno);
                        eno = eno.levo;
                    }
                    if (stack.Count == 0)
                    {
                        break;
                    }
                    eno = stack.Pop();
                    vrsta.Enqueue(eno.podatek);
                    eno = eno.desno;
                }

            }

            public void obratni(Queue<double> vrsta)
            {
                Vozlisce eno = this;
                if (eno == null)
                {
                    return;
                }
                else
                {
                    Stack<Vozlisce> stackena = new Stack<Vozlisce>();
                    Stack<Vozlisce> stackdva = new Stack<Vozlisce>();
                    stackdva.Push(eno);
                    while (stackdva.Count > 0)
                    {
                        Vozlisce ee = stackdva.Pop();
                        stackena.Push(ee);
                        if (ee.levo != null)
                        {
                            stackdva.Push(ee.levo);
                        }
                        if (ee.desno != null)
                        {
                            stackdva.Push(ee.desno);
                        }
                    }
                    while(stackena.Count > 0)
                    {
                        Vozlisce ee = stackena.Pop();
                        vrsta.Enqueue(ee.podatek);
                    }
                }
                foreach(var x in vrsta)
                {
                    Console.WriteLine(x);
                }

            }

            public bool iskanje(double stevilo)
            {
                Vozlisce eno = this;
                while(eno != null)
                {
                    if (eno.podatek == stevilo) return true;
                    if (eno.podatek > stevilo) 
                    { eno = eno.levo; }
                    else 
                    { eno = eno.desno; }
                }

                return false;
            }

            public double vsota()
            {
                Vozlisce eno = this;
                Stack<Vozlisce> ee = new Stack<Vozlisce>(); 
                if (eno == null)
                {
                    return 0;
                }
                decimal n = 0;
                while (eno != null||ee.Count>0)
                {
                    while (eno != null)
                    {
                        ee.Push(eno);
                        eno = eno.levo;
                    }
                    eno = ee.Pop();
                    n = n + (decimal)eno.podatek;
                    eno = eno.desno;

                }
                return (double)n;
            }
        }

        // nadaljevanje razreda IskalnoDrevo
        Vozlisce koren;

        public IskalnoDrevo()
        {
            this.koren = null;
        }

        public IskalnoDrevo(IskalnoDrevo original)
        {
            koren = new Vozlisce(original.koren);
        }

        public void vstavi(double podatek)
        {
            if (koren == null)
                koren = new Vozlisce(podatek);
            else
                koren.vstavi(podatek);
        }

        public int steviloVozlisc()
        {
            if (koren == null)
                return 0;
            else
                return koren.steviloVozlisc();
        }

        public int visinaDrevesa()
        {
            if (koren == null)
                return 0;
            else
                return koren.visinaDrevesa(1);
        }

        public double najvecji()
        {
            if (koren == null)
                return double.NaN;
            return koren.najvecji();
        }

        public double najmanjsi()
        {
            if (koren == null)
                return double.NaN;
            return koren.najmanjsi();
        }


        public Queue<double> premi()
        {
            Queue<double> vrsta = new Queue<double>();
            if (koren != null)
                koren.premi(vrsta);
            return vrsta;
        }

        public Queue<double> vmesni()
        {
            Queue<double> vrsta = new Queue<double>();
            if (koren != null)
                koren.vmesni(vrsta);
            return vrsta;
        }

        public Queue<double> obratni()
        {
            Queue<double> vrsta = new Queue<double>();
            if (koren != null)
                koren.obratni(vrsta);
            return vrsta;
        }

        public bool iskanje(double stevilo)
        {
            if (koren != null)
                return koren.iskanje(stevilo);

            return false;
        }

        public double vsota()
        {
            if (koren != null)
                return koren.vsota();

            return double.NaN;
        }
    }

    class Program
    {
        static bool test_najmanjsi_element()
        {
            double[] vhod = { 1.4, 1.5, 1.0, 0.9, 20.4, 15.4, -23.0, 13.3, -12.3, 11.0, -11.1, -22.0 };
            int dolzina = vhod.Length;

            // ustvarimo drevo in vstavimo podatke v drevo
            IskalnoDrevo id = new IskalnoDrevo();
            for (int i = 0; i < dolzina; i++)
                id.vstavi((vhod[i]));

            double pricakovan_izhod = -23.0;

            double dobljen_izhod = id.najmanjsi();

            return dobljen_izhod == pricakovan_izhod;
        }

        static void Main(string[] args)
        {
            if (test_najmanjsi_element())
                Console.WriteLine("Metoda najmanjsi() je vrnila najmanjsi element.");
            else
                Console.WriteLine("Metoda najmanjsi() ni vrnila najmanjsega elementa.");

            double[] vhod = { 10,11,3,45,23,67,31,5,2,22,24 };
            //double[] vhod = {56,5,42,68,97,43,22,43,24,63,45,86,84,67,46 };
            //double[] vhod = {12,3,21,43,56,75,3,5,7,8,45,22,44,65,34,35,22,66,31,67,38,9,10,11,99 };
            //double[] vhod = { 1.4, 1.5, 1.0, 0.9, 20.4, 15.4, -23.0, 13.3, -12.3, 11.0, -11.1, -22.0 };
            int dolzina = vhod.Length;

            // ustvarimo drevo in vstavimo podatke v drevo
            IskalnoDrevo id = new IskalnoDrevo();
            for (int i = 0; i < dolzina; i++)
                id.vstavi((vhod[i]));
            Console.WriteLine("-----------------------");
            Queue<double> aaa = new Queue<double>();
            Console.WriteLine(id.steviloVozlisc());
        }
    }
}