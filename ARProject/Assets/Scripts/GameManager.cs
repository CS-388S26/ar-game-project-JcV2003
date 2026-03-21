using Lean.Touch;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{

    void OnEnable()
    {
        LeanTouch.OnFingerTap += HandleTap;
    }

    void OnDisable()
    {
        LeanTouch.OnFingerTap -= HandleTap;
    }

    private bool IsPointerOverUI(LeanFinger finger)
    {
        if (EventSystem.current == null)
            return false;

        var eventData = new PointerEventData(EventSystem.current);
        eventData.position = finger.ScreenPosition;

        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        return results.Count > 0;
    }


    void HandleTap(LeanFinger finger)
    {
        Ray ray = Camera.main.ScreenPointToRay(finger.ScreenPosition);

        if (IsPointerOverUI(finger))
        {
            //Debug.Log("Tapped UI, don't select terminal");
            return;
        }

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Debug.Log("Hit: " + hit.transform.name);

            if (hit.transform.tag == "Terminal") {
 
                TerminalManager tm = GameObject.Find("TerminalManager").GetComponent<TerminalManager>();

                tm.SelectTerminal(hit.transform.gameObject);

            }

        }
        else
        {
            TerminalManager tm = GameObject.Find("TerminalManager").GetComponent<TerminalManager>();
            tm.DeselectAllTerminals();
        }

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Message(string n) { 
    
        Debug.Log(n);
    }
}
