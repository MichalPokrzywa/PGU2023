using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Represents the UI element that displays game statistics.
/// </summary>
public class GameStatsUI : MonoBehaviour
{
    List<TMP_Text> texts = new List<TMP_Text>();

    [SerializeField] GameObject statsValues;

    /// <summary>
    /// Called before the first frame update.
    /// </summary>
    void Start()
    {
        foreach (var text in statsValues.GetComponentsInChildren<TMP_Text>())
        {
            texts.Add(text);
        }
    }

    /// <summary>
    /// Updates the UI with the specified score values.
    /// </summary>
    /// <param name="item1">The value of item 1.</param>
    /// <param name="item2">The value of item 2.</param>
    /// <param name="item3">The value of item 3.</param>
    /// <param name="item4">The value of item 4.</param>
    public void UpdateUiScore(int item1, int item2, int item3, int item4)
    {
        texts[0].text = item1.ToString();
        texts[1].text = item2.ToString();
        texts[2].text = item3.ToString();
        texts[3].text = item4.ToString();
    }
}
