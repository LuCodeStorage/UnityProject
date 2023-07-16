using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InjectionController : MonoBehaviour
{
    // 侵入判定用コライダー
    [SerializeField] ColliderCallReceiver injectionCol = null;
    // インジェクション対象オブジェクト
    [SerializeField] GameObject injectionObj = null;
    // インジェクション対象各コンポネート
    Rigidbody mySphRig = null;
    Transform mySphTfObj = null;
    // 親パーティクルコンポネート
    Transform rootTfObj = null;
    // 射出判定用
    bool isBallCatch = false;

    // Start is called before the first frame update
    void Start()
    {
        // 各コンポネート取得
        injectionCol.TriggerEnterEvent.AddListener(OnMySphereEnter);
        injectionCol.TriggerExitEvent.AddListener(OnMySphereExit);
        rootTfObj = this.gameObject.GetComponentInParent<Transform>();
        mySphRig = injectionObj.GetComponent<Rigidbody>();
        mySphTfObj = injectionObj.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isBallCatch == true)
        {
            StartCoroutine(InjectionBall());
        }
    }

    void OnMySphereEnter(Collider col)
    {
        if (col.gameObject.tag == "MainBall")
        {
            isBallCatch = true;
        }
    }

    void OnMySphereExit(Collider col)
    {
        if (col.gameObject.tag == "MainBall")
        {
            mySphRig.useGravity = true;
        }
    }

    IEnumerator InjectionBall()
    {
        isBallCatch = false;
        mySphTfObj.position = Vector3.Lerp(mySphTfObj.position, rootTfObj.transform.position, 20f * Time.deltaTime);
        mySphRig.useGravity = false;
        mySphRig.velocity = new Vector3(0, 0, 0);

        yield return new WaitForSeconds(1);

        mySphRig.velocity = new Vector3(-60f, 0, 0);
    }
}
