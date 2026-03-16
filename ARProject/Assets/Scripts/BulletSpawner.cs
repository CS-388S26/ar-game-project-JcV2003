using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] BulletConfiguration bulletCongif;

    public Transform target;

    public UnityEvent OnTerminalCreated;

    public bool selected = false;

    float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {

        target = GameObject.Find("Target").transform;

        transform.LookAt(target);

        OnTerminalCreated.Invoke();


    }



    // Update is called once per frame
    void Update()
    {

    
        timer += Time.deltaTime;

        if (timer > 1f)
        {
            GameObject b = Instantiate(bullet, transform);

            b.GetComponent<Bullet>().target = target;
            b.GetComponent<Bullet>().SetPath(bulletCongif);

            timer = 0f;
        }
    }
}
