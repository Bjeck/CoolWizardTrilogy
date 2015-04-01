using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SpellUIManager : MonoBehaviour {

    private static SpellUIManager _instance;

    public RectTransform spellPanel;

    public GameObject cardPrefab;

    private SpellManager manager = new SpellManager();

    private List<GameObject> cards = new List<GameObject>();

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
            Destroy(cards[i]);
            cards.RemoveAt(i);
        }

        float cardWidth = Screen.width / manager.yourCards.Count;

        for (int i = 0; i < manager.yourCards.Count; i++)
        {
            GameObject card = Instantiate(cardPrefab);

            RectTransform cardTran = card.GetComponent<RectTransform>();

            cardTran.position = new Vector3(cardWidth * i, 100, 0);

            cardTran.SetParent(spellPanel);

            string cardName = (manager.yourCards.Keys.ToList())[i];
            
            UnityEngine.UI.Button cardBut = card.GetComponent<UnityEngine.UI.Button>();
            cardBut.onClick.AddListener(() => { ToggleSelectedCard(cardName); ToggleSelectedCard(cardName); });

            cards.Add(card);
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