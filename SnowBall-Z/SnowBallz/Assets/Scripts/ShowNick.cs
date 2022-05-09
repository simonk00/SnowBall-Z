using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
public class ShowNick : MonoBehaviour
{
    string nickname;

    PhotonView view;
    TextMeshPro tmp;


    // Start is called before the first frame update
    void Start()
    {
        nickname = view.Owner.NickName;
        tmp = GetComponent<TextMeshPro>();
        tmp.text = nickname;
    }

   
}
