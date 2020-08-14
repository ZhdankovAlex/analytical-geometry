using System;

namespace laba1
{
    class Program
    {
        static void Part1(double Ax, double Ay, double Bx, double By, double Cx, double Cy)
        {
            bool horizontal = false;
            bool vertical = false;
            bool diagonal = false;
            if (Ax == Bx) vertical = true;
            if (Ay == By) horizontal = true;
            if (vertical && horizontal)
            {
                Console.WriteLine("Error. A equivalent B. Fix it and try again.");
                return;
            }
            if (!vertical && !horizontal) diagonal = true;
            Console.WriteLine("uravnenie ishodnoy pryamoy: ");
            
            if (vertical) Console.WriteLine("x = " + Ax.ToString());
            if (horizontal) Console.WriteLine("y = " + Ay.ToString());
            string first_answer = "";
            double first_k = (By - Ay) / (Bx - Ax);
            double first_b = (Ay - (By - Ay) / (Bx - Ax) * Ax);
            if (diagonal) first_answer = "y = x * " + first_k.ToString() + " + " + first_b.ToString();
            Console.WriteLine(first_answer);

            Console.WriteLine("uravnenie parallelnoy pryamoy cherez C: ");
            if (vertical) Console.WriteLine("x = " + Cx.ToString());
            if (horizontal) Console.WriteLine("y = " + Cy.ToString());
            string second_answer = "";
            double second_k = first_k;
            double second_b = Cy - first_k * Cx;
            if (diagonal) second_answer = "y = x * " + second_k.ToString() + " + " + second_b.ToString();
            Console.WriteLine(second_answer);
        }

        static void Part2(double Ax, double Ay, double Bx, double By, double Cx, double Cy)
        {
            if ((Ax == Bx) && (Ay == By))
            {
                Console.WriteLine("Error. A equivalent B. Fix it and try again.");
                return;
            }
            if ((Cx == Bx) && (Cy == By))
            {
                Console.WriteLine("Error. C equivalent B. Fix it and try again.");
                return;
            }
            if ((Ax == Cx) && (Ay == Cy))
            {
                Console.WriteLine("Error. A equivalent C. Fix it and try again.");
                return;
            }
            if ((Cx-Ax)*(By-Ay) == (Cy-Ay)*(Bx-Ax))
            {
                if ((Ax == Bx) && (Bx == Cx))
                {
                    if (((Ay < Cy) && (Cy < By)) || ((By < Cy) && (Cy < Ay))) Console.WriteLine("C mezhdu A i B");
                    else if ((Ay < Cy) && (By < Cy) && (Ay < By)) Console.WriteLine("C za B");
                    else if ((Ay < Cy) && (By < Cy) && (Ay > By)) Console.WriteLine("C za A");
                }
                else
                {
                    if (((Ax < Cx) && (Cx < Bx)) || ((Bx < Cx) && (Cx < Ax))) Console.WriteLine("C mezhdu A i B");
                    else if ((Ax < Cx) && (Bx < Cx) && (Ax < Bx)) Console.WriteLine("C za B");
                    else if ((Ax < Cx) && (Bx < Cx) && (Ax > Bx)) Console.WriteLine("C za A");
                }
            }
        }

        static void Part3(double Ax, double Ay, double Az, double Bx, double By, double Bz, double Cx, double Cy, double Cz)
        {
            double AB = Math.Sqrt((Bx - Ax) * (Bx - Ax) + (By - Ay) * (By - Ay) + (Bz - Az) * (Bz - Az));
            double AC = Math.Sqrt((Cx - Ax) * (Cx - Ax) + (Cy - Ay) * (Cy - Ay) + (Cz - Az) * (Cz - Az));
            double BC = Math.Sqrt((Bx - Cx) * (Bx - Cx) + (By - Cy) * (By - Cy) + (Bz - Cz) * (Bz - Cz));
            if (AB == AC && AC == BC) 
                Console.WriteLine("Ravnostoronniy");
            if ((AB == AC && AC != BC) || (AC == BC && AC != AB) || (BC == AB && AB != AC)) 
                Console.WriteLine("Ravnobedrenniy");
            if ((AB * AB == AC * AC + BC * BC) || (AC * AC == AB * AB + BC * BC) || (BC * BC == AC * AC + AB * AB))
                Console.WriteLine("Pryamougolniy");
            double A = Math.Acos((AC * AC + AB * AB - BC * BC) / (2 * AC * AB));
            double B = Math.Acos((AB * AB + BC * BC - AC * AC) / (2 * AB * BC));
            double C = Math.Acos((AC * AC + BC * BC - AB * AB) / (2 * AC * BC));
            if ((A < 90) && (B < 90) && (C < 90)) 
                Console.WriteLine("Ostrougolniy");
            if ((A > 90) || (B > 90) || (C > 90)) 
                Console.WriteLine("Tupougolniy");
        }

