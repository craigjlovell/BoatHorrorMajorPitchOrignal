using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InspectRaycast : MonoBehaviour
{
    public ScriptableObjectLinker linker;

    [SerializeField] private int rayLength = 5;        
    [SerializeField] private string excludeLayerName = null;        
    [SerializeField] private Image crosshair;

    [Header("Object Info")]
    [SerializeField] private LayerMask layerMaskInteractObject;
    private ObjectController raycastedOBJ;
    private bool doOnce;
    private bool isCrosshairActive;    

    [Header("Door Info")]
    [SerializeField] private LayerMask layerMaskInteractDoor;
    private DoorController raycastedDoor;
    private bool doOnce2;
    private bool isCrosshairActive2;

    // Update is called once per frame
    void Update()
    {        
        ObjectInfomationActivation();
        DoorActivation();
    }

    void CrosshairChangeColor(bool on)
    {        
        if (on && !doOnce)
        {
            crosshair.color = Color.red;
        }
        else
        {
            crosshair.color = Color.white;
            isCrosshairActive = false;
        }
    }

    public void ObjectInfomationActivation()
    {
        Ray testObject = new Ray(transform.position, transform.forward);
        RaycastHit hitObject;

        // Used for raycastHit
        Vector3 fwd_object = transform.TransformDirection(Vector3.forward);
        

        if (Physics.Raycast(transform.position, fwd_object, out hitObject, rayLength, layerMaskInteractObject.value))
        {
            if (hitObject.collider.CompareTag("InteractObject"))
            {
                if (!doOnce)
                {
                    raycastedOBJ = hitObject.collider.gameObject.GetComponent<ObjectController>();
                    raycastedOBJ.ShowObjectName();
                    CrosshairChangeColor(true);
                }

                isCrosshairActive = true;
                doOnce = true;

                if (Keyboard.current.eKey.wasPressedThisFrame)
                {
                    raycastedOBJ.ShowExInfo();
                    raycastedOBJ.gameObject.SetActive(false);
                    Destroy(raycastedOBJ.gameObject);
                }
            }
        }
        else
        {
            if (isCrosshairActive)
            {
                raycastedOBJ.HideObjectName();
                CrosshairChangeColor(false);
                doOnce = false;
            }
        }
    }

    public void DoorActivation()
    {
        Ray testDoor = new Ray(transform.position, transform.forward);
        RaycastHit hitDoor;

        // Used for raycastHit
        Vector3 fwd_door = transform.TransformDirection(Vector3.forward);

        int mask = 1 << LayerMask.NameToLayer(excludeLayerName) | layerMaskInteractDoor.value;

        if (Physics.Raycast(transform.position, fwd_door, out hitDoor, rayLength, mask))
        {
            if (hitDoor.collider.CompareTag("InteractDoor"))
            {
                if (!doOnce2)
                {
                    raycastedDoor = hitDoor.collider.gameObject.GetComponent<DoorController>();
                    CrosshairChangeColor(true);
                }

                isCrosshairActive2 = true;
                doOnce2 = true;

                if (Keyboard.current.eKey.wasPressedThisFrame)
                {
                    raycastedDoor.PlayAnimation();
                }
            }
        }
        else
        {
            if (isCrosshairActive2)
            {
                CrosshairChangeColor(false);
                doOnce2 = false;
            }
        }
    }
}
