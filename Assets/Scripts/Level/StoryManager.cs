using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    public DayTimeManager DayTimeManager;
    public appleManager appleManager;
    public GameObject ballObject;
    public TMPro.TMP_Text Subtitle;

    private bool hasWashed = false;
    private bool hasPlayed = false;
    private bool hasEaten = false;  

    void Start()
    {
        StartCoroutine(MainStory());
        bedNightSkipper.onSleep += OnSleep; 
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
        // Subscribe to the event
        appleManager.onEaten += SetEaten;
        spawnBall();
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
        Subtitle.SetText("Well done");
        NoNeedToEat();

        //night 1 
        yield return new WaitForSeconds(5);
        Subtitle.SetText("Now I have to go to sleep");
        DayTimeManager.SetTime(3);
        //bedNightSkipper automatically sets the skybox and the index through Daytime manager

        //morning 2


    }

}
