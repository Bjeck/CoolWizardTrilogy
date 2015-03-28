using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spell {

    public List<Card> CardCombination = new List<Card>();
    public List<Card> cardCombination { get { if (CardCombination.Count > 0) { return CardCombination; } return null; } }


    
}
