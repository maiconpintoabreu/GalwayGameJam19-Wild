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
}
