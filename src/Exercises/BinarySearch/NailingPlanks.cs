namespace Exercises.BinarySearch
{
    public class NailingPlanks
    {
        private readonly int[] plankStarts;
        private readonly int[] plankEnds;
        private readonly int[] nails;
        private int[] nailsMarked;

        public NailingPlanks (int[] plankStarts, int[] plankEnds, int[] nails)
        {
            this.nails = nails;
            this.plankEnds = plankEnds;
            this.plankStarts = plankStarts;
            nailsMarked = new int[2 * nails.Length + 1];
        }

        public int MinNumberOfNails ()
        {
            int minNails = 1;
            int maxNails = nails.Length;
            int result = -1;

            while (minNails <= maxNails)
            {
                int midNails = (maxNails + minNails) / 2;
                if (AllNailed (midNails))
                {
                    // try finding a better result
                    maxNails = midNails - 1;
                    result = midNails;
                }
                else
                {
                    // need more nails
                    minNails = midNails + 1;
                }
            }

            return result;
        }

        
        /// <summary>
        /// Check whether all planks nailed by marking nails and then using prefix sums to verify there is a nail for each plank.
        /// For example plank(1,5) is nailed when the number of nails at start and end differs, i.e. there is a nail in this range.
        /// </summary>
        /// <param name="nailsCount"></param>
        /// <returns></returns>
        private bool AllNailed (int nailsCount)
        {
            // reset marked nails
            for (int i = 0; i < nailsMarked.Length; i++)
            {
                nailsMarked[i] = 0;
            }

            // mark nails
            for (int i = 0; i < nailsCount; i++)
            {
                nailsMarked[nails[i]] = 1;
            }


            // prefix sum marked nails
            for (int i = 1; i < nailsMarked.Length; i++)
            {
                nailsMarked[i] += nailsMarked[i - 1];
            }

            // check there's a nail for every plank
            for (int i = 0; i < plankStarts.Length; i++)
            {
                if (!NailMarkedForPlank(i))
                    return false;
            }

            return true;
        }

        private bool NailMarkedForPlank(int i)
        {
            return nailsMarked[plankEnds[i]] - nailsMarked[plankStarts[i] - 1] > 0;
        }
    }
}