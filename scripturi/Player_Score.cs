using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Player_Score : MonoBehaviour
{
    public GameObject ScorUI;
    public static int playerscore = 0;
    public static  int j;
     void Start()
    {
        
        j = playerscore;
        
    }

    // Update is called once per frame
    void Update()
    {
        ScorUI.gameObject.GetComponent<Text>().text = ("Scor:" + playerscore);
        mori();
        tepi();
        esc();
    }


    private void OnTriggerEnter2D(Collider2D trig)

    {
        if (trig.gameObject.tag == "Coin")
        {
            playerscore = playerscore + 100;
            Destroy(trig.gameObject);

        }



        if (trig.gameObject.tag == "Gem")
        {
            playerscore = playerscore + 500;
            Destroy(trig.gameObject);

        }



    }


    void mori()
    {
        if (gameObject.transform.position.y < -7)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            playerscore = 0;
        }
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right);
        if (hit.collider != null && hit.distance <= 0.4f && hit.collider.tag == "Enemy")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            playerscore = 0;
        }
        RaycastHit2D hitl = Physics2D.Raycast(transform.position, Vector2.left);
        if (hitl.collider != null && hitl.distance <= 0.4f && hitl.collider.tag == "Enemy")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            playerscore = 0;
        }
    }

    void tepi()
    {
        RaycastHit2D loveala = Physics2D.Raycast(transform.position, Vector2.down);



        if (loveala.collider != null && loveala.distance <= 0.9f && loveala.collider.tag == "Spikes")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            playerscore = 0;

        }
    }



    public void esc()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            playerscore = j;
    }
}
