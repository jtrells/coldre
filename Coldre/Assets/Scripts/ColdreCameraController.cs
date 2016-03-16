using UnityEngine;
using System.Collections;

public class ColdreCameraController : MonoBehaviour
{
	public Transform target;
	public float lookSmooth = 0.09f;
	public Vector3 offsetFromTarget = new Vector3 (0, 6, -8);

	[System.Serializable]
	public class PositionSettings
	{
		public Vector3 targetPosOffset = new Vector3 (0, 0, 0);
		public float lookSmooth = 100f;
		public float distanceFromTarget = -8f;
		public float zoomSmooth = 100f;
		public float maxZoom = -2f;
		public float minZoom = -15f;

	}

	[System.Serializable]
	public class OrbitSettings
	{
		public float xRotation = -20f;
		public float yRotation = -180f;
		public float maxXRotation = 25f;
		public float minYRotation = -85f;
		public float vOrbitSmooth = 150f;
		public float hOrbitSmooth = 150f;
	}

	public PositionSettings position = new PositionSettings ();
	public OrbitSettings orbit = new OrbitSettings ();

	Vector3 targetPos = Vector3.zero;
	Vector3 destination = Vector3.zero;
	CharacterController characterController;
	float vOrbitInput,hOrbitInput,zoomInput,hOrbitSnapInput;
	float rotateVelocity = 0;

	// Use this for initialization
	void Start ()
	{
		SetCameraTarget (target);

		targetPos = target.position + position.targetPosOffset;
		destination = Quaternion.Euler (orbit.xRotation, orbit.yRotation, 0) * -Vector3.forward * position.distanceFromTarget;
		destination += targetPos;
		transform.position = destination;
	}
	
	// Update is called once per frame
	void Update ()
	{
		GetInput ();
		OrbitTarget ();
		ZoomInOnTarget ();
	}

	public void SetCameraTarget (Transform t)
	{
		target = t;

		if (target != null) {
			if (target.GetComponent<CharacterController> ()) {
				characterController = target.GetComponent<CharacterController> ();
			} else
				Debug.LogError ("The Camera's target needs a character conttoller.");
		} else
			Debug.LogError ("Camera needs a target");
	}

	void GetInput()
	{
		vOrbitInput = CAVE2Manager.GetButton (4,CAVE2Manager.Button.SpecialButton2)?1:0;
		if(vOrbitInput ==1)
		Debug.Log (vOrbitInput);
	}
	void LateUpdate ()
	{
		MoveToTarget ();
		LookAtTarget ();
	}

	void MoveToTarget ()
	{
//		targetPos = target.position + position.targetPosOffset;
//		destination = Quaternion.Euler (orbit.xRotation, orbit.yRotation, 0) * -Vector3.forward * position.distanceFromTarget;
//		destination += targetPos;
//		transform.position = destination;

		destination = characterController.TargetRotation () * offsetFromTarget;
		destination += target.position;
		transform.position = destination;
	}

	void LookAtTarget ()
	{
//		Quaternion targetRotation = Quaternion.LookRotation (targetPos - transform.position);
//		transform.rotation = Quaternion.Lerp (transform.rotation, targetRotation, position.lookSmooth * Time.deltaTime);

		float eulerYAngle = Mathf.SmoothDampAngle (transform.eulerAngles.y, target.eulerAngles.y, ref rotateVelocity, lookSmooth);
		transform.rotation = Quaternion.Euler (transform.eulerAngles.x, eulerYAngle, 0);
	}

	void OrbitTarget()
	{
	}

	void ZoomInOnTarget()
	{

	}
}
