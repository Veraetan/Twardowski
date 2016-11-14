using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public int score;
    public int health;
    Text text;
	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        score = 0;
        health = 0;
	}
	
	// Update is called once per frame
	void Update () {
        text.text = "Score: " + score + "\nHealth: ";
        if (health <= 0)
            text.text += "DEAD";
        else
            text.text += health;
	}
}
