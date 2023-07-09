using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour
{
    public Party adventurers;
    public Party monsters;
    public Balance balance;
    public void StartGame()
    {
        adventurers.Init();
        balance.gold = 50;
        DontDestroyOnLoad(gameObject);
        monsters.scale = 1f;
        SceneManager.LoadScene("Shop");
    }
}
