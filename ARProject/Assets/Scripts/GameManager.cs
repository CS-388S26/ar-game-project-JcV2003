using Lean.Touch;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public UnityEvent OncoreJustPlaced;
     public GameObject tm;
     public Button startButton;
     public Button resetButton;
     public GameObject targetCyilinder;

    public TextMeshProUGUI phase;

    string CoreSetPhase = "Find a can and tap when the core appears";
    string TerminalSetPhase = "Place the turret markets and tap anywhere when they appear";
    string TerminalPreparationPhase = "Select a turret to modify its bullets";
    string AbouttoStartPhase = "Tap Start to start the round";

    bool coreReady = false;
    bool coreOnSight = false;

    bool terminalsReady = false;
    bool nextRound = false;
    bool roundStarted = false;

    float timer = 0f;
    float resetTime = 0f;
    void Start() {

        phase.text = CoreSetPhase;
    }

    public void coreInCamera() {

        coreOnSight = true;
    }

    public void corePlaced()
    {

        OncoreJustPlaced.Invoke();
    }

    public void coreDestroyed()
    {

        coreReady = false;
        coreOnSight = false;
        terminalsReady = false;

        resetTime = 0f;

        GameObject.Find("ARTerminalManager").GetComponent<TerminalManager>().TerminalsStop();
        GameObject.Find("ARTerminalManager").GetComponent<TerminalManager>().DeactivateTerminals();

        tm.SetActive(false);

        targetCyilinder.SetActive(false);

        nextRound = true;
        roundStarted = false;

    }

    public void ResetRound()
    {

        coreReady = false;
        coreOnSight = false;
        terminalsReady = false;

        GameObject.Find("ARTerminalManager").GetComponent<TerminalManager>().TerminalsStop();
        GameObject.Find("ARTerminalManager").GetComponent<TerminalManager>().DeactivateTerminals();

        GameObject.Find("Core").GetComponent<Core>().ResetUIvalues();


        tm.SetActive(false);

        targetCyilinder.SetActive(false);

        nextRound = true;
        roundStarted = false;

    }



    void OnEnable()
    {
        LeanTouch.OnFingerTap += HandleTap;
    }


    public void RoundStarted() {

        roundStarted = true;
        TerminalManager tm = GameObject.Find("ARTerminalManager").GetComponent<TerminalManager>();
        tm.DeselectAllTerminals();

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


        if (IsPointerOverUI(finger))
        {
            //Debug.Log("Tapped UI, don't select terminal");
            return;
        }

        Ray ray = Camera.main.ScreenPointToRay(finger.ScreenPosition);


        if (!coreReady) {

            if (coreOnSight)
            {


                coreReady = true;

                corePlaced();

                Debug.Log("Core SET");

            
                tm.SetActive(true);
              

                phase.text = TerminalSetPhase;


                return;
            }
        }

        if (!terminalsReady) {


            int n = tm.GetComponent<TerminalManager>().TerminalsActive();

            if (n > 0) {

                terminalsReady = true;

                phase.text = TerminalPreparationPhase;

                Debug.Log("TERMINALS SET: "+n);


                GameObject.Find("Core").GetComponent<Core>().TerminalsSet(tm.GetComponent<TerminalManager>().TerminalsActiveList());

            }
            else
            {
                Debug.Log("NO TERMINALS SET");
            }

            return;
        }

        if (coreReady && terminalsReady) {


            startButton.gameObject.SetActive(true);
        }

        if (roundStarted) return;

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Debug.Log("Hit: " + hit.transform.name);

            if (hit.transform.tag == "Terminal") {
 
                TerminalManager tm = GameObject.Find("ARTerminalManager").GetComponent<TerminalManager>();

                tm.SelectTerminal(hit.transform.gameObject);

            }

        }
        else
        {
            TerminalManager tm = GameObject.Find("ARTerminalManager").GetComponent<TerminalManager>();
            tm.DeselectAllTerminals();
        }


       

    }



    // Update is called once per frame
    void Update()
    {

        if (roundStarted) startButton.gameObject.SetActive(false);

        if (nextRound) {

            timer += Time.deltaTime;
            resetTime = 0f;

            if (timer > 5f)
            {

                targetCyilinder.SetActive(true);
     
              
                phase.gameObject.SetActive(true);

                phase.text = CoreSetPhase;

                resetButton.gameObject.SetActive(false);

                nextRound = false;

                timer = 0f;
            }

        }

        if (roundStarted) {

            resetTime += Time.deltaTime;
            if (resetTime > 15f)
            {

                resetButton.gameObject.SetActive(true);
                resetTime = 0f;
            }
        }
  
    
    }

    public void Message(string n) { 
    
        Debug.Log(n);
    }
}
