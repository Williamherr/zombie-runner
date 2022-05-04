using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketExplosion : MonoBehaviour
{
    private float explosionDamage = 200f;
    private float explosiveRadius = 5f;
    private float explosivesSpeed = .5f ;

    private void Awake()
    {
        Explode(this.gameObject);
    }


    public void Explode(GameObject sphere)
    {
        sphere.gameObject.GetComponent<SphereCollider>().isTrigger = true;
       // sphere.gameObject.GetComponent<MeshRenderer>().enabled = false;
        StartCoroutine(RocketShoot(sphere));
    }


    IEnumerator RocketShoot(GameObject sphere)
    {
        Debug.Log("RocketShot");
        int size = 1;
        while (size < explosiveRadius)
        {
            sphere.transform.localScale += new Vector3(size, size, size);
            yield return new WaitForSeconds(explosivesSpeed * Time.deltaTime);
            size++;
        }

        Destroy(sphere);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyHealth>().TakeDamage(explosionDamage);
        }
    }


}
