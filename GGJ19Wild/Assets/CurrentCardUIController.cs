using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentCardUIController : MonoBehaviour
{
    TopDownController playerController;
    [SerializeField] GameObject player;
    Image spriteRenderer;
    Sprite newSprite;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<Image>();
    }
    void Awake()
    {
        playerController = player.GetComponent<TopDownController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController && playerController.handCards[0].cardAction != "")
        {
            spriteRenderer.sprite = playerController.handCards[0].sprite;
        }

    }
    void ChangeSprite()
    {
        spriteRenderer.sprite = newSprite;
    }
}
