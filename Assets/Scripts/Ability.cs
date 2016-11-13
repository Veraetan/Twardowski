
//A class all abilities inherit from

using UnityEngine;
using System.Collections;

public class Ability : MonoBehaviour
{
    float cooldownTime;         //in seconds
    float nextUsageTime;
    float castTime;
    float range;
   
    protected void Initialize(float cd, float ct, float r)
    {
        cooldownTime = cd;
        nextUsageTime = 0.0f;
        castTime = ct;
        range = r;
    }

    protected float cooldownPercentage()
    {
        if(Time.time >= nextUsageTime) return 0;
        var startTime = nextUsageTime - cooldownTime;
        return (Time.time - startTime) / (nextUsageTime - startTime);
    }

    protected float cooldownTimeRemaining()
    {
            return cooldownPercentage() * cooldownTime;
    }

    protected bool isCooldownOver()
    {
        return (Time.time >= nextUsageTime);
    }

    protected void startCooldown()
    {
        nextUsageTime = Time.time + cooldownTime;
    }
    
}

