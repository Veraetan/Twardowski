using UnityEngine;
using System.Collections;

public class Lava : MonoBehaviour {
    Collider o;
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered");
        if (other.tag == "Player")
        {
            o = other;
            InvokeRepeating("getOut", 0.0f, 0.5f);
            other.GetComponent<Burning>().startburning();
        }
    }

    void OnTriggerExit(Collider other)
    {
        CancelInvoke();
    }

    void getOut()
    {
        o.GetComponent<CharController>().addHealth(-10);
    }
}
