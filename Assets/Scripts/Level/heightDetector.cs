using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heightDetector : MonoBehaviour
{
    public DayTimeManager dayTimeManager;
    private int skyIndex;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(HeightReached());
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
    // Start is called before the first frame update
    IEnumerator HeightReached()
    {
        skyIndex=dayTimeManager.timeIndex;
        dayTimeManager.SetTime(4);
        yield return new WaitForSeconds(1);
        dayTimeManager.SetTime(skyIndex);
        yield return null;
    }
}
