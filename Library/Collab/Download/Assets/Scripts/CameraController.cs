using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public float rotationSpeed = 1;
	public Transform Player, Focus, LookThrough;
	float xDirec, yDirec;
    float zoom = 2f;
    private Rigidbody camrb;

    // Start is called before the first frame update
    void Start()
    {
        camrb = GetComponent<Rigidbody>();
        LookThrough = Focus;
    }

    // LateUpdate is called after update
    void LateUpdate()
    {
        cameraMovement();
        thingInWay();
      

	}

    void cameraMovement()
    {

        xDirec += Input.GetAxis("Horizontal") * rotationSpeed;
        yDirec -= Input.GetAxis("Vertical") * rotationSpeed;
        yDirec = Mathf.Clamp(yDirec, -30f, 10f);

        transform.LookAt(Focus);

        Focus.rotation = Quaternion.Euler(-yDirec, -xDirec, 0);

    }



    void thingInWay()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position, Focus.position - transform.position, out hit, 3f))
        {
            if(hit.collider.gameObject.tag != "Player" && hit.collider.gameObject.tag != "Finish" && hit.collider.tag != "MovingPlatform")
            {
                LookThrough = hit.transform;
                LookThrough.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;

                if(Vector3.Distance(LookThrough.position, transform.position) >= 2.5f && Vector3.Distance(Focus.position, transform.position)>= 1f)
                {
                    transform.Translate(Vector3.forward * zoom * Time.deltaTime);
                }
            }
            else
            {
                LookThrough.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
                if(Vector3.Distance(transform.position, Focus.position) < 3f)
                {
                    transform.Translate(Vector3.back * zoom * Time.deltaTime);
                }

            }
        }
    }
}
