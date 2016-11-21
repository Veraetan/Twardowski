using UnityEngine;
using System.Collections;

public class EnemyHealthbar : MonoBehaviour {

    private float hp, maxhp;

	// Use this for initialization
	void Start () {
        
        hp = GetComponentInParent<CharController>().health;
        maxhp = GetComponentInParent<CharController>().health_max;
        GetComponent<TextMesh>().text = hp.ToString() + "/" + maxhp.ToString();
    }
	
	// Update is called once per frame
	void Update () {
        hp = GetComponentInParent<CharController>().health;
        maxhp = GetComponentInParent<CharController>().health_max;
        GetComponent<TextMesh>().text = hp.ToString() + "/" + maxhp.ToString();
        transform.LookAt(Camera.main.transform);
        transform.Rotate(0,180,0);

    }
}
