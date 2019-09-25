using System.Collections;
using System.Collections.Generic;
using UnityAtoms;
using UnityEngine;

public class DebugDestroyLine : MonoBehaviour
{
    [SerializeField] private float maxDistance;

    [SerializeField] private BoolVariable DebugModeOn;
    
    void Update()
    {
        if(!DebugModeOn.Value) return;
        
        
        Debug.DrawRay(transform.position, Vector3.forward * maxDistance, Color.red);        
    }
}
