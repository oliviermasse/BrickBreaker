using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle1;
    [SerializeField] float xInitial;
    [SerializeField] float yInitial;
    float yOffset = 0.65f;
    bool HasStarted = false;
    float randomBounce = 0.5f;  // in case of horizontal/vertical deadlock bounces
    Rigidbody2D myRigidBody2D;

    Vector2 paddleBallVector;
    void Start()
    {
        paddleBallVector = transform.position - paddle1.transform.position;
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        while (!HasStarted)
        {
            StartLockBall();
            Debug.Log("Not Started");
            LaunchBall();

        }
    }

    private void StartLockBall()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y + yOffset);
    }
    private void LaunchBall()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HasStarted = true;
            myRigidBody2D.velocity = new Vector2(xInitial, yInitial);
            Debug.Log("Started");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 randomVelocityBounce = new Vector2(randomBounce, randomBounce); //for perfectly horizontal/vertical deadlocks
        if (HasStarted)
        {
            GetComponent<AudioSource>().Play();
            myRigidBody2D.velocity += randomVelocityBounce;
        }   
    }
}
