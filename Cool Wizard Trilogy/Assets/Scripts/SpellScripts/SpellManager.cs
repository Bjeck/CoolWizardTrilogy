using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SpellManager : MonoBehaviour {


    public List<string> names = new List<string>();
    Dictionary<string, Card> allCards = new Dictionary<string, Card>();
    Dictionary<string, Card> yourCards = new Dictionary<string, Card>();
    Card ChosenSpell;
    public Card chosenSpell{ get{ return ChosenSpell; } }

	public void ChooseSpell(string cardName)
    {
        if(yourCards.ContainsKey(cardName))
        {
            ChosenSpell = yourCards[cardName];
        }
    }


    public void UnChooseSpell()
    {
        ChosenSpell = null;
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


    public void MakeAllCards
    {

    }


    public void SetYourFirstCard()
    {

    }
}