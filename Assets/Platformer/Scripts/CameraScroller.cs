using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScroller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(verticalInput, 0f, 0f);
        transform.Translate(moveDirection * 8f * Time.deltaTime);
    }
}
