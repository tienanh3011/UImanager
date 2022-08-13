using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public bool isGameOver=false;
    public GameObject popupGameOver;
    public PhysicMove player;

    private void Update()
    {
        if(player.isDead)
        {
            isGameOver = true;
        }
        if (isGameOver)
        {
            popupGameOver.SetActive(true);
        }

    }
    public void OnClickPlay()
    {
        Debug.Log("---------Click Play");
    }
    public void OnClickRestart()
    {
        SceneManager.LoadScene("DEmo2");
    }
}
