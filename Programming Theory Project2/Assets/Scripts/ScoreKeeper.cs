using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    private int score = 0;
    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        Add(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Add(int value)
    {
        score += value;
        scoreText.text = "Score: " + score;
    }
}
