using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneExit : MonoBehaviour {

    public string next;
	
    void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<Camera>().GetComponent<Camera_Controller>().dir = 1;
        Data data = FindObjectOfType<Data>();
        PlayerController pc = FindObjectOfType<PlayerController>();
        data.hp = pc.health;
        data.hpM = pc.health_max;
        data.score = pc.score;
        SceneManager.LoadScene(next);
    }
}
