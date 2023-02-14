using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPause : Menu
{
    [SerializeField] private GameObject _menu;

    private void Start()
    {
        CloseMenu();
    }

    public void OnButtonResum()
    {
        Time.timeScale = 1;
        CloseMenu();
    }

    public void OpenMenu()
    {
        _menu.SetActive(true);
        Time.timeScale = 0;
    }

    public void CloseMenu()
    {
        _menu.SetActive(false);
    }
}
