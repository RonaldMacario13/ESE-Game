using System.Collections.Generic;
using UnityEngine;

public class DetectionController : MonoBehaviour
{
    private string tagTargetDetection = "Player";

    public List<Collider2D> detectedObjs = new List<Collider2D>();

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == tagTargetDetection)
        {
            detectedObjs.Add(other);
        }
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == tagTargetDetection)
        {
            detectedObjs.Remove(other);
        }
    }

}
