using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PyramidArrays
{
    static public int[][] pyramidEz;
    public static void Initialize()
    {
        //ylärivi
        PyramidArrays.pyramidEz[0][0] = 0; // empty = 0 / filled = 1
        PyramidArrays.pyramidEz[0][1] = 2; // health ranking 0 - 2

        //keskirivi
        PyramidArrays.pyramidEz[1][0] = 0; // empty = 0 / filled = 1
        PyramidArrays.pyramidEz[1][1] = 1; // health ranking 0 - 2

        PyramidArrays.pyramidEz[2][0] = 0; // empty = 0 / filled = 1
        PyramidArrays.pyramidEz[2][1] = 1; // health ranking 0 - 2

        //alarivi
        PyramidArrays.pyramidEz[3][0] = 0; // empty = 0 / filled = 1
        PyramidArrays.pyramidEz[3][1] = 0; // health ranking 0 - 2

        PyramidArrays.pyramidEz[4][0] = 0; // empty = 0 / filled = 1
        PyramidArrays.pyramidEz[4][1] = 0; // health ranking 0 - 2

        PyramidArrays.pyramidEz[5][0] = 0; // empty = 0 / filled = 1
        PyramidArrays.pyramidEz[5][1] = 0; // health ranking 0 - 2
    }
}
