using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class Bullet : MonoBehaviour
{
    public Tween transform_tween;

    public Transform target;


    void Start()
    {

  

    
    }

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

                control1 = start + direction * 2 + Vector3.up * arcHeight /*+ Random.insideUnitSphere * 2*/;
                control2 = end - direction * 2 + Vector3.up * (arcHeight * 0.5f) /*+ Random.insideUnitSphere * 2*/;

                break;

            case 1:

                control1 = start + direction * 2 - Vector3.up * arcHeight /*+ Random.insideUnitSphere * 2*/;
                control2 = end - direction * 2 - Vector3.up * (arcHeight * 0.5f) /*+ Random.insideUnitSphere * 2*/;

                break;
            case 2:

                control1 = start + direction * 2 + right * arcHeight /*+ Random.insideUnitSphere * 2*/;
                control2 = end - direction * 2 + right * (arcHeight * 0.5f) /*+ Random.insideUnitSphere * 2*/;

                break;

            case 3:

                control1 = start + direction * 2 - right * arcHeight /*+ Random.insideUnitSphere * 2*/;
                control2 = end - direction * 2 - right * (arcHeight * 0.5f) /*+ Random.insideUnitSphere * 2*/;

                break;


        };



        Debug.DrawLine(transform.position, control1, Color.red, 5f);
        Debug.DrawLine(control1, control2, Color.green, 5f);
        Debug.DrawLine(control2, target.position, Color.blue, 5f);

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
}
