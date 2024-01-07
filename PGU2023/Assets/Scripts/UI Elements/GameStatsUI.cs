using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStatsUI : MonoBehaviour
{
    List<TMP_Text> texts = new List<TMP_Text>();

    [SerializeField] GameObject statsValues;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var text in statsValues.GetComponentsInChildren<TMP_Text>())
        {
            texts.Add(text);
        }
    }

    public void UpdateUiScore(int item1,int item2,float item3,int item4, float item5, float item6, int item7)
    {
        texts[0].text = item1.ToString();
        texts[1].text = item2.ToString();
        texts[2].text = MathF.Round(item3, 3).ToString();
        texts[3].text = item4.ToString();
        texts[4].text = MathF.Round(item5, 3).ToString();
        texts[5].text = MathF.Round(item5, 3).ToString();
        texts[6].text = item7.ToString();
        ;
    }

}
