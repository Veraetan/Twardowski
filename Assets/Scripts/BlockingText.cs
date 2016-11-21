using UnityEngine;
using System.Collections;

public class BlockingText : MonoBehaviour {
    
	void Start () {
	    
	}
	
	void Update () {
        transform.LookAt(Camera.main.transform);
        transform.Rotate(0,180,0);
	}
}
