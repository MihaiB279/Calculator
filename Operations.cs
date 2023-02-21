using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Calculator.Calculator;
using System.Windows.Forms;

namespace Calculator
{
    public class Operations
    {
        int distanceAdot, distanceBdot;
        public string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        /// <summary>
        /// count the number of digits after "." in a number
        /// </summary>
        /// <param name="number">the number to count the digits for</param>
        /// <returns>count</returns>
        public int dotDistance(string number)
        {
            int i = 0;
            while (i < number.Length)
            {
                if (number[i] == '.')
                    return i;
                i++;
            }
            return 0;
        }
        /// <summary>
        /// rounds the result to the selected limit (or the default one)
        /// </summary>
        /// <param name="result"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public string Rounding(string result, int x)
        {
            distanceAdot = dotDistance(result);
            if (x > distanceAdot)
                return result;
            int digit1, digit2;
            while (distanceAdot > x)
            {
                if (result.First() == '9' && result[1] == '9')
                {
                    while (result.First() == '9')
                    {
                        result = result.Substring(1);
                        distanceAdot--;
                    }
                    if (result.First() == '.')
                    {
                        result = result.Substring(1);
                    }
                    digit1 = Convert.ToInt32(result.First() - '0');
                    result = result.Substring(1);
                    result = (digit1 + 1) + result;
                }
                else
                {
                    digit1 = Convert.ToInt32(result.First() - '0');
                    result = result.Substring(1);
                    if (result.First() == '.')
                        result = result.Substring(1);
                    digit2 = Convert.ToInt32(result.First() - '0');
                    result = result.Substring(1);
                    if (digit1 >= 5)
                    {
                        if (digit2 == 9)
                        {
                            while (result.First() != '.' && digit2 == 9)
                            {
                                digit2 = Convert.ToInt32(result.First() - '0');
                                result = result.Substring(1);
                                distanceAdot--;
                            }
                            if (result.First() == '.' && digit2 == 9)
                            {
                                distanceAdot = 0;
                                result = result.Substring(1);
                                digit2 = Convert.ToInt32(result.First() - '0');
                                result = result.Substring(1);
                            }
                            result = (digit2 + 1) + result;
                        }
                        else result = (digit2 + 1) + result;
                    }
                    else result = digit2 + result;
                    distanceAdot--;
                }
            }
            return result;
        }
        /// <summary>
        /// find the maximum between 2 numbers
        /// </summary>
        /// <param name="a">first number</param>
        /// <param name="b">second number</param>
        /// <returns></returns>
        public int NumbersMax(string a, string b)
        {
            a = Reverse(a);
            b = Reverse(b);
            if (a == "0")
                return 0;
            if (b == "0" || a == b)
                return 1;
            int dA = dotDistance(a);
            int dB = dotDistance(b);
            if ((dB != 0 && dA > dB) || (dA == 0 && dB != 0 && a.Length > dB))
                return 1;
            else if ((dA != 0 && dB > dA) || (dB == 0 && dA != 0 && b.Length > dA))
                return 0;
            else
            {
                int nrA, nrB;
                if (dA == 0)
                    nrA = a.Length;
                else nrA = a.Length - (a.Length - dA);
                if (dB == 0)
                    nrB = b.Length;
                else nrB = b.Length - (b.Length - dB);
                if (nrA > nrB)
                    while (nrB != nrA)
                    {
                        b = '0' + b;
                        nrB++;
                    }
                else while (nrB != nrA)
                    {
                        a = '0' + a;
                        nrA++;
                    }
                int i = 0;
                while (i < a.Length && i < b.Length)
                {
                    if (a[i] != '.' && b[i] != '.')
                    {
                        if (a[i] > b[i])
                            return 1;
                        else if (b[i] > a[i])
                            return 0;
                    }
                    i++;
                }
                if (i == a.Length && i < b.Length)
                    return 0;
                else if (i == b.Length && i < a.Length)
                    return 1;
                else if (a[i] > b[i])
                    return 1;
                else return 0;
            }
        }
        /// <summary>
        /// if a number is bigger than the other one when doing an add operation
        /// we insert those digits directly in the result
        /// </summary>
        public void AdjustAdd(int distA, int distB, ref int iA, ref int iB, string a, string b, ref numbers c)
        {
            if (distA != distB)
            {
                if (distanceAdot < distanceBdot)
                    while (distanceBdot > distanceAdot)
                    {
                        c.number = c.number + b[iB];
                        iB++;
                        distanceBdot--;
                    }
                else while (distanceAdot > distanceBdot)
                    {
                        c.number = c.number + a[iA];
                        iA++;
                        distanceAdot--;
                    }
            }
        }
        /// <summary>
        /// add extra 0's to perform the substract operation
        /// </summary>
        public void AdjustSubstract(int distA, int distB, ref numbers a, ref numbers b, ref numbers c)
        {
            if (distA != distB)
            {
                if (distanceAdot < distanceBdot)
                    while (distanceBdot > distanceAdot)
                    {
                        a.number = '0' + a.number;
                        distanceBdot--;
                    }
                else while (distanceAdot > distanceBdot)
                    {
                        b.number = '0' + b.number;
                        distanceAdot--;
                    }
            }
        }
        public numbers Add(numbers a, numbers b)
        {
            numbers c;
            c.number = "";
            c.symbol = '+';
            distanceAdot = dotDistance(a.number);
            distanceBdot = dotDistance(b.number);
            int iA = 0, iB = 0;
            AdjustAdd(distanceAdot, distanceBdot, ref iA, ref iB, a.number, b.number, ref c);
            int aux = 0;
            while (iA < a.number.Length && iB < b.number.Length)
            {
                if (a.number[iA] == '.' && b.number[iB] != '.')
                {
                    c.number = c.number + '.';
                    iA++;
                }
                else if (b.number[iB] == '.' && a.number[iA] != '.')
                {
                    c.number = c.number + '.';
                    iB++;
                }
                else if (a.number[iA] == '.' && b.number[iB] == '.')
                {
                    c.number = c.number + '.';
                    iA++;
                    iB++;
                }
                else
                {
                    aux = aux + Convert.ToInt32(a.number[iA]) - '0' + Convert.ToInt32(b.number[iB]) - '0';
                    c.number = c.number + Convert.ToString(aux % 10);
                    aux /= 10;
                    iA++;
                    iB++;
                }
            }
            if (iA < a.number.Length)
            {
                while (aux > 0)
                {
                    if (iA < a.number.Length)
                        aux = aux + Convert.ToInt32(a.number[iA]) - '0';
                    c.number = c.number + Convert.ToString(aux % 10);
                    aux /= 10;
                    iA++;
                }
                while (iA < a.number.Length)
                {
                    c.number = c.number + a.number[iA];
                    iA++;
                }
            }
            else if (iB < b.number.Length)
            {
                while (aux > 0)
                {
                    if (iB < b.number.Length)
                        aux = aux + Convert.ToInt32(b.number[iB]) - '0';
                    c.number = c.number + Convert.ToString(aux % 10);
                    aux /= 10;
                    iB++;
                }
                while (iB < b.number.Length)
                {
                    c.number = c.number + b.number[iB];
                    iB++;
                }
            }
            else if (aux > 0)
                c.number = c.number + Convert.ToString(aux);
            return c;
        }
        public numbers Substract(numbers a, numbers b)
        {
            char[] auxString;
            numbers P;
            P.number = "";
            P.symbol = '+';
            distanceAdot = dotDistance(a.number);
            distanceBdot = dotDistance(b.number);
            int iA = 0, iB = 0;
            AdjustSubstract(distanceAdot, distanceBdot, ref a, ref b, ref P);
            int aux;
            while (iA < a.number.Length && iB < b.number.Length)
            {
                if (a.number[iA] == '.' && b.number[iB] != '.')
                {
                    P.number = P.number + '.';
                    iA++;
                }
                else if (b.number[iB] == '.' && a.number[iA] != '.')
                {
                    P.number = P.number + '.';
                    iB++;
                }
                else if (a.number[iA] == '.' && b.number[iB] == '.')
                {
                    P.number = P.number + '.';
                    iA++;
                    iB++;
                }
                else
                {
                    if (a.number[iA] < b.number[iB])
                    {
                        int k = 1;
                        while (a.number[iA + k] == '0' || a.number[iA + k] == '.')
                            k++;
                        auxString = a.number.ToCharArray();
                        auxString[iA + k] = (char)((int)auxString[iA + k] - 1);
                        a.number = new string(auxString);
                        k--;
                        while (k != 0)
                        {
                            if (a.number[iA + k] != '.')
                            {
                                auxString = a.number.ToCharArray();
                                auxString[iA + k] = '9';
                                a.number = new string(auxString);
                            }
                            k--;
                        }
                        aux = 10 + (Convert.ToInt32(a.number[iA]) - '0') - (Convert.ToInt32(b.number[iB]) - '0');
                    }
                    else
                        aux = (Convert.ToInt32(a.number[iA]) - '0') - (Convert.ToInt32(b.number[iB]) - '0');
                    P.number = P.number + aux;
                    iA++;
                    iB++;
                }
            }
            if (iA < a.number.Length)
            {
                while (a.number.Length > 0 && a.number.Last() == '0')
                    a.number = a.number.Substring(0, a.number.Length - 1);
                while (iA < a.number.Length)
                {
                    P.number = P.number + a.number[iA];
                    iA++;
                }
            }
            else if (iB < b.number.Length)
            {
                while (b.number.Length > 0 && b.number.Last() == '0')
                    b.number = b.number.Substring(0, b.number.Length - 1);
                while (iB < b.number.Length)
                {
                    P.number = P.number + b.number[iB];
                    iB++;
                }
            }
            while (P.number.Length > 1 && P.number.Last() == '0')
                P.number = P.number.Substring(0, P.number.Length - 1);
            if (P.number.Last() == '.')
                P.number = P.number + '0';
            return P;
        }
        public numbers Multiply(numbers a, numbers b)
        {
            int t, i = 0, j;
            numbers aux, produs;
            produs.number = aux.number = "";
            produs.symbol = aux.symbol = '+';
            distanceAdot = dotDistance(a.number);
            distanceBdot = dotDistance(b.number);
            int distV = distanceAdot + distanceBdot;
            a.number = String.Join("", a.number.Split('.'));
            b.number = String.Join("", b.number.Split('.'));
            while (i < a.number.Length)
            {
                if (a.number[i] != '0')
                {
                    t = 0;
                    aux.number = "";
                    j = i;
                    while (j > 0)
                    {
                        aux.number = aux.number + '0';
                        j--;
                    }
                    while (j < b.number.Length)
                    {
                        t = t + (Convert.ToInt32(a.number[i]) - '0') * (Convert.ToInt32(b.number[j]) - '0');
                        aux.number = aux.number + t % 10;
                        t /= 10;
                        j++;
                    }
                    if (t > 0)
                        aux.number = aux.number + t;
                    if (produs.number == "")
                        produs = aux;
                    else produs = Add(produs, aux);
                }
                i++;
            }
            if ((a.symbol == '+' && b.symbol == '+') || (a.symbol == '-' && b.symbol == '-'))
                produs.symbol = '+';
            else if ((a.symbol == '-' && b.symbol == '+') || (a.symbol == '+' && b.symbol == '-'))
                produs.symbol = '-';
            if (distV > 0)
            {
                if (distV < produs.number.Length)
                    produs.number = produs.number.Insert(distV, ".");
                else
                {
                    while (distV + 1 != produs.number.Length)
                        produs.number = produs.number + '0';
                    produs.number = produs.number.Insert(distV, ".");
                }
            }
            while (produs.number[produs.number.Length - 1] == '0' && produs.number[produs.number.Length - 2] == '0')
                produs.number = produs.number.Substring(0, produs.number.Length - 1);
            return produs;
        }
        public numbers Divide(numbers a, numbers b)
        {
            numbers c, aux;
            int count, dot = 0, bigger = 0;
            c.symbol = aux.symbol = '+';
            c.number = aux.number = "";
            if (b.number == "0")
            {
                c.number = "0";
                return c;
            }
            distanceAdot = dotDistance(a.number);
            distanceBdot = dotDistance(b.number);
            if (distanceAdot > 0)
            {
                a.number = String.Join("", a.number.Split('.'));
                while (distanceAdot > 0)
                {
                    distanceAdot--;
                    if (distanceBdot == 0)
                        b.number = '0' + b.number;
                    else
                    {
                        b.number = String.Join("", b.number.Split('.'));
                        distanceBdot--;
                        if (distanceBdot > 0)
                            b.number = b.number.Insert(distanceBdot, ".");
                    }
                }
                while (a.number.Last() == '0' || a.number.Last() == '.')
                    a.number = a.number.Substring(0, a.number.Length - 1);
            }
            bigger = NumbersMax(b.number, a.number);
            if (bigger == 0)
            {
                dot = 1;
                if (b.number.Last() == '0')
                {
                    b.number = b.number.Substring(0, b.number.Length - 2);
                    c.number = ".0";
                }
            }
            for (int i = b.number.Length - 1; i >= 0; i--)
                if (b.number[i] != '.')
                {
                    count = 0;
                    if (aux.number == "0")
                        aux.number = "";
                    aux.number = b.number[i] + aux.number;
                    while (NumbersMax(aux.number, a.number) == 1)
                    {
                        count++;
                        aux = Substract(aux, a);
                    }
                    if (c.number.Length > 0 || count > 0)
                        c.number = count + c.number;
                }
                else
                {
                    if (c.number == "")
                        c.number = '0' + c.number;
                    c.number = '.' + c.number;
                    dot = 1;
                }
            if (bigger == 0 && c.number == "")
            {
                c.number = "0";
                dot = 0;
            }
            if (aux.number != "0")
            {
                int nrDec = 15;
                count = 0;
                if (dot == 0)
                    c.number = '.' + c.number;
                while (aux.number != "0" && nrDec != 0)
                {
                    aux.number = '0' + aux.number;
                    count = 0;
                    while (NumbersMax(aux.number, a.number) == 1)
                    {
                        count++;
                        aux = Substract(aux, a);
                    }
                    c.number = count + c.number;
                    nrDec--;
                }
            }
            if ((a.symbol == '+' && b.symbol == '+') || (a.symbol == '-' && b.symbol == '-'))
                c.symbol = '+';
            else if ((a.symbol == '-' && b.symbol == '+') || (a.symbol == '+' && b.symbol == '-'))
                c.symbol = '-';
            return c;
        }
        public numbers Pow(numbers a, numbers b)
        {
            if (b.number == "0")
            {
                numbers c;
                c.number = "1";
                c.symbol = '+';
                return c;
            }
            else if (b.number == "1") return a;
            else if (b.number[0] == '0' || b.number[0] == '2' || b.number[0] == '4' || b.number[0] == '6' || b.number[0] == '8')
            {
                numbers c, aux;
                c.number = "2";
                c.symbol = '+';
                aux = Divide(c, b);
                distanceAdot = dotDistance(aux.number);
                if (distanceAdot > 0)
                    while (distanceAdot >= 0)
                    {
                        distanceAdot--;
                        aux.number = aux.number.Substring(1);
                    }
                return Pow(Multiply(a, a), aux);
            }
            else
            {
                numbers c, d, aux;
                c.number = "2";
                d.number = "1";
                c.symbol = d.symbol = '+';
                aux = Divide(c, Substract(b, d));
                distanceAdot = dotDistance(aux.number);
                if (distanceAdot > 0)
                    while (distanceAdot >= 0)
                    {
                        distanceAdot--;
                        aux.number = aux.number.Substring(1);
                    }
                return Multiply(a, Pow(Multiply(a, a), aux));
            }
        }
        public numbers NthRoot(numbers A, numbers N)
        {
            Random rand = new Random();
            numbers xPre, delX, eps, xK, unitary, one, rounding;
            xPre.symbol = delX.symbol = eps.symbol = xK.symbol = unitary.symbol = one.symbol = rounding.symbol = '+';
            rounding.number = "0.000001";
            unitary.number = "0.1";
            one.number = "1";
            xPre.number = "8";
            eps.number = "100.0";
            delX.number = "7463847412";
            xK.number = "0.0";
            while (NumbersMax(delX.number, eps.number) == 1)
            {
                xK = Divide(N, Add(Multiply(Substract(N, unitary), xPre), Divide(Pow(xPre, Substract(N, one)), A)));
                if (NumbersMax(xK.number, xPre.number) == 1)
                    delX = Substract(xK, xPre);
                else delX = Substract(xPre, xK);
                xPre = xK;
            }
            int pos = 0;
            while (xK.number[pos] != '.')
                pos++;
            if ((xK.number[pos - 1] == '0' && xK.number[pos - 2] == '0') || (xK.number[pos - 1] == '9' && xK.number[pos - 2] == '9'))
                xK.number = Rounding(xK.number, 0);
            return xK;
        }
        public numbers Percentage(numbers cat)
        {
            numbers c, S;
            c.symbol = S.symbol = '+';
            c.number = "";
            S.number = "001";
            c = Divide(S, cat);
            return c;
        }
        public numbers Factorial(numbers factorial)
        {
            numbers c, one, two, result;
            if (factorial.number == "0")
            {
                factorial.number = "1";
                factorial.symbol = '+';
                return factorial;
            }
            distanceAdot = dotDistance(factorial.number);
            if (distanceAdot > 0)
            {
                throw new CalculatorException(Errors.factorialError);
            }
            c.symbol = two.symbol = one.symbol = result.symbol = '+';
            c.number = one.number = result.number = factorial.number;
            two.number = "2";
            for (one = Substract(one, two); one.number != "1" && one.number != "0"; one = Substract(one, two))
            {
                c = Add(c, one);
                result = Multiply(result, c);
            }
            if (factorial.number.First() == '1' || factorial.number.First() == '3' || factorial.number.First() == '5' || factorial.number.First() == '7' || factorial.number.First() == '9')
            {
                numbers odd;
                one.number = "1";
                odd = Divide(two, factorial);
                odd.number = odd.number.Substring(2);
                result = Multiply(result, Add(odd, one));
            }
            return result;
        }
    }
}
