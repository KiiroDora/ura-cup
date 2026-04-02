using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class RaceController : MonoBehaviour
{
    public static RaceController instance;

    public GameObject gate;

    public bool raceInProcess = false;

    private float time;
    public static TimeSpan raceTime;

    Camera mainCamera;


    void Awake()  // initialize
    {
        instance = this;
        time = 0;
        raceInProcess = false;
        mainCamera = Camera.main;
        mainCamera.orthographicSize = 5;
        mainCamera.gameObject.transform.position = new Vector3(0, 0, -10);
    }

    void Start()
    {
        StartCoroutine(StartRace());
    }

    void Update()
    {
        if (raceInProcess) 
        {
            time += Time.deltaTime;
            raceTime = TimeSpan.FromSeconds((int)time); 
        }
    }

    public IEnumerator StartRace()
    {
        UI_Controller.instance.countdownText.gameObject.SetActive(true);

        for (int i = 10; i >= 0; i--)  // countdown
        {
            yield return new WaitForSeconds(1f);
            UI_Controller.instance.ChangeCountdownText(i.ToString()); 
        }
        
        yield return new WaitForSeconds(1f);
        UI_Controller.instance.countdownText.gameObject.SetActive(false);
        gate.SetActive(false);
        raceInProcess = true;
    }

    public void EndRace(Horse horse)
    {
        raceInProcess = false;
        UI_Controller.instance.SetWinnerPanel(horse.horseData.name, horse.sprite);
    }
}
