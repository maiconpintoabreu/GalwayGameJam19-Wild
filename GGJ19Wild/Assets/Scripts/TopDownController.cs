using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownController : MonoBehaviour
{

    public CardModel[] handCards = new CardModel[3];

    [SerializeField] CardModel[] NormalCardDeck;
    [SerializeField] CardModel[] WildCardDeck;

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
            switch(this.handCards[0].cardAction)
            {
                case "WalkRight":

                    dir.x = 1;
                    animator.SetInteger("Direction", 2);

                    break;
                case "WalkLeft":

                    dir.x = -1;
                    animator.SetInteger("Direction", 3);

                    break;
                case "WalkUp":

                    dir.y = 1;
                    animator.SetInteger("Direction", 1);

                    break;
                case "WalkDown":

                    dir.y = -1;
                    animator.SetInteger("Direction", 0);

                    break;
            }
            animator.SetInteger("MovementType", this.handCards[0].movementType);
            dir.Normalize();
            animator.SetBool("IsMoving", dir.magnitude > 0);
            GetComponent<Rigidbody2D>().velocity = dir;
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
    public void UseCurrentCard()
    {
        if (!this.isMoving)
        {
            if (this.handCards[0].cardAction != "")
            {
                Debug.Log(this.handCards[0].cardAction);
                this.isMoving = true;
                StartCoroutine(WaitForCasting());
            }
        }
    }
    public void CardSelected(string deckName)
    {
        if (!this.isMoving)
        {
            if (deckName == "NormalDeck")
            {
                if (this.NormalCardDeck.Length > 0)
                {
                    int cardIndex = Random.Range(0, this.NormalCardDeck.Length);
                    this.handCards[0] = this.RemoveAt<CardModel>(ref this.NormalCardDeck, cardIndex);
                }
            }
            else
            {
                if (this.WildCardDeck.Length > 0)
                {
                    int cardIndex = Random.Range(0, this.WildCardDeck.Length);
                    this.handCards[0] = this.RemoveAt<CardModel>(ref this.WildCardDeck, cardIndex);
                }
            }
        }
    }

    IEnumerator WaitForCasting()
    {

        //yield on a new YieldInstruction that waits for 2 seconds.
        yield return new WaitForSeconds(this.handCards[0].number);
        this.isMoving = false;
        this.handCards[0] = null;
    }
    public T RemoveAt<T>(ref T[] arr, int index)
    {
        T item = arr[index];
        arr[index] = arr[arr.Length - 1];
        System.Array.Resize(ref arr, arr.Length - 1);

        return item;
    }
}

