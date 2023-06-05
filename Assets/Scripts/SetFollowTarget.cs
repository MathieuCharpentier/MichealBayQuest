using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFollowTarget : MonoBehaviour
{
    public string targetName;
    // Use this for initialization
    void Start()
    {
        GameObject target = GameObject.Find(targetName);
        if (target != null)
        {
            Police followTarget = GetComponent<Police>();
            followTarget.target = target.transform;
        }
    }
}