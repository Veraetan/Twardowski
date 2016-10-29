using UnityEngine;
using System.Collections;


[RequireComponent(typeof(CharacterController))]
public class BasicEnemy_Controler : MonoBehaviour {

    public float velocity = 10;
    CharacterController cc;

	// Use this for initialization
	void Start () {
        cc.GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 v = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        cc.Move(v * Time.deltaTime);
        cc.SimpleMove(Physics.gravity);
	}
}
