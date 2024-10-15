using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;

namespace Algoritmos
{
    internal class PRAM
    {
        private static Random random = new Random(); // Instancia de Random

        /// <summary>
        /// Algoritmo: 1) sumaEREW PROBADO Y LISTO
        /// </summary>
        /// <param arreglo="Array"></param>
        /// <returns></returns>
        public static (List<List<int>>, String) SumaEREW(List<int> Array)
        {
            List<List<int>> arrays = new List<List<int>>();
            int n = Array.Count;
            var ret = ReStructure(n, Array, false);
            Array = ret.Item1;
            n = ret.Item2;
            arrays.Add(new List<int>(Array));
            int logN = (int)Math.Log(n, 2);

            for (int i = 1; i <= logN; i++)
            {
                Parallel.For(1, (n / 2) + 1, j =>
                {
                    int index1 = 2 * j;
                    int index2 = GetPow(i);// (int)Math.Pow(2, i);
                    int suma = GetPow(i - 1) + 1;// (int)Math.Pow(2, i - 1) + 1;
                    double modulo = index1 % index2;
                    if (modulo == 0)
                    {
                        Array[index1 - 1] = Array[index1 - 1] + Array[index1 - suma];
                    }
                });
                arrays.Add(new List<int>(Array));
            }
            return (arrays, $"Objetivo={Array[n - 1]} en Índice={(n - 1)}");
        }

        /// <summary>
        /// Algoritmo: 2) sumaCREW PROBADO Y LISTO
        /// </summary>
        /// <param arreglo="Array"></param>
        /// <returns></returns>
        public static (List<List<int>>, String) SumaCREW(List<int> Array)
        {
            List<List<int>> arrays = new List<List<int>>();
            int n = Array.Count;
            var ret = ReStructure(n, Array, false);
            Array = ret.Item1;
            n = ret.Item2;
            arrays.Add(new List<int>(Array));
            int logN = (int)Math.Log(n, 2);

            for (int i = 1; i <= logN; i++)
            {
                List<int> temp = new List<int>(Array);
                int pow = GetPow(i - 1);// 1 << (i - 1);
                Parallel.For(pow, n, j =>
                {
                    int param1 = temp[j];
                    int param2 = temp[j - pow];
                    Array[j] = param1 + param2;
                });
                arrays.Add(new List<int>(Array));
            }
            return (arrays, $"Objetivo={Array[n - 1]} en Índice={(n - 1)}");
        }

