using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{

	public float speed = 3f;
	public float maxControlledSpeed = 5f;
	public static Rigidbody rb;
	private float distToFloor;
	public Vector3 direction;
	public Vector3 relativeDirection;
	public Vector3 actSped;
	public Camera playerCam;
	private float xPlayDirec, yPlayDirec;
	AudioSource playerSounds;
	public AudioClip playerJump;
	public AudioClip playerRoll;
	Scene lastScene;

	private bool isPlayerGrounded()
	{
		return Physics.Raycast(transform.position, -Vector3.up, distToFloor + 0.1f);
	}

	// Start is called before the first frame update
	void Start()
	{
		playerCam = Camera.main;
		rb = GetComponent<Rigidbody>();
		distToFloor = GetComponent<Collider>().bounds.extents.y;
		playerSounds = GetComponent<AudioSource>();
		DataSaved.setLastSceneName(SceneManager.GetActiveScene());

	}

	// Update is called once per frame
	void Update()
	{

		//Players moves
		playerMovement();

		//Players jump and double jump. Possibly move the isGrounded check to second if statement so rays aren't casted on each frame
		if (Input.GetKeyDown(KeyCode.Space) && isPlayerGrounded())
		{

			rb.AddForce(0, 500, 0, ForceMode.Force);
			jumpSoundPlay();
		}
		/* Double jump in contruction
		else if (Input.GetKeyDown(KeyCode.Space) && !isPlayerGrounded() && (transform.InverseTransformDirection(rb.velocity).y > -1.0f && transform.InverseTransformDirection(rb.velocity).y < 1.0f) && !hasDoubleJumped)
		{
			hasDoubleJumped = true;
		}

		//Controls the double jump behavior
		if (hasDoubleJumped && isPlayerGrounded())
		{
			hasDoubleJumped = false;
			rb.AddForce(0, 600, 0, ForceMode.Force);
		}
		*/

	}

	void playerMovement()
	{
		xPlayDirec = Input.GetAxis("VerticalPlayer");

		yPlayDirec = Input.GetAxis("HorizontalPlayer");

		direction = new Vector3(yPlayDirec, 0f, xPlayDirec);

		relativeDirection = playerCam.transform.TransformVector(direction);
		relativeDirection.y = 0f;
		actSped = rb.velocity;

		if (Mathf.Abs(actSped.magnitude) < 5)
		{
			rb.AddTorque(relativeDirection * -speed, ForceMode.Force);
		}

		/**if (isPlayerGrounded() && Mathf.Abs(actSped.magnitude) > 0)
        {
			rollSoundPlay();
        }
        else
        {
			stopSound();
        }*/
	}


	void jumpSoundPlay()
    {
		playerSounds.loop = false;
		playerSounds.volume = 1f;
		playerSounds.clip = playerJump;
		playerSounds.Play();
    }

	void rollSoundPlay()
    {
		playerSounds.loop = true;
		playerSounds.clip = playerRoll;
		playerSounds.Play();
    }

	void stopSound()
    {
		playerSounds.Stop();
    }
}