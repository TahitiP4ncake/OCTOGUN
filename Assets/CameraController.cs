using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public List<GameObject> guns;

    public List<Vector3> origins;

    public GameObject gunTransform;

    [Space]

    public Camera cam;

    public float lerpSpeed;

    float camX;
    float camY;

    public float xSensi;
    public float ySensi;

    float x;
    float z;

    public float speed;

    Vector3 movement;

    [Space]

    public Rigidbody rb;

    

    void Start()
    {
        foreach (GameObject _gun in guns)
        {
            origins.Add(_gun.transform.position-transform.position);
        }
    }
    
    void FixedUpdate () 
	{
        MoveGuns();
	}
    
    void Update()
    {
        //CheckInput();
    }

    void CheckInput()
    {
        camX = Input.GetAxis("Mouse X");
        camY = Input.GetAxis("Mouse Y");

        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");

        Horizontal();
        Vertical();

        Move();
    }

    void Horizontal()
    {
        transform.Rotate(Vector3.up, camX * xSensi);
    }
    
    void Vertical()
    {
        transform.Rotate(transform.right, -camY * ySensi,Space.Self);
    }

    void Move()
    {
        movement = (transform.forward * z + transform.right * x).normalized * speed;
        movement.y = rb.velocity.y;
        rb.velocity = movement;
    }

    void MoveGuns()
    {
        for (int i = 0; i < guns.Count; i++)
        {
            guns[i].transform.position = Vector3.Lerp(guns[i].transform.position, transform.position + origins[i], lerpSpeed * Time.deltaTime);
        }
    }
}
