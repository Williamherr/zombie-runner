using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private bool isOnWood;
    public bool IsOnWood { get { return isOnWood; } }

    private bool isOnCement;
    public bool IsOnCement { get { return isOnCement; } }

    private AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = GetComponentInParent<AudioManager>();
    }



    private void OnTriggerEnter(Collider other)
    {
        TriggerSound(other);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colliusion" + collision.gameObject.name);
    }


    void TriggerSound(Collider other)
    {
        Debug.Log(other.tag);

        if (other.CompareTag("Wood"))
        {
            audioManager.OutsideVolumeHandler(0.3f);
            audioManager.OnWood();
        }
        else if (other.CompareTag("Cement"))
        {
            audioManager.OutsideVolumeHandler(0.1f);
            audioManager.OnCement();
        }
        else if (other.CompareTag("Terrain"))
        {
            audioManager.OutsideVolumeHandler(0.6f);
            audioManager.OnDirt();
        }
    }

}
