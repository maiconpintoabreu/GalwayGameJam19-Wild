using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownController : MonoBehaviour
{
    public string card;
    private bool isMoving = false;
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
        if (this.isMoving)
        {
            if (this.card == "TestCard")
            {

                dir.x = -5;
                animator.SetInteger("Direction", 3);
            }
            dir.Normalize();
            animator.SetBool("IsMoving", dir.magnitude > 0);
            GetComponent<Rigidbody2D>().velocity = dir;
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = dir;
        }

        //Get Card Selected and process the movement
        //Check if character is moving to animate

    }
    public void CardSelected(string card)
    {
        Debug.Log(card);
        this.card = card;
        this.isMoving = true;
        StartCoroutine(WaitForCasting());
        Debug.Log(card);
    }

    IEnumerator WaitForCasting()
    {

        //yield on a new YieldInstruction that waits for 2 seconds.
        yield return new WaitForSeconds(2);
        this.isMoving = false;
    }
}

