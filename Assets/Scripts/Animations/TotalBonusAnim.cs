using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalBonusAnim : MonoBehaviour
{
    private Text pointObject;
    private float moveSpeed = 4.5f;

    void Start()
    {
        pointObject = GetComponent<Text>();
        pointObject.text = "+" + FormatNumbers.FormatNumber(GameLogic.Instance.totalBonusIncome);
        Destroy(gameObject, 0.75f);
    }

    void Update()
    {
        pointObject.color = new Color(pointObject.color.r, pointObject.color.g, pointObject.color.b, Mathf.PingPong(Time.time / 2.5f, 1.0f));

        transform.position += transform.up * Time.deltaTime * moveSpeed;
    }
}
