using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum types
{
    puzzle,
    voids
}
public class ScriptableObjectController : ScriptableObject
{
    public bool puzzel1;
    public bool puzzel2;
    public bool puzzel3;
    public bool puzzel4;
    public bool puzzel5;

    public uint index;

    public types type;
    public GameObject prefab;
}
