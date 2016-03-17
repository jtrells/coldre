using UnityEngine;
using System.Collections;

public class FSMAI : MonoBehaviour {


	public float speed=1.0f;
	public bool reversed =false;
	public float factor = 1;


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


	}
	
	// Update is called once per frame
	void Update () {
		if (reversed)
			state = State.Action;
	}

	public IEnumerator Oscillate()
	{
		while(true)
		{
			transform.position = new Vector3(transform.position.x,transform.position.y,Mathf.Sin(Time.time*factor) *speed);
			yield return new WaitForEndOfFrame();


		}
	}
}
