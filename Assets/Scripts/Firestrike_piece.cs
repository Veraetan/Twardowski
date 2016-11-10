using UnityEngine;
using System.Collections;

public class Firestrike_piece : MonoBehaviour {

    public float lifetime = 2;

	// Use this for initialization
	void Start () {

        Physics.IgnoreLayerCollision(10,11,true);
        Destroy(gameObject, lifetime);
    }
	
	// Update is called once per frame
	void Update () {
	    
	}
    
}
