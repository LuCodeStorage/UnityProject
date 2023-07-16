using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // 中心ターゲット
    [SerializeField] private GameObject target;
    // オフセット
    private Vector3 offset;
    // ズームベクトル
    Vector3 zoomVal = new Vector3();
    // ズーム量
    const float ZOOM_IN_VAL = 6f;
    const float ZOOM_OUT_VAL = 13.5f;
    bool isZoom = false;

    // Start is called before the first frame update
    void Start()
    {
        // ゲーム開始時点のカメラとターゲットの距離（オフセット）を取得
        offset = this.gameObject.transform.position - target.transform.position;
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0) == true)
        {
            isZoom = true;
            zoomVal = new Vector3(
                this.gameObject.transform.position.x,
                ZOOM_IN_VAL, 
                this.gameObject.transform.position.z);
            this.gameObject.transform.position = zoomVal;
            offset = new Vector3(
                offset.x, 
                this.gameObject.transform.position.y - target.transform.position.y, 
                offset.z);
        }

        if(Input.GetMouseButtonUp(0) == true)
        {
            zoomVal = new Vector3(
                this.gameObject.transform.position.x,
                ZOOM_OUT_VAL, 
                this.gameObject.transform.position.z);
            this.gameObject.transform.position = zoomVal;
                //Vector3.Lerp(zoomVal, this.gameObject.transform.position, 0.5f * Time.deltaTime);
            offset = new Vector3(offset.x, this.gameObject.transform.position.y - target.transform.position.y, offset.z);
            isZoom = false;
        }

    }

    /// <summary>
    /// プレイヤーが移動した後にカメラが移動するようにするためにLateUpdateにする。
    /// </summary>
    void LateUpdate()
    {
        if (isZoom == true)
        {
            // カメラの位置をターゲットの位置にオフセットを足した場所にする。
            this.gameObject.transform.position = target.transform.position + offset;
        }

        if (isZoom == false)
        {
            // カメラの位置をターゲットの位置にオフセットを足した場所にする。(Lerpによる補完移動)
            this.gameObject.transform.position = Vector3.Lerp(
                this.gameObject.transform.position, 
                target.transform.position + offset, 
                10f * Time.deltaTime);
        }
     }

}