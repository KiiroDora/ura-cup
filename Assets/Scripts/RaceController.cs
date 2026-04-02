using System;
using System.Collections;
using UnityEngine;

public class RaceController : MonoBehaviour
{
    public static RaceController instance;

    public GameObject gate;

    public bool raceInProcess = false;

    private float time;
    public static TimeSpan raceTime;

    public AudioSource neigh;
    public AudioSource bgm;
    public AudioSource winBGM;
    public AudioSource announcer;
    public AudioClip[] announcerLines;

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

        announcer.clip = announcerLines[11];
        announcer.Play();

        for (int i = 10; i >= 0; i--)  // countdown
        {
            yield return new WaitForSeconds(1f);
            announcer.clip = announcerLines[i];
            announcer.Play();
            UI_Controller.instance.ChangeCountdownText(i.ToString()); 
        }

        announcer.clip = announcerLines[0];
        announcer.Play();
        UI_Controller.instance.ChangeCountdownText("GO"); 
        yield return new WaitForSeconds(1f);
        UI_Controller.instance.countdownText.gameObject.SetActive(false);
        gate.SetActive(false);
        raceInProcess = true;
        bgm.Play();
    }

    public IEnumerator EndRace(Horse horse)
    {
        GameObject[] horses = GameObject.FindGameObjectsWithTag("Horse");
        foreach (GameObject h in horses)
        {
            h.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        }
        bgm.Stop();
        neigh.Play();
        yield return new WaitForSeconds(2f);
        winBGM.Play();
        raceInProcess = false;
        UI_Controller.instance.SetWinnerPanel(horse.horseData.name, horse.sprite);
    }
}
