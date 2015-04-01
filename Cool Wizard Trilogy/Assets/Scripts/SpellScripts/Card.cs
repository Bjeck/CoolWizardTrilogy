using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Card {
    public string name;
    public string description;
    public int strength;
    public float image;
    public float effect;

    public Card(string _name, float _effect)
    {
        name = _name;
        description = "";
        strength = 1;
        effect = _effect;
    }
}
