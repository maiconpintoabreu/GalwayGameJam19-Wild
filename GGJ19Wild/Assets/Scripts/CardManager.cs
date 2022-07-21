using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
   
    TopDownController playerController;
    GameObject player;

    void Awake()
    {
        player = GameObject.Find("Player");
        playerController = player.GetComponent<TopDownController>();
        for (int i = 0; i < playerController.AllCards.Count; i++)
        {
            var tempCard = playerController.AllCards[i];
            GameObject newButton = DefaultControls.CreateButton(new DefaultControls.Resources());
            newButton.transform.SetParent(transform, false);
            RectTransform rt = newButton.GetComponent (typeof (RectTransform)) as RectTransform;
            rt.sizeDelta = new Vector2 (200, 200);
            Button newButton2 = newButton.GetComponent<Button>();
            newButton2.onClick.AddListener(delegate{ TaskOnClick(tempCard); });
            var spriteRenderer = newButton.GetComponent<Image>();
            spriteRenderer.sprite = tempCard.sprite;
            foreach (Transform child in newButton.transform) {
                GameObject.Destroy(child.gameObject);
            }
        }
    }
	void TaskOnClick(CardModel card){
        this.playerController.UseCurrentCard(card);
	}


    // Update is called once per frame
    void Update()
    {
        
    }
}
