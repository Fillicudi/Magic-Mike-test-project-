using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  

public class UI_base : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public void SetScoreText(int score)
    {
        scoreText.text = score.ToString();
    }
}
