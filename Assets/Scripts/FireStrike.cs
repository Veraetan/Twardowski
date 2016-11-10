using UnityEngine;
using System.Collections;

public class FireStrike : MonoBehaviour {

    public Rigidbody firestrikePrefab;

	void Start () {
	    


	}
	
	void Update () {
        

        if (Input.GetKeyDown(KeyCode.E))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 15.0f)); //15 is camera distance
            Vector3 shooterPos = transform.position;
            shooterPos.y += 1;
            Vector3 dir = mousePos - shooterPos;
            dir.Normalize();

            Rigidbody piece = Instantiate(firestrikePrefab, shooterPos, transform.rotation) as Rigidbody;
            piece.AddForce(dir * 400);

        }

	}
}
