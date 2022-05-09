using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Attack : MonoBehaviour
{
    [SerializeField] private string snowballPrefab;
    [SerializeField] private float throwForce;
    [SerializeField] private Transform muzzle;

    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject snowball = PhotonNetwork.Instantiate(snowballPrefab, muzzle.position, Quaternion.identity);
            snowball.GetComponent<Rigidbody>().AddForce(cam.transform.forward * throwForce, ForceMode.Impulse);
        }
    }
}
