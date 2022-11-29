using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine;
using TMPro;

public class InspectController : MonoBehaviour
{
    [SerializeField] private GameObject objectNameGO;
    [SerializeField] private TextMeshProUGUI objectNameUI;

    [SerializeField] private GameObject exInfoGO;
    [SerializeField] private TextMeshProUGUI exInfoUI;

    [SerializeField] private float onScreenTimer;
    [SerializeField] public bool startTimer;
    private float timer;

    private void Start()
    {
        objectNameGO.SetActive(false);
        exInfoGO.SetActive(false);
    }

    private void Update()
    {
        if(startTimer)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                timer = 0;
                ClearExInfo();
                startTimer = false;
            }
        }
    }

    public void ShowName(string objectName)
    {
        objectNameGO.SetActive(true);
        objectNameUI.text = objectName;
    }

    public void HideName()
    {
        objectNameGO.SetActive(false);
        objectNameUI.text = "";
    }

    public void ShowExInfo(string newInfo)
    {
        timer = onScreenTimer;
        startTimer = true;
        exInfoGO.SetActive(true);
        exInfoUI.text = newInfo;
    }

    void ClearExInfo()
    {
        exInfoGO.SetActive(false);
        exInfoUI.text = "";
    }
}
