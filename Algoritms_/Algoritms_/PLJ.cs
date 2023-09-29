using System.Data;

namespace Algoritms_
{
    public class PLJ
    {
        public bool Satisfy(int cardinality, List<(List<int>, List<int>)> dependencies)
        {
            bool[,] arr = new bool[dependencies.Count, cardinality];

            InitializeArr(arr, dependencies);

            for (int i = 0; i < cardinality; i++)
            {
                for (int j = 0; j < dependencies.Count; j++)
                {
                    if (arr[i, j])
                    {
                        Update(dependencies, arr, (i, j));
                    }
                }
            }

            return false;
        }


        private void InitializeArr(bool[,] arr, List<(List<int>, List<int>)> dependencies)
        {
            foreach (var dependence in dependencies)
            {
                foreach (var item in dependence.Item1)
                {
                    arr[dependencies.IndexOf(dependence), item] = true;
                }

                foreach (var item in dependence.Item2)
                {
                    arr[dependencies.IndexOf(dependence), item] = true;
                }
            }
        }

        private void Update(List<(List<int>, List<int>)> dependencies, bool[,] arr, (int, int) coordenate)
        {
            List<int> checks = new List<int>();
            for (int i = 0; i < coordenate.Item2; i++)
            {
                if (arr[coordenate.Item1, i]) checks.Add(i);
            }

            foreach (var item in dependencies)
            {
                if (SubSet(item.Item1, checks)) Update(item.Item2, coordenate.Item1, arr); 
            }
        }

        private void Update(List<int> list, int row, bool[,] arr)
        {
            foreach (var item in list)
            {
                arr[row, item] = true;
            }
        }

        private bool SubSet(List<int> list1, List<int> list2)
        {
            foreach (var item in list1)
            {
                if (!list2.Contains(item)) return false;
            }
            return true;
        }
    }
}