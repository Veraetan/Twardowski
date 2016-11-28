using UnityEngine;
using System.Collections;

public class FireBallPrefab : MonoBehaviour {

    Vector3 dir;
    bool blocked;
	// Use this for initialization
	void Start () {
        blocked = false;
        Vector3 target = GameObject.FindGameObjectWithTag("Player").transform.position;
        target.y += 1;
        Vector3 shooterPos = transform.position;
        dir = target - shooterPos;
        dir.Normalize();
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody>().velocity = dir * 10;
        //Debug.Log(GetComponent<Rigidbody>().velocity);
    }

    void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "Tmp" || other.tag == "Player") && !blocked)
        {
            if (other.GetComponentInParent<PlayerController>().blocking)
            {
                //Debug.Log(dir);
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y+1, -Camera.main.transform.position.z)); //15 is camera distance
                Vector3 shooterPos = other.transform.position;
                shooterPos.y += 1;
                dir = mousePos - shooterPos;
                //Debug.Log(dir);
                dir.Normalize();
                blocked = true;
            }
            else
            {
                other.gameObject.GetComponentInParent<PlayerController>().addHealth(-15);
                Destroy(gameObject);
            }
            
        }
        else if(other.tag == "Enemy" && blocked)
        {
            other.gameObject.GetComponent<CharController>().addHealth(-25);
            Destroy(gameObject);
        }
        else if(other.tag == "Terrain")
        {
            Destroy(gameObject);
        }
    }
}
