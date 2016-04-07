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
		public bool smoothFollow = true;
		public float smooth = 0.05f;

		[HideInInspector]
		public float adjustmentDistance = -8;
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

	[System.Serializable]
	public class DebugSettings
	{
		public bool drawDesiredCollisionLines = true;
		public bool drawAdjustedCollisionLines = true;
	}

	public PositionSettings position = new PositionSettings ();
	public OrbitSettings orbit = new OrbitSettings ();
	public DebugSettings debug = new DebugSettings ();
	public CollisionHandeler collision = new CollisionHandeler ();

	Vector3 targetPos = Vector3.zero;
	Vector3 destination = Vector3.zero;
	Vector3 adjustedDestination = Vector3.zero;
	Vector3 camVel = Vector3.zero;
	ColdreCharacterController characterController;
	float vOrbitInput,hOrbitInput,zoomInput,hOrbitSnapInput;
	float rotateVelocity = 0;

	// Use this for initialization
	void Start ()
	{
		if (target != null) {
			SetCameraTarget (target);

			MoveToTarget();

//			collision.Initialize(Camera.main);
//			collision.UpdateCameraClipPoints(transform.position, transform.rotation,ref collision.adjustedCameraClipPoints);
//			collision.UpdateCameraClipPoints(destination, transform.rotation,ref collision.desiredCameraClipPoints);

		}



	}
	
	// Update is called once per frame
	void Update ()
	{
		if (target != null) {
			GetInput ();
			OrbitTarget ();
			ZoomInOnTarget ();
		}
	}

	void FixedUpdate()
	{
//		collision.UpdateCameraClipPoints(transform.position, transform.rotation,ref collision.adjustedCameraClipPoints);
//		collision.UpdateCameraClipPoints(destination, transform.rotation,ref collision.desiredCameraClipPoints);
//
//		for (int i =0; i<5; i++) {
//		if(debug.drawDesiredCollisionLines)
//			{
//				Debug.DrawLine(targetPos,collision.desiredCameraClipPoints[i],Color.white);
//			}
//		if(debug.drawAdjustedCollisionLines)
//			{
//				Debug.DrawLine(targetPos,collision.adjustedCameraClipPoints[i],Color.green);
//			}
//		}
//
//		collision.CheckColliding (targetPos);
//		position.adjustmentDistance = collision.GetAdjustedDistanceWithRayFrom (targetPos);
	}

	public void SetCameraTarget (Transform t)
	{
		target = t;

		if (target != null) {
			if (target.GetComponent<ColdreCharacterController> ()) {
				characterController = target.GetComponent<ColdreCharacterController> ();
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
		if (target != null) {
			MoveToTarget ();
			LookAtTarget ();
		}
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


//		if (collision.colliding) {
//			adjustedDestination = Quaternion.Euler (orbit.xRotation, orbit.yRotation, 0) * -Vector3.forward * position.distanceFromTarget;;
//			adjustedDestination += targetPos;
//			
//			if(position.smoothFollow)
//			{
//				transform.position = Vector3.SmoothDamp(transform.position,adjustedDestination, ref camVel,position.smooth);
//			}
//			else
//				transform.position = adjustedDestination;
//		} else {
//			
//			if(position.smoothFollow)
//			{
//				transform.position = Vector3.SmoothDamp(transform.position,destination, ref camVel,position.smooth);
//				
//			}
//			else
//				transform.position = destination;
//		}
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



	[System.Serializable]
	public class CollisionHandeler
	{
		public LayerMask collisionLayer;

		[HideInInspector]
		public bool colliding = false;
		[HideInInspector]
		public Vector3[] adjustedCameraClipPoints;
		[HideInInspector]
		public Vector3[] desiredCameraClipPoints;

		Camera camera;

		public void Initialize(Camera cam)
		{
			camera = cam;
			adjustedCameraClipPoints = new Vector3[5];
			desiredCameraClipPoints = new Vector3[5];
		}

		bool CollisionDetectedAtClipPoints(Vector3[] clipPoints, Vector3 fromPosition)
		{
			for (int i =0; i<clipPoints.Length; i++) {
				Ray ray = new Ray(fromPosition,clipPoints[i] - fromPosition);
				float distance = Vector3.Distance(clipPoints[i],fromPosition);
				if(Physics.Raycast(ray,distance,collisionLayer))
				{
					return true;
				}
			}

			return false;
		}

		public void UpdateCameraClipPoints(Vector3 cameraPosition,Quaternion atRotation, ref Vector3[] intoArray)
		{
			if (!camera)
				return;
			intoArray = new Vector3[5];

			float z = camera.nearClipPlane;
			float x = Mathf.Tan (camera.fieldOfView / 3.41f) * z;
			float y = x / camera.aspect;

			intoArray [0] = (atRotation * new Vector3 (-x, y, z)) + cameraPosition;
			intoArray [1] = (atRotation * new Vector3 (x, y, z)) + cameraPosition;
			intoArray [2] = (atRotation * new Vector3 (-x, -y, z)) + cameraPosition;
			intoArray [3] = (atRotation * new Vector3 (x, -y, z)) + cameraPosition;
			intoArray [4] = cameraPosition - camera.transform.forward;

		}

		public float GetAdjustedDistanceWithRayFrom(Vector3 from)
		{
			float distance = -1;

			for (int i=0; i<desiredCameraClipPoints.Length; i++) {
				Ray ray = new Ray(from,desiredCameraClipPoints[i]-from);
				RaycastHit hit;
				if(Physics.Raycast(ray,out hit))
				{
					if(distance == -1)
						distance = hit.distance;
					else{
						if(hit.distance < distance)
							distance = hit.distance;
					}
				}
			}

			if (distance == -1)
				return 0;
			else
				return distance;
		}

		public void CheckColliding(Vector3 targetPosition)
		{
			if (CollisionDetectedAtClipPoints (desiredCameraClipPoints, targetPosition)) {
				colliding = true;
			} else {
				colliding = false;
			}


		}
	}


}
