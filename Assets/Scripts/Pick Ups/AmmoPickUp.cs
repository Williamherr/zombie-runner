using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUp : MonoBehaviour
{

    [SerializeField] int ammoAmount = 5;
    [SerializeField] AmmoType ammoType;

   
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag.Equals("Player"))
        {
            FindObjectOfType<Ammo>().IncreaseAmmo(ammoType, ammoAmount);

            Destroy(gameObject);
        }
    }
  
}
