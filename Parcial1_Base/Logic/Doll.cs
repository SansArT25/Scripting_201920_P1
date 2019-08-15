using System.Collections.Generic;

namespace Parcial1_Base.Logic
{
    /// <summary>
    /// Definition for the player's avatar. Players dress up a doll to win the contest.
    /// </summary>
    public class Doll : IClonable<Doll>
    {
        /// <summary>
        /// The accessories collection.
        /// </summary>
        private List<Accessory> accessories = new List<Accessory>();

        /// <summary>
        /// The doll's name
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// Whether the doll can be included in the contest.
        /// </summary>
        public bool CanParticipate { get => CanParticipate; set => CanParticipate = value; }
        

        /// <summary>
        /// The total accessories count worn by the doll.
        /// </summary>
        public int TotalAccessories { get => accessories.Count; }


        public int BraceletCount { get => BraceletCount; set => BraceletCount = value; }

        /// <summary>
        /// The total style score, affected by each worn accessory.
        /// </summary>
        public int Style { get => Style; set => Style = value; }

        public Doll(string name)
        {
            Name = name;
            CanParticipate = false;
        }

        /// <summary>
        /// Removes the given accessory.
        /// </summary>
        /// <param name="a">The accessory to be removed</param>
        /// <returns>True if the accessory was being worn, then removed. False otherwise</returns>
        public bool Remove(Accessory a)
        {
            bool result = false;
            if(accessories.Contains(a))
            {
                for(int i = 0; i < accessories.Count; i++)
                {
                    if (accessories[i] == a)
                    {
                        accessories.Remove(accessories[i]);
                        result = true;
                        if(accessories[i] is Dress)
                        {
                            accessories.Clear();
                        }
                    }
                }
            }
            
            return result;
        }

        /// <summary>
        /// Makes the doll wear the given accessory
        /// </summary>
        /// <param name="a">The accessory to be worn by the doll</param>
        /// <returns>True if the doll successfully wore the accessory. False otherwise</returns>
        public bool Wear(Accessory a)
        {
            bool result = true;
            if(a is Dress)
            {
                for(int i = 0; i < accessories.Count; i++)
                {
                    if(accessories[i] is Dress && result == true)
                    {
                        result = false;
                    }
                    else if (i == accessories.Count - 1 && result == true)
                    {
                        accessories.Add(a);
                        CanParticipate = true;
                    }
                }
            }
            else if (a is Necklace)
            {
                for (int i = 0; i < accessories.Count; i++)
                {
                    if (accessories[i] is Necklace && result == true)
                    {
                        result = false;
                    }
                    else if (i == accessories.Count - 1 && result == true)
                    {
                        accessories.Add(a);
                    }
                }
            }
            else if (a is Purse)
            {
                for (int i = 0; i < accessories.Count; i++)
                {
                    if (accessories[i] is Purse && result == true)
                    {
                        result = false;
                    }
                    else if(i == accessories.Count - 1 && result == true)
                    {
                        accessories.Add(a);
                    }
                }
            }
            else if (a is Bracelet)
            {
                int limit = 0;
                for (int i = 0; i < accessories.Count; i++)
                {
                    if (accessories[i] is Bracelet && result == true)
                    {
                        limit++;
                    }
                    if(limit >= 5)
                    {
                        result = false;
                    }
                    else
                    {

                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Copies this instance attributes to a new independant one
        /// </summary>
        /// <returns>A new Doll object with the same values of this instance</returns>
        public Doll Copy()
        {
            return new Doll(Name);
        }
    }
}