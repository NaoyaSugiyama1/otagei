using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookatforward : MonoBehaviour
{
    public Transform target;
    //public Vector3 offset = new Vector3(0,0,1);
    void Update()
    {
        transform.position = target.forward + target.transform.position;
    }
}
