using UnityEngine;

namespace db
{
    public class FoodsNeededEz : MonoBehaviour
    {
        public int[,] needToBeFetched = new int[6, 2] 
        { 
            {1, 0}, {1, 0}, {1, 0}, {2, 0}, {2, 0}, {3, 0} 
        }; // {health rank, fetched(false = 0 / true = 1)}
    }
}
