using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndManager : MonoBehaviour
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
        //var scriptableObject = ScriptableObject.CreateInstance<MoveData>();
        //GetComponent<EndWriter>().StoreData(inputFieldName.text, difficultyManagger.levels[difficultyManagger.dropdown.value]); //tutaj zaladowanie danych
        //DontDestroyOnLoad(scriptableObject);
        //SceneManager.LoadScene("EndingScreen");
    }
}
