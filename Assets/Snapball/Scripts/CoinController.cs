using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    // 得点
    public static int pt = 0;

    // Start is called before the first frame update
    void Start()
    {
        ColliderCallReceiver coinTrigger = transform.GetChild(0).gameObject.GetComponent<ColliderCallReceiver>();
        coinTrigger.TriggerEnterEvent.AddListener(OnMySphereEnter);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMySphereEnter(Collider col)
    {
        if (col.gameObject.tag == "MainBall")
        {
            Destroy(this.gameObject);
            pt += 100;
        }
    }
}
