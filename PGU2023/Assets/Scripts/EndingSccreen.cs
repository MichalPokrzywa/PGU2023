using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Represents the ending screen of the game.
/// </summary>
public class EndingSccreen : MonoBehaviour
{
    [SerializeField] TMP_Text cost;
    [SerializeField] TMP_Text value;
    [SerializeField] TMP_Text intrest;
    [SerializeField] TMP_Text functionality;
    [SerializeField] TMP_Text nickname;
    [SerializeField] Image diffImage;
    [SerializeField] GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        cost.text = GetComponent<EndComsumer>().endData.cost.ToString();
        value.text = GetComponent<EndComsumer>().endData.value.ToString();
        intrest.text = GetComponent<EndComsumer>().endData.intrest.ToString();
        functionality.text = GetComponent<EndComsumer>().endData.functionality.ToString();

        nickname.text = GetComponent<EndComsumer>().data.nickname.ToString();
        diffImage.sprite = Resources.Load<Sprite>(GetComponent<EndComsumer>().data.level.IconLevelPath);
    }
}
