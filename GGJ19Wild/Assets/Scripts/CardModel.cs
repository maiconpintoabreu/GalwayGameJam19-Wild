using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CardModel : ScriptableObject
{
    public string cardName;
    public string cardAction;
    public string description;
    public int number;
    public int movementType;
    public Sprite sprite;
}
