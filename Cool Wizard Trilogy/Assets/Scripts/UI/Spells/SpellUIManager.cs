using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SpellUIManager : MonoBehaviour {

    private static SpellUIManager _instance;

    public RectTransform spellPanel;

    public GameObject cardPrefab;

    public float cardWidthPct = 5;

    public Vector2 cardStartPct = new Vector2(5f,5f);

    public float cardTotalWidthPct = 10;

<<<<<<< HEAD
    public SpellManager manager = new SpellManager();
=======
    public float raiseSelectedCardPct = 1;


    private SpellManager manager = new SpellManager();
>>>>>>> origin/master

    private Dictionary<string, GameObject> cards = new Dictionary<string, GameObject>();


    public static SpellUIManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<SpellUIManager>();
                DontDestroyOnLoad(_instance.gameObject);
            }

            return _instance;
        }
    }


    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            if (this != _instance)
                Destroy(this.gameObject);
        }

        manager.MakeAllCards();
        manager.SetYourFirstCards();
    }


    void Update()
    {
        UpdateCardsUI();
    }


    public void UpdateCardsUI()
    {
        for(int i = cards.Count -1; i >= 0; i--)
        {
            string cardName = (cards.Keys.ToArray())[i];

            if(!manager.yourCards.Keys.Contains(cardName))
            {
                Destroy(cards[cardName]);
                cards.Remove(cardName);
                i--;
            }
        }

        foreach (string cardName in manager.yourCards.Keys)
        {
            if(!cards.ContainsKey(cardName))
            {
                GameObject card = Instantiate(cardPrefab);

                RectTransform cardTran = card.GetComponent<RectTransform>();
                cardTran.SetParent(spellPanel);
                Button cardBut = card.GetComponent<Button>();

                switch(cardName){
                    case "fire":
                        cardBut.onClick.AddListener(()=> { manager.ToggleSpell("fire"); });
                        break;
                    case "fire1":
                        cardBut.onClick.AddListener(()=> { manager.ToggleSpell("fire1"); });
                        break;
                    case "fire2":
                        cardBut.onClick.AddListener(()=> { manager.ToggleSpell("fire2"); });
                        break;
                    case "fire3":
                        cardBut.onClick.AddListener(()=> { manager.ToggleSpell("fire3"); });
                        break;
                    case "fire4":
                        cardBut.onClick.AddListener(()=> { manager.ToggleSpell("fire4"); });
                        break;
                }

                cards.Add(cardName, card);
            }
        }
                                               
        float cardWidth = ( Screen.width / 100 ) * cardWidthPct;
        float cardPosIt = ((Screen.width / 100) * cardTotalWidthPct) / cards.Count;
        float selCardRaise = (Screen.height / 100) * raiseSelectedCardPct;
        Vector2 cardMargin = new Vector2((Screen.width / 100) * cardStartPct.x, (Screen.height / 100) * cardStartPct.y);

        int q = 0;
        
        foreach(string cardName in cards.Keys)
        {
            RectTransform cardTran = cards[cardName].GetComponent<RectTransform>();

            float cardY = cardMargin.y;

            if(manager.chosenSpell != null && cardName == manager.chosenSpell.name)
            {
                cardY += selCardRaise;
            }

            cardTran.position = new Vector3((cardPosIt * q) + cardMargin.x, cardY, 0);
            cardTran.sizeDelta = new Vector2(cardWidth, cardTran.rect.height);

            q++;
        }
    }


    public Card cardClicked()
    {
        if(manager.chosenSpell != null)
        {
            return manager.chosenSpell;
        }

        return null;
    }
}