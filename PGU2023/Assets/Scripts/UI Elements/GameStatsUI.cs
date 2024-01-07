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

    public void UpdateUiScore(int item1,int item2,int item3,int item4)
    {
        texts[0].text = item1.ToString();
        texts[1].text = item2.ToString();
        texts[2].text = item3.ToString();
        texts[3].text = item4.ToString();
        
    }

}
