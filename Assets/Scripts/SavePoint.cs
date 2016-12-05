using UnityEngine;
using System.Collections;

public class SavePoint : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Colliding");
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerController>().save = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Not Colliding");
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerController>().save = false;
        }
    }
}
