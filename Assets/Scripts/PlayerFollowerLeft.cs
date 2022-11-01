using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowerLeft : MonoBehaviour
{
    public Transform PlayerTransformPos;
    public Vector3 ver;
    public float Zcoordinate;

    void Update()
    {
        Zcoordinate = PlayerTransformPos.position.z;
        transform.position = new Vector3(-2,0,Zcoordinate);
    }
        
}
