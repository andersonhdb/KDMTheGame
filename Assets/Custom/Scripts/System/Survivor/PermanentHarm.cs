using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PermanentHarm : MonoBehaviour
{
    private static int partsCount = 5;
    [SerializeField]
    private GameObject[] bodyParts = new GameObject[partsCount];

    [SerializeField]
    private ParticleSystem[] Blood = new ParticleSystem[partsCount];

    private bool[] bloodActive = new bool[partsCount];

    private float[] bleedTime = new float[partsCount];

    private float bleedTimeLimit = 2f;
    // Start is called before the first frame update
    void Start()
    {
        for (int i=0; i< partsCount; i++)
        {
            bloodActive[i] = false;
            bleedTime[i] = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0; i<partsCount; i++)
        {
            if (bloodActive[i])
            {
                bleedTime[i] += Time.deltaTime;
                if (bleedTime[i] >= bleedTimeLimit)
                {
                    Blood[i].Pause();
                    Blood[i].Clear();
                    bloodActive[i] = false;
                    bleedTime[i] = 0;
                }
            }
        }
    }

    public void Explode_member(int i)
    {
        bodyParts[i].SetActive(false);
        Blood[i].Play();
        bloodActive[i] = true;
    }
}
