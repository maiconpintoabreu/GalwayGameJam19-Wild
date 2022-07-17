using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownController : MonoBehaviour
{
    [System.Serializable]
    public struct Cards
    {
        public string cardName;
        public string cardAction;
        public string description;
        public float number;
        public Sprite sprite;
    }
    public Cards card;
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
            switch(this.card.cardAction)
            {
                case "WalkRight":

                    dir.x = this.card.number;
                    animator.SetInteger("Direction", 2);
                    dir.Normalize();
                    animator.SetBool("IsMoving", dir.magnitude > 0);
                    GetComponent<Rigidbody2D>().velocity = dir;

                    break;
                case "WalkLeft":

                    dir.x = this.card.number * (-1);
                    animator.SetInteger("Direction", 3);
                    dir.Normalize();
                    animator.SetBool("IsMoving", dir.magnitude > 0);
                    GetComponent<Rigidbody2D>().velocity = dir;

                    break;
                case "WalkUp":

                    dir.y = this.card.number;
                    animator.SetInteger("Direction", 0);
                    dir.Normalize();
                    animator.SetBool("IsMoving", dir.magnitude > 0);
                    GetComponent<Rigidbody2D>().velocity = dir;

                    break;
                case "WalkDown":

                    dir.y = this.card.number * (-1);
                    animator.SetInteger("Direction", 1);
                    dir.Normalize();
                    animator.SetBool("IsMoving", dir.magnitude > 0);
                    GetComponent<Rigidbody2D>().velocity = dir;

                    break;
                
                dir.x = -5;
                animator.SetInteger("Direction", 3);
            }
        }
        else
        {
            dir.Normalize();
            animator.SetBool("IsMoving", dir.magnitude > 0);
            GetComponent<Rigidbody2D>().velocity = dir;
        }

        //Get Card Selected and process the movement
        //Check if character is moving to animate

    }
    public void CardSelected(string card)
    {
        Debug.Log(card);
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

