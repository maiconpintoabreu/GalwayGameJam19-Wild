using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
 {
    private bool mouse_over = false;
    public CardModel cardModel;
    public Sprite buttonSprite;
    private RectTransform rt;
    private Image image;
    public TopDownController playerController;
    private bool cardSet = false;

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
    void setCardValues()
    {
        if(this.cardModel && !this.cardSet)
        {
            this.cardSet = true;
            this.image.sprite = this.buttonSprite;
            GameObject newCardImage = DefaultControls.CreateImage(new DefaultControls.Resources());
            var cardImage = newCardImage.GetComponent (typeof (Image)) as Image;
            cardImage.sprite = this.cardModel.sprite;
            var cardImageRt = newCardImage.GetComponent (typeof (RectTransform)) as RectTransform;
            cardImageRt.anchoredPosition = transform.position;
            cardImageRt.anchorMin = new Vector2(0, 0);
            cardImageRt.anchorMax = new Vector2(1, 1);
            // cardImageRt.offsetMax = new Vector2(0, 0);
            // cardImageRt.offsetMin = new Vector2(0, 0);
            cardImageRt.pivot = new Vector2(0.5f, 0.5f);
            cardImageRt.sizeDelta = new Vector2 (100, 100);
            cardImageRt.position = new Vector3 (0, 0, 0);

            //Set Animal on the card
            GameObject newArrowImage = DefaultControls.CreateImage(new DefaultControls.Resources());
            cardImage = newArrowImage.GetComponent (typeof (Image)) as Image;
            cardImage.sprite = this.cardModel.spriteArrow;
            var newImageRt = newArrowImage.GetComponent (typeof (RectTransform)) as RectTransform;
            newImageRt.anchoredPosition = cardImageRt.position;
            newImageRt.anchorMin = cardImageRt.anchorMin;
            newImageRt.anchorMax = cardImageRt.anchorMax;
            newImageRt.pivot = cardImageRt.pivot;
            newImageRt.sizeDelta = cardImageRt.sizeDelta;
            newImageRt.position = cardImageRt.position;

            //Set Animal on the card
            GameObject newAnimalImage = DefaultControls.CreateImage(new DefaultControls.Resources());
            cardImage = newAnimalImage.GetComponent (typeof (Image)) as Image;
            cardImage.sprite = this.cardModel.spriteAnimal;
            newImageRt = newAnimalImage.GetComponent (typeof (RectTransform)) as RectTransform;
            newImageRt.anchoredPosition = cardImageRt.position;
            newImageRt.anchorMin = cardImageRt.anchorMin;
            newImageRt.anchorMax = cardImageRt.anchorMax;
            newImageRt.pivot = cardImageRt.pivot;
            newImageRt.sizeDelta = cardImageRt.sizeDelta;
            newImageRt.position = cardImageRt.position;
            

            //Set Number on the card
            GameObject newNumberImage = DefaultControls.CreateImage(new DefaultControls.Resources());
            cardImage = newNumberImage.GetComponent (typeof (Image)) as Image;
            cardImage.sprite = this.cardModel.getNumber();
            newImageRt = newNumberImage.GetComponent (typeof (RectTransform)) as RectTransform;
            newImageRt.anchoredPosition = cardImageRt.position;
            newImageRt.anchorMin = cardImageRt.anchorMin;
            newImageRt.anchorMax = cardImageRt.anchorMax;
            newImageRt.pivot = cardImageRt.pivot;
            newImageRt.sizeDelta = cardImageRt.sizeDelta;
            newImageRt.position = cardImageRt.position;


            newCardImage.transform.SetParent(transform, false);
            newNumberImage.transform.SetParent(transform, false);
            newArrowImage.transform.SetParent(transform, false);
            newAnimalImage.transform.SetParent(transform, false);
        }
    }
 
    void Update()
    {
        this.setCardValues();
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
        if(this.playerController.UseCurrentCard(this.cardModel)){
            this.enabled = false;
            rt.anchorMin = new Vector2(0, 0);
            rt.anchorMax = new Vector2(0, 0);
            rt.sizeDelta = new Vector2 (0, 0);
        }
    }
 }
