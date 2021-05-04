using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour
{
    public GameObject hex;
    public static int vert = 20, hor = 40;
    private GameObject[,] hexlist = new GameObject[hor, vert];
    //public GameObject[,] minihexlist = new GameObject[40, 20];
    public float vertCorr = 0.75f, horCorr = 0.86f;
    void Start()
    {
        for (int i = 0; i < hor; i++)
        {
            for (int j = 0; j < vert; j++)
            {
                if (j % 2 == 0)
                {
                    hexlist[i, j] = Instantiate(hex, new Vector3(2 * i * horCorr, 0, -2 * j * vertCorr), Quaternion.AngleAxis(90, Vector3.up)) as GameObject;
                    hexlist[i, j].transform.SetParent(transform);
                    hexlist[i, j].GetComponent<Hex>().x = i;
                    hexlist[i, j].GetComponent<Hex>().z = j;
                    hexlist[i, j].GetComponent<Hex>().y = -i - j;
                }
                else
                {
                    hexlist[i, j] = Instantiate(hex, new Vector3(horCorr * 2 * i + horCorr, 0, -2 * j * vertCorr), Quaternion.AngleAxis(90, Vector3.up)) as GameObject;
                    hexlist[i, j].transform.SetParent(transform);
                    hexlist[i, j].GetComponent<Hex>().x = i;
                    hexlist[i, j].GetComponent<Hex>().z = j;
                    hexlist[i, j].GetComponent<Hex>().y = -i - j;
                }
            }
        }
        //spawned
    }

    // Update is called once per frame
    void Update()
    {

    }
}
