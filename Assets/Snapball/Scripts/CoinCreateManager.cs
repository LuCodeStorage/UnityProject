using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCreateManager : MonoBehaviour
{
    // 座標値_MAX
    const float MAX_X = -15.5f;
    const float MAX_Z = 9.5f;
    // 座標値_MIN
    const float MIN_X = 5f;
    const float MIN_Z = -9f;
    // 座標値_y座標
    const float y = 1.4f;
    // 経過時間
    private float time;
    // 生成時間
    private float createTime = 2.0f;
    //
    [SerializeField] GameObject coinPrefab = null;
    private List<GameObject> gameObjects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        for(var i = 0; i<=5; i++ )
        {
            CoinCreate();
        }
    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;

        if(time > createTime)
        {
            CoinCreate();
            time = 0f;
        }
    }

    void CoinCreate()
    {
        // ランダム座標生成
        float x = Random.Range(MIN_X, MAX_X);
        float z = Random.Range(MIN_Z, MAX_Z);

        Instantiate(coinPrefab, new Vector3(x, y, z), coinPrefab.transform.rotation);
    }
}
