using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameCanvas : MonoBehaviour
{
    private static GameCanvas _instance;
    public static GameCanvas instance => _instance;

    [SerializeField] GameStatsUI statsUi;
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

    public void UpdateStats(int item1, int item2, int item3, int item4)
    {
        statsUi.UpdateUiScore(item1, item2, item3, item4);
    }

}