        /// <summary>
        /// Algoritmo: 3) búsquedaEREW PROBADO Y LISTO
        /// </summary>
        /// <param arreglo="Array"></param>
        /// <param busqueda="X"></param>
        /// <returns></returns>
        public static (List<List<int>>, String) BusquedaEREW(List<int> Array, int X)
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
            });

            listas = Minimo(log2, n, Temp);
            foreach (List<int> lista in listas)
            {
                arrays.Add(new List<int>(lista));
            }
            //Boolean isMax = Temp[0] == int.MaxValue ? true: false;
            //Console.WriteLine($"isMax={isMax} Objetivo={string.Join(", ", Array)} en Índice={string.Join(", ", Temp)}");
            //return (arrays, $"Objetivo={Array[isMax ? 0 : Temp[0]]} en Índice={(isMax ? "NO_ENCONTRADO" : "" + Temp[0])}");
            return (arrays, $"Objetivo={Array[Temp[0]]} en Índice ={Temp[0]}");
        }

        private static List<List<int>> Broadcast(List<int> Temp, int X, int N)
        {
            List<List<int>> arrays = new List<List<int>>();
            Temp[0] = X;
            arrays.Add(new List<int>(Temp));
            int k = (int)Math.Sqrt(N);

            for (int i = 1; i <= k; i++)
            {
                int pow = GetPow(i - 1);
                Parallel.For(pow, GetPow(i), j => Temp[j] = Temp[j - pow]);
                arrays.Add(new List<int>(Temp));
            }
            return arrays;
            //Parallel.For(0, n, i => Temp[i] = X); // Algoritmo resumido:
        }

        private static List<List<int>> Minimo(int Log2, int N, List<int> Array)
        {
            List<List<int>> arrays = new List<List<int>> { new List<int>(Array) };
            for (int j = 1; j <= Log2; j++)
            {
                List<int> temp = new List<int>(Array);
                Parallel.For(0, N / GetPow(j), i =>
                {
                    int index = (2 * i) + 1;// getPow(i); // FORMULA INCORRECTA
                    Array[i] = temp[index - 1] > temp[index] ? temp[index] : temp[index - 1];
                });
                arrays.Add(new List<int>(Array));
            }
            return arrays;
        }

        /// <summary>
        /// Algoritmo: 4) búsquedaCRCW PROBADO Y LISTO
        /// </summary>
        /// <param arreglo="Array"></param>
        /// <returns></returns>
        public static (List<List<int>>, String) BusquedaCRCW(List<int> L)
        {
            List<List<int>> arrays = new List<List<int>> { new List<int>(L) };

            int n = L.Count;
            List<int> win = new List<int>(new int[n]);

            Parallel.For(0, n, i => win[i] = 0); // Paso 1: Inicializar todos los valores de win[i] en 0 en paralelo

            Parallel.For(0, n, i => // Paso 2: Comparar cada par (i, j) en paralelo y ajustar el valor de win[i] o win[j]
            {
                Parallel.For(i + 1, n, j =>
                {
                    win[(L[i] > L[j]) ? i : j] = 1;
                });
            });

            arrays.Add(new List<int>(win)); // Agregar el estado de 'win[]' después de las comparaciones

            // Paso 3: Buscar el índice del valor mínimo
            int IndexMin = -1;
            Parallel.For(0, n, i =>
            {
                if (win[i] == 0)
                {
                    IndexMin = i; // El primer índice que quede con 0 en win[] es el valor mínimo
                }
            });

            return (arrays, $"Objetivo={L[IndexMin]} en Índice={IndexMin}");
        }

        /// <summary>
        /// Algoritmo 5) ordenamientoCRCW PROBADO Y LISTO
        /// </summary>
        /// <param arreglo="Array"></param>
        /// <returns></returns>
        public static (List<List<int>>, String) OrdenamientoCRCW(List<int> L)
        {
            List<List<int>> arrays = new List<List<int>> { new List<int>(L) };
            int n = L.Count;
            List<int> win = new List<int>(new int[n]);

            Parallel.For(0, n, i => win[i] = 0); // Paso 1: Inicializar todos los valores de win[i] en 0 en paralelo

            Parallel.For(0, n, i => // Paso 2: Comparar cada par (i, j) en paralelo y ajustar el conteo de win
            {
                Parallel.For(i + 1, n, j =>
                {
                    win[(L[i] > L[j]) ? i : j]++;
                });
            });
            arrays.Add(new List<int>(win)); // Agregar el estado de 'win[]' después de las comparaciones

            List<int> sortedArray = new List<int>(new int[n]); // Paso 3: Colocar los elementos en la posición correcta de acuerdo a 'win[i]'
            Parallel.For(0, n, i =>
            {
                sortedArray[win[i]] = L[i];
            });

            arrays.Add(new List<int>(sortedArray)); // Agregar el array ordenado al historial de pasos

            return (arrays, $"Objetivo={string.Join(", ", sortedArray)} en Índice=NA");
        }

        /// <summary>
        /// Algoritmo 6) ordenamientoEREW (Odd-Even Short) PROBADO Y LISTO
        /// </summary>
        /// <param name="L">Arreglo.</param>
        /// <param name="n">Tamaño del arreglo.</param>
        /// <returns></returns>
        public static (List<List<int>>, String) OrdenamientoEREW(List<int> L, int n)
        {
            List<List<int>> arrays = new List<List<int>> { new List<int>(L) };
            if (n >= 2)
            {
                int mid = n / 2;
                var retorno1 = (new List<List<int>>(), "");
                var retorno2 = (new List<List<int>>(), "");
                // Llamadas paralelas para ordenar las dos mitades
                Parallel.Invoke(
                    () => retorno1 = OrdenamientoEREW(L.GetRange(0, mid), mid), // Mitad izquierda
                    () => retorno2 = OrdenamientoEREW(L.GetRange(mid, n - mid), n - mid) // Mitad derecha
                );
                arrays.Add(new List<int> { 57339, 1 });
                foreach (var lista in retorno1.Item1)
                {
                    arrays.Add(new List<int>(lista));

                }
                arrays.Add(new List<int> { 57339, 2 });
                foreach (var lista in retorno2.Item1)
                {
                    arrays.Add(new List<int>(lista));

                }

                // Llamada a oddEvenMergePRAM para fusionar las dos mitades
                OddEvenMergePRAM(L, n);
            }
            arrays.Add(new List<int>(L));
            return (arrays, $"Objetivo={string.Join(", ", L)} en Índice=NA");
        }

        // Procedimiento oddEvenMergePRAM
        private static void OddEvenMergePRAM(List<int> L, int n)
        {
            if (n == 2)
            {
                // Si hay dos elementos, intercambiamos si no están en orden
                if (L[0] > L[1])
                {
                    (L[0], L[1]) = (L[1], L[0]); // ESTE ES: call interchange. ('DesEstructurado de tuplas' ó 'tupla de intercambio')
                }
            }
            else
            {
                int mid = n / 2;
                List<int> odd = new List<int>();
                List<int> even = new List<int>();

                // Llamar a oddEvenSplit para dividir la lista en pares e impares
                OddEvenSplit(L, odd, even, mid);

                // Llamadas paralelas para fusionar las dos mitades (pares e impares)
                Parallel.Invoke(
                    () => OddEvenMergePRAM(odd, mid),
                    () => OddEvenMergePRAM(even, mid)
                );

                // Fusionar las listas resultantes de los pares e impares
                Parallel.For(0, mid, i =>
                {
                    L[2 * i] = odd[i];
                    L[2 * i + 1] = even[i];
                });

                // Ajustar los elementos que están fuera de orden
                Parallel.For(0, mid - 1, i =>
                {
                    if (L[2 * i + 1] > L[2 * i + 2])
                    {
                        (L[2 * i + 1], L[2 * i + 2]) = (L[2 * i + 2], L[2 * i + 1]); // UTILIZANDO: call interchange
                    }
                });
            }
        }

        // Procedimiento oddEvenSplit: Divide la lista L en pares e impares
        private static void OddEvenSplit(List<int> L, List<int> odd, List<int> even, int mid)
        {
            Parallel.For(0, mid, i =>
            {
                odd.Add(L[2 * i]);
                even.Add(L[2 * i + 1]);
            });
        }

        /// <summary>
        /// Algoritmo 7) multiplicaciónMatricesCREW PROBADO Y LISTO
        /// </summary>
        /// <param matriz="A"></param>
        /// <param matriz="B"></param>
        /// <param tamaño="n"></param>
        /// <returns></returns>
        public static int[,] MatMultCREW(int[,] A, int[,] B, int n)
        {
            int[,,] C = new int[n, n, n];
            // Paso 1: Multiplicaciones paralelas
            Parallel.For(0, n, i =>
            {
                Parallel.For(0, n, j =>
                {
                    Parallel.For(0, n, k =>
                    {
                        C[i, j, k] = A[i, k] * B[k, j]; // Calcular producto A[i,k] * B[k,j] y almacenarlo en C[i, j, k]
                    });
                });
            });

            // Paso 2: Sumas logarítmicas en paralelo
            for (int L = 1; L <= (int)Math.Log(n, 2); L++) // Iteramos log(n,2) veces
            {
                int powL = GetPow(L);
                int powLMinus1 = GetPow(L - 1);

                Parallel.For(0, n, i =>
                {
                    Parallel.For(0, n, j =>
                    {
                        Parallel.For(0, n / 2, k =>
                        {
                            int twoK = 2 * (k + 1); // Ajuste para que los índices de C sean correctos
                            if (twoK % powL == 0 && twoK - powLMinus1 >= 0)
                            {
                                C[i, j, twoK - 1] += C[i, j, twoK - powLMinus1 - 1];
                            }
                        });
                    });
                });
            }

            int[,] result = new int[n, n]; // Matriz final
            Parallel.For(0, n, i =>
            {
                Parallel.For(0, n, j =>
                {
                    result[i, j] = C[i, j, n - 1]; // Tomar el valor final acumulado
                });
            });

            return result;
        }

        /// <summary>
        /// Este metodo es el hermano primitivo de PrintArray.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="title"></param>
        protected static void PrintList(List<int> L, string title)
        {
            Console.WriteLine(title);
            foreach (int val in L)
            {
                Console.Write(val + " ");
            }
            Console.WriteLine();
        }

        protected static void PrintArray(List<int> arr, string operation) => Console.WriteLine($"{operation}: {string.Join(", ", arr)}");

        public static void PrintMatrix(int[,] matrix, string title)
        {
            Console.WriteLine(title);
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private static int GetPow(int Potencia) => 1 << Potencia;

        public static (List<int>, int) ReStructure(int ArraySize, List<int> Source, Boolean ReFin)
        {
            int nextPowerOf2 = GetPow((int)Math.Ceiling(Math.Log(ArraySize, 2))); // (int)Math.Pow(2, Math.Ceiling(Math.Log(ArraySize, 2)));
            if (ArraySize != nextPowerOf2) // Si el tamaño actual no es una potencia de 2, aumenta el tamaño
            {
                for (int i = ArraySize; i < nextPowerOf2; i++) // Agrega ceros al inicio para llenar hasta la siguiente potencia de 2
                {
                    //Source.ReFin ? Add(0) : Insert(0, 0);
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
            Console.WriteLine("ReEstructuro... Exitosamente");
            return (Source, nextPowerOf2);
        }

        /// <summary>
        /// Genera un número entero aleatorio dentro de un rango específico.
        /// </summary>
        /// <param name="min">Límite inferior del rango (incluido).</param>
        /// <param name="max">Límite superior del rango (excluido).</param>
        /// <returns>Número entero aleatorio en el rango especificado.</returns>
        public static int GetRand(int min, int max)
        {
            if (min >= max)
            {
                throw new ArgumentOutOfRangeException("El valor mínimo debe ser menor que el valor máximo.");
            }

            return random.Next(min, max);
        }
    }
}
