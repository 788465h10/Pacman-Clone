using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    GameObject target;
    NavMeshAgent agent;
    FinalLevelMusic finalLevelMusic;
    private void Awake()
    {
        finalLevelMusic = GameObject.FindGameObjectWithTag("Audio").GetComponent<FinalLevelMusic>();
    }
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GetComponent<GameObject>();
        target = GameObject.Find("Pacman");
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
    private void Update()
    {
        agent.SetDestination(target.transform.position);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            finalLevelMusic.PlaySFX(finalLevelMusic.enemyDie);
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
