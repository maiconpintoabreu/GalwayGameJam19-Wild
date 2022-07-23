using UnityEngine;
using UnityEngine.EventSystems;

public class CardManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
 {
     private bool mouse_over = false;
     private RectTransform rt;

     void Awake()
     {
        
            rt = GetComponent (typeof (RectTransform)) as RectTransform;
     }
 
     void Update()
     {
         if (mouse_over)
         {
            rt.sizeDelta = new Vector2 (200, 200);
         }else{
            rt.sizeDelta = new Vector2 (100, 100);
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
