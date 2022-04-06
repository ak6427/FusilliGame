using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Better.StreamingAssets
{
    public class BSA : MonoBehaviour
    {
        // Start is called before the first frame update
        public void InitBSA()
        {
            BetterStreamingAssets.Initialize();
        }
    }
}
