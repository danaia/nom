using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Animator animator;
    private bool isMoving = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        if (horizontalInput != 0 || verticalInput != 0)
        {
            isMoving = true;
            transform.position += new Vector3(horizontalInput, verticalInput, 0f) * moveSpeed * Time.deltaTime;
        }
        else
        {
            isMoving = false;
        }

        animator.SetBool("isMoving", isMoving);
    }
}
