using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : CharController
{
    Data data;
    float timer;
    public bool left, blocking, countering, save, died = false;
    public int score;
    public byte jumps;
    public byte jumps_max;
    CharacterController charCtrl;
    public Canvas GUI;
    // Use this for initialization

    void Start()
    {
        transform.Find("SaveTextMesh").gameObject.SetActive(false);
        data = FindObjectOfType<Data>();
        save = false;
        countering = false;
        left = false;
        blocking = false;
        if(PlayerPrefs.GetInt("saved") == 1 && died)
        {
            initiate(8, 15, (short)PlayerPrefs.GetInt("health"), data.hpM, 0);
            score = PlayerPrefs.GetInt("score");
            transform.position = new Vector3(PlayerPrefs.GetFloat("playerX"), PlayerPrefs.GetFloat("playerY"), 0);
        }
        else
        {
            initiate(8, 15, data.hp, data.hpM, 0);
            score = data.score;
        }
        
        jumps_max = 2;
        jumps = jumps_max;
        charCtrl = GetComponent<CharacterController>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.F) && save)
        {
            PlayerPrefs.SetInt("health", health);
            PlayerPrefs.SetFloat("playerX", transform.position.x);
            PlayerPrefs.SetFloat("playerY", transform.position.y);
            PlayerPrefs.SetInt("score", score);
            PlayerPrefs.SetInt("saved", 1);
            PlayerPrefs.SetInt("scene", SceneManager.GetActiveScene().buildIndex);
            Debug.Log("Game Saved. Health: " + PlayerPrefs.GetInt("health") + " Score: " + PlayerPrefs.GetInt("score"));
            timer = Time.time;
        }

        if (Input.GetButton("Fire2"))
        {
            blocking = true;
            transform.Find("BlockTextMesh").gameObject.SetActive(true);
            
        }
        else if(Input.GetButtonUp("Fire2"))
        {
            blocking = false;
            transform.Find("BlockTextMesh").gameObject.SetActive(false);
        }
           

        if (jumps != 0 && Input.GetButtonDown("Jump"))
        {
            addSpd(direction.ver, 1);
            jumps--;
        }
        else if(cc.velocity.y<0 && Input.GetButton("Jump"))
        {
            if (Input.GetAxis("Horizontal") > 0)
                left = false;
            else if(Input.GetAxis("Horizontal") < 0)
                left = true;

            if (left)
                addSpd(direction.hor, -1);
            else
                addSpd(direction.hor, 1);

            addSpd(direction.ver, -1, 2);
        }
        else
            addSpd(direction.hor, Input.GetAxis("Horizontal"));

        if (GUI != null)
        {
            GUI.GetComponent<Score>().score = score;
            GUI.GetComponent<Score>().health = health;
            GUI.GetComponent<Score>().cooldown = gameObject.GetComponent<FireStrike>().cooldownPercentage();
        }
        if (Input.GetKeyDown(KeyCode.E)) { gameObject.GetComponent<FireStrike>().cast(); }

        if(timer+2 > Time.time)
        {
            transform.Find("SaveTextMesh").gameObject.SetActive(true);
        }
        else
        {
            transform.Find("SaveTextMesh").gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        move();

        if (cc.isGrounded)
        {
            jumps = jumps_max;
        }

        
    }

    public void addHealth(short add, GameObject other)
    {
        
        if (health > 0 && !blocking)
        {
            health += add;
            if (health <= 0)
            {
                health = 0;
                died = true;
                Debug.Log("Player Died");
                if(PlayerPrefs.GetInt("saved") == 1)
                {
                    SceneManager.LoadScene(PlayerPrefs.GetInt("scene"));
                }
                else
                {
                    SceneManager.LoadScene("Prototype - Veraetan");
                }
                
            }
            else if (health > health_max)
                health = health_max;
        }
        else if (blocking)
        {
            other.GetComponent<CharController>().daze();
        }
    }
    public void addScore(int add)
    {
        score += add;
    }


}
