using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    public int speed=10,upSpeed=5;
    public bool collected;
    private bool dead=false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, speed*Time.deltaTime, 0);
        if (collected) Collect();
        if(dead) transform.position = transform.position + transform.up * upSpeed/2 *Time.deltaTime;
    }
    public void Collect()
    {
        collected = false;
        StartCoroutine(Collection());
        dead = true;
        GetComponent<AudioSource>().enabled = true;
    }
    IEnumerator Collection()
    {
        int i = 15;
        while (i--!=0)
        {
            speed += 80;
            yield return new WaitForSeconds(0.1f);
        }
        Destroy(this.gameObject);
    }
}
