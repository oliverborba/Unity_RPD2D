using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Monster : MonoBehaviour
{
    [Header("Controller")]
    public Entity entity = new Entity();
    public GameManager manager;

    [Header("Patrol")]
    public Transform[] waypointList;
    public float arrivalDistance;
    public float waitTime = 5;

    //Privates
    Transform targetWaypoint;
    int currentWaypoint = 0;
    float lastDistanceToTarget = 0f;
    float currentWaitTime = 0f;

    [Header("Experience Reward")]
    public int rewardWxperience = 10;
    public int lootGoldMin = 0;
    public int lootGoldMax = 10;

    [Header("Respawn")]
    public GameObject prefab;
    public bool respawn = true;
    public float respawnTime = 10;

    Rigidbody2D rb2D;
    Animator animator;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();

        entity.maxHealth = manager.CalculateHealth(entity);
        entity.maxMana = manager.CalculateMana(entity);
        entity.maxStamina = manager.CalculateStamina(entity);

        entity.currentHealth = entity.maxHealth;
        entity.currentMana = entity.maxMana;
        entity.currentStamina = entity.maxStamina;

        currentWaitTime = waitTime;
        if (waypointList.Length > 0)
        {
            targetWaypoint = waypointList[currentWaypoint];
            lastDistanceToTarget = Vector2.Distance(transform.position, targetWaypoint.position);
        }
    }
}
