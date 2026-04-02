using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Horse", menuName = "Horses/Horse")]
public class Horse : ScriptableObject
{
    [Serializable]
    public class HorseData
    {
        public string name = "Resolute Yearning Example";
        public float speed = 1;  // how fast horse accelerates
        public float stamina = 1;  // how much momentum horse keeps after collision
        public float power = 1;  // how much horse knocks back other horses and how little horse gets affected by pushing

        public HorseData(string name, float speed, float stamina, float power)
        {
            this.name = name;
            this.speed = speed;
            this.stamina = stamina;
            this.power = power;
        }
    }

    public Sprite sprite;
    public HorseData horseData;
}
