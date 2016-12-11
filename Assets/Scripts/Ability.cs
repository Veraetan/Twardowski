
//A class all abilities inherit from

using UnityEngine;
using System.Collections;

public class Ability : MonoBehaviour
{
    protected float cooldownTime,         //in seconds
                    nextUsageTime,
                    castTime,
                    range;
   
    protected void Initialize(float cd, float ct, float r)
    {
        cooldownTime = cd;
        nextUsageTime = 0.0f;
        castTime = ct;
        range = r;
    }

    public float cooldownPercentage()
    {
        if(Time.time >= nextUsageTime) return 0;
        var startTime = nextUsageTime - cooldownTime;
        return 1 - (Time.time - startTime) / (nextUsageTime - startTime);
    }

    protected float cooldownTimeRemaining()
    {
            return cooldownPercentage() * cooldownTime;
    }

    public bool isCooldownOver()
    {
        return (Time.time >= nextUsageTime);
    }

    public void startCooldown()
    {
        nextUsageTime = Time.time + cooldownTime;
    }
    
}

