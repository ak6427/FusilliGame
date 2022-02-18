using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCoordinates : MonoBehaviour
{
    public Vector2 myLastCoordinates;
    // Start is called before the first frame update
    void Start()
    {
        myLastCoordinates = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
