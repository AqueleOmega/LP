using UnityEngine;

public class locomoca : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private float velocidade = 10f;

    [SerializeField] private float forcaPulo = 10f;

    private bool estouNoChao = false;


    // im at the club
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Mover();
        Pular();
    }

    private void Mover(){
        float direção = Input.GetAxis("Horizontal");
        
        if(Input.GetKey(KeyCode.A)){
            rb.linearVelocity = new Vector2 (velocidade * -1, rb.linearVelocity.y);
        }
        else if(Input.GetKey(KeyCode.D)){
            rb.linearVelocity = new Vector2 (velocidade * 1, rb.linearVelocity.y);
        }
    }

    private void Pular(){
        if(Input.GetKeyDown((KeyCode.Space)) && estouNoChao == true){
            estouNoChao = false;
            Debug.Log("Pulou");
            rb.AddForce(Vector2.up * forcaPulo, ForceMode2D.Impulse);
        }
    }
    private void OnCollisionEnter2D (Collision2D obj){
        if (obj.gameObject.tag == "Chao") {
            Debug.Log("Está no chão");
            estouNoChao = true;
        }
    }
}
