using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Card {
    public string name;
    public string description;
    public int strength;
    public float effect;
    public Sprite image;

    public Card(string _name, Sprite _image, float _effect)
    {
        name = _name;
        description = "";
        strength = 1;
        effect = _effect;
        image = _image;
    }
}
