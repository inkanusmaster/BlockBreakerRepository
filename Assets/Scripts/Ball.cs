using UnityEngine;

public class Ball : MonoBehaviour
{
    //Config parameters.
    [SerializeField] Paddle paddle;
    [SerializeField] float xVelocity = 2f;
    [SerializeField] float yVelocity = 15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomBounceFactor = 0.5f;

    //State variables
    Vector2 paddleToBallVector;
    bool hasStarted;

    //Cached references
    AudioSource myAudioSource;
    Rigidbody2D myRigidbody2D;

    void Start()
    {
        paddleToBallVector = transform.position - paddle.transform.position;
        hasStarted = false;
        myAudioSource = GetComponent<AudioSource>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!hasStarted)
        {
            LockBallToBaddle();
            LaunchOnClick();
        }
    }

    private void LockBallToBaddle()
    {
        Vector2 paddlePosition = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePosition + paddleToBallVector;
    }

    private void LaunchOnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            myRigidbody2D.velocity = new Vector2(xVelocity, yVelocity);
            hasStarted = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityChange = new Vector2(Random.Range(0f, randomBounceFactor), Random.Range(0f, randomBounceFactor));
        if (hasStarted)
        {
            myRigidbody2D.velocity += velocityChange;
            AudioClip clip = ballSounds[Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
        }
    }
}