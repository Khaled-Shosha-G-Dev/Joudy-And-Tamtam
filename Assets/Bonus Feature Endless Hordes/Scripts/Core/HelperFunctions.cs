using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HelperFunctions
{

    // apparently everytime camera.main is called unity searches the whole scene for the camera with the main tag
    // this is useful if the camera is always static in the scene and won't BE CHANGED
    // if the camera is deleted then you're in trouble
    // for transitioning between scenes this static class should be cleaned as static classes persists between scenes
    private static Camera _mainCamera;
    public static Camera GetMainCamera{
        get{
            if(_mainCamera == null)
                _mainCamera = Camera.main;
            return _mainCamera;
        }
    }

    //this is to reduce garbage collection allocations and deletions
    private static Dictionary<float, WaitForSeconds> _waitDictionary = new Dictionary<float, WaitForSeconds>();

    public static WaitForSeconds GetWaitForSeconds(float time){
        if(_waitDictionary.TryGetValue(time, out var wait)) return wait;

        return _waitDictionary[time] = new WaitForSeconds(time);
    }


    //When Transitioning scenes THIS SHOULD BE CALLED!
    public static void ResetData(){
        _mainCamera = null;
        //there's no need to free the wait dictionary, but i'm going to do it to avoid any memory clutter.
        _waitDictionary = new Dictionary<float, WaitForSeconds>();
    }



    

}
