using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public GameObject mainMenuHolder;
    public GameObject audioMenuHolder;

	public void Play() {
        SceneManager.LoadScene("Game");
	}

    public void Quit() {
        Application.Quit();
    }

    public void AudioMenu() {
        mainMenuHolder.SetActive(false);
        audioMenuHolder.SetActive(true);
    }

    public void MainMenu() {
        mainMenuHolder.SetActive(true);
        audioMenuHolder.SetActive(false);
    }

    public void SetScreebResolution(int i){

    }

    public void SetFullscreen(bool isFullscreen){

    }

    public void SetMasterVolume(float value) {

    }



}
