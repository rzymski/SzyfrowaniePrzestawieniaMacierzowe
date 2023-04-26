using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrzestawieniaMacierzowe
{
    internal class Program
    {
        public static string encryptA(string text, string key)
        {
            //usuniecie spacji z wiadomosci
            //text = text.Replace(" ", "");
            //ustalenie porządku klucza
            string[] keys = key.Split("-");
            int[] orderKey = new int[keys.Length];
            for (int i = 0; i < keys.Length; i++)
                orderKey[i] = Int32.Parse(keys[i]);
            //wypisanie klucza
            //Console.WriteLine("Order:");
            //for (int i = 0; i < orderKey.Length; i++)
            //    Console.Write($"{orderKey[i],3}");
            //zadklerowanie tablic
            int matrixRows = text.Length / orderKey.Length + 1;
            char[][] matrix = new char[matrixRows][];
            for (int i = 0; i < matrixRows; i++)
                matrix[i] = new char[orderKey.Length];
            //uzupełnienie macierzy
            int indx = 0;
            for (int i = 0; i < matrixRows; i++)
                for (int j = 0; j < orderKey.Length; j++)
                    if (indx < text.Length)
                        matrix[i][j] = text[indx++];
                    else
                        matrix[i][j] = '\0';
            //wypisanie tablic
            //Console.WriteLine();
            //for (int i = 0; i < matrixRows; i++)
            //{
            //    for (int j = 0; j < orderKey.Length; j++)
            //        Console.Write($"{matrix[i][j],3}");
            //    Console.WriteLine();
            //}
            //odczytanie wyniku z macierzy
            string result = "";
            for (int i = 0; i < matrixRows; i++)
                for (int j = 0; j < orderKey.Length; j++)
                    if (matrix[i][orderKey[j] - 1] != '\0')
                        result += matrix[i][orderKey[j] - 1];
            return result;
        }

        public static string decryptA(string text, string key)
        {
            //ustalenie porządku klucza
            string[] keys = key.Split("-");
            int[] orderKey = new int[keys.Length];
            for (int i = 0; i < keys.Length; i++)
                orderKey[i] = Int32.Parse(keys[i]);
            //wypisanie klucza
            //Console.WriteLine("Order:");
            //for (int i = 0; i < orderKey.Length; i++)
            //    Console.Write($"{orderKey[i],3}");
            //zadklerowanie tablic
            int matrixRows = text.Length / orderKey.Length + 1;
            int matrixColumns = orderKey.Length;
            char[][] matrix = new char[matrixRows][];
            for (int i = 0; i < matrixRows; i++)
                matrix[i] = new char[matrixColumns];
            //wypełnienie tablic \0
            for (int i = 0; i < matrixRows; i++)
                for (int j = 0; j < matrixColumns; j++)
                    matrix[i][j] = '\0';
            //uzupełnienie macierzy
            int indx = 0;
            int blank = orderKey.Length - (text.Length % orderKey.Length);
            for (int i = 0; i < matrixRows; i++)
            {
                for (int j = 0; j < matrixColumns; j++)
                {
                    if (indx >= text.Length)
                        break;
                    if (i < matrixRows - 1)
                        matrix[i][orderKey[j] - 1] = text[indx++];
                    else
                    {
                        while (orderKey[j] - 1 >= orderKey.Length - blank)
                        {
                            j++;
                        }
                        matrix[i][orderKey[j] - 1] = text[indx++];
                    }
                }
            }
            //wypisanie macierzy
            //Console.WriteLine("Macierz:");
            //for (int i = 0; i < matrixRows; i++)
            //{
            //    for (int j = 0; j < matrixColumns; j++)
            //        if (matrix[i][j] != '\0')
            //            Console.Write($"{matrix[i][j],3}");
            //    Console.WriteLine();
            //}
            //odczytanie wyniku z macierzy
            string result = "";
            for (int i = 0; i < matrixRows; i++)
                for (int j = 0; j < matrixColumns; j++)
                    if (matrix[i][j] != '\0')
                        result += matrix[i][j];
            return result;
        }

        public static string encryptB(string text, string key)
        {
            //usuniecie spacji z wiadomosci
            //text = text.Replace(" ", "");
            //ustalenie porządku klucza
            int[] orderKey = new int[key.Length];
            int indx = 1;
            for (int i = 65; i <= 122; i++)
            {
                for (int j = 0; j < key.Length; j++)
                {
                    if (key[j] == (char)i)
                        orderKey[j] = indx++;
                }
            }
            //wypisanie klucza
            //Console.WriteLine("Order:");
            //for(int i=0; i<orderKey.Length; i++)
            //    Console.Write($"{orderKey[i],3}");
            //zadklerowanie tablic
            int matrixRows = text.Length / orderKey.Length + 1;
            char[][] matrix = new char[matrixRows][];
            for (int i = 0; i < matrixRows; i++)
                matrix[i] = new char[orderKey.Length];
            //uzupełnienie macierzy
            indx = 0;
            for (int i = 0; i < matrixRows; i++)
                for (int j = 0; j < orderKey.Length; j++)
                    if (indx < text.Length)
                        matrix[i][j] = text[indx++];
                    else
                        matrix[i][j] = '\0';
            //wypisanie tablic
            //Console.WriteLine();
            //for (int i = 0; i < matrixRows; i++)
            //{
            //    for (int j = 0; j < orderKey.Length; j++)
            //        Console.Write($"{matrix[i][j],3}");
            //    Console.WriteLine();
            //}
            //odczytanie wyniku z macierzy
            string result = "";
            for (int i = 1; i <= orderKey.Length; i++)
            {
                int column = Array.IndexOf(orderKey, i); //orderKey[i];
                for (int j = 0; j < matrixRows; j++)
                {
                    //if (matrix[j][column] != '\0')
                    //    result += matrix[j][column];
                    //else
                    //    result += "_";
                    result += matrix[j][column];
                }
            }
            return result;
        }

        public static string decryptB(string text, string key)
        {
            int width = key.Length;
            int height = text.Length / key.Length;
            //ustalenie porządku klucza
            int[] orderKey = new int[width];
            int indx = 1;
            for (int i = 65; i <= 122; i++)
                for (int j = 0; j < width; j++)
                    if (key[j] == (char)i)
                        orderKey[j] = indx++;
            //wypisanie klucza
            //Console.WriteLine("Order:");
            //for (int i = 0; i < orderKey.Length; i++)
            //    Console.Write($"{orderKey[i],3}");
            //stworzenie macierzy
            char[][] matrix = new char[height][];
            for (int i = 0; i < height; i++)
                matrix[i] = new char[width];
            //uzupełnienie macierzy
            //Console.WriteLine();
            for (int i = 0, m = 0; i < width; i++)
            {
                int k = Array.IndexOf(orderKey, i + 1);
                for (int j = 0; j < height && m < text.Length; j++)
                {
                    //Console.WriteLine("I: " + i + "  J: " + j + "   Text: " + text[m]);
                    matrix[j][k] = text[m++];
                }
            }
            //wypisanie macierzy
            //Console.WriteLine();
            //for (int i = 0; i < height; i++)
            //{
            //    for (int j = 0; j < width; j++)
            //        Console.Write($"{matrix[i][j],3}");
            //    Console.WriteLine();
            //}
            //zapisanie wyniku
            string result = "";
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                    result += matrix[i][j];
            return result;
        }

        static void Main(string[] args)
        {
            //przykłady 2a
            Console.WriteLine("\nPrzykłady A");
            Console.WriteLine(encryptA("CRYPTOGRAPHYOSA", "3-1-4-2"));
            Console.WriteLine(decryptA(encryptA("CRYPTOGRAPHYOSA", "3-1-4-2"), "3-1-4-2"));

            Console.WriteLine("\n" + encryptA("FRANCJA", "3-4-1-5-2"));
            Console.WriteLine(decryptA(encryptA("FRANCJA", "3-4-1-5-2"), "3-4-1-5-2"));

            Console.WriteLine("\n" + encryptA("DOBRYDZIEN", "3-4-1-5-2"));
            Console.WriteLine(decryptA(encryptA("DOBRYDZIEN", "3-4-1-5-2"), "3-4-1-5-2"));

            Console.WriteLine("\n" + encryptA("POLITECHNIKA", "3-4-1-5-2"));
            Console.WriteLine(decryptA(encryptA("POLITECHNIKA", "3-4-1-5-2"), "3-4-1-5-2"));

            Console.WriteLine("\n" + encryptA("UNIVERSITY", "3-4-1-5-2"));
            Console.WriteLine(decryptA(encryptA("UNIVERSITY", "3 -4-1-5-2"), "3-4-1-5-2"));

            //przykłady 2b
            Console.WriteLine("\n\nPrzykłady B");
            Console.WriteLine(encryptB("HERE IS A SECRET MESSAGE ENCIPHERED BY TRANSPOSITION", "CONVENIENCE"));
            Console.WriteLine(decryptB(encryptB("HERE IS A SECRET MESSAGE ENCIPHERED BY TRANSPOSITION", "CONVENIENCE"), "CONVENIENCE"));

            Console.WriteLine("\n" + encryptB("FRANCJA", "CDAEB"));
            Console.WriteLine(decryptB(encryptB("FRANCJA", "CDAEB"), "CDAEB"));

            Console.WriteLine("\n" + encryptB("DOBRYDZIEN", "CDAEB"));
            Console.WriteLine(decryptB(encryptB("DOBRYDZIEN", "CDAEB"), "CDAEB"));

            Console.WriteLine("\n" + encryptB("POLITECHNIKA", "CDAEB"));
            Console.WriteLine(decryptB(encryptB("POLITECHNIKA", "CDAEB"), "CDAEB"));

            Console.WriteLine("\n" + encryptB("UNIVERSITY", "CDAEB"));
            Console.WriteLine(decryptB(encryptB("UNIVERSITY", "CDAEB"), "CDAEB"));
        }
    }
}
