using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySphereController : MonoBehaviour
{
    // 操作ベクトル表示矢印
    [SerializeField] LineRenderer arrow = null;
    // 操作フラグ
    public bool IsControll = true;
    // マウスドラッグ操作用座標変数
    Vector3 startMousePosition = new Vector3();
    Vector3 endMousePosition = new Vector3();
    // 自オブジェクト位置
    Vector3 myPos = new Vector3();
    // 自射出速度係数
    const float SNAP_SPEED_COEFFICIENT = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsControll == true)
        {
            OnMouseDownSnapSphere();
            OnMouseDragSnapSphere();
            OnMouseUpSnapSphere();
        }
    }

    void FixedUpdate()
    {

    }

    private void OnMouseDownSnapSphere()
    {
        if (Input.GetMouseButtonDown(0) == true)
        {
            Time.timeScale = 0.3f;
            startMousePosition = Input.mousePosition;
            this.arrow.enabled = true;

            myPos = new Vector3(this.transform.position.x, 0, this.transform.position.y);

            this.arrow.SetPosition(0, myPos);
            this.arrow.SetPosition(1, myPos);
        }
    }

    private void OnMouseDragSnapSphere()
    {
        if (Input.GetMouseButton(0) == true)
        {
            endMousePosition = Input.mousePosition;

            if (startMousePosition != endMousePosition)
            {
                Vector3 startWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(startMousePosition.x, 0, startMousePosition.y));
                Vector3 endWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(endMousePosition.x, 0, endMousePosition.y));

                float vectorX = (endWorldPos.x - startWorldPos.x);
                float vectorZ = (endWorldPos.z - startWorldPos.z);

                this.arrow.SetPosition(0, transform.InverseTransformPoint(this.transform.position));
                this.arrow.SetPosition(1, new Vector3(vectorX, 0, -vectorZ));
            }
        }
    }

    private void OnMouseUpSnapSphere()
    {
        if (Input.GetMouseButtonUp(0) == true)
        {
            this.arrow.enabled = false;
            endMousePosition = Input.mousePosition;

            Vector3 startWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(startMousePosition.x, 0, startMousePosition.y));
            Vector3 endWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(endMousePosition.x, 0, endMousePosition.y));

            float vectorX = (endWorldPos.x - startWorldPos.x);
            float vectorZ = (endWorldPos.z - startWorldPos.z);

            Rigidbody mySphereRigidbody = gameObject.GetComponent<Rigidbody>();
            mySphereRigidbody.velocity = new Vector3(vectorX, 0, -vectorZ) * SNAP_SPEED_COEFFICIENT;
            Time.timeScale = 1f;
        }
    }
}
