using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DropDownLevelHandler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Text dropdownLabel;
    void Start()
    {

        Debug.Log("start scr");
        var dropdown = GetComponent<Dropdown>();
        dropdown.options.Clear();

        List<string> items = new List<string>();
        items.Add("Menu");
        items.Add("Level 1");
        items.Add("Level 2");
        items.Add("Level 3");
        items.Add("Level 4");

        // load item into dropdown
        foreach (var item in items)
        {
            dropdown.options.Add(new Dropdown.OptionData() { text = item });
        }

        dropdown.value = SceneManager.GetActiveScene().buildIndex;

        // load label into dropdown
        dropdownLabel.text = items[dropdown.value];


        // set event
        dropdown.onValueChanged.AddListener(delegate { OnDropdownItemSelected(dropdown); });
    }

    private void OnDropdownItemSelected(Dropdown dropdown)
    {

        int index = dropdown.value;

        PlayerPrefs.SetInt("dropdownindex", dropdown.value);

        Debug.Log( "on value change"+ dropdown.options[index].text);



        SceneManager.LoadScene(dropdown.value);
    }
}
