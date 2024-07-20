using System.Collections.Generic;
using UnityEngine;

public class DetectionController : MonoBehaviour
{
    private readonly string tagTargetDetection = "Player";

    public List<Collider2D> detectedObjs = new();

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag(tagTargetDetection))
        {
            detectedObjs.Add(other);
        }
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag(tagTargetDetection))
        {
            detectedObjs.Remove(other);
        }
    }
}
