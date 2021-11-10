using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator : Form
    {
        public struct numere    // in acest struct vor fi memorate numerele pentru a putea avea orice dimensiune. Numerele vor fi memorate in ordine inversa
        {
            public string numar;
            public char semn;
        };
        Stack<numere> N = new Stack<numere>();//stiva folosita pentru a salva numerele operației inserate si cele obținute pe parcurs
        Stack<char> S = new Stack<char>();//stiva folosita pentru a salva semnele de calcul 
        Stack<string> R = new Stack<string>();//stiva folosita pentru a salva ordinele radicalelor 
        numere ordinRad;
        string operatie, sir= "1234567890+-*()/%^.!√⁰¹²³⁴⁵⁶⁷⁸⁹", sirSemne1 = "+-*/^.", sirSemne2 = "().!"; // aceste siruri vor fi utilizate pentru a identifica anumite erori de calcul ale utilizatorului
        int distApunct, distBpunct;
        int ok0, okRad, eroare, nrParanteze, semne; // aceste variabile vor fi utilizate pentru a identifica anumite erori de calcul ale utilizatorului
        int limita;
        public Calculator()
        {
            InitializeComponent();
        }
        private void OnMouseEnterButton(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackColor = Color.SkyBlue; 
        }
        private void OnMouseLeaveButton(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackColor = Color.Transparent;
        }
        public int distantaPunct(string numar) // calculez numarul de numere aflate dupa punct (Ex: 3.39 returneaza 2, 45 returneaza 0)
        {
            int i = 0;
            while (i < numar.Length)
            {
                if (numar[i] == '.')
                    return i;
                i++;
            }
            return 0;
        }
        public string Reverse(string s) // deoarece salvez numerele in ordine inversa, pentru afisare voi avea nevoie de forma corecta a numarului
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        /*
         * operatia urmatoare este cea de rotunjire
         * utilizatorul are libertatea de a stabili cate cifre doreste sa fie calculate dupa virgula
         * setarea prestabilita de cifre dupa virgula este 6, aceasta poate fi schimbata in setari
         * aceasta operatie ne ajuta pentru a rotunji cifrele atunci cand reducem numarul de zecimale dupa virgula
         * Ex: 4.56721 poate deveni: 4.5672, 4.567, 4.57, 4.6, 5
         */
        public string Rotunjire(string s, int x)
        {
            distApunct = distantaPunct(s);
            if (x > distApunct)
                return s;
            int cifr1, cifr2;
            while (distApunct > x)
            {
                if (s.First() == '9' && s[1] == '9')
                {
                    while (s.First() == '9')
                    {
                        s = s.Substring(1);
                        distApunct--;
                    }
                    if (s.First() == '.')
                    {
                        s = s.Substring(1);
                    }
                    cifr1 = Convert.ToInt32(s.First() - '0');
                    s = s.Substring(1);
                    s = (cifr1 + 1) + s;
                }
                else
                {
                    cifr1 = Convert.ToInt32(s.First() - '0');
                    s = s.Substring(1);
                    if (s.First() == '.')
                        s = s.Substring(1);
                    cifr2 = Convert.ToInt32(s.First() - '0');
                    s = s.Substring(1);
                    if (cifr1 >= 5)
                    {
                        if (cifr2 == 9)
                        {
                            while (s.First() != '.' && cifr2 == 9)
                            {
                                cifr2 = Convert.ToInt32(s.First() - '0');
                                s = s.Substring(1);
                                distApunct--;
                            }
                            if (s.First() == '.' && cifr2 == 9)
                            {
                                distApunct = 0;
                                s = s.Substring(1);
                                cifr2 = Convert.ToInt32(s.First() - '0');
                                s = s.Substring(1);
                            }
                            s = (cifr2 + 1) + s;
                        }
                        else s = (cifr2 + 1) + s;
                    }
                    else s = cifr2 + s;
                    distApunct--;
                }
            }
            return s;
        }
        public int numereMax(string a, string b) // determin maximul dintre doua numere pentru a ma ajuta la calcule precum scaderea
        {
            a = Reverse(a);
            b = Reverse(b);
            if (a == "0")
                return 0;
            if (b == "0" || a == b)
                return 1;
            int dA = distantaPunct(a);
            int dB = distantaPunct(b);
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
        public void reglareAdunare(int distA, int distB, ref int iA, ref int iB, string a, string b, ref numere c)
        {
            if (distA != distB)
            {
                if (distApunct < distBpunct)
                    while (distBpunct > distApunct)
                    {
                        c.numar = c.numar + b[iB];
                        iB++;
                        distBpunct--;
                    }
                else while (distApunct > distBpunct)
                    {
                        c.numar = c.numar + a[iA];
                        iA++;
                        distApunct--;
                    }
            }
        }
        public void reglareScadere(int distA, int distB, ref numere a, ref numere b, ref numere c)
        {
            if (distA != distB)
            {
                if (distApunct < distBpunct)
                    while (distBpunct > distApunct)
                    {
                        a.numar = '0' + a.numar;
                        distBpunct--;
                    }
                else while (distApunct > distBpunct)
                    {
                        b.numar = '0' + b.numar;
                        distApunct--;
                    }
            }
        }
        public numere adunare(numere a, numere b) // adunarea a doua numere mari
        {
            numere c;
            c.numar = "";
            c.semn = '+';
            distApunct = distantaPunct(a.numar);
            distBpunct = distantaPunct(b.numar);
            int iA = 0, iB = 0;
            reglareAdunare(distApunct, distBpunct, ref iA, ref iB, a.numar, b.numar, ref c);
            int aux = 0;
            while (iA < a.numar.Length && iB < b.numar.Length)
            {
                if (a.numar[iA] == '.' && b.numar[iB] != '.')
                {
                    c.numar = c.numar + '.';
                    iA++;
                }
                else if (b.numar[iB] == '.' && a.numar[iA] != '.')
                {
                    c.numar = c.numar + '.';
                    iB++;
                }
                else if (a.numar[iA] == '.' && b.numar[iB] == '.')
                {
                    c.numar = c.numar + '.';
                    iA++;
                    iB++;
                }
                else
                {
                    aux = aux + Convert.ToInt32(a.numar[iA]) - '0' + Convert.ToInt32(b.numar[iB]) - '0';
                    c.numar = c.numar + Convert.ToString(aux % 10);
                    aux /= 10;
                    iA++;
                    iB++;
                }
            }
            if (iA < a.numar.Length)
            {
                while (aux > 0)
                {
                    if (iA < a.numar.Length)
                        aux = aux + Convert.ToInt32(a.numar[iA]) - '0';
                    c.numar = c.numar + Convert.ToString(aux % 10);
                    aux /= 10;
                    iA++;
                }
                while (iA < a.numar.Length)
                {
                    c.numar = c.numar + a.numar[iA];
                    iA++;
                }
            }
            else if (iB < b.numar.Length)
            {
                while (aux > 0)
                {
                    if (iB < b.numar.Length)
                        aux = aux + Convert.ToInt32(b.numar[iB]) - '0';
                    c.numar = c.numar + Convert.ToString(aux % 10);
                    aux /= 10;
                    iB++;
                }
                while (iB < b.numar.Length)
                {
                    c.numar = c.numar + b.numar[iB];
                    iB++;
                }
            }
            else if (aux > 0)
                c.numar = c.numar + Convert.ToString(aux);
            return c;
        }
        public numere scadere(numere a, numere b) // diferenta dintre doua numere mari
        {
            char[] auxString;
            numere P;
            P.numar = "";
            P.semn = '+';
            distApunct = distantaPunct(a.numar);
            distBpunct = distantaPunct(b.numar);
            int iA = 0, iB = 0;
            reglareScadere(distApunct, distBpunct, ref a, ref b, ref P);
            int aux = 0;
            while (iA < a.numar.Length && iB < b.numar.Length)
            {
                if (a.numar[iA] == '.' && b.numar[iB] != '.')
                {
                    P.numar = P.numar + '.';
                    iA++;
                }
                else if (b.numar[iB] == '.' && a.numar[iA] != '.')
                {
                    P.numar = P.numar + '.';
                    iB++;
                }
                else if (a.numar[iA] == '.' && b.numar[iB] == '.')
                {
                    P.numar = P.numar + '.';
                    iA++;
                    iB++;
                }
                else
                {
                    if (a.numar[iA] < b.numar[iB])
                    {
                        int k = 1;
                        while (a.numar[iA + k] == '0' || a.numar[iA + k] == '.')
                            k++;
                        auxString = a.numar.ToCharArray();
                        auxString[iA + k] = (char)((int)auxString[iA + k] - 1);
                        a.numar = new string(auxString);
                        k--;
                        while (k != 0)
                        {
                            if (a.numar[iA + k] != '.')
                            {
                                auxString = a.numar.ToCharArray();
                                auxString[iA + k] = '9';
                                a.numar = new string(auxString);
                            }
                            k--;
                        }
                        aux = 10 + (Convert.ToInt32(a.numar[iA]) - '0') - (Convert.ToInt32(b.numar[iB]) - '0');
                    }
                    else
                        aux = (Convert.ToInt32(a.numar[iA]) - '0') - (Convert.ToInt32(b.numar[iB]) - '0');
                    P.numar = P.numar + aux;
                    iA++;
                    iB++;
                }
            }
            if (iA < a.numar.Length)
            {
                while (a.numar.Length > 0 && a.numar.Last() == '0')
                    a.numar = a.numar.Substring(0, a.numar.Length - 1);
                while (iA < a.numar.Length)
                {
                    P.numar = P.numar + a.numar[iA];
                    iA++;
                }
            }
            else if (iB < b.numar.Length)
            {
                while (b.numar.Length > 0 && b.numar.Last() == '0')
                    b.numar = b.numar.Substring(0, b.numar.Length - 1);
                while (iB < b.numar.Length)
                {
                    P.numar = P.numar + b.numar[iB];
                    iB++;
                }
            }
            while (P.numar.Length > 1 && P.numar.Last() == '0')
                P.numar = P.numar.Substring(0, P.numar.Length - 1);
            if (P.numar.Last() == '.')
                P.numar = P.numar + '0';
            return P;
        }
        public numere inmultire(numere a, numere b) // inmultirea dintre doua numere mari
        {
            int t, i = 0, j;
            numere aux, produs;
            produs.numar = aux.numar = "";
            produs.semn = aux.semn = '+';
            distApunct = distantaPunct(a.numar);
            distBpunct = distantaPunct(b.numar);
            int distV = distApunct + distBpunct;
            a.numar = String.Join("", a.numar.Split('.'));
            b.numar = String.Join("", b.numar.Split('.'));
            while (i < a.numar.Length)
            {
                if (a.numar[i] != '0')
                {
                    t = 0;
                    aux.numar = "";
                    j = i;
                    while (j > 0)
                    {
                        aux.numar = aux.numar + '0';
                        j--;
                    }
                    while (j < b.numar.Length)
                    {
                        t = t + (Convert.ToInt32(a.numar[i]) - '0') * (Convert.ToInt32(b.numar[j]) - '0');
                        aux.numar = aux.numar + t % 10;
                        t /= 10;
                        j++;
                    }
                    if (t > 0)
                        aux.numar = aux.numar + t;
                    if (produs.numar == "")
                        produs = aux;
                    else produs = adunare(produs, aux);
                }
                i++;
            }
            if ((a.semn == '+' && b.semn == '+') || (a.semn == '-' && b.semn == '-'))
                produs.semn = '+';
            else if ((a.semn == '-' && b.semn == '+') || (a.semn == '+' && b.semn == '-'))
                produs.semn = '-';
            if (distV > 0)
            {
                if (distV < produs.numar.Length)
                    produs.numar = produs.numar.Insert(distV, ".");
                else
                {
                    while (distV + 1 != produs.numar.Length)
                        produs.numar = produs.numar + '0';
                    produs.numar = produs.numar.Insert(distV, ".");
                }
            }
            while (produs.numar[produs.numar.Length - 1] == '0' && produs.numar[produs.numar.Length - 2] == '0')
             produs.numar = produs.numar.Substring(0, produs.numar.Length-1);
            return produs;
        }
        public numere impartire(numere a, numere b) // impartirea dintre doua numere mari
        {
            numere c, aux;
            int cont, punct = 0, maiMare = 0;
            c.semn = aux.semn = '+';
            c.numar = aux.numar = "";
            if(b.numar == "0")
            {
                c.numar = "0";
                return c;
            }
            distApunct = distantaPunct(a.numar);
            distBpunct = distantaPunct(b.numar);
            if (distApunct > 0)
            {
                a.numar = String.Join("", a.numar.Split('.'));
                while (distApunct > 0)
                {
                    distApunct--;
                    if (distBpunct == 0)
                        b.numar = '0' + b.numar;
                    else
                    {
                        b.numar = String.Join("", b.numar.Split('.'));
                        distBpunct--;
                        if (distBpunct > 0)
                            b.numar = b.numar.Insert(distBpunct, ".");
                    }
                }
                while (a.numar.Last() == '0' || a.numar.Last() == '.')
                    a.numar = a.numar.Substring(0, a.numar.Length - 1);
            }
            maiMare = numereMax(b.numar, a.numar);
            if (maiMare == 0)
            {
                punct = 1;
                if (b.numar.Last() == '0')
                {
                    b.numar = b.numar.Substring(0, b.numar.Length - 2);
                    c.numar = ".0";
                }
            }
            for (int i = b.numar.Length - 1; i >= 0; i--)
                if (b.numar[i] != '.')
                {
                    cont = 0;
                    if (aux.numar == "0")
                        aux.numar = "";
                    aux.numar = b.numar[i] + aux.numar;
                    while (numereMax(aux.numar, a.numar) == 1)
                    {
                        cont++;
                        aux = scadere(aux, a);
                    }
                    if (c.numar.Length > 0 || cont > 0)
                        c.numar = cont + c.numar;
                }
                else
                {
                    if (c.numar == "")
                        c.numar = '0' + c.numar;
                    c.numar = '.' + c.numar;
                    punct = 1;
                }
            if (maiMare == 0 && c.numar == "")
            {
                c.numar = "0";
                punct = 0;
            }
            if (aux.numar != "0")
            {
                int nrzec = limita+10; // numarul de zecimale calculate dupa virgula
                cont = 0;
                if (punct == 0)
                    c.numar = '.' + c.numar;
                while (aux.numar != "0" && nrzec != 0)
                {
                    aux.numar = '0' + aux.numar;
                    cont = 0;
                    while (numereMax(aux.numar, a.numar) == 1)
                    {
                        cont++;
                        aux = scadere(aux, a);
                    }
                    c.numar = cont + c.numar;
                    nrzec--;
                }
            }
            if ((a.semn == '+' && b.semn == '+') || (a.semn == '-' && b.semn == '-'))
                c.semn = '+';
            else if ((a.semn == '-' && b.semn == '+') || (a.semn == '+' && b.semn == '-'))
                c.semn = '-';
            return c;
        }
        /*
         * urmeaza ridicarea la putere a doua numere, in functie de cat de mari sunt numarele operatia va fi mai lenta
         * am utilizat metoda ridicarii la putere in timp logaritmic
         */
        public numere putere(numere a, numere b) 
        {
            if (b.numar == "0")
            {
                numere c;
                c.numar = "1";
                c.semn = '+';
                return c;
            }
            else if (b.numar == "1") return a;
            else if (b.numar[0] == '0' || b.numar[0] == '2' || b.numar[0] == '4' || b.numar[0] == '6' || b.numar[0] == '8')
            {
                numere c, aux;
                c.numar = "2";
                c.semn = '+';
                aux = impartire(c, b);
                distApunct = distantaPunct(aux.numar);
                if (distApunct > 0)
                    while (distApunct >= 0)
                    {
                        distApunct--;
                        aux.numar = aux.numar.Substring(1);
                    }
                return putere(inmultire(a, a), aux);
            }
            else
            {
                numere c, d, aux;
                c.numar = "2";
                d.numar = "1";
                c.semn = d.semn = '+';
                aux = impartire(c, scadere(b, d));
                distApunct = distantaPunct(aux.numar);
                if (distApunct > 0)
                    while (distApunct >= 0)
                    {
                        distApunct--;
                        aux.numar = aux.numar.Substring(1);
                    }
                return inmultire(a, putere(inmultire(a, a), aux));
            }
        }
        /*
         * urmeaza radicalul de ordin N dintr-un numar A
         * in functie de cat de mari sunt numerele operatia va dura mai mult
         * pentru calculul acestui radical am folosit metoda lui Newton
         */
        public numere nthRoot(numere A, numere N)
        {
            Random rand = new Random();
            numere xPre, delX, eps, xK, unitar, unu, rotunjire;
            xPre.semn = delX.semn = eps.semn = xK.semn = unitar.semn = unu.semn = rotunjire.semn = '+';
            rotunjire.numar = "0.000001";
            unitar.numar = "0.1";
            unu.numar = "1";
            xPre.numar = "8";
            eps.numar = "100.0";
            delX.numar = "7463847412";
            xK.numar = "0.0";
            while (numereMax(delX.numar, eps.numar) == 1)
            {
                numere calcul;
                calcul = impartire(putere(xPre, scadere(N, unu)), A);
                calcul = impartire(N, impartire(putere(xPre, scadere(N, unu)), A));
                xK = impartire(N, adunare(inmultire(scadere(N, unitar), xPre), impartire(putere(xPre, scadere(N, unu)), A)));
                if (numereMax(xK.numar, xPre.numar) == 1)
                    delX = scadere(xK, xPre);
                else delX = scadere(xPre, xK);
                xPre = xK;
            }
            int poz = 0;
            while (xK.numar[poz] != '.')
                poz++;
            if ((xK.numar[poz - 1] == '0' && xK.numar[poz - 2] == '0') || (xK.numar[poz - 1] == '9' && xK.numar[poz - 2] == '9'))
                xK.numar = Rotunjire(xK.numar, 0);
            return xK;
        }
        public numere procentaj(numere cat) // calculez procentajul p%
        {
            numere c, S;
            c.semn = S.semn = '+';
            c.numar = "";
            S.numar = "001";
            c = impartire(S, cat);
            return c;
        }
        public void Factorial(ref numere factorial)
        {
            numere c, nr, one, doi;
            nr = N.Peek();
            N.Pop();
            if (nr.numar == "0")
            {
                factorial.numar = "1";
                factorial.semn = '+';
                N.Push(factorial);
                return;
            }
            distApunct = distantaPunct(nr.numar);
            if (distApunct > 0) // cazul in care avem un numar rational pentru care sa cere factorialul
            {
                MessageBox.Show("Calculatorul prelucrează factorial doar din numere întregi.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ok0 = 1;
                okRad = 1;
                eroare = 1;
                return;
            }
            c.semn = factorial.semn = doi.semn = one.semn = '+';
            c.numar = factorial.numar = one.numar = nr.numar;
            doi.numar = "2";
            for (one = scadere(one, doi); one.numar != "1" && one.numar != "0"; one = scadere(one, doi))
            {
                c = adunare(c, one);
                factorial = inmultire(factorial, c);
            }
            if (nr.numar.First() == '1' || nr.numar.First() == '3' || nr.numar.First() == '5' || nr.numar.First() == '7' || nr.numar.First() == '9')
            {
                numere impar;
                c.numar = nr.numar;
                c.semn = '+';
                one.numar = "1";
                impar = impartire(doi, nr);
                impar.numar = impar.numar.Substring(2); // folosim doar partea intreaga din numar
                factorial = inmultire(factorial, adunare(impar, one));
            }
        }
        public void calc() // acest subprogram identifica operatia urmatoare de efectuat
        {
            numere a, b;
            if (S.Peek() == '√')
            {
                a = N.Peek();
                N.Pop();
                ordinRad.semn = '+';
                ordinRad.numar = R.Peek();
                R.Pop();
                if (a.semn == '-') // cazul in care avem radical de ordin par din numar negativ
                {
                    if(ordinRad.numar[0] !='1' && ordinRad.numar[0] != '3' && ordinRad.numar[0] != '5' && ordinRad.numar[0] != '7' && ordinRad.numar[0] != '9')
                    {
                        MessageBox.Show("Radical de ordin par din număr negativ.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        okRad = 0;
                        return;
                    }
                }
                numere z = nthRoot(a, ordinRad);
                if (a.semn == '-') z.semn = '-';
                N.Push(z);
                return;
            }
            else if (S.Peek() == '%')
            {
                b = N.Peek();
                N.Pop();
                N.Push(procentaj(b));
                return;
            }
            else if (S.Peek() == '!')
            {
                numere factorial;
                factorial.numar = "";
                factorial.semn = '+';
                Factorial(ref factorial);
                if(eroare!=1)
                N.Push(factorial);
                return;
            }
            a = N.Peek();
            N.Pop();
            b = N.Peek();
            N.Pop();
            if (S.Peek() == '+')
            {
                if (a.semn == '+' && b.semn == '+')
                    N.Push(adunare(a, b));
                else if (a.semn == '-' && b.semn == '+')
                {
                    if (numereMax(b.numar, a.numar) == 1)
                        N.Push(scadere(b, a));
                    else
                    {
                        numere c = scadere(a, b);
                        c.semn = '-';
                        N.Push(c);
                    }
                }
                else if (a.semn == '+' && b.semn == '-')
                {
                    if (numereMax(a.numar, b.numar) == 1)
                        N.Push(scadere(a, b));
                    else
                    {
                        numere c = scadere(b, a);
                        c.semn = '-';
                        N.Push(c);
                    }
                }
                else if (a.semn == '-' && b.semn == '-')
                {
                    numere c = adunare(a, b);
                    c.semn = '-';
                    N.Push(c);
                }
            }
            else if (S.Peek() == '-')
            {
                if (b.semn == '+' && a.semn == '+')
                {
                    if (numereMax(b.numar, a.numar) == 1)
                        N.Push(scadere(b, a));
                    else
                    {
                        numere c = scadere(a, b);
                        c.semn = '-';
                        N.Push(c);
                    }
                }
                else if (b.semn == '+' && a.semn == '-')
                    N.Push(adunare(b, a));
                else if (b.semn == '-' && a.semn == '+')
                {
                    numere c = adunare(a, b);
                    c.semn = '-';
                    N.Push(c);
                }
                else if (a.semn == '-' && b.semn == '-')
                {
                    if (numereMax(b.numar, a.numar) == 1)
                    {
                        numere c = scadere(b, a);
                        c.semn = '-';
                        N.Push(c);
                    }
                    else N.Push(scadere(a, b));
                }
            }
            else if (S.Peek() == '*')
            {
                numere c = inmultire(a, b);
                N.Push(c);
            }
            else if (S.Peek() == '/')
            {
                if (a.numar == "0")
                {
                    MessageBox.Show("Împărțire la 0.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ok0 = 0;
                    return;
                }
                N.Push(impartire(a, b));
            }
            else if (S.Peek() == '^')
            {
                if(a.numar == "0" && b.numar == "0")
                {
                    MessageBox.Show("0 la puterea 0 este o nedeterminare.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    eroare = 1;
                    return;
                }
                numere c = putere(b, a);
                if (b.semn == '-')
                {
                    if (a.numar[0] != '0' && a.numar[0] != '2' && a.numar[0] != '4' && a.numar[0] != '6' && a.numar[0] != '8')
                        c.semn = '-';
                }
                if (a.semn == '-')
                {
                    numere d;
                    d.numar = "1";
                    d.semn = '+';
                    c = impartire(c, d);
                }
                N.Push(c);
            }
        }
        /*
         * urmatoarele doua subprograme determina folosind regula formei poloneze pentru a determina
         * care operatie va fi efectuata urmatoarea, astfel incat sa respecte ordinea calculelor
         */
        public int verifVarf(char c)
        {
            if (c == '^')
            {
                if (S.Peek() == '^' || S.Peek() == '√' || S.Peek() == '!')
                    return 0;
                return 1;
            }
            if (c == '*' || c == '/')
            {
                if (S.Peek() == '^' || S.Peek() == '*' || S.Peek() == '/' || S.Peek() == '√' || S.Peek() == '!')
                    return 0;
                return 1;
            }
            if (c == '+' || c == '-')
            {
                if (S.Peek() == '^' || S.Peek() == '+' || S.Peek() == '-' || S.Peek() == '*' || S.Peek() == '/' || S.Peek() == '√' || S.Peek() == '!')
                    return 0;
                return 1;
            }
            if (c == ')')
            {
                while (S.Peek() != '(')
                {
                    calc();
                    S.Pop();
                }
                S.Pop();
                return 1;
            }
            return 1;
        }
        public void verificare(char c)
        {
            if (verifVarf(c) == 1)
            {
                if (c != ')') S.Push(c);
                return;
            }
            if (okRad == 0) return;
            while (S.Count() != 0 && verifVarf(c) == 0)
            {
                calc();
                S.Pop();
            }
            S.Push(c);
        }
        /*
        * urmatorul subprogram blocheaza cursorul mouse-ului in locul stabilit de utilizator
        * indiferent daca acesta foloseste tastatura laptopului sau butoanele pentru a introduce calculul
        * in acelasi timp sterge mesajul de informare din casuta de calcul, si adauga elementele calculului, daca acestea
        * sunt introduse de la butoanele calculatorului
        */
        private void focus(string c)
        {
            label5.Visible = false;
            if (panel1.Visible == true) return;
            textBox1.Focus();
            textBox1.SelectionLength = 0;
            if (c == "-1")
                return;
            int selectionIndex = textBox1.SelectionStart;
            textBox1.Text = textBox1.Text.Insert(selectionIndex, c);
            textBox1.SelectionStart = selectionIndex+c.Length;
        }
        public string divizare(string nr) // acest subprogram imparte rezultatul in grupe de maxim 3 cifre pentru a fi mai usor de citit(Ex:34536 devine 34,536)
        {
            int i = 0, cont = 0;
            distApunct = distantaPunct(nr);
            if (distApunct > 0)
            {
                i = distApunct;
                i++;
            }
            while(i<nr.Length)
            {
                cont++;
                if (cont == 3 && i+1 < nr.Length)
                {
                    cont = 0;
                    nr = nr.Insert(i+1, ",");
                    i++;
                }
                i++;
            }
            return nr;
        }
        public void separare_operatie() //urmatorul subprogram imparte operatia citita in numere si simboluri de calcul
        {
            int i = 0, contorSirInapoi;
            numere nr;
            nr.semn = '+';
            operatie = textBox1.Text;
            while (i < operatie.Length)
            {
                if(i>0 && ((sirSemne1.Contains(operatie[i]) == true && sirSemne1.Contains(operatie[i-1]) == true) || ( operatie[i]== '√' && sirSemne2.Contains(operatie[i-1]) ) ||(operatie[i-1] == '%' && sirSemne2.Contains(operatie[i]) ) ))
                {
                    semne = 0;
                    return;
                }
                if (operatie[i] == '(')
                    nrParanteze++;
                else if (operatie[i] == ')')
                {
                    nrParanteze--;
                    if (i > 0 && operatie[i - 1] == '(')
                    {
                        nrParanteze = -1;
                        return;
                    }
                }
                if (nrParanteze < 0)
                    return;
                if (sir.Contains(operatie[i]) == false)
                {
                    MessageBox.Show("Calcul introdus greșit.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ok0 = 1;
                    okRad = 1;
                    eroare = 1;
                    return;
                }
                if (i == 0 && operatie[i] == '-')
                {
                    char c = operatie[i];
                    i++;
                    nr.numar = "";
                    while (i < operatie.Length && (char.IsNumber(operatie[i]) == true || operatie[i] == '.'))
                        i++;
                    contorSirInapoi = i - 1;
                    while (contorSirInapoi >= 0 && (char.IsNumber(operatie[contorSirInapoi]) == true || operatie[contorSirInapoi] == '.'))
                    {
                        nr.numar = nr.numar + operatie[contorSirInapoi];
                        contorSirInapoi--;
                    }
                    numere zero;
                    zero.semn = '+';
                    zero.numar = "0";
                    N.Push(zero);
                    N.Push(nr);
                    S.Push(c);
                }
                else if (i == 0 && operatie[i] == '+') 
                {
                    i++;
                    continue; 
                }
                else if (i == 0 && (operatie[i] == '.' || operatie[i] == '*' || operatie[i] == '/' || operatie[i] == '.' || operatie[i] == '!' || operatie[i] == '%' || operatie[i] == '^'))
                {
                    MessageBox.Show("Calcul introdus greșit.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ok0 = 1;
                    okRad = 1;
                    eroare = 1;
                    return;
                }
                else if (i < operatie.Length && operatie[i] >= '0' && operatie[i] <= '9')
                {
                    nr.numar = "";
                    nr.semn = '+';
                    while (i < operatie.Length && (char.IsNumber(operatie[i]) == true || operatie[i] == '.'))
                        i++;
                    contorSirInapoi = i - 1;
                    while (contorSirInapoi >= 0 && (char.IsNumber(operatie[contorSirInapoi]) == true || operatie[contorSirInapoi] == '.'))
                    {
                        nr.numar = nr.numar + operatie[contorSirInapoi];
                        contorSirInapoi--;
                    }
                    N.Push(nr);
                }
                else
                {
                    if (operatie[i] == '√' && (i == 0 || (i > 0 && char.IsNumber(operatie[i - 1]) == false)))
                    {
                        R.Push("2");
                        if (S.Count() == 0)
                            S.Push(operatie[i]);
                        else verificare(operatie[i]);
                    }
                    else if (char.IsNumber(operatie[i]) == true)
                    {
                        string c = "";
                        while (char.IsNumber(operatie[i]) == true)
                        {
                            if (operatie[i] == '⁰') c = c + '0';
                            if (operatie[i] == '¹') c = c + '1';
                            if (operatie[i] == '²') c = c + '2';
                            if (operatie[i] == '³') c = c + '3';
                            if (operatie[i] == '⁴') c = c + '4';
                            if (operatie[i] == '⁵') c = c + '5';
                            if (operatie[i] == '⁶') c = c + '6';
                            if (operatie[i] == '⁷') c = c + '7';
                            if (operatie[i] == '⁸') c = c + '8';
                            if (operatie[i] == '⁹') c = c + '9';
                            i++;
                        }
                        R.Push(Reverse(c));
                        i--;
                    }
                    else if (S.Count() == 0)
                        S.Push(operatie[i]);
                    else if (operatie[i - 1] == '(')
                    {
                        numere zero;
                        zero.semn = '+';
                        zero.numar = "0";
                        N.Push(zero);
                        S.Push(operatie[i]);
                    }
                    else verificare(operatie[i]);
                    i++;
                }
            }
        }
        public void afisare_rezultat() // afisarea rezultatului rotunjit la limita ceruta
        {
            string rezultat = N.Peek().numar;
            rezultat = Rotunjire(rezultat, limita);
            if (distantaPunct(rezultat) > 0)
                while (rezultat.First() == '0')
                    rezultat = rezultat.Substring(1);
            if (rezultat.First() == '.')
                rezultat = rezultat.Substring(1);
            rezultat = divizare(rezultat);
            if (N.Peek().semn == '-')
                rezultat = rezultat + Convert.ToString(N.Peek().semn);
            rezultat = rezultat + "=";
            //urmatoarele doua randuri sunt folosite pentru ca indiferent unde se afla mouse-ul in casuta de calcul, rezultatul sa apara la finalul operatiei
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.SelectionLength = 0;
            focus(Reverse(rezultat));
            listBox1.Items.Insert(0, textBox1.Text);
        }
        public void solve() // acesta este "programul" principal care conduce la rezolvarea operatiei
        {
            ok0 = 1; okRad = 1; eroare = 0; nrParanteze = 0; semne = 1;
            N.Clear(); S.Clear(); R.Clear();
            if (textBox1.Text == "")
            {
                focus("-1");
                return;
            }
            if (radioButton1.Checked == true) limita = 6;
            else limita = Convert.ToInt32(textBox3.Text);
            separare_operatie();
            if(semne==0)
            {
                MessageBox.Show("Calcul introdus greșit.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(nrParanteze!=0)
            {
                MessageBox.Show("Distribuire greșită a parantezelor.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (eroare == 1)
                return;
            while (ok0 == 1 && okRad == 1 && eroare == 0 && S.Count() != 0)
            {
                calc();
                if (S.Count() != 0)
                    S.Pop();
            }
            if (ok0 == 1 && okRad == 1 && eroare == 0)
                afisare_rezultat();
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                solve();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            focus("-1");

        }
        // urmatoarele subprograme sunt in legatura cu butoanele construite pentru calculator, astfel incat sa afiseze in casuta de calcul textul apasat
        private void button1_Click(object sender, EventArgs e)
        {
            focus("1");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            focus("2");
        }
        private void button3_Click(object sender, EventArgs e)
        {
            focus("3");
        }
        private void button4_Click(object sender, EventArgs e)
        {
            focus("4");
        }
        private void button5_Click(object sender, EventArgs e)
        {
            focus("5");
        }
        private void button6_Click(object sender, EventArgs e)
        {
            focus("6");
        }
        private void button7_Click(object sender, EventArgs e)
        {
            focus("7");
        }
        private void button8_Click(object sender, EventArgs e)
        {
            focus("8");
        }
        private void button9_Click(object sender, EventArgs e)
        {
            focus("9");
        }
        private void button10_Click(object sender, EventArgs e)
        {
            focus("0");
        }
        private void button11_Click(object sender, EventArgs e)
        {
            focus("+");
        }
        private void button12_Click(object sender, EventArgs e)
        {
            focus("-");
        }
        private void button14_Click(object sender, EventArgs e)
        {
            focus("*");
        }
        private void button15_Click(object sender, EventArgs e)
        {
            focus("/");
        }
        private void button18_Click(object sender, EventArgs e)
        {
            focus("^");
        }
        private void button26_Click(object sender, EventArgs e)
        {
            focus("%");
        }
        private void button19_Click(object sender, EventArgs e)
        {
            focus("√");
        }
        private void button21_Click(object sender, EventArgs e)
        {
            if (textBox2.Text=="")
            {
                MessageBox.Show("Te rog introdu ordinul radicalului în casuță.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }    
            string nr = "", c = textBox2.Text;
            if(c == "0" || c == "1" || c[0] == '0')
            {
                MessageBox.Show("Te rog introdu un ordin valid în casuța radicalului.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == '0') nr = nr + '⁰';
                else if (c[i] == '1') nr = nr + '¹';
                else if (c[i] == '2') nr = nr + '²';
                else if (c[i] == '3') nr = nr + '³';
                else if (c[i] == '4') nr = nr + '⁴';
                else if (c[i] == '5') nr = nr + '⁵';
                else if (c[i] == '6') nr = nr + '⁶';
                else if (c[i] == '7') nr = nr + '⁷';
                else if (c[i] == '8') nr = nr + '⁸';
                else if (c[i] == '9') nr = nr + '⁹';
                else
                {
                    MessageBox.Show("Te rog introdu doar cifre în casuța pentru ordinul radicalului n.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ok0 = 1;
                    okRad = 1;
                    eroare = 1;
                    return;
                }
            }
                nr = nr + "√";
                focus(nr);
        }
        private void button22_Click(object sender, EventArgs e)
        {
            focus("!");
        }
        private void button24_Click(object sender, EventArgs e)
        {
            focus(".");
        }
        private void button16_Click(object sender, EventArgs e)
        {
            focus("(");
        }
        private void button17_Click(object sender, EventArgs e)
        {
            focus(")");
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.Visible = false;
            focus("-1");
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            focus("-1");
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.Visible = true;
            focus("-1");
        }
        private void button23_Click(object sender, EventArgs e)
        {
            focus("-1");
            if (panel1.Visible == true)
                panel1.Visible = false;
            else panel1.Visible = true;
        }
        private void button20_Click(object sender, EventArgs e)
        {
            string c = textBox1.Text;
            int pos = textBox1.SelectionStart - 1;
            if (c == "")
            {
                focus("-1");
                return; 
            }
            if (c.Length > 1)
                c = c.Remove(pos,1);
            else
                c = "";
            textBox1.Text = c;
            focus("-1");
            textBox1.SelectionStart = pos;
        }
        private void button25_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            N.Clear();
            R.Clear();
            S.Clear();
            ok0 = 1;
            okRad = 1;
            focus("-1");
        }
        private void button27_Click(object sender, EventArgs e)
        {
            focus("-1");
            if (panel2.Visible == true)
                panel2.Visible = false;
            else panel2.Visible = true;
        }
        /*
         *  fiecare calcul va fi inregistrat in istoricul de moment al calculatorului
         *  acestea putand fi accesate ulterior, cat timp aplicatia nu este inchisa
         */
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)  
        {
            if (listBox1.SelectedItem != null)
            {
                textBox1.Text = listBox1.SelectedItem.ToString();
            }
            focus("-1");
        }
        private void button13_Click(object sender, EventArgs e)
        {
            solve();
        }
    }
}
