using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField] TextMeshProUGUI killCounterTMP, gameOverCount;
    [SerializeField] GameObject spawnRateTMP;
    [HideInInspector] public int killCount;
    private Animator anim;
    [HideInInspector] public bool gameOver = false;
    [SerializeField] GameObject GameOverTMP;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        anim = spawnRateTMP.GetComponent<Animator>();
        GameOverTMP.SetActive(false);
        AudioListener.volume = 1;
    }

    public void UpdateKillCounterUI()
    {
        killCounterTMP.text = killCount.ToString();
    }

    public void DisplaySpawnRateIncrease()
    {
        anim.SetBool("rateIncrease", true);
    }

    public void GameOver()
    {
        gameOver = true;
        Destroy(GameObject.FindWithTag("KillCounter"));
        GameOverTMP.SetActive(true);
        gameOverCount.text = killCount.ToString();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

}
