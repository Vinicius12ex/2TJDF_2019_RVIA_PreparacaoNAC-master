using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MaquinaEstado : MonoBehaviour
{

    public enum Estados
    {
        Esperar,
        Patrulhar,
        Perseguir
    }

    private Estados estadoAtual;

    public NavMeshAgent navMeshAgent;
    private Transform target;

    //Esperar
    public float tempoEsperar = 2f;
    private float tempoEsperando;

    //Patrulhar
    public Transform waypoint1;
    public Transform waypoint2;
    public Transform waypoint3;
    private Transform waypointAtual;
    public float distanciaMinimaWaypoint = 1.5f;
    private float distanciaWaypointAtual;
    

    //Perseguir
    public float distanciaMinimaPerseguicao = 5f;
    private float distanciaAtualPlayer;
    private GameObject player;


    void Start()
    {
        Esperar();

        player = GameObject.FindGameObjectWithTag("Player");

        waypointAtual = waypoint1;
        
    }

    private void Esperar()
    {
        estadoAtual = Estados.Esperar;
        tempoEsperando = Time.time;
    }


    void Update()
    {
        //if (target != null){
        // navMeshAgent.destination = target.position;
        //}
        if (PossuiVisaoJogador())
        {
            Perseguir();
        }

        switch (estadoAtual)
        {
            case Estados.Esperar:
                target = transform;
                if (EsperouTempoSuficiente())
                {
                    Patrulhar();
                }

                break;
            case Estados.Patrulhar:
                target = waypointAtual;
                if (PertoWaypointAtual())
                {
                    AlterarWaypoint();
                }
                break;
            case Estados.Perseguir:
                target = player.transform;

                if (!PossuiVisaoJogador())
                {
                    Esperar();
                }

                break;
        }



        navMeshAgent.destination = target?.position ?? navMeshAgent.destination;
    }


    private bool PossuiVisaoJogador()
    {
        distanciaAtualPlayer = Vector3.Distance(transform.position, player.transform.position);

        return distanciaAtualPlayer <= distanciaMinimaPerseguicao;
    }

    //define estado de perseguir
    private void Perseguir()
    {
        estadoAtual = Estados.Perseguir;
    }
    private bool EsperouTempoSuficiente()
    {
        return tempoEsperando + tempoEsperar <= Time.time;
    }

    //define estado de patrulhamento
    private void Patrulhar()
    {
        estadoAtual = Estados.Patrulhar;
    }

    private bool PertoWaypointAtual()
    {
        distanciaWaypointAtual = Vector3.Distance(transform.position, waypointAtual.position);
        return distanciaWaypointAtual <= distanciaMinimaWaypoint;
    }

    private void AlterarWaypoint()
    {
        if(waypointAtual == waypoint1)
        {
            waypointAtual = waypoint2;
        }
        else if (waypointAtual == waypoint2)
        {
            waypointAtual = waypoint3;
        }
        else if(waypointAtual == waypoint3)
        {
            waypointAtual = waypoint1;
        }
    }






}
