using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotScore : MonoBehaviour
{
    public int value;
    public ScoreKeeper scoreKeeper;

    // Start is called before the first frame update
    void Start()
    {
        scoreKeeper = GameObject.Find("ScoreController").GetComponent<ScoreKeeper>();
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
