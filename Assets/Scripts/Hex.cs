using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Hex : MonoBehaviour
{
    [SerializeField]
    private InputActionAsset InputAsset;

    public int x, y, z;
    public float red, blue;


    void OnEnable() => InputAsset.Enable();
    void OnDisable() => InputAsset.Disable();


    // Start is called before the first frame update
    void Start()
    {
        red = x / (float)Generate.hor;
        blue = z / (float)Generate.vert;
        GetComponent<Renderer>().material.color = new Color(red, 0, blue);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(
            InputAsset.FindAction("MoveCameraVertical").ReadValue<float>() / 4f +
            InputAsset.FindAction("MoveCameraTouchHorizontal").ReadValue<float>() / 40f, 0,
            -InputAsset.FindAction("MoveCameraHorizontal").ReadValue<float>() / 4f +
            InputAsset.FindAction("MoveCameraTouchVertical").ReadValue<float>() / 40f));

        //Wrapping around Z
        if (transform.position.z < -Generate.vert * 1.5f)//-30) //Z was 20
        {
            transform.SetPositionAndRotation(new Vector3(transform.position.x, 0, transform.position.z + Generate.vert * 1.5f), Quaternion.AngleAxis(90, Vector3.up));
        }
        if (transform.position.z > 0)
        {
            transform.SetPositionAndRotation(new Vector3(transform.position.x, 0, transform.position.z - 60.0f), Quaternion.AngleAxis(90, Vector3.up));
        }
        //Wrapping around X
        if (transform.position.x < 0)
        {
            transform.SetPositionAndRotation(new Vector3(transform.position.x + Generate.hor * 1.72f, 0, transform.position.z), Quaternion.AngleAxis(90, Vector3.up));
        }
        if (transform.position.x > Generate.hor * 1.72f)//70) // 40 
        {
            transform.SetPositionAndRotation(new Vector3(transform.position.x - Generate.hor * 1.72f, 0, transform.position.z), Quaternion.AngleAxis(90, Vector3.up));
        }
    }
}
