using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Vector3 moveDirection;

    [SerializeField] private Rigidbody playerRigidbody;
    [SerializeField] private Animator animator;
    private bool isDigging;
    private float characterVelocityOffset = 6;

    private void Start()
    {
        //playerRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
          float horizontalInput = Input.GetAxis("Horizontal");
          float verticalInput = Input.GetAxis("Vertical");

          moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;

          if (moveDirection != Vector3.zero)
          {
              transform.rotation = Quaternion.LookRotation(moveDirection);
          }

          Debug.Log("Onder magnitude: "+playerRigidbody.velocity.magnitude);

        if (!isDigging)
        {
            if (playerRigidbody.velocity.magnitude > characterVelocityOffset)
            {
                animator.SetTrigger("Walk");
            }
            else
            {
                animator.SetTrigger("Idle");
            }
        }
    }

    private void FixedUpdate()
    {
        playerRigidbody.velocity = moveDirection * moveSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ore"))
        {
            Debug.Log("Digging");
            animator.SetTrigger("Digging");
            isDigging = true;
            playerRigidbody.constraints = RigidbodyConstraints.FreezePosition;
            StartCoroutine(Delay());

        }
    }

    IEnumerator Delay( )
    {
        yield return new WaitForSeconds(4f);
        playerRigidbody.constraints = RigidbodyConstraints.None;
        isDigging = false;
    }

}
