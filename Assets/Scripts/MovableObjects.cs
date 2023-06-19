using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObjects : MonoBehaviour
{
    public Vector3 startPosition, endPosition;
    public float speed=1.5f;
    private Vector3 refVel;
    private Vector3 target;
    //private Vector3 prePos;
    //private bool contact=false;
    private Transform playerP;
    void Start()
    {
        transform.position = startPosition;
        target = endPosition;
    }
    private void OnTriggerEnter(Collider other)
    {
        playerP = other.transform.parent;
        other.transform.SetParent(transform);
        //contact = true;
    }
    private void OnTriggerExit(Collider other)
    {
        other.transform.SetParent(playerP);
        //contact = false;
    }
    private void OnTriggerStay(Collider other)
    {
        //other.transform.position += transform.position - prePos;
    }
    void FixedUpdate()
    {
        if ((target-transform.position).magnitude<0.5f)
        {
            if (target == endPosition)
                target = startPosition;
            else target = endPosition;
            refVel = Vector3.zero;
        }
        //prePos = transform.position;
        transform.position = Vector3.SmoothDamp(transform.position, target, ref refVel, speed*Time.deltaTime);
        
    }
    //private void LateUpdate()
    //{
    //    if (contact)
    //    {
    //        player.position += transform.position - prePos;
    //    }
    //}
}
