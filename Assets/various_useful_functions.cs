using UnityEngine;

public class various_useful_functions : MonoBehaviour
{
    public float getDistanceBetweenPoints(Vector2 thingGlobalPosition, Vector2 targetGlobalPosition) //can actually be used for position too. as long as both parameters are the same type of position
    {
        //--------------------------------------------------
        //Vector2 centerPosition = GetNode<Marker2D>(@"/root/logicnode/worldBackground/perspectiveCenter").GlobalPosition; //idk this source says putting @ at the start is better??
        //https://www.reddit.com/r/godot/comments/u3n92g/comment/i4uxlsf/?utm_source=share&utm_medium=web3x&utm_name=web3xcss&utm_term=1&utm_content=share_button
        //note that (^"path") dosent work for some reason here despite the godot docs saying so, as well as the fact that this is godot 4.
        //but @"path" works i guess
        //ill put it in all the getnode()s i can find.
        //
        //after doing so, it performs better? idk if its just placebo or not.
        //
        //changed so that you can set the target global position, rather than just being limited to perspectivecenter.

        float distanceToSendBack;
        //--------------------------------------------------

        distanceToSendBack = Mathf.Sqrt(Mathf.Pow(targetGlobalPosition.x - thingGlobalPosition.x, 2) + Mathf.Pow(targetGlobalPosition.y - thingGlobalPosition.y, 2)); //puts stuff through the distance formula(tm)

        return distanceToSendBack;
    }

    public int findemptyslotinarray(GameObject[] arr)
    {
        int intToReturn = 99999; //pretty much throws an error if this somehow goes through as this number
        for (int i = 0; i < arr.Length; ++i)
        {
            if (arr[i] == null)
            {
                intToReturn = i;
            }
        }

        return intToReturn; //returns slot deemed empty
    }

    public int findgemobjectinarray(GameObject[] arr, GameObject thingtofind) //finds a specific gameobject in an array
    {
        int intToReturn = 99999; //pretty much throws an error if this somehow goes through as this number
        for (int i = 0; i < arr.Length; ++i)
        {
            if (arr[i] == thingtofind)
            {
                intToReturn = i;
            }
        }

        return intToReturn; //returns slot deemed empty
    }

    public int findnotnullinarray(GameObject[] arr) 
    {
        int intToReturn = 99999;
        for (int i = 0; i < arr.Length; ++i)
        {
            if (arr[i] != null)
            {
                intToReturn = i;
            }
        }

        return intToReturn;
    }

    public bool isarraynull(GameObject[] arr)
    {
        bool booltoreturn;

        int intToReturn = 99999;
        for (int i = 0; i < arr.Length; ++i)
        {
            if (arr[i] != null)
            {
                intToReturn = i;
            }
        }

        if (intToReturn == 99999)
        {
            booltoreturn = true;
        }
        else
        {
            booltoreturn = false;
        }

        return booltoreturn;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
