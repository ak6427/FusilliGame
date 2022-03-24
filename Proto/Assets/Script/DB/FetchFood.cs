using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace db
{
    [RequireComponent(typeof(Image))]
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
        public FoodsNeededMed foodsNeededMed;
        //public FoodsNeededHard foodsNeededHard;
        public DragDrop dragDrop;
        public DuplicateCheck duplicateCheck;
        private int duplicateCheckTarget;
        private string compareString;
        private string imagePath;
        public Image image;
        private string activeScene;

        void Awake()
        {
            db = FindObjectOfType<DBAccess>();
            db = db.GetComponent<DBAccess>();
            rndSeed = System.DateTime.Now.Millisecond;
            Random.InitState(rndSeed);
            dragDrop = GetComponent<DragDrop>();
            image = GetComponent<Image>();
            duplicateCheck = FindObjectOfType<DuplicateCheck>();
            duplicateCheck = duplicateCheck.GetComponent<DuplicateCheck>();
            activeScene = SceneManager.GetActiveScene().name;
            if (activeScene == "Easy") 
            {
                foodsNeededEz = FindObjectOfType<FoodsNeededEz>();
            }
            else if (activeScene == "Medium")
            {
                foodsNeededMed = FindObjectOfType<FoodsNeededMed>();
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            // ID QUERY
            db.OpenDB(Application.dataPath + "/DB/" + "food.db");

            // Set compareString
            if (activeScene == "Easy") 
            {
                compareString = FillNeededEz();
            }
            else if (activeScene == "Medium") 
            {
                compareString = FillNeededMed();
            }

            dragDrop.rankFood = int.Parse(compareString);

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
                }
                return (string)foodsNeededEz.needToBeFetched[i, 0].ToString();
            }
        }

        private string FillNeededMed()
        {
            int i;
            while(true)
            {
                i = Random.Range(0, foodsNeededMed.needToBeFetched.GetLength(0));
                if (foodsNeededMed.needToBeFetched[i, 1] == 0)
                {
                    foodsNeededMed.needToBeFetched[i, 1] = 1;
                }
                return (string)foodsNeededMed.needToBeFetched[i, 0].ToString();
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
            while(true)
            {
                foodID = Random.Range(0, foodsArrayID.GetLength(0));
                foodID = foodsArrayID[foodID];
                for(int i = 0; i < duplicateCheck.intFoodArray.Length; i++)
                {
                    if (duplicateCheck.intFoodArray[i] == 0)
                    {
                        duplicateCheck.intFoodArray[i] = foodID;
                        return;
                    }
                    else if(duplicateCheck.intFoodArray[i] == foodID)
                    {
                        break;
                    }
                }
            }
        }

        private void WhereQueryString()
        {
            // WHERE query compare ID
            compareString = foodID.ToString();

            // STRING QUERY
            foodsArrayList = db.SingleSelectWhereString(foodTable, "nimi", "id", "=", compareString);

            // Set food name
            foodName = (string)foodsArrayList[0].ToString();
            Sprite sp = Resources.Load<Sprite>("Images/"+foodName);
            image.sprite = sp;
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}
