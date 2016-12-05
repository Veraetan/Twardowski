using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneExit : MonoBehaviour {

    public Vector3 entryPoint;
    public GameObject lvlCtrl;
    public GameObject exit;
	
    void OnTriggerEnter(Collider other)
    {
        /*FindObjectOfType<Camera>().GetComponent<Camera_Controller>().dir = 1;
        Data data = FindObjectOfType<Data>();
        PlayerController pc = FindObjectOfType<PlayerController>();
        data.hp = pc.health;
        data.hpM = pc.health_max;
        data.score = pc.score;
        SceneManager.LoadScene(next);*/
        if(other.tag == "Player")
        {
            other.GetComponent<PlayerController>().lvlCtrl = exit.GetComponent<SceneExit>().lvlCtrl;
            exit.GetComponent<SceneExit>().entry();
            lvlCtrl.GetComponent<Level_Controller>().despawn();
        }
    }

    public void entry()
    {

        FindObjectOfType<Camera_Controller>().fade(entryPoint);
        if(lvlCtrl != null)
        {
            lvlCtrl.GetComponent<Level_Controller>().spawn();
        }
        
    }
}
