using UnityEngine;

namespace db
{
    public class FoodsNeededMed : MonoBehaviour
    {
        public int[,] needToBeFetched = new int[28, 2] 
        { 
            {1, 0}, {1, 0}, {1, 0}, {1, 0}, {1, 0}, {1, 0}, {1, 0},
            {2, 0}, {2, 0}, {2, 0}, {2, 0}, {2, 0}, {2, 0},
            {3, 0}, {3, 0}, {3, 0}, {3, 0}, {3, 0},
            {4, 0}, {4, 0}, {4, 0}, {4, 0},
            {5, 0}, {5, 0}, {5, 0},
            {6, 0}, {6, 0},
            {7, 0} 
        }; // {health rank, fetched(false = 0 / true = 1)}
    }
}
