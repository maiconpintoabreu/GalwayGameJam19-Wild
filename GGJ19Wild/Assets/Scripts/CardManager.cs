using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
 {
    private bool mouse_over = false;
    public CardModel cardModel;
    private RectTransform rt;
    private Image image;
    public TopDownController playerController;

    void Awake()
    {
        rt = GetComponent (typeof (RectTransform)) as RectTransform;
        rt.sizeDelta = new Vector2 (100, 100);
        Button newButton = GetComponent<Button>();
        newButton.onClick.AddListener(delegate{ TaskOnClick(); });
        image = GetComponent (typeof (Image)) as Image;
        foreach (Transform child in transform) {
            GameObject.Destroy(child.gameObject);
        }
    }
 
    void Update()
    {
        this.image.sprite = this.cardModel.sprite;
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
    void TaskOnClick(){
        this.playerController.UseCurrentCard(this.cardModel);
        this.enabled = false;
        rt.sizeDelta = new Vector2 (0, 0);
    }
 }
