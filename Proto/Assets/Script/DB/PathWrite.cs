using UnityEngine;
using UnityEngine.Networking;
using System.IO;

namespace db
{
    public class PathWrite : MonoBehaviour
    {
        public string dbPath; 
        public string imagePath; 
        float timer;

        public void Awake()
        {
            dbPath = Path.Combine(Application.persistentDataPath + "/food.db");

            if(!File.Exists(dbPath))
            {
                UnityWebRequest loadDb = UnityWebRequest.Get("jar:file://" + Application.dataPath + "!/assets/food.db");

                timer = 0;

                while (!loadDb.isDone) 
                { 
                    timer += Time.deltaTime;
                    if (timer >= 5)
                    {
                        break;
                    }
                }
                byte[] newBytes = loadDb.downloadHandler.data;
                File.WriteAllBytes(dbPath, newBytes);
            }
        }
    }
}