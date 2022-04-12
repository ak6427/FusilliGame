using UnityEngine;
using UnityEngine.SceneManagement;

namespace db
{
    public class DuplicateCheck : MonoBehaviour
    {
        public int[] intFoodArray;
        public int[] intFoodArrayHealth;
        public int[] intFoodArrayClimate;
        private string activeScene;

        void Awake()
        {
            activeScene = SceneManager.GetActiveScene().name;
            if (activeScene == "Easy")
            {
                intFoodArray = new int[6];
            }
            else if (activeScene == "Medium")
            {
                intFoodArray = new int[28];
            }
            else if (activeScene == "Hard")
            {
                intFoodArrayHealth = new int[28];
                intFoodArrayClimate = new int[28];
            }
        }
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}