using UnityEngine;
using System.Collections;

public class FSMAI : MonoBehaviour {


	public float speed=1.0f;
	public bool horizontal =false;
	public float factor = 1;
	private Vector3 initialPos;


	public enum State
	{
		Idle,
		Action,
		Checking,
		VisualCue
	}

	private State _state;

	public State state {
		get
		{
			return _state;
		}
		set
		{
			ExitState(_state);
			_state = value;
			EnterState(_state);
		}
	
	}
	void Awake()
	{
		state = State.Idle;
	}

	void EnterState(State stateEntered)
	{
		switch (stateEntered) 
		{
			case State.Idle:
				StopCoroutine("Oscillate");
			break;

			case State.Action:
				StartCoroutine ("Oscillate");
			break;
		
		}
	}

	void ExitState(State stateExit)
	{
	}

	// Use this for initialization
	void Start () {
		initialPos = transform.position;

	}
	
	// Update is called once per frame
	void Update () {

	}

	public IEnumerator Oscillate()
	{
		while(true)
		{
			if(horizontal)
			{
				transform.position = new Vector3(initialPos.x-Mathf.Sin(Time.time*factor) *speed,transform.position.y,transform.position.z);
				yield return new WaitForEndOfFrame();
			}
			else
			{
				transform.position = new Vector3(transform.position.x,transform.position.y,initialPos.z-Mathf.Sin(Time.time*factor) *speed);
				yield return new WaitForEndOfFrame();
			}


		}
	}
}
