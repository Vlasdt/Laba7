using System;
using System.Collections.Generic;
using System.IO;


namespace Laba7
{
    public class TArray<T> where T : IComparable<T>
    {
        public T[] Array { get; private set; }
        public int Length { get; private set; }

        public T this[int i]
        {
            get { return Array[i]; }
            set { Array[i] = value; }
        }

        public TArray(T[] array)
        {
            Array = array;
            Length = array.Length;
        }

        public virtual void Add(T item)
        {
            T[] tmp = new T[Length + 1];
            for (int i = 0; i < Length; i++)
            {
                tmp[i] = Array[i];
            }
            tmp[tmp.Length - 1] = item;
            Array = tmp;
            Length = tmp.Length;
        }

        public override string ToString()
        {
            return string.Join(" ", Array) + " type: " + Array.GetType();
        }

        public int Compare(T x, T y)
        {
            return x.CompareTo(y);
        }
    }

    public class TSortedArray<T> : TArray<T> where T : IComparable<T>
    {
        public TSortedArray(T[] array) : base(array)
        {
            SortArray();
        }

        public override void Add(T item)
        {
            base.Add(item);
            SortArray();
        }

        private void SortArray()
        {
            for (int i = 0; i < Length - 1; i++)
            {
                for (int j = 0; j < Length - i - 1; j++)
                {
                    if (Compare(Array[j], Array[j + 1]) > 0)
                    {
                        T temp = Array[j];
                        Array[j] = Array[j + 1];
                        Array[j + 1] = temp;
                    }
                }
            }
        }


    }

    public class TArrayContainer
    {
        public List<object> Arrays = new List<object>();

        public void AddSorted(int[] array)
        {
            Arrays.Add(new TSortedArray<int>(array));
        }

        public void AddUnSorted(int[] array)
        {
            Arrays.Add(new TArray<int>(array));
        }

        public void AddSorted(float[] array)
        {
            Arrays.Add(new TSortedArray<float>(array));
        }

        public void AddUnSorted(float[] array)
        {
            Arrays.Add(new TArray<float>(array));
        }

        public void DeleteArray(int i)
        {
            object t = Arrays[i];
            Arrays.Remove(t);
        }

        public TArrayContainer(string fileName)
        {
            string[] line;
            using (StreamReader sr = new StreamReader(fileName))
            {
                while ((line = sr.ReadLine()?.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)) != null)
                {
                    bool isIntArray = true;

                    for (int i = 1; i < line.Length; i++)
                    {
                        if (line[i].Contains(","))
                        {
                            isIntArray = false;
                            break;
                        }
                    }

                    if (isIntArray)
                    {
                        int[] intArray = new int[line.Length - 1];
                        for (int i = 1; i < line.Length; i++)
                        {
                            intArray[i - 1] = int.Parse(line[i]);
                        }

                        if (line[0] == "sorted")
                        {
                            AddSorted(intArray);
                        }
                        else
                        {
                            AddUnSorted(intArray);
                        }
                    }
                    else
                    {
                        float[] floatArray = new float[line.Length - 1];
                        for (int i = 1; i < line.Length; i++)
                        {
                            floatArray[i - 1] = float.Parse(line[i]);
                        }
                        if (line[0] == "sorted")
                        {
                            AddSorted(floatArray);
                        }
                        else
                        {
                            AddUnSorted(floatArray);
                        }
                    }
                }
            }
        }


        public override string ToString()
        {
            string result = "";
            foreach (var array in Arrays)
            {
                result += array.ToString() + "\n";
            }
            return result;
        }
        public delegate bool CompareTarray(object a, object b);
        public void DeleteRep(CompareTarray compare)
        {
            for (int i = 0; i < Arrays.Count - 1; i++)
            {
                for (int j = Arrays.Count - 1; j > i; j--)
                {
                    if (compare(Arrays[i], Arrays[j]))
                    {
                        DeleteArray(j);
                    }
                }
            }

        }
    }

}
