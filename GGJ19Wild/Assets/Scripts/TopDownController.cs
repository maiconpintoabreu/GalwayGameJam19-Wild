using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TopDownController : MonoBehaviour
{
    //Audio
    public AK.Wwise.Event PlayTransformSounds;
    //
    private int hendCardsLimit = 3;
    public List<CardModel> handCards;
    List<CardModel> NormalCardDeck;
    List<CardModel> WildCardDeck;
    [SerializeField] List<CardModel> AllCards;
    private bool isMoving = false;
    public bool isAlive = true;
    private Animator animator;

  

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Awake()
    {
        this.isAlive = true;
        this.NormalCardDeck = new List<CardModel>();
        this.WildCardDeck = new List<CardModel>();
        for(var i = 0; i < this.AllCards.Count; i++){
            CardModel element = this.AllCards[i];
            if(element.cardType == "Normal"){
                this.NormalCardDeck.Add(element);
            }else if(element.cardType == "Wild"){
                this.WildCardDeck.Add(element);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = Vector2.zero;
        if (this.isMoving && this.isAlive)
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

    }
    public void UseCurrentCard()
    {
        if (!this.isMoving)
        {
            if (this.handCards[0] && this.handCards[0].cardAction != "")
            {
                //Audio
                PlayTransformSounds.Post(gameObject);
                //
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
                if (this.NormalCardDeck.Count > 0)
                {
                    int cardIndex = Random.Range(0, this.NormalCardDeck.Count);
                    this.handCards[0] = this.NormalCardDeck[cardIndex];
                    this.NormalCardDeck.RemoveAt(cardIndex);
                }
            }
            else
            {
                if (this.WildCardDeck.Count > 0)
                {
                    int cardIndex = Random.Range(0, this.WildCardDeck.Count);
                    this.handCards[0] = this.WildCardDeck[cardIndex];
                    this.WildCardDeck.RemoveAt(cardIndex);
                }
            }
        }
    }
    public void Die(){
       

        this.isAlive = false;
    }
    public void GetDamage(string damageType)
    {
        //TODO: check if correct card for the tile
        this.Die();
    }

    IEnumerator WaitForCasting()
    {

        //yield on a new YieldInstruction that waits for 2 seconds.
        yield return new WaitForSeconds(this.handCards[0].number);
        this.isMoving = false;
        this.handCards[0] = null;
    }
}

