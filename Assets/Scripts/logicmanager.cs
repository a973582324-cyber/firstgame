using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class logicmanager: MonoBehaviour
{
    public Text scoretext;
    public Text highesttext;
    public GameObject Gameoverscreen;

    public int score = 0;
    private int maxscore = 0;

    public void Awake()
    {
        Time.timeScale = 1f;
        maxscore = PlayerPrefs.GetInt("maxscore", 0);
        highesttext.text = "最高分:" + maxscore.ToString();
    }
    
    public void addscore()
    {
        score++;
        scoretext.text = score.ToString();
        if (score > maxscore)
        {
            maxscore = score;
            PlayerPrefs.SetInt("maxscore", maxscore);
            PlayerPrefs.Save();
            highesttext.text = "最高分:" + maxscore.ToString();
        }

    }
    public void restartgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
       
    }
    public void gameover()
    {
        Time.timeScale = 0f;
        Gameoverscreen.SetActive(true);
    }
}
