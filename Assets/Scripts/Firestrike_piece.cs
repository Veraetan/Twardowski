using UnityEngine;
using System.Collections;

public class Firestrike_piece : MonoBehaviour {

    public float lifetime = 3;
    
	void Start () {
        
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
            other.gameObject.GetComponent<CharController>().addHealth(-5);
    }
    
}
