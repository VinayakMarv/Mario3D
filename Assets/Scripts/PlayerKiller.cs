using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKiller : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Invoke(nameof(Kill), 0f);
        }
    }
    void Kill()
    {
        GameController.Instance.Menu();
        GameController.Instance.MenuPanel.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);

    }
}
