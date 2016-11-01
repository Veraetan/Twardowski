using UnityEngine;
using System.Collections;

public class PickupController : MonoBehaviour {

    public enum PickType
    {
        Crystal,
        Treasure
    }
    public PickType ptype;
    //public SphereCollider coll;
    //public SphereCollider trigger;
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (ptype == PickType.Crystal)
            {
                other.gameObject.GetComponent<PlayerController>().addHealth(this.gameObject, 15);
            }
            if (ptype == PickType.Treasure)
            {
                other.gameObject.GetComponent<PlayerController>().addScore(this.gameObject, 250);
            }
        }
    }
    
}
