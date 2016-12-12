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
        if (attacking)
        {
            
            if (other.tag == "Enemy")
            {
                //Debug.Log("Hit enemy!");
                other.gameObject.GetComponent<CharController>().addHealth(-25);
            }
            else if(other.tag == "Secret")
            {
                Debug.Log("secret!");
                Destroy(other);
            }
        }
        
        
    }

}