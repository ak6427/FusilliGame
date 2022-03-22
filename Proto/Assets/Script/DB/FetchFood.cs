using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace db
{
    public class FetchFood : MonoBehaviour
    {
        private string foodTable = "foods";
        private ArrayList foodsArrayList;
        private int[] foodsArrayID;
        private int rndSeed;
        public int foodID;
        public string foodName;
        public DBAccess db;
        public FoodsNeededEz foodsNeededEz;
        //public FoodsNeededMed foodsNeededMed;
        //public FoodsNeededHard foodsNeededHard;
        private string compareString;

        void Awake()
        {
            db = FindObjectOfType<DBAccess>();
            db = db.GetComponent<DBAccess>();
            rndSeed = System.DateTime.Now.Millisecond;
            Random.InitState(rndSeed);
            foodsNeededEz = FindObjectOfType<FoodsNeededEz>();
        }

        // Start is called before the first frame update
        void Start()
        {
            // ID QUERY
            db.OpenDB(Application.dataPath + "/DB/" + "food.db");

            // Set compareString
            compareString = FillNeededEz();

            // Set array list
            foodsArrayList = db.SingleSelectWhereID(foodTable, "id", "health", "=", compareString);

            // Fill array
            FillArray();

            //Randomize the food
            RandomizeFood();

            // Set food name
            WhereQueryString();
        }

        private string FillNeededEz()
        {
            int i;
            while(true)
            {
                i = Random.Range(0, foodsNeededEz.needToBeFetched.GetLength(0));
                if (foodsNeededEz.needToBeFetched[i, 1] == 0)
                {
                    foodsNeededEz.needToBeFetched[i, 1] = 1;
                    return (string)foodsNeededEz.needToBeFetched[i, 0].ToString();
                }
            }
        }

        private void FillArray()
        {
            foodsArrayID = new int[foodsArrayList.Count];
            for(int i = 0; i < foodsArrayList.Count; i++)
            {
                foodsArrayID[i] = (int)foodsArrayList[i];
            }
        }

        private void RandomizeFood()
        {
            foodID = Random.Range(0, foodsArrayID.Length);
            foodID = foodsArrayID[foodID];
        }

        private void WhereQueryString()
        {
            // WHERE query compare ID
            compareString = foodID.ToString();

            // STRING QUERY
            foodsArrayList = db.SingleSelectWhereString(foodTable, "nimi", "id", "=", compareString);

            // Set food name
            foodName = (string)foodsArrayList[0].ToString();
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}
