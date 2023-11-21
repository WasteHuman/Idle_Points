using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScaleChanger : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static ScaleChanger Instance;

    private GameObject pointObject;
    private GameObject totalClickObj;
    private GameObject totalBonusObj;

    [SerializeField]
    private bool isBonusPurchased = false;

    public Transform canvasTransform;

    public GameObject pointPrefab;
    public GameObject totalClickObjPrefab;
    public GameObject totalBonusObjPrefab;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        if (GameLogic.Instance.totalBonusIncome != 0f)
        {
            isBonusPurchased = true;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        gameObject.transform.localScale = new Vector3(0.85f, 0.85f, 0.85f);

        //Спавн по клику Point Object'а
        Vector3 pos = new Vector3(Random.Range(-113f, 113f), Random.Range(-135f, 135f), transform.position.z);
        totalClickObj = Instantiate(totalClickObjPrefab, pos, Quaternion.identity);
        totalClickObj.transform.SetParent(canvasTransform, false);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
    }

    public IEnumerator SpawnPoints()
    {
        while (!isBonusPurchased)
        {
            yield return null;
        }

        while (isBonusPurchased)
        {
            Vector3 pos = new Vector3(Random.Range(-113f, 113f), Random.Range(-135f, 135f), transform.position.z);
            totalBonusObj = Instantiate(totalBonusObjPrefab, pos, Quaternion.identity);
            totalBonusObj.transform.SetParent(canvasTransform, false);
            yield return new WaitForSeconds(1f);
        }
    }
}
