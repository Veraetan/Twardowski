using UnityEngine;
using System.Collections;

public class FireBallPrefab : MonoBehaviour {

    Vector3 dir;
	// Use this for initialization
	void Start () {
        Vector3 target = GameObject.FindGameObjectWithTag("Player").transform.position;
        target.y += 1;
        Vector3 shooterPos = transform.position;
        dir = target - shooterPos;
        dir.Normalize();
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody>().velocity = dir * 10;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if(other.GetComponent<PlayerController>().blocking)
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z)); //15 is camera distance
                Vector3 shooterPos = other.transform.position;
                shooterPos.y += 1;
                Vector3 dir = mousePos - shooterPos;
                dir.Normalize();

                GetComponent<Rigidbody>().velocity = dir * 10;
            }
            other.gameObject.GetComponent<PlayerController>().addHealth(-15);
            Destroy(gameObject);
        }
        else if(other.tag != "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
