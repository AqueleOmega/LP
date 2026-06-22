using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private float velocidade;

    [SerializeField] private GameObject C2D_2;

    [SerializeField] private GameObject Point;

    [SerializeField] private Animator animator; 

    private float direction;

    void Start()
    {
        Collider2D CL_2D_2 = C2D_2.GetComponent<Collider2D>();  
        Collider2D CL_2D = GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(CL_2D, CL_2D_2);
        MoverProjetil();
        animator.SetBool("EstaAtirando", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MoverProjetil(){

        if (Input.GetKey(KeyCode.A))
        {

            direction = -1;
        }
        else{
            direction = 1;
        }
        
        velocidade = velocidade * direction;
        rb.AddForce(new Vector2(velocidade, rb.linearVelocity.y));
        animator.SetBool("EstaAtirando", false);
    }
}
