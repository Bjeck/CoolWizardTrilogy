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

    public float cardStartPct = 5;

    public float cardTotalWidthPct = 10;

    public SpellManager manager = new SpellManager();

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
                cardBut.onClick.AddListener(() => { manager.ToggleSpell(cardName); });
                cards.Add(cardName, card);
            }
        }

        float cardWidth = ( Screen.width / 100 ) * cardWidthPct;
        float cardPosIt = ((Screen.width / 100) * cardTotalWidthPct) / cards.Count;
        float cardMargin = (Screen.width / 100) * cardStartPct;

        int q = 0;
        
        foreach(string cardName in cards.Keys)
        {
            RectTransform cardTran = cards[cardName].GetComponent<RectTransform>();

            cardTran.position = new Vector3((cardPosIt * q) + cardMargin + (cardWidth / 2), 100, 0);
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