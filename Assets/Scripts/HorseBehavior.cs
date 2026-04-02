using UnityEngine;

public class HorseBehavior : MonoBehaviour
{
    public Horse horse;
    public Horse.HorseData horseData;
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rb;
    public AudioSource clop;

    public float acceleration;
    public float maxVelocity;
    public float velocity;

    public Vector2 direction;


    void Awake()  
    {
        // get components
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        clop = GetComponentInChildren<AudioSource>();
        clop.volume = 0.3f;

        // initialize horse
        horseData = horse.horseData;
        horseData.power = Mathf.Max(1, horseData.power);
        horseData.stamina = Mathf.Max(1, horseData.stamina);
        horseData.speed = Mathf.Max(1, horseData.speed);

        // set accel and velocity (max velocity is same for all horses)
        acceleration = horseData.speed * 0.2f;
        maxVelocity = 10f;
        velocity = 0f;
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        // set initial direction for horse to move in
        float initialDirection = Mathf.Deg2Rad * Random.Range(0, 360);
        direction = new Vector2((float)Mathf.Cos(initialDirection), (float)Mathf.Sin(initialDirection)).normalized;
    }

    void Update()
    {
        if (RaceController.instance.raceInProcess) 
        {
            if (velocity < maxVelocity)  // apply accel
            {
                velocity += acceleration * Time.deltaTime;
            }

            velocity = Mathf.Min(velocity, maxVelocity);

            // set linear velocity via current direction
            rb.linearVelocity = direction.normalized * velocity;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Cheese"))
        {
            Destroy(collision.gameObject);
            StartCoroutine(RaceController.instance.EndRace(horse));
        }

        else if (collision.gameObject.CompareTag("Horse"))  // horse collision
        {
            clop.Play();
            HorseBehavior collidedHorse = collision.gameObject.GetComponent<HorseBehavior>();
    
            // take power difference into account
            float powerDifference = horseData.power / collidedHorse.horseData.power;

            float takenKnockback = collidedHorse.velocity / powerDifference;
            velocity = horseData.speed / horseData.stamina * Mathf.Clamp(takenKnockback, 0.5f, 5f);
            direction = (-direction + new Vector2(Random.Range(-1f, 1f),Random.Range(-1f, 1f))).normalized;
        }

        else  // wall collision
        {
            clop.Play();
            velocity /= Mathf.Max(1, 9 - horseData.stamina);
            direction = (-direction + new Vector2(Random.Range(-1f, 1f),Random.Range(-1f, 1f))).normalized;
        }
    }
}
