using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    [SerializeField] Image panelPause;
    [SerializeField] Image pauseButton;
    [SerializeField] Image playImage;
    public static bool isPaused = false;
    public void Pause(){
        if(Time.timeScale == 1 && !isPaused){
            Time.timeScale = 0;
            panelPause.gameObject.SetActive(true);
            pauseButton.enabled = false;
            playImage.gameObject.SetActive(true);
            isPaused = true;
            Debug.Log("Pausado");
        }else if (Time.timeScale == 0 && isPaused){
            Time.timeScale = 1;
            panelPause.gameObject.SetActive(false);
            pauseButton.enabled = true;
            playImage.gameObject.SetActive(false);
            isPaused = false;
            Debug.Log("Play");
        }
    }
}
