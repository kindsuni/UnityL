using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//범용성 있게 Static으로 클래스를 해서 바인딩없이 접근 가능.
public static class Utility   {
    //seed값만 알면 섞인 정보를 알 수 있어서 랜덤이지만 지정된 랜덤이기에 좋음.
	public static T[] ShuffleArray<T>(T[] array, int seed) //메소드
        //T = 임의의 형태, 타입. 
    {
        System.Random prng = new System.Random(seed);
       
        for(int i = 0; i< array.Length-1; i++)
        {
            int randomIndex = prng.Next(i, array.Length);
            T tempItem = array[randomIndex];
            array[randomIndex] = array[i];
            array[i] = tempItem;
        }
        return array;
    }
}


//public static int[] ShuffleArray<int>(int[] array, int seed)
//    public static float[] ShuffleArray<float>(float[] array, int seed)