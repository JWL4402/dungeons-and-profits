using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PartyScript : MonoBehaviour
{
    public Party adventurers;
    public Party monsters;
    // Start is called before the first frame update
    void Start()
    {
        adventurers.Init();
        monsters.Init();
    }

    [ContextMenu("a")]
    public void a()
    {
        SceneManager.LoadScene("Battle");

    }
}
