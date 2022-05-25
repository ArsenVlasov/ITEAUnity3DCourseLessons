using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
	[SerializeField] private float _jumpForce = 400f;                          // Amount of force added when the player jumps.
	[Range(0, 1)] [SerializeField] private float _crouchSpeed = .36f;          // Amount of maxSpeed applied to crouching movement. 1 = 100%
	[Range(0, .3f)] [SerializeField] private float _movementSmoothing = .05f;  // How much to smooth out the movement
	[SerializeField] private bool _airControl = false;                         // Whether or not a player can steer while jumping;
	[SerializeField] private LayerMask m_WhatIsGround;                          // A mask determining what is ground to the character
	[SerializeField] private Transform _groundCheck;                           // A position marking where to check if the player is grounded.
	[SerializeField] private Transform _ceilingCheck;                          // A position marking where to check for ceilings
	[SerializeField] private Collider2D _crouchDisableCollider;                // A collider that will be disabled when crouching

	const float _groundedRadius = 0.2f; // Radius of the overlap circle to determine if grounded
	private bool _grounded;            // Whether or not the player is grounded.
	const float _ceilingRadius = 0.2f; // Radius of the overlap circle to determine if the player can stand up
	private Rigidbody2D _rigidbody2D;
	private bool _facingRight = true;  // For determining which way the player is currently facing.
	private Vector3 velocity = Vector3.zero;

	[Header("Events")]
	[Space]

	public UnityEvent OnLandEvent;

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }

	private void Awake()
	{
		_rigidbody2D = GetComponent<Rigidbody2D>();
	}


	private void FixedUpdate()
	{
		_grounded = false;

		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		// This can be done using layers instead but Sample Assets will not overwrite your project settings.
		Collider2D[] colliders = Physics2D.OverlapCircleAll(_groundCheck.position, _groundedRadius, m_WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
				_grounded = true;
		}
	}


	public void Move(float move, bool crouch, bool jump)
	{
		// If crouching, check to see if the character can stand up
		if (!crouch)
		{
			// If the character has a ceiling preventing them from standing up, keep them crouching
			if (Physics2D.OverlapCircle(_ceilingCheck.position, _ceilingRadius, m_WhatIsGround))
			{
				crouch = true;
			}
		}

		//only control the player if grounded or airControl is turned on
		if (_grounded || _airControl)
		{

			// If crouching
			if (crouch)
			{
				// Reduce the speed by the crouchSpeed multiplier
				move *= _crouchSpeed;

				// Disable one of the colliders when crouching
				if (_crouchDisableCollider != null)
					_crouchDisableCollider.enabled = false;
			}
			else
			{
				// Enable the collider when not crouching
				if (_crouchDisableCollider != null)
					_crouchDisableCollider.enabled = true;
			}

			// Move the character by finding the target velocity
			Vector3 targetVelocity = new Vector2(move * 10f, _rigidbody2D.velocity.y);
			// And then smoothing it out and applying it to the character
			_rigidbody2D.velocity = Vector3.SmoothDamp(_rigidbody2D.velocity, targetVelocity, ref velocity, _movementSmoothing);

			// If the input is moving the player right and the player is facing left...
			if (move > 0 && !_facingRight)
			{
				// ... flip the player.
				Flip();
			}
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (move < 0 && _facingRight)
			{
				// ... flip the player.
				Flip();
			}
		}
		// If the player should jump...
		if (_grounded && jump)
		{
			// Add a vertical force to the player.
			_grounded = false;
			_rigidbody2D.AddForce(new Vector2(0f, _jumpForce));
		}
	}


	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		_facingRight = !_facingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
