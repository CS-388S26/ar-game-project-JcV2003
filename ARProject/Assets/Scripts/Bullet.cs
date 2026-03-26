using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class Bullet : MonoBehaviour
{
    public Tween transform_tween;

    public Transform target;

    public float bulletDamage;

    public MeshRenderer m;


    void Start()
    {


        m = transform.Find("Mesh").GetComponent<MeshRenderer>();


    }

    public void SetColor( Color tColor) { 
        
        m.material.color = tColor;
    }

    //THIS FUNCTION CREATES A PATH USING DIFFERENT CASE SCENARIOS FOR THE CURVE MADE OF THE BULLET
    //UPDATE: THis is no longer needed as I couldnt implement the obstacles, but it makes a good visual effect
    public void SetPath(BulletConfiguration config) {


        float arcHeight = config.curveMagnitude;

        Vector3 start = transform.position;
        Vector3 end = target.position;

        Vector3 direction = (end - start).normalized;

        Vector3 control1 = Vector3.zero;
        Vector3 control2 = Vector3.zero;

        Vector3 right = Vector3.Cross(Vector3.up, direction).normalized;

        switch (config.mode) { 

            case 0:

                control1 = start + direction * 2 + Vector3.up * arcHeight + Random.insideUnitSphere * 2;
                control2 = end - direction * 2 + Vector3.up * (arcHeight * 0.5f) + Random.insideUnitSphere * 2;

                break;

            case 1:

                control1 = start + direction * 2 - Vector3.up * arcHeight + Random.insideUnitSphere * 2;
                control2 = end - direction * 2 - Vector3.up * (arcHeight * 0.5f) + Random.insideUnitSphere * 2;

                break;
            case 2:

                control1 = start + direction * 2 + right * arcHeight + Random.insideUnitSphere * 2;
                control2 = end - direction * 2 + right * (arcHeight * 0.5f) + Random.insideUnitSphere * 2;

                break;

            case 3:

                control1 = start + direction * 2 - right * arcHeight + Random.insideUnitSphere * 2;
                control2 = end - direction * 2 - right * (arcHeight * 0.5f) + Random.insideUnitSphere * 2;

                break;


        };


        Vector3[] path = new Vector3[]
        {
            end,
            control1,
            control2,

        };

        transform_tween = transform.DOPath(path, 2f, PathType.CubicBezier)
                 .SetEase(Ease.Linear)
                 .SetLookAt(0.01f)
                 .SetLink(gameObject)
                 .OnComplete(() => Destroy(this.gameObject));

    }


    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Core")
        {
            other.gameObject.GetComponent<Core>().ReduceHealth(1,this);
        }
    }
}
