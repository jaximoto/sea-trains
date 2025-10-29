using UnityEngine;

public class WaveMaker : MonoBehaviour
{
    public ComputeShader waveFreq;
    public RenderTexture output;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        output = new RenderTexture(256, 256, 24);
        output.enableRandomWrite = true;
        output.Create();

        waveFreq.SetTexture(0, "Result", output);
        waveFreq.Dispatch(0, output.width / 8, output.height / 8, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
