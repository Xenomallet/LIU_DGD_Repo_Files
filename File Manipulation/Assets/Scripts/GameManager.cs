using UnityEngine;
using UnityEngine.InputSystem;
using System.IO;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Variables
    private int score;

    // Hold score as a string
    public string inputNum;

    // Add input references for interacting with score and save
    public InputActionReference scorePlus;
    public InputActionReference save;
    public InputActionReference clear;

    // Set folder path
    private const string DIR_RES = "/Resources";
    // Set a file to read
    private const string FILE_SAVES = DIR_RES +  "/Saves.txt";
    // Create file path
    private string FILE_PATH_SAVES;

    // Add TMPro for previous and current scores
    public TextMeshProUGUI currentScore;
    public TextMeshProUGUI savedScores;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Declare file path
        FILE_PATH_SAVES = Application.dataPath + FILE_SAVES;

        // Set score
        score = 0;

        // Show all saved scores
        savedScores.text = File.ReadAllText(FILE_PATH_SAVES);
    }

    // Update is called once per frame
    void Update()
    {
        // Show score
        currentScore.text = "" + score;

        // When button pushed increase score
        if(scorePlus.action.WasPressedThisFrame())
        {
            score++;
        }

        // When button pushed run save
        if(save.action.WasPressedThisFrame())
        {
            SaveScore(score);
            score = 0;
            savedScores.text = File.ReadAllText(FILE_PATH_SAVES);
        }

        // If button pushed clear all saves
        if(clear.action.WasPressedThisFrame())
        {
            ClearSaves();
        }
    }

    // Saves score
    public void SaveScore(int s)
    {
        inputNum = s.ToString();

        string fileContents = File.ReadAllText(FILE_PATH_SAVES);
        fileContents += inputNum + "\n";
        File.WriteAllText(FILE_PATH_SAVES, fileContents);
    }

    // Clears saves
    public void ClearSaves()
    {
        File.WriteAllText(FILE_PATH_SAVES, "");
        savedScores.text = "";
    }
}
