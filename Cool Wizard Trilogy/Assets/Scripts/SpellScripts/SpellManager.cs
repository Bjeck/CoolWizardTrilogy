using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpellManager : MonoBehaviour {

    List<Card> allCards = new List<Card>();
    List<Card> yourCards = new List<Card>();
    

	public bool DoSpell(List<Card> cardsUsed)
    {
        List<Card> cardCombination = new List<Card>();

        while (true)
        {
            bool found = false;

            foreach(Card card in allCards)
            {
                List<Card> cardsToCombine = new List<Card>();
                if (false)
                {
                    found = true;
                }
            }

            if (!found)
                break;
        }

        return true;
    }
}