        static void Part4(double Ax, double Ay, double Az, double Bx, double By, double Bz, double Cx, double Cy, double Cz, double Dx, double Dy, double Dz)
        {
            double a = Ay * Bz - Ay * Cz + By * Cz - By * Az + Cy * Az - Cy * Bz;
            double b = Ax * Cz - Ax * Bz + Bx * Az - Bx * Cz + Cx * Bz - Cx * Az;
            double c = Ax * By - Ax * Cy + Bx * Cy - Bx * Ay + Cx * Ay - Cx * By;
            double d = - a * Ax - b * Ay - c * Az;
            Console.WriteLine("uravnenie ishodnoy ploskosti: ");
            Console.WriteLine("|x-" + Ax.ToString() + "  y-" + Ay.ToString() + "  z-" + Az.ToString() + "|");
            Console.WriteLine("|" + (Bx - Ax).ToString() + "    " + (By - Ay).ToString() + "    " + (Bz - Az).ToString() + "|");
            Console.WriteLine("|" + (Cx - Ax).ToString() + "    " + (Cy - Ay).ToString() + "    " + (Cz - Az).ToString() + "|");
            Console.WriteLine(a.ToString() + "*x + " + b.ToString() + "*y + " + c.ToString() + "*z + " + d.ToString() + " = 0");
            Console.WriteLine("uravnenie parallelnoy ploskosti: ");
            d = -a * Dx - b * Dy - c * Dz;
            Console.WriteLine(a.ToString() + "*x + " + b.ToString() + "*y + " + c.ToString() + "*z + " + d.ToString() + " = 0");
        }

        static void Main(string[] args)
        {
            double Ax, Ay, Az, Bx, By, Bz, Cx, Cy, Cz, Dx, Dy, Dz;
            
            Console.WriteLine("Input Ax:");
            Ax = double.Parse(Console.ReadLine());
            Console.WriteLine("Input Ay:");
            Ay = double.Parse(Console.ReadLine());
            Console.WriteLine("Input Az:");
            Az = double.Parse(Console.ReadLine());
            Console.WriteLine("Input Bx:");
            Bx = double.Parse(Console.ReadLine());
            Console.WriteLine("Input By:");
            By = double.Parse(Console.ReadLine());
            Console.WriteLine("Input Bz:");
            Bz = double.Parse(Console.ReadLine());
            Console.WriteLine("Input Cx:");
            Cx = double.Parse(Console.ReadLine());
            Console.WriteLine("Input Cy:");
            Cy = double.Parse(Console.ReadLine());
            Console.WriteLine("Input Cz:");
            Cz = double.Parse(Console.ReadLine());
            Console.WriteLine("Input Dx:");
            Dx = double.Parse(Console.ReadLine());
            Console.WriteLine("Input Dy:");
            Dy = double.Parse(Console.ReadLine());
            Console.WriteLine("Input Dz:");
            Dz = double.Parse(Console.ReadLine());
            
            Console.WriteLine("Number 1:");
            Part1(Ax, Ay, Bx, By, Cx, Cy);
            
            Console.WriteLine("Number 2:");
            Part2(Ax, Ay, Bx, By, Cx, Cy);

            Console.WriteLine("Number 3:");
            Part3(Ax, Ay, Az, Bx, By, Bz, Cx, Cy, Cz);

            Console.WriteLine("Number 4:");
            Part4(Ax, Ay, Az, Bx, By, Bz, Cx, Cy, Cz, Dx, Dy, Dz);
        }
    }
}
