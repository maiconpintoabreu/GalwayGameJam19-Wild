using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentCardUIController : MonoBehaviour
{
    TopDownController playerController;
    GameObject player;
    [SerializeField] Sprite defaultHand;
    Image spriteRenderer;
    Sprite newSprite;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<Image>();
    }
    void Awake()
    {
        player = GameObject.Find("Player");
        playerController = player.GetComponent<TopDownController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController && playerController.handCards[0] && playerController.handCards[0].number > 0)
        {
            spriteRenderer.sprite = playerController.handCards[0].sprite;
        }
        else
        {
            spriteRenderer.sprite = this.defaultHand;
        }

    }
}
