using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoObstacle : MonoBehaviour
{

    
    public float velocidade = 2f;
    public int direcao = 1;
    public float maxesquerda = 4.5f;
    public float maxdireita = 8.8f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //definir que o gameobject deve se movimentar pra uma direcao primeiramente

        transform.Translate(Vector3.forward * velocidade * direcao * Time.deltaTime);
        
        //capturar a distância do eixo z que ele deve se movimentar e definir que elas
        //são o ponto limite e devem retornar!

        if (transform.position.z <= maxesquerda)
        {
            direcao = 1;
        }

        else if (transform.position.z >= maxdireita)
        {
            direcao = -1;
        }
    }
}
