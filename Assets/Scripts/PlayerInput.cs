using UnityEngine;
using System.Collections;


public class PlayerInput : MonoBehaviour
{
	// movement config
	public float gravity = -25f;
	public float runSpeed = 8f;
	public float groundDamping = 20f; // how fast do we change direction? higher means faster
	public float inAirDamping = 5f;
	public float jumpHeight = 3f;
	public bool nearVacuum = false;
	public bool nearLight = false;
	public bool nearTV = false;
	public bool nearOut = false;
	public bool isItGrounded;
	public Rigidbody2D Rigid;
	public AudioSource jumpSource;
	public AudioSource transSound;
	public AudioSource unPossSound;
	public AudioSource vacuumStarting;
	public AudioSource vacuumRunning;
	public AudioSource vacuumOff;
	private Collider coli;

	[HideInInspector]
	private float normalizedHorizontalSpeed = 0;

	private CharacterController2D _controller;
	//private Animator _animator;
	private RaycastHit2D _lastControllerColliderHit;
	private Vector3 _velocity;

	void Start(){
		Rigid = gameObject.GetComponent<Rigidbody2D> ();
	}


	void Awake()
	{
		//_animator = GetComponent<Animator>();
		_controller = GetComponent<CharacterController2D>();

		// listen to some events for illustration purposes
		_controller.onControllerCollidedEvent += onControllerCollider;
		_controller.onTriggerEnterEvent += onTriggerEnterEvent;
		_controller.onTriggerExitEvent += onTriggerExitEvent;
	}


	#region Event Listeners

	void onControllerCollider( RaycastHit2D hit )
	{
		// bail out on plain old ground hits cause they arent very interesting
		if( hit.normal.y == 1f )
			return;

		// logs any collider hits if uncommented. it gets noisy so it is commented out for the demo
		//Debug.Log( "flags: " + _controller.collisionState + ", hit.normal: " + hit.normal );
	}


	void onTriggerEnterEvent( Collider2D col )
	{
		Debug.Log( "onTriggerEnterEvent: " + col.gameObject.name );
	}


	void onTriggerExitEvent( Collider2D col )
	{
		Debug.Log( "onTriggerExitEvent: " + col.gameObject.name );
	}

	#endregion


	// the Update loop contains a very simple example of moving the character around and controlling the animation
	void Update()
	{
		isItGrounded = _controller.isGrounded;

		if( _controller.isGrounded )
			_velocity.y = 0;

		if( Input.GetKey( KeyCode.RightArrow ) )
		{
			normalizedHorizontalSpeed = 1;
			if( transform.localScale.x < 0f )
				transform.localScale = new Vector3( -transform.localScale.x, transform.localScale.y, transform.localScale.z );

			//if( _controller.isGrounded )
				//_animator.Play( Animator.StringToHash( "Run" ) );
		}
		else if( Input.GetKey( KeyCode.LeftArrow ) )
		{
			normalizedHorizontalSpeed = -1;
			if( transform.localScale.x > 0f )
				transform.localScale = new Vector3( -transform.localScale.x, transform.localScale.y, transform.localScale.z );

			//if( _controller.isGrounded )
				//_animator.Play( Animator.StringToHash( "Run" ) );
		}
		else
		{
			normalizedHorizontalSpeed = 0;

			//if( _controller.isGrounded )
				//_animator.Play( Animator.StringToHash( "Idle" ) );
		}


		// we can only jump whilst grounded
		if( _controller.isGrounded && Input.GetKeyDown( KeyCode.UpArrow ) )
		{
			_velocity.y = Mathf.Sqrt( 2f * jumpHeight * -gravity );
			//_animator.Play( Animator.StringToHash( "Jump" ) );
		}


		// apply horizontal speed smoothing it. dont really do this with Lerp. Use SmoothDamp or something that provides more control
		var smoothedMovementFactor = _controller.isGrounded ? groundDamping : inAirDamping; // how fast do we change direction?
		_velocity.x = Mathf.Lerp( _velocity.x, normalizedHorizontalSpeed * runSpeed, Time.deltaTime * smoothedMovementFactor );

		// apply gravity before moving
		_velocity.y += gravity * Time.deltaTime;

		// if holding down bump up our movement amount and turn off one way platform detection for a frame.
		// this lets us jump down through one way platforms
		if( _controller.isGrounded && Input.GetKey( KeyCode.DownArrow ) )
		{
			_velocity.y *= 3f;
			_controller.ignoreOneWayPlatformsThisFrame = true;
		}

		_controller.move( _velocity * Time.deltaTime );

		// grab our current _velocity to use as a base for all calculations
		_velocity = _controller.velocity;
		takeControl ();
		Jump ();
	}

