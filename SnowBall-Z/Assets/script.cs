using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script : MonoBehaviour
{


    private void Update()
    {
        transform.position += Vector3.forward * 10 * Time.deltaTime;
    }
}
