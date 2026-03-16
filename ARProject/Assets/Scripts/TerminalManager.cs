using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class TerminalManager : MonoBehaviour
{
    List<GameObject> terminals = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        //for (int i = 0; i < 4; i++)
        //terminals.Add(transform.GetChild(i).gameObject);


    }

    public void TerminalCreated(BulletSpawner t) {

        terminals.Add(t.gameObject);

        Debug.Log("Terminal "+ t.gameObject.name + " added");



    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
            SelectTerminal(0);
        if (Input.GetKey(KeyCode.W))
            SelectTerminal(1);
        if (Input.GetKey(KeyCode.E))
            SelectTerminal(2);
        if (Input.GetKey(KeyCode.R))
            SelectTerminal(3);
    }

    void SelectTerminal(int index) {

        DeselectAllTerminals();

        terminals[index].GetComponent<BulletConfiguration>().selected = true;

        Debug.Log("Terminal " + terminals[index].name + " selected");


    }

    void DeselectAllTerminals() {

        for (int i = 0; i < 3; i++)
            terminals[i].GetComponent<BulletConfiguration>().selected = false;
    }
}
