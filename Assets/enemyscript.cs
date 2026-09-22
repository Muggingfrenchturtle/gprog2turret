using UnityEngine;

public class enemyscript : MonoBehaviour //basically godot pathfollow2d
{

    public ineedpath2dscript path2d;

    public float progress;

    public float movespeed = 0.5f;

    public bool reversed = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        path2d = transform.parent.GetComponentInChildren<ineedpath2dscript>(); //this looks unstable as hell
    }

    // Update is called once per frame
    void Update()
    {
        progresscap();
        pathfollow2dprogressimplement();

        enemyprogressmove();
        reverseboolflipping();


    }

    private void pathfollow2dprogressimplement()
    {
        Vector2 progline = path2d.points[0] + progress * (path2d.points[1] - path2d.points[0]); //lmao this works. its also 0-100%. progress implemented like this is progresspercentage instead of per pixel like godot

        transform.position = progline;
    }

    private void progresscap()
    {
        /*
        if (progress < 0) 
        {
            progress = 0;
        }
        else if (progress > 1)
        {
            progress = 1;
        }
        */ //with the above method, the enemy can get out of the path if the progress value gets changed hard enough

        progress = Mathf.Clamp(progress, 0, 1);
    }


    private void enemyprogressmove()
    {

        if (reversed == false)
        {
            progress += movespeed * Time.deltaTime;
        }
        else if (reversed == true)
        {
            progress -= movespeed * Time.deltaTime;
        }
        
    }

    private void reverseboolflipping()
    {
       if (progress <= 0 && reversed == true)
       {
            reversed = false;
       }
       else if (progress >= 1 && reversed == false)
        {
            reversed = true;
        }
    }
}
