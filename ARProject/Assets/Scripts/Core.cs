using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Core : MonoBehaviour
{

    float health;
    public float maxHealth; 

    public UnityEvent OnCoreDestroyed;
    public UnityEvent OnCoreCreated;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        OnCoreCreated.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReduceHealth(float dmg) {

        health -= dmg;

        if (health < 0) {
            Destroy(this.gameObject);
        }
    }


    private void OnDestroy()
    {
        OnCoreDestroyed.Invoke();
    }

    
}
