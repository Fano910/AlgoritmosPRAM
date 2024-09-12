using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;

namespace Algoritmos
{
    internal class PRAM
    {
        /**/
        private static void Maines()
        {
            // Definir un nuevo color usando valores RGB
            Color miColor = Color.FromArgb(255, 128, 0); // Naranja

            // Usar el color en algún componente, por ejemplo, en una consola
            Console.ForegroundColor = ConsoleColor.Yellow; // Esto es solo un ejemplo, ConsoleColor no acepta Color directamente
            Console.WriteLine("Este texto es de color naranja (simulado).");

            // Mostrar los valores del color
            Console.WriteLine($"Color definido: R={miColor.R}, G={miColor.G}, B={miColor.B}");
        }

        // Imprime el arreglo actual
        private static void PrintArray(List<int> arr, string operation)
        {
            Console.WriteLine($"{operation}: {string.Join(", ", arr)}");
        }

        private static int GetPow(int Potencia)
        {
            return 1 << Potencia;
        }

        private static (List<int>, int) ReStructure(int ArraySize, List<int> Source, Boolean ReFin)
        {
            int nextPowerOf2 = (int)Math.Pow(2, Math.Ceiling(Math.Log(ArraySize, 2)));
            if (ArraySize != nextPowerOf2) // Si el tamaño actual no es una potencia de 2, aumenta el tamaño
            {
                for (int i = ArraySize; i < nextPowerOf2; i++) // Agrega ceros al inicio para llenar hasta la siguiente potencia de 2
                {
                    //ReFin ? {Source.Add(0)} : { Source.Insert(0, 0)};
                    if (ReFin)
                    {
                        Source.Add(0);
                    }
                    else
                    {
                        Source.Insert(0, 0);
                    }
                }
            }
            return (Source, nextPowerOf2);
        }

        // Algoritmo: 1) sumaEREW
        public static List<List<int>> SumaEREW(List<int> Array)
        {
            List<List<int>> arrays = new List<List<int>>();
            int n = Array.Count;
            var ret = ReStructure(n, Array, false);
            Array = ret.Item1;
            n = ret.Item2;
            arrays.Add(new List<int>(Array));
            //PrintArray(A, "\nsumaEREW - Iteración 0");
            int logN = (int)Math.Log(n, 2);

            for (int i = 1; i <= logN; i++)
            {
                Parallel.For(1, (n / 2) + 1, j =>
                {
                    int index1 = 2 * j;
                    int index2 = GetPow(i);// (int)Math.Pow(2, i);
                    int suma = GetPow(i - 1) + 1;// (int)Math.Pow(2, i - 1) + 1;
                    double modulo = index1 % index2;
                    //Console.WriteLine(A[0] + "> j:" + j + " on i:" + i + " < in1=" + index1 + " in2=" + index2 + " modulo=" + modulo + " suma=" + suma);
                    if (modulo == 0) // Verificar si el índice está dentro del rango
                    {
                        //Console.WriteLine("r=" + A[index1 - 1] + " S1=" + A[index1 - 1] + " S2=" + A[index1 - suma]);
                        Array[index1 - 1] = Array[index1 - 1] + Array[index1 - suma];
                    }
                });
                arrays.Add(new List<int>(Array));
                //PrintArray(A, "sumaEREW - Iteración " + i);
            }
            return arrays;
        }

        // Algoritmo: 2) sumaCREW
        public static List<List<int>> SumaCREW(List<int> Array)
        {
            List<List<int>> arrays = new List<List<int>>();
            int n = Array.Count;
            var ret = ReStructure(n, Array, false);
            Array = ret.Item1;
            n = ret.Item2;
            arrays.Add(new List<int>(Array));
            //PrintArray(A, "sumaCREW - Iteración 0");
            int logN = (int)Math.Log(n, 2);

            for (int i = 1; i <= logN; i++)
            {
                List<int> temp = new List<int>(Array);
                int pow = GetPow(i - 1);// 1 << (i - 1);
                //Console.Write("potencia=" + pow + " - ");
                Parallel.For(pow, n, j =>
                {
                    int param1 = temp[j];
                    int param2 = temp[j - pow];
                    //Thread.Sleep(700);
                    Array[j] = param1 + param2;
                });
                arrays.Add(new List<int>(Array));
                //PrintArray(A, "sumaCREW - Iteración " + i);
            }
            return arrays;
        }

        // Algoritmo: 3) búsquedaEREW
        public static List<List<int>> BusquedaEREW(List<int> Array, int X)
        {
            List<List<int>> arrays = new List<List<int>>();
            int n = Array.Count;
            var ret = ReStructure(n, Array, true);
            Array = ret.Item1;
            n = ret.Item2;
            arrays.Add(new List<int>(Array));

            int log2 = (int)Math.Log(n, 2);
            List<int> Temp = new List<int>(new int[n]);

            List<List<int>> listas = Broadcast(Temp, X, n);
            foreach (List<int> lista in listas)
            {
                arrays.Add(new List<int>(lista));
            }

            Parallel.For(0, n, i =>
            {
                Temp[i] = Array[i] == Temp[i] ? i : int.MaxValue;
                //if (Array[i] == Temp[i])
                //{
                //    Temp[i] = i;
                //}
                //else
                //{
                //    Temp[i] = int.MaxValue;
                //}
            });

            listas = Minimo(log2, n, Temp);
            foreach (List<int> lista in listas)
            {
                arrays.Add(new List<int>(lista));
            }
            return arrays;
        }

