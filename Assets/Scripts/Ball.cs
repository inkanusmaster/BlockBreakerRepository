using UnityEngine;

public class Ball : MonoBehaviour
{

    //Config parameters.
    [SerializeField] Paddle paddle;
    [SerializeField] float xVelocity = 2f;
    [SerializeField] float yVelocity = 15f;
    [SerializeField] AudioClip[] ballSounds;

    //Pole służące do losowania wartości, która będzie dodawana do velocity przy odbiciu.
    //Dzięki temu nie będzie nudnych i zapętlonych bounców!
    [SerializeField] float randomBounceFactor = 0.5f;

    //State variables
    Vector2 paddleToBallVector;
    bool hasStarted;

    //Cached references
    AudioSource myAudioSource;

    //Podobnie jak myAudioSource, chcemy zrobić cache reference do myRigidBody2d.
    Rigidbody2D myRigidbody2D;

    void Start()
    {
        paddleToBallVector = transform.position - paddle.transform.position;
        hasStarted = false;
        myAudioSource = GetComponent<AudioSource>();

        //Też inicjalizujemy na starcie, tak jak myAudioSource;
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
            //Używamy zadeklarowanej i zainicjalizowanej wcześniej zmiennej myRigidbody2D.
            myRigidbody2D.velocity = new Vector2(xVelocity, yVelocity);
            hasStarted = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Robimy nową wartość velocity. 
        //Przy bounce, losuje nam się nowe velocity z lekkimi zmianami x i y.
        //Te zmiany są to wartości losowe z przediału od 0f do randomBounceFactor. Zarówno dla x jak i y
        Vector2 velocityChange = new Vector2(Random.Range(0f, randomBounceFactor), Random.Range(0f, randomBounceFactor));
        if (hasStarted)
        {
            //Zmieniamy obecne velocity o wartość z wektora.
            myRigidbody2D.velocity += velocityChange;

            AudioClip clip = ballSounds[Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
        }
    }

}
