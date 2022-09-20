using UnityEngine;

public class Characters : MonoBehaviour
{
    //health stats
    public float healthPoint;
    [SerializeField] protected float maxHealthPoint;
    
    //atk stats
    [SerializeField] public int atkDamage;
    [SerializeField] protected float atkInterval;
    protected int damager;

    //behaviour
    protected int moveSpeed = 3;
    protected Transform target;
    protected bool isColliding = false;

    protected virtual void Start()
    {
        healthPoint = maxHealthPoint; //set awal darah max

        target = GameObject.FindGameObjectWithTag("Hero").GetComponent<Transform>(); //enemy kejar hero
        //Debug.Log("hp is at " + healthPoint);

    }

    // Update is called once per frame
    protected virtual void Update()
    {
        //Debug.Log("current hp " + healthPoint);        
        //Attack();

        //disable object yang darahnya habis
        if(healthPoint <= 0)
        {
            Death();
        }
    }

    private void FixedUpdate()
    {
        //interval serangan, bisa juga pakai courotine 
        atkInterval += Time.deltaTime;
        if (atkInterval > 1)
        {
            atkInterval -= 3;

            //kasih damage jika status sedang tabrakan
            if (isColliding == true) 
            { 
               Attack();
            }       
        }

        //method untuk bergerak
        Move();
    }

    protected virtual void Attack()
    {
        healthPoint -= damager;
        Debug.Log("Sisa darah entitas " + healthPoint + ", diserang oleh yang punya damage = " + damager);
    }

    protected virtual void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }
    
    protected virtual void Death()
    {
        gameObject.SetActive(false);
        Debug.Log("An entity died" + healthPoint);
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Hero"))
        {
            isColliding = true;
            damager = collision.gameObject.GetComponent<Characters>().atkDamage; //perlu ambil data atkDamage dari yang ditabrak
            //Debug.Log(atkDamage + " nabrak hp sisa " + healthPoint);
        }

    }

    /*jika enemy mati maka akan terbaca sebagai collisionexit, isColliding diset false kembali untuk 
     decision Attack
    */
    protected virtual void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Hero"))
        {
            isColliding = false;
        }
        

    }
}
