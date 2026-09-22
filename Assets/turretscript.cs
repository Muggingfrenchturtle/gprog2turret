using Unity.Mathematics;
using UnityEngine;

public class turretscript : MonoBehaviour
{
    public GameObject[] enemy = new GameObject[50];

    public GameObject closestenemy;

    public various_useful_functions vuf;

    private GameObject enemyfordottracking;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        turrettrack();
    }


    private void turretrackbutwithdot()
    {
    }
    private void turrettrack()
    {
        if (vuf.isarraynull(enemy) == false)
        {
                
            
            var direction = (getclosestenemy().transform.position - transform.position).normalized;

            transform.right = Vector2.Lerp(transform.right, direction, 25 * Time.deltaTime);
            //we dont need lookrotation



            //Vector3 transformmod = Vector3.zero;

            //transformmod.z = Vector2.Dot(transform.right, direction);

            //transform.rotation = transformmod;
        }
    }

    private GameObject getclosestenemy()
    {
        var currentclosest = enemy[vuf.findnotnullinarray(enemy)];

        GameObject enemyToTest;

        for (int i = 0; i < enemy.Length; i++)
        {
            enemyToTest = enemy[i];

            if (enemyToTest != null)
            {
                if (vuf.getDistanceBetweenPoints(enemyToTest.transform.position,this.transform.position) <= vuf.getDistanceBetweenPoints(currentclosest.transform.position, this.transform.position))
                {
                    currentclosest = enemyToTest;
                }
            }

        }

        return currentclosest;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "enemy")
        {
            Debug.Log("slot free : " + vuf.findemptyslotinarray(enemy));
            enemy[vuf.findemptyslotinarray(enemy)] = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("ontrigexit");
        if (collision.tag == "enemy")
        {
            Debug.Log("slot delete : " + vuf.findgemobjectinarray(enemy, collision.gameObject));
            enemy[vuf.findgemobjectinarray(enemy, collision.gameObject)] = null;
        }
    }
}
