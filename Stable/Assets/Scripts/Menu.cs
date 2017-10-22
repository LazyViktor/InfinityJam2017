using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    public GameObject mainMenuHolder;
    public GameObject audioMenuHolder;
    public GameObject creditsMenuHolder;

    public Slider[] volumeSlider;

    void Start() {

    }


	public void Play() {
        SceneManager.LoadScene("Game");
	}

    public void Quit() {
        Application.Quit();
    }

    public void CreditsMenu() {
        mainMenuHolder.SetActive(false);
        audioMenuHolder.SetActive(false);
        creditsMenuHolder.SetActive(true);
    }

    public void AudioMenu() {
        mainMenuHolder.SetActive(false);
        audioMenuHolder.SetActive(true);
        creditsMenuHolder.SetActive(false);
    }

    public void MainMenu() {
        mainMenuHolder.SetActive(true);
        audioMenuHolder.SetActive(false);
        creditsMenuHolder.SetActive(false);
    }

    public void SetMasterVolume(float value) {
        
    }



}
