using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class ObjectController : MonoBehaviour
{
    [SerializeField] private string itemName;

    [TextArea] [SerializeField] private string itemExInfo;

    [SerializeField] private InspectController InspectController;
    
    public void ShowObjectName()
    {
        InspectController.ShowName(itemName);
    }

    public void HideObjectName()
    {
        InspectController.HideName();
    }

    public void ShowExInfo()
    {
        InspectController.ShowExInfo(itemExInfo);
    }
}
