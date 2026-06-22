using UnityEngine;

public class Arma : MonoBehaviour
{
    [SerializeField] private Transform _StartingPoint;

    [SerializeField] private GameObject _PrefabProjectile;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Atirar();
        }
    }

    private void Atirar(){
        Debug.Log("Atirou");

        GameObject novoProjetil = Instantiate(_PrefabProjectile, _StartingPoint.position, Quaternion.identity);

    }


}
