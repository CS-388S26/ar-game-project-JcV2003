using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletConfiguration : MonoBehaviour
{

    public int mode = 0;
    public float curveMagnitude = 2f;

    public bool selected = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (!selected) return;


        if (Input.GetKey(KeyCode.Alpha0))
            mode=0;
        if (Input.GetKey(KeyCode.Alpha1))
            mode=1;
        if (Input.GetKey(KeyCode.Alpha2))
            mode=2;
        if (Input.GetKey(KeyCode.Alpha3))
            mode=3;
    }

    
}
