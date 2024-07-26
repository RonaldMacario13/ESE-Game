using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbulanceController : MonoBehaviour
{
    [SerializeField] private DetectionController _detectionArea;
    private Animator _animator;
    private PlayerController playerController = new PlayerController();
    
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        if (_detectionArea.detectedObjs.Count > 0)
        {
            _animator.SetBool("isDetected", true);
            playerController._health = 10;
            print(playerController._health);
        } else if (_detectionArea.detectedObjs.Count == 0)
        {
            _animator.SetBool("isDetected", false);
        }
    }
}
