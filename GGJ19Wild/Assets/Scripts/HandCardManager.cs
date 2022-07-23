using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HandCardManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
   
    TopDownController playerController;
    GameObject player;
    private bool mouse_over = false;
    private RectTransform rt;

    void Awake()
    {
        rt = GetComponent (typeof (RectTransform)) as RectTransform;
        player = GameObject.Find("Player");
        playerController = player.GetComponent<TopDownController>();
        for (int i = 0; i < playerController.AllCards.Count; i++)
        {
            var tempCard = playerController.AllCards[i];
            GameObject newButton = DefaultControls.CreateButton(new DefaultControls.Resources());
            newButton.AddComponent(typeof(CardManager));
            newButton.GetComponent<CardManager>().cardModel = tempCard;
            newButton.GetComponent<CardManager>().playerController = playerController;
            newButton.transform.SetParent(transform, false);
        }
    }


    // Update is called once per frame
    void Update()
    {
         if (mouse_over)
         {
            rt.position = Vector3.Lerp(transform.position, new Vector3 (0, 0, 0), 2 * Time.deltaTime);
         }else{;
            rt.position = Vector3.Lerp(transform.position, new Vector3 (0, -50, 0), 2 * Time.deltaTime);
         }
    }
     public void OnPointerEnter(PointerEventData eventData)
     {
         mouse_over = true;
     }
 
     public void OnPointerExit(PointerEventData eventData)
     {
         mouse_over = false;
     }
}
