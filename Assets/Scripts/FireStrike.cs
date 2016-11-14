using UnityEngine;
using System.Collections;

public class FireStrike : Ability {

    public Rigidbody firestrikePrefab;
    public float miniCooldownTime = 0.05f;
    private float miniNextUsageTime = 0f;
    public byte numberOfPieces = 5;
    private byte piecesLeft;
    private bool sequenceEnded;

	void Start () {
        Initialize(4, 1.5f, 0);
        piecesLeft = numberOfPieces;
        sequenceEnded = true;
	}
	
    public void cast()
    {
        if (isCooldownOver())
        {
            StartCoroutine(shoot());
            startCooldown();
        }
    }

    private IEnumerator shoot()
    {
        while(piecesLeft > 0)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z)); //15 is camera distance
            Vector3 shooterPos = transform.position;
            shooterPos.y += 1;
            Vector3 dir = mousePos - shooterPos;
            dir.Normalize();

            Rigidbody piece = Instantiate(firestrikePrefab, shooterPos, transform.rotation) as Rigidbody;
            piece.AddForce(dir * 800);

            piecesLeft--;
            yield return new WaitForSeconds(miniCooldownTime);
        }
        piecesLeft = numberOfPieces;   
    }
    
}
