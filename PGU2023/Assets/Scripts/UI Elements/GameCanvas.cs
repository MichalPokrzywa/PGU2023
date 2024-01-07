using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameCanvas : MonoBehaviour
{
    private static GameCanvas _instance;
    public static GameCanvas instance => _instance;

    [SerializeField] GameStatsUI statsUi;
    [SerializeField] Button endButton;
    [SerializeField] CardShowUI cardShowUI;
    void Start()
    {
        endButton.onClick.AddListener(SendValuesToEnd);
    }
    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void UpdateStats(int item1, int item2, int item3, int item4, int item5, int item6, int item7)
    {
        statsUi.UpdateUiScore(item1, item2, item3, item4, item5, item6, item7);
    }

    public void ShowCard(CardObject cardObject)
    {
        cardShowUI.UpdateCard(cardObject);
        cardShowUI.gameObject.SetActive(true);
    }

    public void HideCard()
    {
        cardShowUI.gameObject.SetActive(false);
    }
    public void SendValuesToEnd()
    {
        GameManager manager = GameManager.instance;
        GetComponent<EndWriter>().StoreData(manager.totalApartment,manager.totalCost,manager.totalBiodegradable,manager.totalTree);
        SceneManager.LoadScene("EndingScreen");

    }

}
