using UnityEngine;
using TMPro;

public class Pontos : MonoBehaviour
{
    public TMP_Text textoPontos;

    void Update()
    {
        textoPontos.text = PlayerPrefs.GetInt("score", 0).ToString();
    }

    public void RespostaCorreta()
    {
        int score = PlayerPrefs.GetInt("score", 0);
        score++;
        PlayerPrefs.SetInt("score", score);
    }
}