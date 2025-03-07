using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    public DayTimeManager DayTimeManager;
    public appleManager appleManager;
    public GameObject ballObject;
    public TMPro.TMP_Text Subtitle;
    public GameObject endpanel;
    public audioManaer audioManager;

    private bool hasWashed = false;
    private bool hasPlayed = false;
    private bool hasEaten = false;
    public bool closedTask = false;


    void Start()
    {
        StartCoroutine(MainStory());
        bedNightSkipper.onSleep += OnSleep;
        UIManager.onTaskClosed += SetTask;
    }

    public void spawnBall()
    {
        Instantiate(ballObject, new Vector3(10,3,10), Quaternion.identity);
    }

    //Water Events
    private void NeedToWash()
    {
        Subtitle.SetText("I have to wash");
        hasWashed = false;
        // Subscribe to the event
        water.OnWash += SetWashed;
    }
    private void NoNeedToWash()
    {
        // Unsubscribe from the event
        water.OnWash -= SetWashed;
    }
    private void SetWashed()
    {
        // Set the flag to true when the event is invoked
        hasWashed = true;
    }

    //Ball events
    private void NeedToPlay()
    {
        Subtitle.SetText("I have to play with the ball.");
        hasPlayed = false;
        // Subscribe to the event
        ball.onPlayed += SetPlayed;
        spawnBall();
    }
    private void NoNeedToPlay()
    {
        // Unsubscribe from the event
        ball.onPlayed -= SetPlayed;
    }
    private void SetPlayed()
    {
        // Set the flag to true when the event is invoked
        hasPlayed = true;
    }

    //Apple event
    private void NeedToEat()
    {
        Subtitle.SetText("I have to eat 5 apples.");
        hasEaten = false;
        appleManager.applesEaten = 0;
        appleManager.SpawnApples(appleManager.appleLoc);
        // Subscribe to the event
        appleManager.onEaten += SetEaten;
    }
    private void NoNeedToEat()
    {
        // Unsubscribe from the event
        appleManager.onEaten -= SetEaten;
    }
    private void SetEaten()
    {
        // Set the flag to true when the event is invoked
        hasEaten = true;
    }

    //task Events
    private void SetTask()
    {
        // Set the flag to true when the event is invoked
        closedTask = true;
    }


    private void OnSleep()
    {

    }


    IEnumerator MainStory()
    {
        Subtitle.SetText("Ah. Good morning!");

        //morning 1
        yield return new WaitForSeconds(5);
        NeedToWash();
        yield return new WaitUntil(() => hasWashed);
        NoNeedToWash();
        Subtitle.SetText("Nice.");

        //day 1
        audioManager.PlaySFX(audioManager.crokensky);
        DayTimeManager.SetTime(4);
        yield return new WaitForSeconds(1);
        DayTimeManager.SetTime(1);

        NeedToPlay();
        yield return new WaitUntil(() => hasPlayed);
        NoNeedToPlay();
        Subtitle.SetText("Good job.");

        //evening 1
        DayTimeManager.SetTime(2);
        NeedToEat();
        yield return new WaitUntil(() => hasEaten);
        Subtitle.SetText("Well done.");
        NoNeedToEat();

        //night 1 
        yield return new WaitForSeconds(3);
        Subtitle.SetText("Now I have to go to sleep. Find the bed.");
        DayTimeManager.SetTime(3);
        yield return new WaitUntil(() => closedTask);
        //bedNightSkipper automatically sets the skybox and the index through Daytime manager

        //morning 2
        DayTimeManager.SetTime(0);
        Subtitle.SetText("Good morning! Time to get washed.");
        NeedToWash();
        yield return new WaitUntil(() => hasWashed);
        NoNeedToWash();

        //day 2
        DayTimeManager.SetTime(1);
        Subtitle.SetText("Okay. New apples have grown.");
        yield return new WaitForSeconds(3);
        Subtitle.SetText("Go and collect the apples.");
        NeedToEat();
        yield return new WaitUntil(() => hasEaten);
        NoNeedToEat();

        //evening 2
        DayTimeManager.SetTime(2);
        Subtitle.SetText("Now I have time to play with the ball.");
        NeedToPlay();
        yield return new WaitUntil(() => hasPlayed);
        NoNeedToPlay();

        //night 2
        DayTimeManager.SetTime(3);
        yield return new WaitForSeconds(3);
        Subtitle.SetText("Now I have to go to sleep.");
        DayTimeManager.SetTime(3);
        yield return new WaitUntil(() => closedTask);
        //bedNightSkipper automatically sets the skybox and the index through Daytime manager

        //morning 3
        DayTimeManager.SetTime(0);
        Subtitle.SetText("Wash.");
        NeedToWash();
        yield return new WaitUntil(() => hasWashed);
        NoNeedToWash();

        //day 3 - corrupted task
        DayTimeManager.SetTime(4);
        //skybox is broken
        audioManager.PlaySFX(audioManager.crokensky);
        Subtitle.SetText("Now i have to eat.");
        yield return new WaitForSeconds(3);
        audioManager.PlaySFX(audioManager.crokensky);
        Subtitle.SetText("There are no apples.");
        yield return new WaitForSeconds(3);
        audioManager.PlaySFX(audioManager.crokensky);
        Subtitle.SetText("I'm going to starve.");
        yield return new WaitForSeconds(5);

        //evening 3
        //skybox is broken
        audioManager.PlaySFX(audioManager.crokensky);
        Subtitle.SetText("The sun is setting now.");
        yield return new WaitForSeconds(3);
        Subtitle.SetText("No ball...");
        yield return new WaitForSeconds(3);

        //night 3
        //sky is still broken
        Subtitle.SetText("i can't sleep.");
        yield return new WaitForSeconds(3);
        Subtitle.SetText("Let's stargaze.");
        yield return new WaitForSeconds(3);
        Subtitle.SetText("I've never noticed the sky's beauty.");
        yield return new WaitForSeconds(10);


        //morning 4
        Subtitle.SetText("I think it's morning now.");
        yield return new WaitForSeconds(3);
        audioManager.PlaySFX(audioManager.crokensky);
        Subtitle.SetText("Wash in the pond.");

        NeedToWash();
        yield return new WaitUntil(() => hasWashed);
        NoNeedToWash();
        Subtitle.SetText("Nice.");
        yield return new WaitForSeconds(3);

        //day 4
        audioManager.PlaySFX(audioManager.crokensky);
        Subtitle.SetText("Wash in the pond.");

        NeedToWash();
        audioManager.PlaySFX(audioManager.crokensky);
        yield return new WaitUntil(() => hasWashed);
        NoNeedToWash();
        Subtitle.SetText("Nice.");
        yield return new WaitForSeconds(3);

        //evening 4
        Subtitle.SetText("Wash in the pond.");

        NeedToWash();
        audioManager.PlaySFX(audioManager.crokensky);
        yield return new WaitUntil(() => hasWashed);
        NoNeedToWash();
        Subtitle.SetText("Nice.");
        yield return new WaitForSeconds(3);

        //night 4
        audioManager.PlaySFX(audioManager.crokensky);
        DayTimeManager.SetTime(5);
        yield return new WaitForSeconds(0.1f);
        DayTimeManager.SetTime(4);
        yield return new WaitForSeconds(0.5f);
        DayTimeManager.SetTime(5);
        endpanel.SetActive(true);
        yield return new WaitForSeconds(10);
        Application.Quit();
    }

}
