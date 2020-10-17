using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SkinnedMeshRenderer))]
public class GhostInvisibilityHandler : MonoBehaviour
{
    SkinnedMeshRenderer rend;
    public Material matInvisible;
    public Material matNormal;

    void Start() => rend = GetComponent<SkinnedMeshRenderer>(); 

    void Update() => InvisiblePower(); 

    void InvisiblePower()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            //GetComponentInChildren<BoxCollider>().isTrigger = true;
            rend.material = matInvisible;
        }

        if (Input.GetKeyUp(KeyCode.F))
        {
            //GetComponentInChildren<BoxCollider>().isTrigger = false;
            rend.material = matNormal;
        }
    }
}
