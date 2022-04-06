using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using System;
using Better.StreamingAssets;

namespace db
{
    public class PathWrite : MonoBehaviour
    {
        public string runtimeDBPath; 
        public string loadDBpath; 
        float timer;
        public BSA bsa;

        public void Awake()
        {
            bsa = GetComponent<BSA>();
            bsa.InitBSA();

            runtimeDBPath = Path.Combine(Application.persistentDataPath, "food.db");
            Debug.Log(runtimeDBPath);
            loadDBpath = Path.Combine("jar:file://" + Application.dataPath + "!/assets/", "food.db");
            Debug.Log(loadDBpath);

            if(!File.Exists(runtimeDBPath))
            {
                byte[] newBytes = BetterStreamingAssets.ReadAllBytes("food.db");
                File.WriteAllBytes(runtimeDBPath, newBytes);
                Debug.Log("dbPath exists: " + File.Exists(runtimeDBPath));
                Debug.Log(Convert.ToBase64String(newBytes));
            }
        }
    }
}