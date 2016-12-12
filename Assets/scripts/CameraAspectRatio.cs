using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAspectRatio : MonoBehaviour {
    //this script is used to ensure the aspect ratio of our game. it will help make sure everything fits in the screen correctly.
	void Start () {
        float tgtAspect = 16.0f / 9.0f;
        float windowAspect = (float)Screen.width/(float)Screen.height;
        float scaleFactor = windowAspect / tgtAspect;

        Camera myCam = GetComponent<Camera>();

        if(scaleFactor < 1.0f)//scaled height is less than current height. add letterbox
        {
            Rect camRect = myCam.rect;

            camRect.width = 1.0f; camRect.height = scaleFactor;
            camRect.x = 0f; camRect.y = (1.0f - scaleFactor) / 2.0f;

            myCam.rect = camRect;
        }
        else if(scaleFactor > 1.0f) //scaled height greater than current height. add pillarbox
        {
            float scaleWidth = 1.0f / scaleFactor; Rect camRect = myCam.rect;

            camRect.width = scaleWidth; camRect.height = 1.0f;
            camRect.x = (1.0f - scaleWidth) / 2.0f; camRect.y = 0f;

            myCam.rect = camRect;
        }
	}
}
