using UnityEngine;

public class BirdScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private float flapStrength = 5f;
    [SerializeField] private LogicScriptFlappy logic;
    public bool remiIsAlive = true;
    Animator animator;

    [SerializeField] private float cooldownTime = 3f;
    private float nextFireTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScriptFlappy>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && remiIsAlive) {
            rigidbody.velocity = Vector2.up * flapStrength;
            animator.SetTrigger("flap");
        }

        if (rigidbody.transform.position.y > 5 || rigidbody.transform.position.y < -5)
        {
            logic.gameOver();
            remiIsAlive = false;
        }
        
        if (Time.time > nextFireTime)
        {
            //Debug.Log("habilidad lista");
            logic.megaFlapReady(true);

            if (Input.GetKeyDown(KeyCode.E) && remiIsAlive)
            {
                //Debug.Log("huevo del pollo");
                megaJump();
                logic.megaFlapReady(false);
                // Cuando se usa la habilidad, esta se podrá volver a usar en 'cooldownTime' segundos a partir del tiempo actual (time.deltatime)
                nextFireTime = Time.time + cooldownTime;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("colision");
        if (collision.gameObject.tag == "Muerte")
        {
            //Debug.Log("muerte");
            logic.gameOver();
            remiIsAlive = false;

        }
    }

    private void megaJump()
    {
        rigidbody.velocity = Vector2.up * flapStrength * 2f;
    }
}
