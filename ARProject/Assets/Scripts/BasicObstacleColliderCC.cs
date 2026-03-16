using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicObstacleCollider : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet") {
            //other.gameObject.GetComponent<Bullet>().transform_tween.Kill();
           Destroy(other.gameObject);
        }
    }
}
