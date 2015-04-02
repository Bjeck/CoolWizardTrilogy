using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public partial class SpellManager : MonoBehaviour {


    public Dictionary<string, Card> allCards = new Dictionary<string, Card>();
    public Dictionary<string, Card> yourCards = new Dictionary<string, Card>();
    Card ChosenSpell;
    public Card chosenSpell{ get{ return ChosenSpell; } }
    public List<Sprite> cardImages = new List<Sprite>();

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
		allCards.Add("fire", new Card("fire", cardImages[0], 0));
		allCards.Add("fire1", new Card("fire1", cardImages[1], 0));
		allCards.Add("fire2", new Card("fire2", cardImages[2], 0));
		allCards.Add("fire3", new Card("fire3", cardImages[3], 0));
		allCards.Add("fire4", new Card("fire4", cardImages[4], 0));
		allCards.Add("fire5", new Card("fire5", cardImages[5], 0));
		allCards.Add("fire6", new Card("fire6", cardImages[6], 0));
    }


    public void SetYourFirstCards()
    {
        FoundNewCard("fire");
        FoundNewCard("fire1");
        FoundNewCard("fire2");
        FoundNewCard("fire3");
        FoundNewCard("fire4");
    }
}