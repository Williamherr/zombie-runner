using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    DeathHandler win;

    

    private void OnTriggerEnter(Collider other)
    {
        win = FindObjectOfType<DeathHandler>();

        if (other.CompareTag("Player"))
        {
            win.HandleWin();
        }
    }
}
