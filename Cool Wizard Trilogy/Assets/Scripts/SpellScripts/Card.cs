using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Card {
    public string description;
    public int strength;
    public List<Card> prerequisites = new List<Card>();
}
