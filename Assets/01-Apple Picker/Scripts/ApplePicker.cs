using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class ApplePicker : MonoBehaviour
{
    public GameObject basketPrefab;

    public int numBaskets = 3;

    public float basketBottomY = -14;

    public float basketSpacingY = 2f;

    public List<GameObject> basketList;


    // Start is called before the first frame update
    void Start()
    {
        basketList = new List<GameObject>();

        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate(basketPrefab) as GameObject;

            Vector3 pos = Vector3.zero;

            pos.y = basketBottomY + (basketSpacingY * i);

            tBasketGO.transform.position = pos;

            basketList.Add(tBasketGO);  
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AppleDestroyed()
    {
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        
        int basketIndex = basketList.Count - 1;
        GameObject tBasketGO = basketList[basketIndex];
        basketList.RemoveAt(basketIndex);
        Destroy(tBasketGO);
    }
}
