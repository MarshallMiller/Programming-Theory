using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PulsatingPeg : PegController
{
    float pegMaxSize = .5f;
    float pegMinSize = .25f;
    public float pegCurSize = 1;
    float pegChangeRate = 0.4f;
    bool isPulsing = false;

	private void Update()
	{
        if (isPulsing)
        {
            pegCurSize += pegChangeRate * Time.deltaTime;
            if (pegCurSize < pegMinSize)
            {
                pegCurSize = pegMinSize;
                pegChangeRate = -pegChangeRate;
            }
            else if (pegCurSize > pegMaxSize)
            {
                pegCurSize = pegMaxSize;
                pegChangeRate = -pegChangeRate;
            }
            transform.localScale = new Vector3(pegCurSize, pegCurSize, 1);
        }
	}

	public override void Hit()
	{
        isPulsing = !isPulsing;
	}
	public override string audioPath
    {
        get
        {
            return Path.Combine(Application.dataPath, "Audio", "grunt.ogg");
        }
    }

    public override void InitColor()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.color = Color.red;
    }

}
