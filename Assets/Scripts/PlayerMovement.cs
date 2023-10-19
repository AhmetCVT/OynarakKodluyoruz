using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Vector3 moveDirection;

    [SerializeField] private Rigidbody playerRigidbody;

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
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {


        }
    }

    private void FixedUpdate()
    {
        playerRigidbody.velocity = moveDirection * moveSpeed;
    }
}
