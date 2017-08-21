﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour {

	public Image fadePlane;
	public GameObject gameOverUI;
    public RectTransform newWaveBanner;
    public Text newWaveTitle;
    public Text newWaveEnemyCount;

    Spawner spawner;
    private void Awake()
    {
        spawner = FindObjectOfType<Spawner>();
        spawner.OnNewWave += OnNewWave;
    }
    void OnNewWave(int waveNumber)
    {
        string[] numbers = { "One", "Two", "Three" };
        newWaveTitle.text = "- Wave " + numbers[waveNumber - 1] + " -";
        string enemyCountString = spawner.waves[waveNumber - 1].enemyCount + "";
        newWaveEnemyCount.text = "Enemies: " + enemyCountString;
        StopCoroutine("AnimateNewWaveBanne");
        StartCoroutine(AnimateNewWaveBanner());
    }
    void Start ()
    {
		FindObjectOfType<Player> ().OnDeath += OnGameOver;
	}

	void OnGameOver() {
		StartCoroutine(Fade (Color.clear, Color.black,1));
		gameOverUI.SetActive (true);
	}

	IEnumerator Fade(Color from, Color to, float time) {
		float speed = 1 / time;
		float percent = 0;

		while (percent < 1) {
			percent += Time.deltaTime * speed;
			fadePlane.color = Color.Lerp(from,to,percent);
			yield return null;
		}
	}
    IEnumerator AnimateNewWaveBanner()
    {
        float delayTime = 1.5f; //화면에 올라오고나서 딜레이후 내려감.
        float speed = 3f; //움직이는 속도.
        float animaterPercent = 0;
        int dir = 1;

        float endDelayTime = Time.time + 1 / speed + delayTime; //현재 시점의 시간

        while(animaterPercent >=0)
        {
            animaterPercent += Time.deltaTime * speed * dir;
            if(animaterPercent >=1)
            {
                animaterPercent = 1;
                if(Time.time >endDelayTime)
                {
                    dir = -1;
                }
            }
            newWaveBanner.anchoredPosition = Vector2.up * Mathf.Lerp(-170, 45, animaterPercent);
            yield return null;
        }
    }
	// UI Input
	public void StartNewGame() {
		SceneManager.LoadScene ("Game");
	}
}
