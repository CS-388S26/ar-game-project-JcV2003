using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SocialPlatforms.Impl;


public class Core : MonoBehaviour
{

    int health;
    List<int> healthColor = new List<int>();

    public int maxHealth; 

    public UnityEvent OnCoreDestroyed;
    public UnityEvent OnCoreCreated;

    public GameObject gm = null;
    public GameObject PanelHits;

    // Start is called before the first frame update
    void Start()
    {
       
        //OnCoreCreated.Invoke();


    }

    private void OnEnable()
    {
        gm = GameObject.Find("GameManager");
        gm.GetComponent<GameManager>().coreInCamera();



    }

    void CreateHealth(List<GameObject> list) {

        for (int i = 0; i < list.Count; i++)
        {
            healthColor.Add(Random.Range(1, 7));
        }
    }

    public void TerminalsSet(List<GameObject> list)
    {
        CreateHealth(list);

        for (int i = 0; i < PanelHits.transform.childCount; i++)
        {
            TextMeshProUGUI txt;  
            PanelHits.transform.GetChild(i).TryGetComponent<TextMeshProUGUI>(out txt);


            txt.text = healthColor[i].ToString();

            if (txt != null) {

                MeshRenderer a = list[i].GetComponentInChildren<MeshRenderer>(true);
           
                
                if (a != null) {

                    txt.color = a.material.color;
                }
            }
        }



    }



    // Update is called once per frame
    void Update()
    {
        

    }

    public void ReduceHealth(int dmg,Bullet b) {


        TerminalManager tm = GameObject.Find("ARTerminalManager").GetComponent<TerminalManager>();


        List<GameObject>a = tm.TerminalsActiveList();

        for (int i = 0; i < a.Count; i++)
        {
            if (b.transform.parent.gameObject == a[i].gameObject) {

                healthColor[i] -= 1;

                TextMeshProUGUI txt;

                PanelHits.transform.GetChild(i).TryGetComponent<TextMeshProUGUI>(out txt);


                txt.text = healthColor[i].ToString();

            }
        }


        for (int i = 0; i < healthColor.Count; i++)
        {
            if (healthColor[i] > 0) {

                return;
            
            }

        }



         gameObject.SetActive(false);
            //health = maxHealth;

        
    }

    private void OnDisable()
    {

        ResetUIvalues();


        OnCoreDestroyed.Invoke();

        gm.GetComponent<GameManager>().coreDestroyed();

    }

    
    public void ResetUIvalues() {

        healthColor.Clear();

        for (int i = 0; i < PanelHits.transform.childCount; i++)
        {
            TextMeshProUGUI txt;
            PanelHits.transform.GetChild(i).TryGetComponent<TextMeshProUGUI>(out txt);
            txt.text = "0".ToString();

            if (txt != null)
            {

                txt.color = Color.white;

            }
        }

    }

    //private void OnDestroy()
    //{
    //    OnCoreDestroyed.Invoke();

    //    gm.GetComponent<GameManager>().coreDestroyed();
    //}


}
