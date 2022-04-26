using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyMovement : MonoBehaviour {
public int EnemySpeed;
public int XMoveDirection;



	
	// Update is called once per frame
	void Update () {
       
       

        RaycastHit2D hit = Physics2D.Raycast(transform.position ,new Vector2(XMoveDirection, 0));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection, 0) * EnemySpeed;
       
       if (hit.distance < 0.4f)
        { FlipEnemy(); }

	}

    void PlayerRaycast()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up);
        if (hit.collider != null && hit.distance <= 0.8f && hit.collider.tag == "Player")
        {


            GetComponent<Animator>().SetBool("Die", true);
        }
    }

    void FlipEnemy()
    {
        Vector2 localscale;
        if (XMoveDirection > 0)
        {

            XMoveDirection = -1;
            localscale = gameObject.transform.localScale; //aci ii cand sa se intoarca spre stanga sau dreapta 
            localscale.x *= -1;
            transform.localScale = localscale;
        }
        else
        {
            XMoveDirection = 1;
            localscale = gameObject.transform.localScale; //aci ii cand sa se intoarca spre stanga sau dreapta 
            localscale.x *= -1;
            transform.localScale = localscale;
        }
    }
    
}

