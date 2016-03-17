using UnityEngine;
using System.Collections;

public class ColdreCharacterController : MonoBehaviour
{

	[System.Serializable]
	public class MoveSettings
	{
		public float forwardVelocity = 12;
		public float rotateVelocity = 100;
		public float jumpVelocity = 25;
		public float distToGrounded = 0.1f;
		public LayerMask ground;
	}

	[System.Serializable]
	public class PhysSettings
	{
		public float downAccelaration = 0.75f;
	}

	[System.Serializable]
	public class InputSettings
	{
		public float inputDelay = 0.1f;
	}


	public MoveSettings moveSettings = new MoveSettings ();
	public PhysSettings physSettings = new PhysSettings ();
	public InputSettings inputSettings = new InputSettings ();


	Vector3 velocity = Vector3.zero;
	Quaternion targetRotation;
	Rigidbody rBody;
	float forwardInput, turnInput, jumpInput;

// Use this for initialization
	void Start ()
	{
		targetRotation = transform.rotation;

		if (GetComponent<Rigidbody> ())
			rBody = GetComponent<Rigidbody> ();
		else
			Debug.LogError ("No Rigidbody attachted");

		forwardInput = turnInput = 0;
	}

// Update is called once per frame
	void Update ()
	{

		GetInput ();
		Turn ();
	}

	void FixedUpdate ()
	{
		Run ();
		Jump ();

		rBody.velocity = transform.TransformDirection (velocity);;
	}

	void GetInput ()
	{
		forwardInput = CAVE2Manager.GetAxis (1, CAVE2Manager.Axis.LeftAnalogStickUD);
		turnInput = CAVE2Manager.GetAxis (1, CAVE2Manager.Axis.LeftAnalogStickLR);
		//jumpInput = CAVE2Manager.GetButton (1, CAVE2Manager.Button.Button7) ? 1 : 0;
		jumpInput = CAVE2Manager.GetButton (1, CAVE2Manager.Button.Button3) ? 1 : 0;


		//jumpInput = Input.GetAxis("Jump_Trigger");

	}

	void Run ()
	{
		if (Mathf.Abs (forwardInput) > inputSettings.inputDelay) {
			velocity.z = moveSettings.forwardVelocity * forwardInput;
		} else
			velocity.z = 0;
	}

	void Turn ()
	{
		if (Mathf.Abs (turnInput) > inputSettings.inputDelay) {
			targetRotation *= Quaternion.AngleAxis (moveSettings.rotateVelocity * turnInput * Time.deltaTime, Vector3.up);
		}
		transform.rotation = targetRotation;


	}

	void Jump()
	{
		if (jumpInput > 0 && Grounded ()) {
			velocity.y = moveSettings.jumpVelocity;
		}
		else if (jumpInput == 0 && Grounded ()) {
			velocity.y=0;
		}
		else {
			velocity.y -= physSettings.downAccelaration;
		}
	}

	public Quaternion TargetRotation ()
	{
		return targetRotation;
	}

	bool Grounded()
	{
		return Physics.Raycast(transform.position,Vector3.down,moveSettings.distToGrounded,moveSettings.ground);
	}
}
