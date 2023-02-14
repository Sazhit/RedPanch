using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerDied : MonoBehaviour
{
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _player;
    [SerializeField] private TextMeshProUGUI _highscore;

    private void Start()
    {
        Time.timeScale = 1;
        _player.SetActive(true);
        _menu.SetActive(false);
    }

    public void Death()
    {
        OpenMenu();
    }

    private void OpenMenu()
    {
        ScoreController.instance.CheckNewHigscore();
        _highscore.text = ScoreController.instance.ScoreText.text;
        Time.timeScale = 0;
        _player.SetActive(false);
        _menu.SetActive(true);
    }
} 
