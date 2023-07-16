using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiPointText : MonoBehaviour
{
    // UIテキスト
    [SerializeField] GameObject uiTextObj = null;
    Text scoreText = null;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = uiTextObj.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = CoinController.pt.ToString();
    }
}
