namespace Algoritms_
{
    public class PLJ
    {
        public bool Satisfy(int cardinality, List<(List<int>, List<int>)> dependencies)
        {
            bool[,] arr = new bool[dependencies.Count, cardinality];

            InitializeArr(arr, dependencies);

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
    }
}