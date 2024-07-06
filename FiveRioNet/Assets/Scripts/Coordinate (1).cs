
using UnityEngine;
using Leap.Unity;
using Leap;

public class Coordinate : MonoBehaviour
{
    public LeapProvider provider;
    public Vector3[] fingerPosition = new Vector3[5];

    void Update()
    {
        Frame frame = provider.CurrentFrame;
        foreach (Hand hand in frame.Hands)
        {
            if (hand.IsLeft || hand.IsRight) // Check if it's the left or right hand
            {
                Finger thumbFinger = hand.Fingers[(int)Finger.FingerType.TYPE_THUMB];//親指
                Finger indexFinger = hand.Fingers[(int)Finger.FingerType.TYPE_INDEX];//人差し指
                Finger middleFinger = hand.Fingers[(int)Finger.FingerType.TYPE_MIDDLE];//中指
                Finger ringFinger = hand.Fingers[(int)Finger.FingerType.TYPE_RING];//薬指
                Finger pinkyFinger = hand.Fingers[(int)Finger.FingerType.TYPE_PINKY];//小指


                fingerPosition[0] = new Vector3(thumbFinger.TipPosition.x, thumbFinger.TipPosition.y, thumbFinger.TipPosition.z);
                fingerPosition[1] = new Vector3(indexFinger.TipPosition.x, indexFinger.TipPosition.y, indexFinger.TipPosition.z);
                fingerPosition[2] = new Vector3(middleFinger.TipPosition.x, middleFinger.TipPosition.y, middleFinger.TipPosition.z);
                fingerPosition[3] = new Vector3(ringFinger.TipPosition.x, ringFinger.TipPosition.y, ringFinger.TipPosition.z);
                fingerPosition[4] = new Vector3(pinkyFinger.TipPosition.x, pinkyFinger.TipPosition.y, pinkyFinger.TipPosition.z);

                Debug.Log(fingerPosition[0]);
            }
        }
    }
}