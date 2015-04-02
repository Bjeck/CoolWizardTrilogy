using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SpellUIManager : MonoBehaviour {

    private static SpellUIManager _instance;

    public RectTransform spellPanel;

    public GameObject cardPrefab;

    private SpellManager manager = new SpellManager();

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
                cardBut.onClick.AddListener(() => { ToggleSelectedCard(cardName); });
                cards.Add(cardName, card);
            }
        }

        float cardWidth = Screen.width / manager.yourCards.Count;
        int q = 0;

        foreach(string cardName in cards.Keys)
        {
            RectTransform cardTran = cards[cardName].GetComponent<RectTransform>();

            cardTran.position = new Vector3(cardWidth * q, 100, 0);
            cardTran.sizeDelta = new Vector2(cardWidth, cardTran.rect.height);

            q++;
        }
    }


    public void ToggleSelectedCard(string name)
    {
        print("hello");

        manager.ToggleSpell(name);
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