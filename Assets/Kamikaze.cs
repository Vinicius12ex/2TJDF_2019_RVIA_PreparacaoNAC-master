using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Kamikaze : MonoBehaviour
{

    private GameObject player;

    public NavMeshAgent navMeshAgent;

    public float distanciaMinima = 2f;

    private float distanciaAtual;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        //kamikaze irá seguir o player
        navMeshAgent.destination = player.transform.position;

        //Atualiza a distância entre o Kamikaze e o player
        distanciaAtual = Vector3.Distance(transform.position, player.transform.position);

        //se tiver perto o suficiente, destrói

        if (distanciaAtual <= distanciaMinima)
        {
            Destroy(gameObject);
        }


    }
}