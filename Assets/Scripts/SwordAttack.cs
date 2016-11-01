using UnityEngine;
using System.Collections;

public class SwordAttack : MonoBehaviour
{
    public GameObject parent;
    // Use this for initialization
    void Start()
    {
        Physics.IgnoreCollision(parent.GetComponent<Collider>(), GetComponent<Collider>());
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Debug.Log("Hit enemy!");
            Destroy(other.gameObject);
        }
        
    }
}