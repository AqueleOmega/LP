using UnityEngine;

public class locomoca : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private float velocidade = 10f;

    [SerializeField] private float forcaPulo = 10f;
    
    [SerializeField] private Animator animator; 

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

            transform.localRotation = Quaternion.Euler(0, -180, 0);
            //Eu acesso o componente transform que essa script está atribuida e mexo na rotação local dela
            //Ela pede uma 'quartenion identity', (um valor quartenion, como o API fala: Quaternions are used to represent rotations.)
            //E existe um 'metodo' (nao sei se esse é o nome) que permite nós usarmos angulos para mexer no Quartenion(vou chamar de rotação): o .Euler
            //Euler	Converts an input Euler angle rotation specified as three floats to a Quaternion.
            //Resumidamente, ela faz que o Quartenion sejam apenas angulos normais,e eu mexo na rotação Y para inverter-la.
        }
        else if(Input.GetKey(KeyCode.D)){
            rb.linearVelocity = new Vector2 (velocidade * 1, rb.linearVelocity.y);
            
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            //Mesma coisa do de cima
        }
        if(direção != 0){
            animator.SetBool("EstaCorrendo", true);
        }
        else{   
            animator.SetBool("EstaCorrendo", false);
        }
    }

    private void Pular(){
        if(Input.GetKeyDown((KeyCode.Space)) && estouNoChao == true){
            estouNoChao = false;
            Debug.Log("Pulou");
            rb.AddForce(Vector2.up * forcaPulo, ForceMode2D.Impulse);
            animator.SetBool("EstaPulando", true);
        }
    }
    private void OnCollisionEnter2D (Collision2D obj){
        if (obj.gameObject.tag == "Chao") {
            Debug.Log("Está no chão");
            animator.SetBool("EstaPulando", false);
            estouNoChao = true;

        }
    }
}
