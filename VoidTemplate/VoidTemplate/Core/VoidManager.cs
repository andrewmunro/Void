using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VoidTemplate.Core.Managers;
using System.Xml;
using Microsoft.Xna.Framework;

namespace VoidTemplate.Core
{

    public enum BotState
    {
        Navigation, // Finds mobs
        Combat, // sends guid to combat
        Loot, // Loot
        Rest, // Buffs / Heals / Mana
        Dead
    }

    public class VoidManager
    {
        private BotState curState;
        private BotState prvState;

        public VoidManager()
        {
            ScriptManager.loadScript("../../Assets/01-10 Elwynn Forest.xml");
            //Update();
        }

/*
        public void Update()
        {
            switch (curState)
            {
                case BotState.Navigation:


                    if (NavigationManager.NearbyMobs().Contains("Bear"))
                    {
                        NavigationManager.AttackMob(target);
                    }
                    else
                    {
                        NavigationManager.WalkToNextWaypoint();
                    }

                    break;

                case BotState.Combat:

                    CombatManager.DoCombat();            

                    break;

                case BotState.Loot:

                    // loot list
                    // goto rest

                    break;

                case BotState.Rest:
                    // heal up
                    // when ready goto navigation
                    break;

                case BotState.Dead:

                    // NavigationManager.walkToCorpse();
                    // if revive then loot

                    break;

                default:
                    break;
            }
        }
        */
    }
}
