using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
   public static GameEvents current;

   private void Awake()
   {
       current = this;
   }

   public event Action onDoorwayTriggerEnter;
   public void DoorwayTriggerEnter()
   {
       if(onDoorwayTriggerEnter != null)
       {
           onDoorwayTriggerEnter();
       }
   }
   public event Action onDoorwayTriggerExit;
   public void DoorwayTriggerExit()
   {
       if(onDoorwayTriggerExit != null)
       {
           onDoorwayTriggerExit();
       }
   }

   public event Action onEggTriggerEnter;
   public void EggTriggerEnter()
   {
       if(onEggTriggerEnter != null)
       {
           onEggTriggerEnter();
       }
   }
   public event Action onEggTriggerExit;
   public void EggTriggerExit()
   {
       if(onEggTriggerExit != null)
       {
           onEggTriggerExit();
       }
   }
}
