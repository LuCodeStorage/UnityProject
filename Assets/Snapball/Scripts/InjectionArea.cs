using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InjectionArea : MonoBehaviour
{
    // 侵入判定用コライダー
    [SerializeField] ColliderCallReceiver injectionAreaCol = null;
    // 自操作ボールオブジェクト
    [SerializeField] MySphereController mySphere = null;

    // Start is called before the first frame update
    void Start()
    {
        injectionAreaCol.TriggerEnterEvent.AddListener(OnMySphereAreaEnter);
        injectionAreaCol.TriggerExitEvent.AddListener(OnMySphereAreaExit);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMySphereAreaEnter(Collider sphereCol)
    {
        if (sphereCol.gameObject.tag == "MainBall")
        {
            mySphere.IsControll = false;
        }
    }

    void OnMySphereAreaExit(Collider sphereCol)
    {
        if (sphereCol.gameObject.tag == "MainBall")
        {
            mySphere.IsControll = true;
        }
    }
}
