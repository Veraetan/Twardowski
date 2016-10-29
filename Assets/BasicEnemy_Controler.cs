using UnityEngine;
using System.Collections;


[RequireComponent(typeof(CharacterController))]
public class BasicEnemy_Controler : MonoBehaviour {

    public float velocity = 6f;
    Vector3 movement = new Vector3(0f,0f,0f);
    CharacterController cc;

	// Use this for initialization
	void Start () {
        cc = gameObject.GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {

        float playerX = GameObject.FindGameObjectWithTag("Player").transform.position.x;
        float enemyX = gameObject.transform.position.x; 
        bool direction = playerX > enemyX;

        if (Mathf.Abs(playerX - enemyX) > 0.5f)
        {
            if (direction)
            {
                movement.x = velocity;
            }
            else
            {
                movement.x = -velocity;
            } 
        }
        else
        {
            movement.x = 0f;
        }

        /*
        if (gameObject.transform.position.z != 0f)
            gameObject.transform.position.Set(gameObject.transform.position.x, gameObject.transform.position.y, 0);*/


        cc.Move(movement * Time.deltaTime);
        cc.SimpleMove(Physics.gravity);
	}
}
