using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Manages the end of the game.
/// </summary>
public class EndManager : MonoBehaviour
{
    [SerializeField] TMP_InputField inputFieldName;
    [SerializeField] Button button;
    [SerializeField] DifficultyManagger difficultyManagger;

    /// <summary>
    /// Called before the first frame update.
    /// </summary>
    void Start()
    {
        button.onClick.AddListener(SendValues);
    }

    /// <summary>
    /// Sends the input field value and difficulty level to the EndWriter component.
    /// </summary>
    void SendValues()
    {
        //var scriptableObject = ScriptableObject.CreateInstance<MoveData>();
        //GetComponent<EndWriter>().StoreData(inputFieldName.text, difficultyManagger.levels[difficultyManagger.dropdown.value]); //tutaj zaladowanie danych
        //DontDestroyOnLoad(scriptableObject);
        //SceneManager.LoadScene("EndingScreen");
    }
}
