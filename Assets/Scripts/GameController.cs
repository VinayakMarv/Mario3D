using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    public StarterAssets.StarterAssetsInputs InputMouse;
    //GamePlay
    private void Awake()
    {
        int num = Random.RandomRange(0, totalCoins - 1);
        for(int i=0; i<totalCoins; i++)
        {
            Instantiate(CoinPrefab, CoinLoc[(num + i) % CoinLoc.Length]);
        }
        num = Random.RandomRange(0, totalStars - 1);
        for (int i = 0; i < totalStars; i++)
        {
            Instantiate(StarPrefab, StarLoc[(num + i) % StarLoc.Length]);
        }
        num = Random.RandomRange(0, totalMainStars - 1);
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
        GameFinish();
    }
    public void StarCollect()
    {
        collectedStars++;
        stars.text = "Stars : " + collectedStars.ToString() + "/" + totalStars.ToString();
        GameFinish();
    }
    public void MainStarCollect()
    {
        collectedMainStars++;
        mainStars.text = "Main Star : " + collectedMainStars.ToString() + "/" + totalMainStars.ToString();
        GameFinish();
    }
    public void GameFinish()
    {
        if(totalCoins==collectedCoins && totalMainStars==collectedMainStars && totalStars == collectedStars)
        {
            Menu();
        }
    }
    //Menu
    public void Menu()
    {
        Time.timeScale = 0;
        MenuPanel.SetActive(true);
        InputMouse.cursorLocked = false;
    }
    public void Resume()
    {
        Time.timeScale = 1;
        MenuPanel.SetActive(false);
        InputMouse.cursorLocked = true;
    }
    public void Exit()
    {
        Application.Quit();
    }
}
