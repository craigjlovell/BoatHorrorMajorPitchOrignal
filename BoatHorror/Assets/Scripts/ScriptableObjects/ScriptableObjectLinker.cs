using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableObjectLinker : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] public ScriptableObjectController itemData;

    public ScriptableObjectController GetItem() { return itemData; }

    //public void OnTriggerEnter(Collider other)
    //{
    //    player = other.GetComponent<PlayerController>();
    //    if(player == other.gameObject.GetComponent<PlayerController>() && other == other.GetComponent<CharacterController>())
    //    {
    //        gameObject.SetActive(false);
    //        Destroy(gameObject);
    //    }
    //}
}
