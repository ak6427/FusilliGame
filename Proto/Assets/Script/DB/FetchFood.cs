using System.Collections;
using System.IO;
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
        public PathWrite pathWrite;
        public FoodsNeededEz foodsNeededEz;
        public FoodsNeededMed foodsNeededMed;
        public FoodsNeededHard foodsNeededHard;
        public DragDrop dragDrop;
        public DuplicateCheck duplicateCheck;
        public SpriteRenderer spriteRenderer;
        private int duplicateCheckTarget;
        private string compareString;
        private string imagePath;
        public Image image;
        private string activeScene;
        public string hardColumn;

        void Awake()
        {
            db = FindObjectOfType<DBAccess>();
            pathWrite = db.GetComponent<PathWrite>();
            db = db.GetComponent<DBAccess>();
            rndSeed = System.DateTime.Now.Millisecond;
            Random.InitState(rndSeed);
            dragDrop = GetComponent<DragDrop>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            image = GetComponent<Image>();
            duplicateCheck = FindObjectOfType<DuplicateCheck>();
            duplicateCheck = duplicateCheck.GetComponent<DuplicateCheck>();
            activeScene = SceneManager.GetActiveScene().name;
            hardColumn = "health";
            if (activeScene == "Easy") 
            {
                foodsNeededEz = FindObjectOfType<FoodsNeededEz>();
            }
            else if (activeScene == "Medium")
            {
                foodsNeededMed = FindObjectOfType<FoodsNeededMed>();
            }
            else if (activeScene == "Hard")
            {
                foodsNeededHard = FindObjectOfType<FoodsNeededHard>();
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            // Open DB connection
            if (Application.platform == RuntimePlatform.Android)
            {
                db.OpenDB(pathWrite.runtimeDBPath);
            }
            else {
                db.OpenDB(Application.dataPath + "/StreamingAssets/food.db");
            }

            // Set compareString
            if (activeScene == "Easy") 
            {
                compareString = FillNeededEz();

                dragDrop.rankFood = int.Parse(compareString);

                // Set array list
                switch(compareString)
                {
                    case "1":
                        compareString = "3";
                        foodsArrayList = db.SingleSelectWhereID(foodTable, "id", "health", "<", compareString);
                        break;
                    case "2":
                        compareString = "2 AND health < 6";
                        foodsArrayList = db.SingleSelectWhereID(foodTable, "id", "health", ">", compareString);
                        break;
                    case "3":
                        compareString = "5";
                        foodsArrayList = db.SingleSelectWhereID(foodTable, "id", "health", ">", compareString);
                        break;
                }
            }
            else if (activeScene == "Medium") 
            {
                compareString = FillNeededMed();

                // Set array list
                foodsArrayList = db.SingleSelectWhereID(foodTable, "id", "health", "=", compareString);

                dragDrop.rankFood = int.Parse(compareString);
            }
            else if (activeScene == "Hard") 
            {
                compareString = FillNeededHard();

                // Set array list
                foodsArrayList = db.SingleSelectWhereID(foodTable, "id", dragDrop.targetPyramid.ToLower(), "=", compareString);

                dragDrop.rankFood = int.Parse(compareString);
            }

            // Fill array
            FillArray();

            //Randomize the food
            RandomizeFood();

            // Set food name
            WhereQueryString();

            db.CloseDB();
        }

        private string FillNeededEz()
        {
            int i;
            int arrayLenght = foodsNeededEz.needToBeFetched.GetLength(0);
            while(true)
            {
                i = Random.Range(0, arrayLenght);
                if (foodsNeededEz.needToBeFetched[i, 1] == 0)
                {
                    foodsNeededEz.needToBeFetched[i, 1] = 1;
                    return (string)foodsNeededEz.needToBeFetched[i, 0].ToString();
                }
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
                    return (string)foodsNeededMed.needToBeFetched[i, 0].ToString();
                }
            }
        }

        private string FillNeededHard()
        {
            int i;
            while(true)
            {
                if (dragDrop.targetPyramid == "Health")
                {
                    i = Random.Range(0, foodsNeededHard.needToBeFetched.GetLength(0));
                    if (foodsNeededHard.needToBeFetched[i, 1] == 0)
                    {
                        foodsNeededHard.needToBeFetched[i, 1] = 1;
                        return (string)foodsNeededHard.needToBeFetched[i, 0].ToString();
                    }
                }
                else if (dragDrop.targetPyramid == "Climate")
                {
                    i = Random.Range(0, foodsNeededHard.needToBeFetchedClimate.GetLength(0));
                    if (foodsNeededHard.needToBeFetchedClimate[i, 1] == 0)
                    {
                        foodsNeededHard.needToBeFetchedClimate[i, 1] = 1;
                        return (string)foodsNeededHard.needToBeFetchedClimate[i, 0].ToString();
                    }
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
            while(true)
            {
                foodID = Random.Range(0, foodsArrayID.GetLength(0));
                foodID = foodsArrayID[foodID];
                if (activeScene != "Hard")
                {
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
                else 
                {
                    if (dragDrop.targetPyramid == "Health")
                    {
                        for(int i = 0; i < duplicateCheck.intFoodArrayHealth.Length; i++)
                        {
                            if (duplicateCheck.intFoodArrayHealth[i] == 0)
                            {
                                duplicateCheck.intFoodArrayHealth[i] = foodID;
                                return;
                            }
                            else if(duplicateCheck.intFoodArrayHealth[i] == foodID)
                            {
                                break;
                            }
                        }
                    }
                    else if (dragDrop.targetPyramid == "Climate")
                    {
                        for(int i = 0; i < duplicateCheck.intFoodArrayClimate.Length; i++)
                        {
                            if (duplicateCheck.intFoodArrayClimate[i] == 0)
                            {
                                duplicateCheck.intFoodArrayClimate[i] = foodID;
                                return;
                            }
                            else if(duplicateCheck.intFoodArrayClimate[i] == foodID)
                            {
                                break;
                            }
                        }
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

            // Set food name and image
            foodName = (string)foodsArrayList[0].ToString();

            Sprite sp = Resources.Load<Sprite>(foodName) as Sprite;
            image.sprite = sp;
        }
    }
}
