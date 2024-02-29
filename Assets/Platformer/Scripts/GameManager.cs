using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI coinText;
    public int coinScore = 0;
    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int intTime = 100 - (int)Time.realtimeSinceStartup;
        if(intTime <= 0){
            intTime = 0;
            Debug.Log("Time Ran Out");
        }
        string timeStr = $"TIME\n{intTime}";
        timerText.text = timeStr;

        // Check for mouse click
        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray from the mouse position into the scene
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            // Check if the ray hits something
            if (Physics.Raycast(ray, out hit))
            {
                // Debug.Log("Hit Object Name: " + hit.collider.gameObject.name);
                // If hit a brick
                if(hit.collider.gameObject.name == "Brick(Clone)")
                {
                    Destroy(hit.collider.gameObject);
                    score += 100;
                    scoreText.text = $"MARIO\n{score}";
                }
                // If hit a '?'
                if(hit.collider.gameObject.name == "Question(Clone)")
                {
                    coinScore++;
                    coinText.text = $"<sprite=0>x{coinScore}";
                    score += 100;
                    scoreText.text = $"MARIO\n{score}";
                }
            }
        }
    }
}
