using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Controller : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        alienList = new List<Alien>();
        turretGun = new Gun();
        for(int i=0;i< Params.iNumOnScreen;i++)
        {
            alienList.Add(new Alien());
        }
    }

    // Update is called once per frame
    void Update()
    {
        turretGun.Update();
        for(int i=0; i< alienList.Count; i++)
        {
            ////if alien has 'died' replace with a new one
            //if (!m_vecActiveAliens[i].Update(m_pGunTurret->m_vecBullets,
            //                           m_pGunTurret->m_vPos))
            //{

            //    //first we need to re-insert into the breeding population so
            //    //that its fitness score and genes are recorded.
            //    m_setAliens.insert(m_vecActiveAliens[i]);

            //    //if the required population size has been reached, delete the 
            //    //worst performer from the multiset
            //    if (m_setAliens.size() >= CParams::iPopSize)
            //    {
            //        m_setAliens.erase(--m_setAliens.end());
            //    }

            //    ++m_iNumSpawnedFromTheMultiset;

            //    //if early in the run then we are still trying out new aliens
            //    if (m_iAliensCreatedSoFar <= CParams::iPopSize)
            //    {
            //        m_vecActiveAliens[i] = CAlien();

            //        ++m_iAliensCreatedSoFar;
            //    }

            //    //otherwise select from the multiset and apply mutation
            //    else
            //    {
            //        m_vecActiveAliens[i] = TournamentSelection();

            //        m_vecActiveAliens[i].Reset();

            //        if (RandFloat() < 0.8)
            //        {
            //            m_vecActiveAliens[i].Mutate();
            //        }
            //    }
            //}
        }
    }
    Gun turretGun;
    List<Alien> alienList;
    Alien TournamentSelection()
    {
        Alien selAlien = null;
        float bestFitnessSofar = 0;
        alienList.Sort((Alien a, Alien b)=> { return (-1)*(int)Mathf.Sign(a.Fitness - b.Fitness); });
        for(int i =0; i<Params.iNumTourneyCompetitors; i++)
        {
            int selectUpper = (alienList.Count - 1) * Params.dPercentageBestToSelectFrom;
            int selectIdx = Random.Range(0, selectUpper);
            Alien curSelAlien = alienList[i];
            if(curSelAlien.Fitness > bestFitnessSofar)
            {
               bestFitnessSofar = curSelAlien.Fitness;
               selAlien = alienList[i];
            }
        }
        return selAlien;
    }
}
