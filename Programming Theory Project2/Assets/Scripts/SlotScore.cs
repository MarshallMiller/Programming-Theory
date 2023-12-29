using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SlotScore : MonoBehaviour
{
    public int value;
    public ScoreKeeper scoreKeeper;
    public TextMeshProUGUI slotValueText;

    // Start is called before the first frame update
    void Start()
    {
        scoreKeeper = GameObject.Find("ScoreController").GetComponent<ScoreKeeper>();
        GameObject slotValueGameObject = Instantiate(SlotValueText.Instance.SlotValueTextPrefab);
        slotValueGameObject.transform.position = transform.position;
        slotValueGameObject.transform.SetParent(transform);
        slotValueText = slotValueGameObject.GetComponentInChildren<TextMeshProUGUI>();
        slotValueText.text = "" + value;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter2D(Collider2D other)
	{
        scoreKeeper.Add(value);
        
        StartCoroutine(DestroyOnTimer(other.gameObject));
	}

    private IEnumerator DestroyOnTimer(GameObject obj)
    {
        yield return new WaitForSeconds(5);
        Destroy(obj);
    }
}
