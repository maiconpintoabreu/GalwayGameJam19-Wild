using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalDeckController : MonoBehaviour
{
    public int Position;
    [System.Serializable]
    public struct Cards
    {
        public string cardName;
        public string cardAction;
        public string description;
        public float number;
        public Sprite sprite;
    }
    public Cards[] CardList;
    public Cards EmptyCard;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    Cards getCurrentCard()
    {
        if(CardList.Length < this.Position)
        {
            return CardList[this.Position];
        }
        else
        {
            return this.EmptyCard;
        }
    }
}
