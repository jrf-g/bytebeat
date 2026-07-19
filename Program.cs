using System;
using NAudio.Wave;
public class Program
{
  public void sample()
  {
    var ms = new MemoryStream();
    long t = 1;
    int samples = 0;
    for (int i = 0; i <= samples; i++)
    {
      t++;
      byte sample = (t*4|t|t>>3&t+t/4&t*12|t*8>>10|t/20&t+140)&t>>4;
      ms.Position = i;
      ms.WriteByte(sample);
    }
    File.WriteAllBytes("a.bin", ms.ToArray());
  }
  public void play()
  {
    var format = new WaveFormat(
      sampleRate: 8000,
      bitsPerSample: 8,
      channels: 1
    );
    var provider = new RawSourceWaveStream(ms, format);
    var waveOut = new WaveOutEvent();
    waveOut.Init(provider);
    waveOut.Play();
    while (waveOut.PlaybackState == PlaybackState.Playing) {
      await Task.Delay(10);
    }
  }
}