	//takes control of other objects given an input
	void takeControl(){
		if (Input.GetKeyDown (KeyCode.E)) {
			RaycastHit hit;
			Ray ray = new Ray (transform.position, Vector2.right);
	    	if (Physics.Raycast (transform.position, Vector2.right, 2)) {
				Physics.Raycast (ray, out hit);
				transSound.Play ();
				if (hit.collider.CompareTag("VacuumCleaner")) {
					Vacuum (hit);
				}
				if (hit.collider.CompareTag("Light")){
					nearLight = true;
					transform.position = hit.collider.transform.position;
					Vector3 spawnPoint = transform.position;
					transform.position = spawnPoint;
				} else if(hit.collider.CompareTag ("TV")) {
					hit.collider.gameObject.GetComponentInChildren<TVLauncher> ().wasHitTV = true;
					Television ();
				} else if (hit.collider.CompareTag ("Outlet")) {
					Outlet (hit);
				}

			}

		}

		if (Input.GetKeyDown (KeyCode.Q)) {
			RaycastHit hit;
			Ray ray = new Ray (transform.position, Vector2.left);
			if (Physics.Raycast (transform.position, Vector2.left, 5)) {
				Physics.Raycast (ray, out hit);
				transSound.Play ();
				if (hit.collider.CompareTag("Light")){	
					nearLight = true;
					transform.position = hit.collider.transform.position;
					Vector3 spawnPoint = transform.position;
					transform.position = spawnPoint;
				} 
				if (hit.collider.CompareTag("VacuumCleaner")) {
					Vacuum (hit);
				} else if (hit.collider.CompareTag ("TV")) {
					hit.collider.gameObject.GetComponent<TVLauncher> ().wasHitTV = true;
					Television ();	
				} else if (hit.collider.CompareTag ("Outlet")) {
					Outlet (hit);
				}

			}

		}
	}

	void Jump(){
		if (Input.GetKeyDown (KeyCode.Space) && isItGrounded) {
			Rigid.AddForce (transform.up * 400);
			jumpSource.Play ();
		}
	}

	void playVacuum(){
		vacuumRunning.enabled = true;
		vacuumRunning.Play ();
	}

	void Vacuum(RaycastHit hit){
		hit.collider.gameObject.GetComponent<VacuumController>().wasHitVac = true;
		vacuumStarting.Play ();
		Invoke ("playVacuum", 1.0f);
		hit.collider.gameObject.GetComponent<VacuumController> ().inControl = true;
		nearVacuum = true;
		gameObject.SetActive (false);
		Vector3 spawnPoint = transform.position;
		spawnPoint.y += 0.6f;
		transform.position = spawnPoint;
	}

	void Television(){
		
		nearTV = true;
		gameObject.SetActive (false);
		Vector3 spawnPoint = transform.position;
		spawnPoint.y += 0.3f;
		transform.position = spawnPoint;
	}

	void Outlet(RaycastHit hit){
		hit.collider.gameObject.GetComponent<Outlet> ().wasHitOut = true;
		nearOut = true;
	}

}