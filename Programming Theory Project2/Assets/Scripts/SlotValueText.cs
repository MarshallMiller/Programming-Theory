using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotValueText : MonoBehaviour
{
    public static SlotValueText Instance;
    public GameObject SlotValueTextPrefab;

    // TODO: move these to another singleton or rename this one
    public AudioClip plasticSound;
    public AudioClip gruntSound;

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
