using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_infoTerminal : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI modeSelected;
    [SerializeField] TextMeshProUGUI arcWeight;
    [SerializeField] public TMP_Dropdown modeDropdown;

    public void SetInformation(BulletConfiguration bc) {

        modeSelected.text = bc.mode.ToString();
        arcWeight.text = bc.curveMagnitude.ToString();


    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
