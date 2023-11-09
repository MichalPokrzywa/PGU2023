using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] TMP_InputField inputFieldName;
    [SerializeField] Button button;
    [SerializeField] DifficultyManagger difficultyManagger;
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(SendValues);
    }

    // Update is called once per frame
    void SendValues()
    {
        
    }
}
