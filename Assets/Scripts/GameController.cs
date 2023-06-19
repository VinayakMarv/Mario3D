using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    public int totalCoins,collectedCoins;
    public int totalStars, collectedStars;
    public int totalMainStars, collectedMainStars;
    public GameObject MenuPanel;
    public TMP_Text coins, stars, mainStars;
    public Transform[] CoinLoc, StarLoc, MainStarLoc;
    public GameObject CoinPrefab, StarPrefab, MainStarPrefab;
    public static GameController Instance;
    //public StarterAssets.StarterAssetsInputs InputMouse;
    //GamePlay
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        int num = Random.RandomRange(0, 10);
        for(int i=0; i<totalCoins; i++)
        {
            Instantiate(CoinPrefab, CoinLoc[(num + i) % CoinLoc.Length]);
        }
        for (int i = 0; i < totalStars; i++)
        {
            Instantiate(StarPrefab, StarLoc[(num + i) % StarLoc.Length]);
        }
        for (int i = 0; i < totalMainStars; i++)
        {
            Instantiate(MainStarPrefab, MainStarLoc[(num + i) % MainStarLoc.Length]);
        }
    }
    private void Start()
    {
        coins.text = "Coins : " + "0/" + totalCoins.ToString();
        stars.text = "Stars : " +  "0/" + totalStars.ToString();
        mainStars.text = "Main Star : " + "0/" + totalMainStars.ToString();
    }
    public void CoinCollect()
    {
        collectedCoins++;
        coins.text = "Coins : " + collectedCoins.ToString() + "/" + totalCoins.ToString();
        StartCoroutine(GameFinish());
    }
    public void StarCollect()
    {
        collectedStars++;
        stars.text = "Stars : " + collectedStars.ToString() + "/" + totalStars.ToString();
        StartCoroutine(GameFinish());
    }
    public void MainStarCollect()
    {
        collectedMainStars++;
        mainStars.text = "Main Star : " + collectedMainStars.ToString() + "/" + totalMainStars.ToString();
        StartCoroutine(GameFinish());
    }
    public IEnumerator GameFinish()
    {
        yield return null;
        if(totalCoins==collectedCoins && totalMainStars==collectedMainStars && totalStars == collectedStars)
        {
            yield return new WaitForSeconds(1.5f);
            Menu();
        }
    }
    //Menu
    public void Menu()
    {
        Time.timeScale = 0;
        MenuPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }
    public void Resume()
    {
        Time.timeScale = 1;
        MenuPanel.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
