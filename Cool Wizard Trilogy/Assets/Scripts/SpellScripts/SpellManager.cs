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
		allCards.Add("FireBall", new Card("FireBall", cardImages[0], 0));
		allCards.Add("FreezeBlast", new Card("FreezeBlast", cardImages[1], 0));
		allCards.Add("GiantBomb", new Card("GiantBomb", cardImages[2], 0));
		allCards.Add("TransformObject", new Card("TransformObject", cardImages[3], 0));
		allCards.Add("RotateObject", new Card("RotateObject", cardImages[4], 0));
		allCards.Add("ScaleObject", new Card("ScaleObject", cardImages[5], 0));
		//allCards.Add("fire6", new Card("fire6", cardImages[6], 0));
    }


    public void SetYourFirstCards()
    {
		//FoundNewCard("RotateObject");
		//FoundNewCard("ScaleObject");
		//FoundNewCard("GiantBomb");
		//FoundNewCard("TransformObject");
        //FoundNewCard("fire4");
    }
}