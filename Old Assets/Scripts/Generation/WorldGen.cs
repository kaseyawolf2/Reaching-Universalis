using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGen : MonoBehaviour
{
    public int WorldSize = 5;


    // Start is called before the first frame update
    void Start()
    {
        GameObject.CreatePrimitive(PrimitiveType.Plane);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
