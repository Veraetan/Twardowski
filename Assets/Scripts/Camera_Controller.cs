using UnityEngine;
using System.Collections;

public class Camera_Controller : MonoBehaviour {
    GameObject player;
    Vector3 diff;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        diff = player.transform.position;

        Physics.IgnoreLayerCollision(10, 11, true);
        Physics.IgnoreLayerCollision(10, 10, true);
    }
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.Translate(player.transform.position-diff);
        diff = player.transform.position;
	}
}
