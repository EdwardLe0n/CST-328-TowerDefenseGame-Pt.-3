using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// We take off MonoBehavior bc this script is detached from an object,
// but we still want the code to get used

[System.Serializable]
public class TurretBlueprint
{

    public GameObject prefab;
    public int cost;

}
