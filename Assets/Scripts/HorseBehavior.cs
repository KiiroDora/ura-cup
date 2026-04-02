using UnityEngine;

public class HorseBehavior : MonoBehaviour
{
    public Horse horse;
    public Horse.HorseData horseData;
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rb;

    public float acceleration;
    public float maxVelocity;
    public float velocity;

    public Vector2 direction;


    void Awake()  
    {
        // get components
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // initialize horse
        horseData = horse.horseData;
        horseData.power = Mathf.Max(1, horseData.power);
        horseData.stamina = Mathf.Max(1, horseData.stamina);
        horseData.speed = Mathf.Max(1, horseData.speed);

        // set accel and velocity (max velocity is same for all horses)
        acceleration = horseData.speed * 0.2f;
        maxVelocity = 10f;
        velocity = 0f;

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

/*  Failsafe for huddling horses   

    void OnCollisionStay2D(Collision2D collision)
    {
        float initialDirection = Mathf.Deg2Rad * Random.Range(0, 360);
        direction = new Vector2((float)Mathf.Cos(initialDirection), (float)Mathf.Sin(initialDirection)).normalized;
        rb.AddForce(direction.normalized * 1);
    } 
*/    

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Cheese"))
        {
            Destroy(collision.gameObject);
            RaceController.instance.EndRace(horse);
        }

        else if (collision.gameObject.CompareTag("Horse"))  // horse collision
        {
            HorseBehavior collidedHorse = collision.gameObject.GetComponent<HorseBehavior>();
    
            // take power difference into account
            float powerDifference = horseData.power / collidedHorse.horseData.power;

            float takenKnockback = collidedHorse.velocity / powerDifference;
            velocity = horseData.speed / horseData.stamina * Mathf.Clamp(takenKnockback, 0.5f, 5f);
            direction = (-direction + new Vector2(Random.Range(-1f, 1f),Random.Range(-1f, 1f))).normalized;
        }

        else  // wall collision
        {
            velocity /= Mathf.Max(1, 9 - horseData.stamina);
            direction = (-direction + new Vector2(Random.Range(-1f, 1f),Random.Range(-1f, 1f))).normalized;
        }
    }
}
