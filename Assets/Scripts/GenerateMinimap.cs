using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMinimap : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject minihex;
    public float vertCorr = 0.17f, horCorr = 0.02f;
    public GameObject[,] minihexlist = new GameObject[Generate.hor, Generate.vert];
    void Start()
    {
        for (int i = 0; i < Generate.hor; i++)
        {
            for (int j = 0; j < Generate.vert; j++)
            {
                if (j % 2 == 0)
                {
                    minihexlist[i, j] = Instantiate(minihex, new Vector3(transform.position.x + 2 * i * horCorr, transform.position.y + 0, transform.position.z + (-2 * j * vertCorr)), Quaternion.AngleAxis(90, Vector3.up)) as GameObject;
                }
                else
                {
                    minihexlist[i, j] = Instantiate(minihex, new Vector3(transform.position.x + horCorr * 2 * i + horCorr, transform.position.y + 0, transform.position.z + (-2 * j * vertCorr)), Quaternion.AngleAxis(90, Vector3.up)) as GameObject;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
