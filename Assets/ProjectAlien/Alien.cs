using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Action
{ 
    Thrust_Left,
    Thrust_Right,
    Thrust_Up,
    Drift
}

public class Alien 
{

    public float Fitness;
    NeuronNet brain;
    Vector3 pos;
    Vector3 velocity;

    float mass;
    float scale;

    int age;//用来计算Fitness
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //同一时间内屏幕中只有3个子弹
    Action GetActionFromNetWork(List<Bullet> bullets,Vector3 gunPos)
    {
        List<float> netInputs = new List<float>();
        List<float> outputs;

        Action action = Action.Drift;

        float toTurretX = gunPos.x - pos.x;
        float toTurretY = gunPos.y - pos.y;

        netInputs.Add(toTurretX);
        netInputs.Add(toTurretY);

        for(int i =0; i<bullets.Count; i++)
        { 
            if(bullets[i].Active)
            {
                float xComp = bullets[i].Pos.x - pos.x;
                float yComp = bullets[i].Pos.y - pos.y;
                netInputs.Add(xComp);
                netInputs.Add(yComp); 
             }
            else
            {
                //子弹未则输入一个指向Turret的向量
                netInputs.Add(toTurretX);
                netInputs.Add(toTurretY);
            }


        }
        outputs = brain.Update(netInputs);
        float bestSoFar = 0;
        for (int i = 0; i < outputs.Count; i++)
        {
            if (outputs[i] > bestSoFar && outputs[i]> 0.9f)
            {
                bestSoFar = outputs[i];
                action = (Action)i;
            }
        }
        return action;
    }
    void Mutate()
    { 
        List<float> weights = brain.
    }
}
