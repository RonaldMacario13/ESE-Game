using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumpsterController : MonoBehaviour
{

    [SerializeField] private DetectionController _detectionArea;
    private Animator _animator;
    public AudioSource audioSourceClosingDoor;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_detectionArea.detectedObjs.Count > 0)
        {
            if (Input.GetKeyDown("c"))
            {
                audioSourceClosingDoor.Play();
                _animator.SetBool("isPressed", true);
            }
        }
    }
}
