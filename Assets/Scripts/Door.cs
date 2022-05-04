using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

public class Door : MonoBehaviour
{
    [SerializeField] float doorRange = 5f;
    [SerializeField] Canvas doorCanvas;
    private bool isPlayerAtDoor = false;
    public bool IsPlayerAtDoor { get { return isPlayerAtDoor; } }
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
      doorCanvas.enabled = false;
      anim = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            doorCanvas.enabled = true;
            isPlayerAtDoor = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            doorCanvas.enabled = false;
            isPlayerAtDoor = false;

        }
    }

    public void TriggerDoor()
    {
        anim.SetTrigger("DoorTrigger");
    }

    private void OnDrawGizmosSelected()
    {
        Vector3 vec = new Vector3(transform.position.x + 2f, transform.position.y, transform.position.z - 1);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(vec, doorRange);
    }
}
