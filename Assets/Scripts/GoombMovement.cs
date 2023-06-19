using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombMovement : MonoBehaviour
{
    public Vector3 startPosition, endPosition;
    public float rotationY1, rotationY2;
    public float speed = 1.5f;
    public float turnRate = 0.5f;
    private Vector3 refVel;
    private Vector3 target;
    private bool rotate=false;
    //private Vector3 prePos;
    //private bool contact=false;
    private Transform playerP;
    private float rot = 180;
    public GameObject DeadPreFab;
    void Start()
    {
        transform.localPosition = startPosition;
        target = endPosition;
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        Destroy(gameObject);
    //    }
    //}
    void Update()
    {
        if ((target - transform.localPosition).magnitude < 0.02f)
        {
            if (target == endPosition)
                target = startPosition;
            else target = endPosition;
            refVel = Vector3.zero;
            rotate = true;
            rot = 180;
        }
        if (rotate)
        {
            transform.Rotate(0, turnRate * Time.deltaTime, 0);
            rot -= turnRate * Time.deltaTime;
            if (target == endPosition)
            {
                if (rot < 5)
                {
                    transform.localRotation = Quaternion.Euler(transform.localRotation.x, rotationY1, transform.localRotation.z);
                    rotate = false;
                }
            }
            else
            {
                if (rot < 5)
                {
                    transform.localRotation = Quaternion.Euler(transform.localRotation.x, rotationY2, transform.localRotation.z);
                    rotate = false;
                }
            }
        }
        else
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, target, speed * Time.deltaTime);
    }
    private void OnDestroy()
    {
        GameObject obj = Instantiate(DeadPreFab, transform);
        obj.transform.SetParent(transform.parent);
        Destroy(obj, 2f);
    }
}
