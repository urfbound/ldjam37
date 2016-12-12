using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour {
    public GameObject scoringText;
    public GameObject directionsText;

    private void Setup()
    {
        scoringText.SetActive(false);
        directionsText.SetActive(false);
    }

	public void startGame()
    {
        SceneManager.LoadScene("game1");
    }
    public void directions()
    {
        scoringText.SetActive(false);
        directionsText.SetActive(true);
    }
    public void scoring()
    {
        directionsText.SetActive(false);
        scoringText.SetActive(true);
    }
    public void quit()
    {

    }
}
