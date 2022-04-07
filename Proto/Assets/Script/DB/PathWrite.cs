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
            loadDBpath = Path.Combine("jar:file://" + Application.dataPath + "!/assets/", "food.db");

            if(!File.Exists(runtimeDBPath))
            {
                byte[] newBytes = BetterStreamingAssets.ReadAllBytes("food.db");
                File.WriteAllBytes(runtimeDBPath, newBytes);
            }
        }
    }
}