using UnityEngine;

public class scoremanagerscript : MonoBehaviour
{
    public static scoremanagerscript instance {get; private set;}


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
    }



    public float score;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addscore(float scoresend)
    {
        score += scoresend;
    }
}
