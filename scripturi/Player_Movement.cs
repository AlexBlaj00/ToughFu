using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{

    public int PlayerSpeed = 10;
    private bool FacingRight = false;
    public int PlayerJumpPower = 1250;
    private float MoveX;
    public bool atinspejos = false;
    public int Nrsarituri = 0;
    public static int nivel = 1;

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        PlayerRaycast();
        Animatii();
        PlayerRaycast2();
        pauza();
       
    }
    void PlayerMove()
    {
        //controale

        MoveX = Input.GetAxis("Horizontal");
       
        //io ma tot duc da nu stiu incotro
        if (Input.GetButtonDown("Jump") && Nrsarituri < 2)
        {
            Jump();
            Nrsarituri++;
        }


        if (MoveX < 0.0f && FacingRight == false)
        {
            FlipPlayer();

        }

        else
            if (MoveX > 0.0f && FacingRight == true)
        {
            FlipPlayer();

        }
        //fizica daca tot nu trec
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(MoveX * PlayerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y); //fara asta nu se poate misca de pe loc
    }
    void Jump()
    {
        //ghici ce aci scrie cum sa sara
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * PlayerJumpPower);
        atinspejos = false;
    }
    void FlipPlayer()
    {
        FacingRight = !FacingRight;
        Vector2 localscale = gameObject.transform.localScale; //aci ii cand sa se intoarca spre stanga sau dreapta 
        localscale.x *= -1;
        transform.localScale = localscale;



    }


    private void OnCollisionEnter2D(Collision2D obiectatins)
    {

        if (obiectatins.gameObject.tag == "Ground")
        {
            atinspejos = true;
            Nrsarituri = 0;

        }


    }
    void PlayerRaycast()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
        if (hit.collider != null && hit.distance <= 0.8f && hit.collider.tag == "Enemy")
        {
         
            Destroy(hit.collider.gameObject);
            
        }
         


    }

    void Animatii()
    {
        if (atinspejos == false)
            GetComponent<Animator>().SetBool("isjumping", true);
        else
            GetComponent<Animator>().SetBool("isjumping", false);

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) && atinspejos == true)
            GetComponent<Animator>().SetBool("iswalking", true);
        else
            GetComponent<Animator>().SetBool("iswalking", false);
    }

    void PlayerRaycast2()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position,Vector2.right);
        if (hit.collider != null && hit.distance <= 0.3f && hit.collider.tag == "EndOfLevel")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            nivel++;

        }
    }

   public void pauza()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene("Meniu");

    }

   public void resume()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + nivel);
    }

    public void play()
    {
        SceneManager.LoadScene("Scena1");
        nivel = 1;
    }



}