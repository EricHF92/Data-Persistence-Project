using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
// If the game is ran in unity editor
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI HighScoreText;

    public GameObject playerName;

    void Start()
    {
        LoadHighScore();
    }

    /// <summary>
    /// Handle start button click event
    /// </summary>
    public void startGame()
    {
        GetPlayerName();
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// Handle quit button click event
    /// </summary>
    public void quitGame()
    {
        // Exit playmode if in Unity
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        // Quit game if built
        #else
            Application.Quit();
        #endif
    }

    /// <summary>
    /// Loads saved data and updates highscore text
    /// </summary>
    private void LoadHighScore()
    {
        GameManager.Instance.LoadHighScore();
        HighScoreText.text = "High Score: " + GameManager.Instance.Name + " " + GameManager.Instance.HighScore;
    }

    /// <summary>
    /// Gets player name from the user input and sets it equal to temp name
    /// </summary>
    private void GetPlayerName()
    {
        string name = playerName.GetComponent<TMP_InputField>().text;
        GameManager.Instance.CurrentName = name;
    }

    /// <summary>
    /// Resets saved high score by adding "Player" and 0
    /// </summary>
    public void ResetHighScore()
    {
        GameManager.Instance.Name = "Player";
        GameManager.Instance.HighScore = 0;
        GameManager.Instance.SaveHighScore();
        HighScoreText.text = "High Score: " + GameManager.Instance.Name + " " + GameManager.Instance.HighScore;
    }
}
