using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    TMP_InputField inputFieldName;
    TMP_Dropdown dropdown;

    // Start is called before the first frame update
    void Start()
    {
        LevelColection levelColection = LevelColection.LoadLevels("difficulty");
        //Debug.Log(levelColection.levels.Count);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
