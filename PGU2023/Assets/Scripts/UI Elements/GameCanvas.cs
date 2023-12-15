using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Represents the canvas used for displaying game UI elements.
/// </summary>
public class GameCanvas : MonoBehaviour
{
    private static GameCanvas _instance;
    public static GameCanvas instance => _instance;

    [SerializeField] GameStatsUI statsUi;
    [SerializeField] Button endButton;

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

    /// <summary>
    /// Updates the displayed stats on the UI.
    /// </summary>
    /// <param name="item1">The value of item 1.</param>
    /// <param name="item2">The value of item 2.</param>
    /// <param name="item3">The value of item 3.</param>
    /// <param name="item4">The value of item 4.</param>
    public void UpdateStats(int item1, int item2, int item3, int item4)
    {
        statsUi.UpdateUiScore(item1, item2, item3, item4);
    }

    /// <summary>
    /// Sends the values to the ending screen and loads it.
    /// </summary>
    public void SendValuesToEnd()
    {
        GameManager manager = GameManager.instance;
        GetComponent<EndWriter>().StoreData(manager.totalCost,manager.totalValue,manager.totalInterest,manager.totalFunctionality);
        SceneManager.LoadScene("EndingScreen");
    }
}
