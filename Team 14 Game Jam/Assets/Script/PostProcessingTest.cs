using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingTest : MonoBehaviour
{
    private PostProcessVolume postprocessVolume;
    private ColorGrading cg;
    private Vignette vg;

    //    public static PostProcessingTest PPT { get; private set; }


    private void Start()
    {
        postprocessVolume = GetComponent<PostProcessVolume>();
        postprocessVolume.profile.TryGetSettings(out cg);
        postprocessVolume.profile.TryGetSettings(out vg);

    }

    private void Update()
    {

    }
    public void lessSaturation()
    {

        cg.saturation.value -= 5;

        if (cg.saturation.value < -100)
        {
            cg.saturation.value = -100;
        }
    }
    public void moreVignette()
    {

        vg.intensity.value += .0125f;

        if (vg.intensity.value < -1)
        {
            vg.intensity.value = -1;
        }
    }

}
