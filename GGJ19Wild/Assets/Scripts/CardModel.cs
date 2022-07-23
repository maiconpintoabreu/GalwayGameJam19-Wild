using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CardModel : ScriptableObject
{
    public string cardName;
    public string cardAction;
    public string cardType;
    public string description;
    public int number;
    public WildTypeEnum movementType;
    public Sprite sprite;
    public Sprite spriteArrow;
    public Sprite spriteAnimal;
    public Sprite[] spriteNumbers;
    
    public Sprite getNumber(){
        if(this.number > 0 && this.spriteNumbers.Length >= this.number)
        {
            return this.spriteNumbers[this.number-1];
        }
        return null;
    }
}
