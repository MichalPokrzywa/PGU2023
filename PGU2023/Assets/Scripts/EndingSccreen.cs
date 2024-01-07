using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndingSccreen : MonoBehaviour
{
    [SerializeField] TMP_Text cost;
    [SerializeField] TMP_Text nickname;
    [SerializeField] Image diffImage;
    [SerializeField] Button button;
    // Start is called before the first frame update
    void Start()
    {
        //cost.text = GetComponent<EndComsumer>().endData.cost.ToString();
        //value.text = GetComponent<EndComsumer>().endData.value.ToString();
        //intrest.text = GetComponent<EndComsumer>().endData.intrest.ToString();
        //functionality.text = GetComponent<EndComsumer>().endData.functionality.ToString();
        cost.text = GetComponent<EndComsumer>().endData.endScore.ToString();
        nickname.text = GetComponent<EndComsumer>().data.nickname.ToString();
        //diffImage.sprite = Resources.Load<Sprite>(GetComponent<EndComsumer>().data.level.IconLevelPath);
        button.onClick.AddListener(delegate { GoMenu();});

    }

    void GoMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
