using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class TitleUIHandler : MonoBehaviour
{
    private GameObject startMenu;
    [SerializeField] private GameObject selectionMenu;
    [SerializeField] private TMP_InputField nameInput;

    private void Start()
    {
        startMenu = GameObject.Find("Start Menu");
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void StartGame(int animalIndex)
    {
        MainManager.animalIndex = animalIndex;

        SceneManager.LoadScene(1);
    }

    public void StartClicked()
    {
        AssignName(nameInput.text);
        
        startMenu.SetActive(false);
        selectionMenu.SetActive(true);
    }

    private void AssignName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            MainManager.playerName = "Anon";
        }
        else
        {
            MainManager.playerName = Truncate(name, 15);
        }
    }

    private string Truncate(string name, int maxChars)
    {
        return name.Length <= maxChars ? name : name.Substring(0, maxChars);
    }
}
