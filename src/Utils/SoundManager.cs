using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

namespace SpaceInvadersRetro.Utils;

public abstract class SoundManager
{
    private static Song _backgroundMusic;
    private static ContentManager _content;

    public static void CreateInstance(ContentManager content)
    {
        if (_content != null)
        {
            _content = content;
        }
    }

    public static void LoadBackgroundMusic(string songName)
    {
        _backgroundMusic = _content.Load<Song>($"Sounds/{songName}");
    }

    public static void PlayMusic(float volume, bool repeat)
    {
        MediaPlayer.IsRepeating = repeat;
        MediaPlayer.Volume -= volume;
        MediaPlayer.Play(_backgroundMusic);
    }

    public static void PauseMusic()
    {
        MediaPlayer.Pause();
    }

    public static void ResumeMusic()
    {
        MediaPlayer.Resume();
    }

    public static void StopMusic()
    {
        MediaPlayer.Stop();
    }

    public static void PlaySoundEffect(string effectName)
    {
        var soundEffect = _content.Load<SoundEffect>($"Sounds/{effectName}");
        soundEffect.Play();
    }
}
