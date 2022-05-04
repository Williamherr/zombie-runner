using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    bool isDead = false;

    public void TakeDamage(float damage)
    {

        BroadcastMessage("OnDamageTaken");
        this.hitPoints -= damage;

        if (this.hitPoints <= 0 && !isDead)
        {
            BroadcastMessage("OnDeath");
            Die();
            Destroy(gameObject,5f);
        }
    }
    
    private void Die()
    {
        isDead = true;
        GetComponent<Animator>().SetTrigger("isDead");
    }

    public bool IsDead()
    {
        return isDead;
    }
    

}
