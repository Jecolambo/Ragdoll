using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityHandler : MonoBehaviour
{
    public float gravityStrength;
    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = new Vector3 (0f, -gravityStrength, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
