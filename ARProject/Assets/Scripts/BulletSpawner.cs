using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] BulletConfiguration bulletCongif;

    public Transform target;

    public UnityEvent OnTerminalCreated;
    public UnityEvent OnTerminalActive;

    public Color tColor;

    public bool selected = false;
    public bool shoot = false;

    int bulletsShoot = 0;



    float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {


        OnTerminalCreated.Invoke();

    }

    private void OnEnable()
    {
        OnTerminalActive.Invoke();
    }



    // Update is called once per frame
    void Update()
    {


        timer += Time.deltaTime;

        if (timer > 1f)
        {
            if (shoot && target && bulletsShoot < bulletCongif.bulletstoBeShoot) {
                GameObject b = Instantiate(bullet, transform);

                b.GetComponent<Bullet>().target = target;
                b.GetComponent<Bullet>().SetPath(bulletCongif);
                b.GetComponent<Bullet>().SetColor(tColor);

                bulletsShoot++;
            }
         

            timer = 0f;
        }
    }

    private void OnDisable()
    {
        bulletsShoot = 0;

    }
    public void ActiveUI() {

        selected = true;
        bulletCongif.ConfigSelected();

    }

    public void DeActiveUI()
    {

        selected = false;
        bulletCongif.ConfigDeselected();

    }



}
