using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelParser : MonoBehaviour
{
    public string filename;
    public Transform environmentRoot;

    [Header("Block Prefabs")]
    public GameObject rockPrefab;
    public GameObject brickPrefab;
    public GameObject questionBoxPrefab;
    public GameObject stonePrefab;
    public GameObject waterPrefab;
    public GameObject goalPrefab;
    
    // --------------------------------------------------------------------------
    void Start()
    {
        LoadLevel();
    }

    // --------------------------------------------------------------------------
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadLevel();
        }
    }

    // --------------------------------------------------------------------------
    private void LoadLevel()
    {
        string fileToParse = $"{Application.dataPath}{"/Resources/"}{filename}.txt";
        Debug.Log($"Loading level file: {fileToParse}");

        Stack<string> levelRows = new Stack<string>();

        // Get each line of text representing blocks in our level
        using (StreamReader sr = new (fileToParse))
        {
            while (sr.ReadLine() is { } line)
            {
                levelRows.Push(line);
            }

            sr.Close();
        }

        // Use this variable in the todo code
        int row = 0;

        // Go through the rows from bottom to top
        while (levelRows.Count > 0)
        {
            string currentLine = levelRows.Pop();

            char[] letters = currentLine.ToCharArray();
            for (var col = 0; col < letters.Length; col++)
            {
                var letter = letters[col];
                // Todo - Instantiate a new GameObject that matches the type specified by letter
                // Todo - Position the new GameObject at the appropriate location by using row and column
                // Todo - Parent the new GameObject under levelRoot
                Vector3 newPos = new Vector3(col, row, 0f);
                if(letter == 'x'){
                    
                    Instantiate(rockPrefab, newPos, Quaternion.identity, environmentRoot);
                } else if (letter == 'b'){
                    Instantiate(brickPrefab, newPos, Quaternion.identity, environmentRoot);
                } else if (letter == 's'){
                    Instantiate(stonePrefab, newPos, Quaternion.identity, environmentRoot);
                } else if (letter == '?'){
                    Instantiate(questionBoxPrefab, newPos, Quaternion.identity, environmentRoot);
                } else if (letter == 'w'){
                    Instantiate(waterPrefab, newPos, Quaternion.identity, environmentRoot);
                } else if (letter == 'g'){
                    Instantiate(goalPrefab, newPos, Quaternion.identity, environmentRoot);
                }
            }
            row++;
        }
    }

    // --------------------------------------------------------------------------
    private void ReloadLevel()
    {
        foreach (Transform child in environmentRoot)
        {
           Destroy(child.gameObject);
        }
        LoadLevel();
    }
}
