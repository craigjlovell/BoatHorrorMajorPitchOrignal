using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingWater : MonoBehaviour
{
    public float lowWaterHeight;
    public float highWaterHeight;
    public float waterRiseSpeed;
    public float t;
    public bool waterRiseEnabled;
    public Transform water;

    private void Update()
    {
        if (waterRiseEnabled)
        {
            t += Time.deltaTime * waterRiseSpeed;
            water.position = new Vector3 (water.position.x, Mathf.Lerp(lowWaterHeight, highWaterHeight, t), water.position.z);
        }
    }
}
