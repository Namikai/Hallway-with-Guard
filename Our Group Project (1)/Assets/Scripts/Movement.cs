using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float mouseSpeed;
    private GameObject CameraRot;
    private float Y;
    private float X;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        CameraRot = Camera.main.gameObject;
    }

    void FixedUpdate()
    {
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");
        Vector3 movement = transform.rotation * new Vector3(moveH, 0, moveV);
        rb.AddForce(movement * Time.deltaTime * speed);

        Y += Input.GetAxis("Mouse X") * mouseSpeed;
        X += Input.GetAxis("Mouse Y") * mouseSpeed;
        X = Mathf.Clamp(X, -50f, 50f);
        transform.eulerAngles = new Vector3(0, Y, 0); //Rotation of the Boi
        CameraRot.transform.eulerAngles = new Vector3(-X, Y, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag ("pickup"))
        {
            SceneManager.LoadScene("WinScreen");
        }
        if (other.gameObject.CompareTag ("enemy"))
        {
            SceneManager.LoadScene("LoseScreen");
        }
    }
}
