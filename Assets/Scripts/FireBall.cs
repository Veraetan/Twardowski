using UnityEngine;
using System.Collections;

public class FireBall : Ability {
    public GameObject fireball;
	// Use this for initialization
	void Start () {
        Initialize(3, 0, 0);
	}
	
	public void cast (GameObject target) {
        if (isCooldownOver()) {
            startCooldown();
            Vector3 shooterPos = transform.position;
            shooterPos.y += 1;
            Vector3 dir = target.transform.position - shooterPos;
            dir.Normalize();

            Rigidbody piece = Instantiate(fireball, shooterPos, transform.rotation) as Rigidbody;
            piece.GetComponent<Rigidbody>().velocity = dir * 10;
        }
    }
}
