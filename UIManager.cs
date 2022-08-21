using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public bool isGameOver=false;
    public GameObject popupGameOver;
    public Player player;
    public Slider hpBar;
    public TextMeshProUGUI txtHighScore;
    public GameObject fruitPrefab;
    public float spawnNum = 5f;
    public float spawnDelay = 5f;
    public bool isGamePlay = false;
    public GameObject PopupOption;
    public GameObject PopupAbout;
    private GameObject currentpopup;

    private void Awake()
    {
        if(SceneManager.GetActiveScene().name.Equals("DEmo2"))
        {
            isGamePlay = true;
        }
    }
    private void Start()
    {
        if (isGamePlay)
        {
            InvokeRepeating("SpawnFruit", spawnNum, spawnDelay);//ham goi nhieu lan invokerepeating
        }
        else
        {
            Debug.Log("========== Main menu");
            PopupAbout.SetActive(false);
            PopupOption.SetActive(false);
        }
    }
    void SpawnFruit()
    {
        var randomX = Random.Range(-10f, 30f);
        var randomY = Random.Range(-3f, 5f);
        var fruit = Instantiate(fruitPrefab);//sinh ra ngau nhien
        //fruit.transform.SetParent();
        fruit.transform.position = new Vector2(randomX, randomY);
    }
    private void Update()
    {
        if (!isGamePlay) return;

        if(player.isDead)
        {
            isGameOver = true;
        }
        if (isGameOver)
        {
            popupGameOver.SetActive(true);
            var highscore = PlayerPrefs.GetInt("highscore", 0);
            txtHighScore.text = "High Score " + highscore;
        }
        hpBar.value = (float)player.HP / 100f;

    }
    public void OnClickPlay()
    {
        Debug.Log("---------Click Play");
        SceneManager.LoadScene("DEmo2");

    }
    public void OnClickRestart()
    {
        SceneManager.LoadScene("DEmo2");
    }
    public void OnClickOption()
    {
        PopupOption.SetActive(true);
        currentpopup = PopupOption;
    }
    public void OnClickAbout()
    {
        PopupAbout.SetActive(true);
        currentpopup = PopupAbout;
    }
    public void OnClickBack()
    {
        if(currentpopup!=null)
        {
            currentpopup.SetActive(false);
        }
    }
}
