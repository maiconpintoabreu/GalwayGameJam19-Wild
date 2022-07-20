using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum WildTypeEnum {None=0, Bird=1, Seal=2, Fox=3, Deer=4}

public class TopDownController : MonoBehaviour
{
    //Audio
    //public AK.Wwise.Event PlayTransformSounds;
    //
    private int hendCardsLimit = 3;
    public List<CardModel> handCards;
    List<CardModel> NormalCardDeck;
    List<CardModel> WildCardDeck;
    [SerializeField] List<CardModel> AllCards;
    private bool isMoving = false;
    public bool isAlive = true;
    private Animator animator;
    private string currentState;

  

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
            int direction = -1;
            switch(this.handCards[0].cardAction)
            {
                case "WalkRight":
                    dir.x = 1;
                    direction = 2;
                    break;
                case "WalkLeft":
                    dir.x = -1;
                    direction = 3;
                    break;
                case "WalkUp":
                    dir.y = 1;
                    direction = 1;
                    break;
                case "WalkDown":
                    dir.y = -1;
                    direction = 0;
                    break;
            }
            dir.Normalize();
            this.ChangeAnimationState(direction, (int)this.handCards[0].movementType, dir.magnitude > 0);
            GetComponent<Rigidbody2D>().velocity = dir;
        }
        else
        {
            dir.Normalize();
            this.ChangeAnimationState(-1, -1, false);
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
                //PlayTransformSounds.Post(gameObject);
                FindObjectOfType<AudioManager>().PlayOneShot("TransformSFX");
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
                    //Audio
                    FindObjectOfType<AudioManager>().PlayOneShot("CardSFX");
                    //
                    int cardIndex = Random.Range(0, this.NormalCardDeck.Count);
                    this.handCards[0] = this.NormalCardDeck[cardIndex];
                    this.NormalCardDeck.RemoveAt(cardIndex);
                }
            }
            else
            {
                if (this.WildCardDeck.Count > 0)
                {
                    //Audio
                    FindObjectOfType<AudioManager>().PlayOneShot("CardSFX");
                    //
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
        switch (damageType)
        {
            
            case "Water":
                if(this.animator.GetInteger("MovementType") != 1 && this.animator.GetInteger("MovementType") != 2)
                {
                    this.Die();
                }
                break;
            default:

                this.Die();

                break;
        }
    }

    IEnumerator WaitForCasting()
    {

        //yield on a new YieldInstruction that waits for 2 seconds.
        yield return new WaitForSeconds(this.handCards[0].number);
        this.isMoving = false;
        this.handCards[0] = null;
    }
    void ChangeAnimationState(int direction, int movementType, bool isMoving)
    {
        string id = direction.ToString() + movementType.ToString() + isMoving.ToString();
        if(this.currentState == id) return;

        animator.SetInteger("Direction", direction);
        animator.SetInteger("MovementType", movementType);
        animator.SetBool("IsMoving", isMoving);
        this.currentState = id;
    }
}

