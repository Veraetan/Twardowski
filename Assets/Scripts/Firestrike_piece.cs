
using UnityEngine;
using System.Collections;

public class Firestrike_piece : MonoBehaviour
{

    public float lifetime = 3;

    void Start()
    {

        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            //Debug.Log("Burning Enemy");
            other.GetComponent<Burning>().startburning();
        }
        else if (other.tag == "Secret")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);

        }
        else if (other.tag == "Terrain")
        {
            Destroy(gameObject);
        }
    }

}