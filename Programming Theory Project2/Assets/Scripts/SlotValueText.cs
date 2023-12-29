using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotValueText : MonoBehaviour
{
    public static SlotValueText Instance;
    public GameObject SlotValueTextPrefab;

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null)
        {
            //Destroy(gameObject);
            return;
        }

        Instance = this;
        //DontDestroyOnLoad(gameObject);
    }
}
