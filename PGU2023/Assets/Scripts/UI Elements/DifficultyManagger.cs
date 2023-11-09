using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DifficultyManagger : MonoBehaviour
{
    [SerializeField] TMP_InputField inputFieldName;
    [SerializeField] TMP_Dropdown dropdown;

    List<Level> levels;
    // Start is called before the first frame update
    void Start()
    {
        levels = LevelColection.LoadLevels("difficulty");
        //Debug.Log(levelColection.levels.Count);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
