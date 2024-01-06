using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] public TMP_Dropdown dropdown;

    void Start()
    {
        dropdown.onValueChanged.AddListener(OnDropdownValueChanged);
        PlayerPrefs.SetInt("characterType", 0);

    }
    private void OnDropdownValueChanged(int index)
    {
        PlayerPrefs.SetInt("characterType", index);
    }
}
