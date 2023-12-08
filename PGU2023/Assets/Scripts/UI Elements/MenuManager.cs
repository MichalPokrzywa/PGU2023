using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Manages the menu functionality in the game.
/// </summary>
public class MenuManager : MonoBehaviour
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
    /// Sends the input field value and selected difficulty level to the Writer component.
    /// </summary>
    void SendValues()
    {
        var scriptableObject = ScriptableObject.CreateInstance<MoveData>();
        GetComponent<Writer>().StoreData(inputFieldName.text, difficultyManagger.levels[difficultyManagger.dropdown.value]);
        DontDestroyOnLoad(scriptableObject);
        SceneManager.LoadScene("FinalGarage");
    }
}
