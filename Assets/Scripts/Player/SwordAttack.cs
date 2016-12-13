
using UnityEngine;
using System.Collections;

public class SwordAttack : MonoBehaviour
{
    public GameObject parent;
    public bool attacking;
    // Use this for initialization
    void Start()
    {
        attacking = false;
        Physics.IgnoreCollision(parent.GetComponent<Collider>(), GetComponent<Collider>());
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && attacking)
        {
            //Debug.Log("Hit enemy!");
            other.gameObject.GetComponent<CharController>().addHealth(-25);
        }

    }
}