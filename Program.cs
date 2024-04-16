using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls7
{
    interface IDbConnection
    {
        string ConnectionString { get; set; }
        bool Connect();
        bool Disconnect();
    }
    class SQLConnection: IDbConnection
    {
        private string _connectionString;
        public string ConnectionString { get => _connectionString; set => _connectionString = value; }
        public bool Connect()
        {
            if(string.IsNullOrEmpty(_connectionString)) return false;
            Console.WriteLine("Connected!");
            return true;
            
        }
        public bool Disconnect()
        {
            if (string.IsNullOrEmpty(_connectionString)) return false;
            Console.WriteLine("Disconnected!");
            _connectionString = null;
            return true;
        }
        

    }
    interface IOutput
    {
        void Show();
        void Show(string info);
    }
    interface IMath
    {
        int Max();
        int Min();
        float Avg();
        bool Search(int valueToSearch);
    }
    interface ISort
    {
        void SortAsc();
        void SortDesc();
        void SortByParam(bool isAsc);
    }
    class Array : IOutput, IMath, ISort
    {
        public int[] arr;
        public void Show()
        {
           Console.WriteLine("Your array: ");
           for(int i = 0; i < arr.Length; i++)
           {
               Console.Write(arr[i] + " ");
           } 
           Console.WriteLine(); 
        }
        public void Show(string info)
        {
            Console.WriteLine("Your array: ");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Info:");
            Console.WriteLine(info);
        }
        public int Min()
        {
            int temp = int.MaxValue;
            for(int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < temp)
                {
                    temp = arr[i];
                }
            }
            return temp;
        }
        public int Max()
        {
            int temp = int.MinValue;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > temp)
                {
                    temp = arr[i];
                }
            }
            return temp;
        }
        public float Avg()
        {
            float temp = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                temp += arr[i];
            }
            return (temp / arr.Length);
        }
        public bool Search(int valueToSearch)
        {
            for(int i = 0; i < arr.Length;i++)
            {
                if (arr[i] == valueToSearch)
                {
                    return true;
                }
            }
            return false;
        }
        public void SortAsc()
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

        public void SortDesc()
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (arr[j] < arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }
        public void SortByParam(bool isAsc)
        {
            if(isAsc)
            {
                SortAsc();
            }else
            {
                SortDesc();
            }
        }
    }

    
    internal class Program
    {
        static void Main(string[] args)
        {
            //Інтерфейси
            //IDbConnection[] providers = new IDbConnection[]
            //{
            //    new SQLConnection() {ConnectionString = "SQL1"},
            //    new SQLConnection() {ConnectionString = "SQL2"}
            //};

            //foreach (var provider in providers)
            //{
            //    if (provider.Connect())
            //    {
            //        provider.Disconnect();
            //    }
            //}
            Console.WriteLine("PRAC_1");
            Array array1 = new Array();
            array1.arr = new int[] { 1, 2, 3, 4, 5 };     
            array1.Show();
            array1.Show("Additional information");
           
            Array array2 = new Array();
            array2.arr = new int[] { 10, 20, 30 };     
            array2.Show();
            array2.Show("Additional information");

            Console.WriteLine("PRAC_2");

            Array array = new Array();
            array.arr = new int[] { 10, 20, 30, 40, 50 };

            array.Show();

            Console.WriteLine("Min value: " + array.Min());

            Console.WriteLine("Max value: " + array.Max());

            Console.WriteLine("Average value: " + array.Avg());

            int valueToSearch = 30;
            if (array.Search(valueToSearch))
            {
                Console.WriteLine("Value " + valueToSearch + " found in the array.");
            }
            else
            {
                Console.WriteLine("Value " + valueToSearch + " not found in the array.");
            }


            Console.WriteLine("PRAC_3");
            Array array3 = new Array();
            array3.arr = new int[] { 5, 2, 8, 1, 3 };

            array3.Show();

            array3.SortByParam(true);
            array3.Show();

            array3.SortByParam(false);
            array3.Show();

            Console.ReadKey();
        }
    }
}
