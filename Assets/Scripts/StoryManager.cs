using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    public DayTimeManager DayTimeManager;
    public appleManager appleManager;
    public GameObject ball;
    public TMPro.TMP_Text Subtitle;

    private bool hasWashed = false;

    void Start()
    {
        StartCoroutine(MainStory());
    }

    public void spawnBall()
    {
        Instantiate(ball, new Vector3(10,3,10), Quaternion.identity);
    }

    private void OnEnable()
    {
        // Subscribe to the event
        water.OnWash += HandleTrigger;
    }

    private void OnDisable()
    {
        // Unsubscribe from the event
        water.OnWash -= HandleTrigger;
    }

    private void HandleTrigger()
    {
        // Set the flag to true when the event is invoked
        hasWashed = true;
    }

    IEnumerator MainStory()
    {
        Subtitle.SetText("Ah. Good morning!");

        //morning 1
        yield return new WaitForSeconds(5);
        hasWashed = false ;
        Subtitle.SetText("I have to wash");
        yield return new WaitUntil(() => hasWashed);

        //day 1
        Subtitle.SetText("Nice.");
        DayTimeManager.SetTime(4);
    }

}
