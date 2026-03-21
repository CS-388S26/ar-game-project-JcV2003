using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class BulletConfiguration : MonoBehaviour
{

    public int mode = 0;
    public float curveMagnitude = 2f;

    public bool selected = false;

    GameObject UIInfo;

    // Start is called before the first frame update
    void Start()
    {
        UIInfo = transform.Find("InfoTerminal").gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        if (!selected) return;

      
        if (Input.GetKey(KeyCode.Alpha0))
            mode=0;
        if (Input.GetKey(KeyCode.Alpha1))
            mode=1;
        if (Input.GetKey(KeyCode.Alpha2))
            mode=2;
        if (Input.GetKey(KeyCode.Alpha3))
            mode=3;

    }


    public void ConfigSelected() {

        selected = true;

        UIInfo.GetComponent<UI_infoTerminal>().SetInformation(this);

        UIInfo.SetActive(true);

    }
    public void ConfigDeselected() {

        selected = false;

        UIInfo.SetActive(false);

    }

    public void IncreaseCurveMagnitude() {
        curveMagnitude += 1f;

        UIInfo.GetComponent<UI_infoTerminal>().SetInformation(this);
    }
    public void ReduceCurveMagnitude() {
        curveMagnitude -= 1f;

        UIInfo.GetComponent<UI_infoTerminal>().SetInformation(this);
    }
    public void ShootModeChange() {

        mode = UIInfo.GetComponent<UI_infoTerminal>().modeDropdown.value;

    }






}
