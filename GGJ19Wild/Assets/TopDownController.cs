using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownController : MonoBehaviour
{
    public string card;
    //private bool isMoving = false;
    //public bool isAlive = true;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 dir = Vector2.zero;
        if (Input.GetKey(KeyCode.A))
        {
            dir.x = -1;
            animator.SetInteger("Direction", 3);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            dir.x = 1;
            animator.SetInteger("Direction", 2);
        }

        if (Input.GetKey(KeyCode.W))
        {
            dir.y = 1;
            animator.SetInteger("Direction", 1);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            dir.y = -1;
            animator.SetInteger("Direction", 0);
        }

        dir.Normalize();

        animator.SetBool("IsMoving", dir.magnitude > 0);
        GetComponent<Rigidbody2D>().velocity = dir;
        //Get Card Selected and process the movement
        //Check if character is moving to animate

    }
    IEnumerator CardSelected(string card)
    {
        this.card = card;
       // this.isMoving = true;
        yield return new WaitForSeconds(2);
        //this.isMoving = false;
    }
}
