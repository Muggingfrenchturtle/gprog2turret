using Unity.VisualScripting;
using UnityEngine;

public class newturretscript : MonoBehaviour
{
    public GameObject closestenemy; 
    public various_useful_functions vuf;

    public bool closestenemyisinrange = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scanenemies();
        if (closestenemy != null)
        {
            enemyinrangecheck();
            turretturn();
        }
        
    }

    private void scanenemies() //this should seriously only run when an enemy spawns instad of every frame, but idk how to do that yet. idk maybe somehow record the array from last frame and if its the same, dont run this entire dang loop
    {
        GameObject[] enemyscan = GameObject.FindGameObjectsWithTag("enemy");

        //Debug.Log(enemyscan[vuf.findnotnullinarray(enemyscan)]);
        var notnullspace = vuf.findnotnullinarray(enemyscan);
        
        if (notnullspace != 99999) //<---- it outputs 99999 if the array is totally null. theres a better way to do this
        {
            closestenemy = enemyscan[notnullspace];

            
            foreach (var enemy in enemyscan)
            {
                
                if (vuf.getDistanceBetweenPoints(enemy.transform.position, this.transform.position) < vuf.getDistanceBetweenPoints(closestenemy.transform.position, this.transform.position) )
                {
                    closestenemy = enemy;
                }

            }
        }
        
        
    }

    private void enemyinrangecheck()
    {
        Vector3 enemydirection = Vector3.Normalize(closestenemy.transform.position - transform.position);
        Vector3 forward = transform.TransformDirection(Vector3.up);

        var dotproduct = Vector3.Dot(forward, enemydirection);

        //Debug.Log(dotproduct);

        if ( dotproduct > 0.98)
        {
            closestenemyisinrange = true;
        }
        else
        {
            closestenemyisinrange = false;
        }
    }

    private void turretturn()
    {
        if (closestenemyisinrange == true)
        {
            var direction = (closestenemy.transform.position - transform.position).normalized;

            transform.up = Vector2.Lerp(transform.up, direction, 25 * Time.deltaTime);


            closestenemy.GetComponent<enemyscript>().inrange = true; //modifying this bool in the turret script is horrible. unfortunately, i want to go home.
        }
        else
        {
            closestenemy.GetComponent<enemyscript>().inrange = false;
        }
    }

}
