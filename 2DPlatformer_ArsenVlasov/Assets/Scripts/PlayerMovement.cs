using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public CharacterController2D controller;
	public Animator animator;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;

	void Update()
	{
		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if (Input.GetKeyDown(KeyCode.Space))
		{
			jump = true;
			animator.SetBool("IsJumping", true);
		}

		if (Input.GetKeyDown(KeyCode.S))
		{
			crouch = true;
		}
		else if (Input.GetKeyUp(KeyCode.S))
		{
			crouch = false;
		}

	}

	public void OnLanding()
	{
		animator.SetBool("IsJumping", false);
	}

	public void OnCrouching(bool isCrouching)
	{
		animator.SetBool("IsCrouching", isCrouching);
	}

	void FixedUpdate()
	{
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.TryGetComponent<TriggerZone>(out var triggerZone))
		{
			if (triggerZone.Type == TriggerZoneType.Death)
			{
				Debug.Log("You are died!");

			}
			else if (triggerZone.Type == TriggerZoneType.Diamond)
			{
				triggerZone.gameObject.SetActive(false);
				Debug.Log("You are collect the diamond");
				//добавить событие взятие монеты
			}
			else if (triggerZone.Type == TriggerZoneType.Finish)
			{
				Debug.Log("You are complete the level");
			}
		}
	}
}
