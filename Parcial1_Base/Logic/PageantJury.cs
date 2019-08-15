using System.Collections.Generic;

namespace Parcial1_Base.Logic
{
    public class PageantJury
    {
        /// <summary>
        /// The contestants collection.
        /// </summary>
        private List<Doll> contestants = new List<Doll>();

        /// <summary>
        /// Returns the total contestants count for a pageant round.
        /// </summary>
        public int TotalContestants { get => contestants.Count; }

        /// <summary>
        /// Adds a contestant to the pageant.
        /// </summary>
        /// <param name="d"></param>
        /// <returns>True if the contestant could be added, False otherwise</returns>
        public bool AddContestant(Doll d)
        {
            bool result = false;
            if (d.CanParticipate && contestants.Count <= 4)
            {
                contestants.Add(d);
                result = true;
            }
            return result;
        }

        /// <summary>
        /// Clears the contestants collection
        /// </summary>
        public void ClearContestants()
        {
            contestants.Clear();
        }

        /// <summary>
        /// Returns the winner of the pageant
        /// </summary>
        /// <returns>The winner Doll</returns>
        public Doll GetWinner()
        {
            Doll winner = null;
            int style = 0;
            for(int i = 0; i < contestants.Count; i++)
            {
                if(i == 0)
                {
                    winner = contestants[0];
                    style = winner.Style;
                }
                else
                {
                    if (contestants[i].Style > style)
                    {
                        winner = contestants[i];
                        style = winner.Style;
                    }
                }
            }

            return winner;
        }
    }
}