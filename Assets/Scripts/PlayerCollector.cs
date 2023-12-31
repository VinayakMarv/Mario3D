using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    public GameController gc;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        
        if(hit.collider.tag == "Enemy")
        {
            if (hit.normal.y>0.6f)
            Destroy(hit.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.name);
        if (other.tag == "Coin")
        {
            gc.CoinCollect();
        }
        else if (other.tag == "Star")
        {
            gc.StarCollect();
        }
        else if (other.tag == "MainStar")
        {
            gc.MainStarCollect();
        }
        else { return; }
        other.GetComponent<Collectibles>().Collect();
    }
}
