using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketPickup : MonoBehaviour
{
    WeaponSwitcher weapon;
    
    private void OnTriggerEnter(Collider other)
    {
        

        if (other.CompareTag("Player"))
        {
            weapon = other.GetComponentInChildren<WeaponSwitcher>();
            weapon.EnableRocket();
            Destroy(this.gameObject);
        }
    }
}