        public static List<List<int>> Broadcast(List<int> Temp, int X, int N)
        {
            List<List<int>> arrays = new List<List<int>>();
            Temp[0] = X;
            arrays.Add(new List<int>(Temp));
            int k = (int)Math.Sqrt(N);

            for (int i = 1; i <= k; i++)
            {
                int pow = GetPow(i - 1);
                Parallel.For(pow, GetPow(i), j =>
                {
                    Temp[j] = Temp[j - pow];
                });
                arrays.Add(new List<int>(Temp));
                //PrintArray(Temp, "Broadcast=" + i);
            }
            return arrays;
            //Parallel.For(0, n, i => Temp[i] = X); // Algoritmo resumido:
        }

        private static List<List<int>> Minimo(int Log2, int N, List<int> Array)
        {
            List<List<int>> arrays = new List<List<int>>();
            arrays.Add(new List<int>(Array));
            //PrintArray(Array, "Minimo=0");
            for (int j = 1; j <= Log2; j++)
            {
                List<int> temp = new List<int>(Array);
                //Console.WriteLine("log2=" + Log2 + " N=" + N + " pow=" + getPow(j) + " n/pow=" + N / getPow(j));
                Parallel.For(0, N / GetPow(j), i =>
                {
                    int index = (2 * i) + 1;// getPow(i); // FORMULA INCORRECTA
                    //Console.WriteLine("j=" + j + " i=" + i + " index1=" + (index - 1) + " index1=" + index + " temp[a]=" + temp[index - 1] + " temp[b]=" + temp[index]);
                    Array[i] = temp[index - 1] > temp[index] ? temp[index] : temp[index - 1];
                    //if (temp[index - 1] > temp[index])
                    //{
                    //    Array[i] = temp[index];
                    //}
                    //else
                    //{
                    //    Array[i] = temp[index - 1];
                    //}
                });
                arrays.Add(new List<int>(Array));
                //PrintArray(Array, "Minimo=" + j);
            }
            return arrays;
        }

        // Algoritmo: 4) búsquedaCRCW
        public static (List<List<int>>, int) BusquedaCRCW(List<int> Array)
        {
            List<List<int>> arrays = new List<List<int>>();
            arrays.Add(new List<int>(Array));
            int n = Array.Count;
            List<int> win = new List<int>(new int[n]);

            Parallel.For(0, n, i => win[i] = 0);

            for (int i = 0; i < n; i++)
            {
                Parallel.For(i + 1, n, j =>
                {
                    if (Array[i] > Array[j])
                    {
                        win[i] = 1;
                    }
                    else
                    {
                        win[j] = 1;
                    }
                });
                arrays.Add(new List<int>(win));
            }

            int IndexMin = -1;
            Parallel.For(0, n, i =>
            {
                if (win[i] == 0)
                {
                    IndexMin = i;
                    //break;
                }
            });

            //PrintArray(Array, "busquedaCRCW");
            //return IndexMin == -1 ? -1 : Array[IndexMin];
            return (arrays, IndexMin == -1 ? -1 : Array[IndexMin]);
        }

        // Algoritmo ordenamientoCRCW
        public static void OrdenamientoCRCW(List<int> L)
        {
            int n = L.Count;
            List<int> win = new List<int>(new int[n]);

            Parallel.For(0, n, i => win[i] = 0);

            for (int i = 0; i < n; i++)
            {
                Parallel.For(i + 1, n, j =>
                {
                    if (L[i] > L[j])
                    {
                        win[i]++;
                    }
                    else
                    {
                        win[j]++;
                    }
                });
            }

            List<int> sortedArray = new List<int>(new int[n]);
            Parallel.For(0, n, i =>
            {
                sortedArray[win[i]] = L[i];
            });

            for (int i = 0; i < n; i++) L[i] = sortedArray[i];
            PrintArray(L, "ordenamientoCRCW");
        }

        // Algoritmo ordenamientoEREW (Odd-Even Merge)
        public static void OrdenamientoEREW(List<int> L, int n)
        {
            if (n == 2)
            {
                if (L[0] > L[1])
                {
                    int temp = L[0];
                    L[0] = L[1];
                    L[1] = temp;
                }
            }
            else
            {
                int mid = n / 2;
                List<int> odd = new List<int>(mid);
                List<int> even = new List<int>(mid);

                Parallel.For(0, mid, i =>
                {
                    odd.Add(L[2 * i]);
                    even.Add(L[2 * i + 1]);
                });

                OrdenamientoEREW(odd, mid);
                OrdenamientoEREW(even, mid);

                Parallel.For(0, mid, i =>
                {
                    L[2 * i] = odd[i];
                    L[2 * i + 1] = even[i];
                });

                Parallel.For(0, mid - 1, i =>
                {
                    if (L[2 * i + 1] > L[2 * i + 2])
                    {
                        int temp = L[2 * i + 1];
                        L[2 * i + 1] = L[2 * i + 2];
                        L[2 * i + 2] = temp;
                    }
                });
            }
            PrintArray(L, "ordenamientoEREW");
        }
    }
}
