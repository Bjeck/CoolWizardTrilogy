using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SpellManager : MonoBehaviour {


    public Dictionary<string, Card> allCards = new Dictionary<string, Card>();
    public Dictionary<string, Card> yourCards = new Dictionary<string, Card>();
    Card ChosenSpell;
    public Card chosenSpell{ get{ return ChosenSpell; } }


	public void ToggleSpell(string cardName)
    {
        if(ChosenSpell != null && ChosenSpell.name == cardName)
        {
            ChosenSpell = null;
        }
        else
        {
            if (yourCards.ContainsKey(cardName))
            {
                ChosenSpell = yourCards[cardName];
            }
        }
    }




    public void FoundNewCard(string cardName)
    {
        if(!yourCards.ContainsKey(cardName))
        {
            if(allCards.ContainsKey(cardName))
            {
                yourCards.Add(cardName, allCards[cardName]);
            }
        }
    }


    public void MakeAllCards()
    {
        allCards.Add("fire", new Card("fire", 0));
    }


    public void SetYourFirstCards()
    {
        FoundNewCard("fire");
    }
}