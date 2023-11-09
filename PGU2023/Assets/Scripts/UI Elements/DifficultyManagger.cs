using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyManagger : MonoBehaviour
{
    [SerializeField] public TMP_Dropdown dropdown;
    [SerializeField] public Image levelImage;
    [SerializeField] public TMP_Text levelText;
    public List<Level> levels;
    // Start is called before the first frame update
    void Start()
    {
        dropdown.onValueChanged.AddListener(OnDropdownValueChanged);
        levels = LevelColection.LoadLevels("difficulty");
        // Accessing TMP_Dropdown options
        List<TMP_Dropdown.OptionData> dropdownOptions = new List<TMP_Dropdown.OptionData>();
        foreach (var level in levels)
        {
            TMP_Dropdown.OptionData option = new TMP_Dropdown.OptionData(level.Name, Resources.Load<Sprite>(level.IconLevelPath));
            dropdownOptions.Add(option);
        }
        // Setting TMP_Dropdown options
        dropdown.ClearOptions();
        dropdown.AddOptions(dropdownOptions);
        dropdown.value = 0;
        OnDropdownValueChanged(0);
    }
    private void OnDropdownValueChanged(int index)
    {
        // Check if the selected index is within the bounds of the levels list
        if (index >= 0 && index < levels.Count)
        {
            // Set the level image based on the selected level
            levelImage.sprite = Resources.Load<Sprite>(levels[index].IconLevelPath);
            levelText.text = levels[index].Description;
        }
    }

}
