using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject discPrefab;
    private GameObject disc;
    private float leftRight;
    public float leftBound;
    public float rightBound;
    public float dropHeight;
    public float moveSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        CreateDisc();
    }

    // Update is called once per frame
    void Update()
    {
        leftRight = Input.GetAxis("Horizontal");
        disc.transform.position += new Vector3(moveSpeed * Time.deltaTime * leftRight, 0, 0);

        bool drop = Input.GetKeyDown(KeyCode.Space);
        if (drop)
        {
            disc.GetComponent<Rigidbody2D>().gravityScale = 1;
            CreateDisc();
        }
    }

    private void CreateDisc()
    {
        disc = Instantiate(discPrefab);
        disc.transform.position = new Vector3(Random.Range(leftBound, rightBound), dropHeight);
        disc.GetComponent<Rigidbody2D>().gravityScale = 0;
    }
}
