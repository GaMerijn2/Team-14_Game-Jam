using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingTest : MonoBehaviour
{
    private PostProcessVolume postprocessVolume;
    private ColorGrading cg;
//    public static PostProcessingTest PPT { get; private set; }


    private void Start()
    {
        postprocessVolume = GetComponent<PostProcessVolume>();
        postprocessVolume.profile.TryGetSettings(out cg);
    }

    private void Update()
    {

    }
    public void lessSaturation()
    {

        cg.saturation.value -= 10;

        if (cg.saturation.value < -100)
        {
            cg.saturation.value = -100;
        }
    }

}
