using UnityEngine;
using System.Collections;

public class TelePoint : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponentInChildren<MeshRenderer>().enabled = false;
	}
	
}
